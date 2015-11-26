

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Communication.Arguments;
using App.Communication.Exceptions;
using App.Communication.Interfaces;
using Hik.Collections;
using Hik.Communication.ScsServices.Service;

namespace ModuleServer
{
    internal class CommunicationService : ScsService, ICommunicationService
    {
        #region Private Fields

        private readonly ThreadSafeSortedList<long, CommunicationClient> _clients;

        #endregion

        #region Public Properties

        public List<ModuleInfo> ModuleList
        {
            get
            {
                return (from client in _clients.GetAllItems()
                        select client.User).ToList();
            }
        }

        #endregion

        #region Public Events

        public event EventHandler ModuleListChanged;

        #endregion

        protected virtual void OnModuleListChanged()
        {
            var handler = ModuleListChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #region Sub classes

        public sealed class CommunicationClient
        {
            public CommunicationClient(IScsServiceClient client, ICommunicationClient clientProxy, ModuleInfo userInfo)
            {
                Client = client;
                ClientProxy = clientProxy;
                User = userInfo;
            }

            public IScsServiceClient Client { get; private set; }

            public ICommunicationClient ClientProxy { get; private set; }

            public ModuleInfo User { get; private set; }
        }

        #endregion

        #region IChatService methods

        public void Login(ModuleInfo userInfo)
        {
            if (FindClientByName(userInfo.Name) != null)
            {
                throw new NameInUseException("The name '" + userInfo.Name +
                                             "' is being used by another user. Please select another one.");
            }

            var client = CurrentClient;

            var clientProxy = client.GetClientProxy<ICommunicationClient>();

            var chatClient = new CommunicationClient(client, clientProxy, userInfo);
            _clients[client.ClientId] = chatClient;

            client.Disconnected += Client_Disconnected;

            Task.Factory.StartNew(
                () =>
                {
                    OnModuleListChanged();
                    SendModuleListToClients(chatClient);
                    SendUserLoginInfoToAllClients(userInfo);
                });
        }

        public void SendMessageToRoom(ChatMessage message)
        {
            var senderClient = _clients[CurrentClient.ClientId];
            if (senderClient == null)
            {
                throw new ApplicationException("Can not send message before login.");
            }

            Task.Factory.StartNew(
                () =>
                {
                    foreach (var chatClient in _clients.GetAllItems())
                    {
                        try
                        {
                            chatClient.ClientProxy.OnMessageToRoom(senderClient.User.Name, message);
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                });
        }

        public void SendPrivateMessage(string destinationNick, ChatMessage message)
        {
            var senderClient = _clients[CurrentClient.ClientId];
            if (senderClient == null)
            {
                throw new ApplicationException("Can not send message before login.");
            }

            var receiverClient = FindClientByName(destinationNick);
            if (receiverClient == null)
            {
                throw new ApplicationException("There is no online user with nick " + destinationNick);
            }

            receiverClient.ClientProxy.OnPrivateMessage(senderClient.User.Name, message);
        }

        public void ChangeStatus(UserStatus newStatus)
        {
            var senderClient = _clients[CurrentClient.ClientId];
            if (senderClient == null)
            {
                throw new ApplicationException("Can not change state before login.");
            }

            senderClient.User.Status = newStatus;

            Task.Factory.StartNew(
                () =>
                {
                    foreach (var chatClient in _clients.GetAllItems())
                    {
                        try
                        {
                            chatClient.ClientProxy.OnUserStatusChange(senderClient.User.Name, newStatus);
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                });
        }

        public void Logout()
        {
            ClientLogout(CurrentClient.ClientId);
        }

        #endregion

        #region Private methods

        private void Client_Disconnected(object sender, EventArgs e)
        {
            var client = (IScsServiceClient)sender;

            ClientLogout(client.ClientId);
        }

        private void SendModuleListToClients(CommunicationClient client)
        {
            var moduleList = ModuleList.Where(user => user.Name != client.User.Name).ToArray();

            if (moduleList.Length <= 0)
            {
                return;
            }

            client.ClientProxy.GetUserList(moduleList);
        }

        private void ClientLogout(long clientId)
        {
            var client = _clients[clientId];
            if (client == null)
            {
                return;
            }

            _clients.Remove(client.Client.ClientId);

            client.Client.Disconnected -= Client_Disconnected;

            Task.Factory.StartNew(
                () =>
                {
                    OnModuleListChanged();
                    SendUserLogoutInfoToAllClients(client.User.Name);
                });
        }

        private void SendUserLoginInfoToAllClients(ModuleInfo moduleInfo)
        {
            foreach (var client in _clients.GetAllItems().Where(client => client.User.Name != moduleInfo.Name))
            {
                try
                {
                    client.ClientProxy.OnUserLogin(moduleInfo);
                }
                catch
                {
                    // ignored
                }
            }
        }

        private void SendUserLogoutInfoToAllClients(string nick)
        {
            foreach (var client in _clients.GetAllItems())
            {
                try
                {
                    client.ClientProxy.OnUserLogout(nick);
                }
                catch
                {
                    // ignored
                }
            }
        }

        private CommunicationClient FindClientByName(string nick)
        {
            return (from client in _clients.GetAllItems()
                    where client.User.Name == nick
                    select client).FirstOrDefault();
        }

        #endregion
    }
}
