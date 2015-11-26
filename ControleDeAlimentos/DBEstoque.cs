using App.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAlimentos
{
    public class DBEstoque
    {
        private string SerializaEstoque(EstoqueAlimentos estoque)
        {
            return ObjectExtensions.ToJson(estoque);
        }

        private EstoqueAlimentos DeserializaEstoque(string estoqueSerializado)
        {
            return ObjectExtensions.ToObject<EstoqueAlimentos>(estoqueSerializado);
        }

        public void SalvaEstoqueSerializado(EstoqueAlimentos estoque)
        {
            StreamWriter streamWriter;
            if (!Directory.Exists("C:\\jgmir"))
            {
                DirectoryInfo diretorioDeEscrita = new DirectoryInfo("C:\\jgmir");
                diretorioDeEscrita.Create();
            }
            
            estoque.dataDeAtualizacao = DateTime.Now;
            
            try
            {
                streamWriter = new StreamWriter("C:\\jgmir\\Estoque.txt");
          
                streamWriter.WriteLine(this.SerializaEstoque(estoque));

                streamWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public EstoqueAlimentos RecuperaEstoqueSerializado()
        {
            StreamReader streamReader;
            EstoqueAlimentos estoque = new EstoqueAlimentos();

            try
            {
                streamReader = new StreamReader("C:\\jgmir\\Estoque.txt");

                estoque = this.DeserializaEstoque(streamReader.ReadLine());

                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return estoque;
        }
    }
}
