using Exercicio01.Entities;
using System.IO;

namespace Exercicio01.Repositores
{
    public class ProdutoRepository
    {
        //atributos
        private const string path = "e:\\temp\\produtos.csv";

        //método para exportar os dados de um produto
        //em um arquivo de extensão .CSV
        public void ExportarCsv(Produto produto)
        {
            //abrir um arquivo em modo de escrita (gravação)
            using (var streamWriter = new StreamWriter(path, true))
            {
                //montando os dados no formato CSV
                var conteudo = string.Format("{0};{1};{2};{3},{4}", //posições
                    produto.IdProduto, produto.Nome, produto.Preco, produto.Quantidade, produto.DataCompra);

                //escrevendo os dados do produto no arquivo..
                streamWriter.WriteLine(conteudo);
            }
        }

        //método para importar e retornar os dados contidos no arquivo CSV
        public string ImportarCsv()
        {
            //abrindo o arquivo em modo de leitura
            using (var streamReader = new StreamReader(path))
            {
                //ler e retornar todo o texto contido no arquivo
                return streamReader.ReadToEnd();
            }
        }
    }
}
