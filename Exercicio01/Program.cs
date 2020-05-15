using Exercicio01.Entities;
using Exercicio01.Repositores;
using System;

namespace Exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            var produto = new Produto();

            try //tentativa
            {
                Console.Write("Informe o Id do Produto.................: ");
                produto.IdProduto = int.Parse(Console.ReadLine());

                Console.Write("Informe o Nome do Produto...............: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Informe o Preço do Produto..............: ");
                produto.Preco = double.Parse(Console.ReadLine());

                Console.Write("Informe a Quantidade do Produto.........: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                Console.Write("Informe a Data da Compra do Produto.....: ");
                produto.DataCompra = DateTime.Parse(Console.ReadLine());

                //criando um objeto da classe ProdutoRepository
                var produtoRepository = new ProdutoRepository();

                //exportando os dados do produto para arquivo CSV
                produtoRepository.ExportarCsv(produto);

                //imprimindo mensagem de sucesso
                Console.WriteLine("\nDados exportados com sucesso para arquivo CSV.");

                //verificar se o usuário deseja ler os dados contidos no arquivo
                Console.Write("\nDeseja ler os dados do arquivo CSV? (S)im ou (N)ão..: ");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    //ler os dados do arquivo..
                    var conteudo = produtoRepository.ImportarCsv();

                    //imprimindo no prompt
                    Console.WriteLine(conteudo);
                }

                Console.WriteLine("\nFIM DO PROGRAMA!");
            }
            catch (Exception e) //captura da exceção (erro)
            {
                Console.WriteLine("\nOcorreu um erro..: " + e.Message);
                Console.WriteLine(e.StackTrace); //detalhamento da pilha de erro
            }

            Console.ReadKey(); //pausar
        }
    }
}
