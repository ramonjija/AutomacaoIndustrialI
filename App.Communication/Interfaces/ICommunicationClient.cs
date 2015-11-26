using App.Communication.Arguments;

namespace App.Communication.Interfaces
{
    public interface ICommunicationClient
    {
        /// <summary>
        ///     This method is used to get user list from chat server.
        ///     It is called by server once after user logged in to server.
        /// </summary>
        /// <param name="modules">All online user informations</param>
        void GetUserList(ModuleInfo[] modules);

        /// <summary>
        ///     This method is called from chat server to inform that a message
        ///     is sent to chat room publicly.
        /// </summary>
        /// <param name="nick">Name of sender</param>
        /// <param name="message">Message</param>
        void OnMessageToRoom(string nick, ChatMessage message);

        /// <summary>
        ///     This method is called from chat server to inform that a message
        ///     is sent to the current user privately.
        /// </summary>
        /// <param name="nick">Name of sender</param>
        /// <param name="message">Message</param>
        void OnPrivateMessage(string nick, ChatMessage message);

        /// <summary>
        ///     This method is called from chat server to inform that a new user
        ///     joined to chat room.
        /// </summary>
        /// <param name="moduleInfo">Informations of new user</param>
        void OnUserLogin(ModuleInfo moduleInfo);

        /// <summary>
        ///     This method is called from chat server to inform that an existing user
        ///     has left the chat room.
        /// </summary>
        /// <param name="nick">Informations of new user</param>
        void OnUserLogout(string nick);

        /// <summary>
        ///     This method is called from chat server to inform that a user changed his/her status.
        /// </summary>
        /// <param name="nick">Name of the user</param>
        /// <param name="newStatus">New status of the user</param>
        void OnUserStatusChange(string nick, UserStatus newStatus);
    }
}