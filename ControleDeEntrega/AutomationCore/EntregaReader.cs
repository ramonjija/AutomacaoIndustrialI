using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEntrega.AutomationCore
{
    /// <summary>
    /// Classe responsavel por escrever e ler o pedido gerado no txt
    /// </summary>
    public static class EntregaReader
    {
        public static void EscreverEntrega(string json)
        {
            StreamWriter streamWriter;
            if (!Directory.Exists("C:\\jgmir"))
            {
                DirectoryInfo diretorioDeEscrita = new DirectoryInfo("C:\\jgmir");
                diretorioDeEscrita.Create();
            }

            try
            {
                streamWriter = new StreamWriter("C:\\jgmir\\EntregaPedido.txt", false);

                streamWriter.WriteLine(json);
                streamWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static string LerEntrega()
        {
            string jsonLido = null;

            StreamReader streamReader = new StreamReader("C:\\jgmir\\EntregaPedido.txt");

            jsonLido = streamReader.ReadLine();

            return jsonLido;
        }

    }
}
