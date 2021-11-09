using System;
using System.IO;
using System.Text;

namespace LeituraClassificacaoDoenca
{
    class Program
    {
        static void Main(string[] args)
        {
            const string script = @"c:\temp\script.sql";
            string linha = string.Empty;
            var linhas = new StringBuilder();
            using (var arquivo = new StreamReader(@"c:\temp\classificacao.txt", Encoding.UTF8))
            {
                while ((linha = arquivo.ReadLine()) != null)
                {
                    string[] colunas = linha.Split('-');
                    linhas.AppendLine($"insert into ClassificacaoDoenca (CID, Descricao) values ('{colunas[0].Trim()}', '{colunas[1].Trim()}');");
                }
            }

            if (File.Exists(script))
                File.Delete(script);

            File.WriteAllText(script, linhas.ToString());
        }
    }
}