using System;
using System.Collections.Generic;
using System.Linq;
class GerenciaEstoque{
    private List<(int Codigo, string Nome, int Quantidade, float Preco)> produtosEstoque = new List<(int Codigo, string Nome, int Quantidade, float Preco)>();
    public List<(int Codigo, string Nome, int Quantidade, float Preco)> getProdutosEstoque(){
        return produtosEstoque;
    }
    public void AdicionaEstoque(){
        Console.WriteLine("Digite o código do produto");
        int Codigo = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o nome do produto");
        string Nome = Console.ReadLine();
        Console.WriteLine("Digite a quantidade em estoque");
        int Quantidade = int.Parse(Console.ReadLine());
        Console.Write("Digite o preço do produto (un): ");
        float Preco = float.Parse(Console.ReadLine());

        var novoProduto = (Codigo, Nome, Quantidade, Preco);
        produtosEstoque.Add(novoProduto);

        Console.WriteLine("Produto adicionado ao estoque com sucesso");
    }
    public void ProcuraProduto(){

        Console.Write("Digite o código do produto: ");
        int codigo = int.Parse(Console.ReadLine());

        var produto = produtosEstoque.FirstOrDefault(p => p.Codigo == codigo);

        if (produto.Equals(default))
        {
            throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");
        }

        Console.WriteLine($"Código: {produto.Codigo}, Nome: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco:C}");
    }
    public void AtualizarEstoque(){
        int opcao;
        do {
            Console.WriteLine("Como deseja atualizar o estoque?");
            Console.WriteLine("1 - Retirar do estoque");
            Console.WriteLine("2 - Adicionar ao estoque");
            Console.WriteLine("3 - Retornar ao menu principal");
            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Console.Write("Digite o código do produto: ");
                int codigo = int.Parse(Console.ReadLine());

                var produto = produtosEstoque.FirstOrDefault(p => p.Codigo == codigo);

                if (produto.Equals(default))
                {
                    throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");
                }

                Console.Write("Digite a quantidade de retirada: ");
                int retirada = int.Parse(Console.ReadLine());

                if (retirada > produto.Quantidade)
                {
                    throw new QuantidadeInsuficienteException($"Quantidade insuficiente em estoque para o produto {produto.Nome}.");
                }

                produtosEstoque.Remove(produto);
                produtosEstoque.Add((produto.Codigo, produto.Nome, produto.Quantidade - retirada, produto.Preco));

                Console.WriteLine($"Estoque atualizado com sucesso");
                }
                else if (opcao == 2)
                {
                Console.Write("Digite o código do produto: ");
                int codigo = int.Parse(Console.ReadLine());

                var produto = produtosEstoque.FirstOrDefault(p => p.Codigo == codigo);

                if (produto.Equals(default))
                {
                    throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");
                }

                Console.Write("Digite a quantidade de entrada: ");
                int entrada = int.Parse(Console.ReadLine());

                produtosEstoque.Remove(produto);
                produtosEstoque.Add((produto.Codigo, produto.Nome, produto.Quantidade + entrada, produto.Preco));

                Console.WriteLine($"Estoque atualizado com sucesso.");
            }
        } while (opcao!=3);
    }
}
public
class Relatorios{
    public void GeraRelatorios(List<(int Codigo, string Nome, int Quantidade, float Preco)> produtosEstoque){
        int opcao;
        do{
            Console.WriteLine("Qual relatório deseja gerar?");
            Console.WriteLine("1. Relatório - Estoque Abaixo do Limite");
            Console.WriteLine("2. Relatório - Produtos por Valor");
            Console.WriteLine("3. Relatório - Valor Total do Estoque");
            Console.WriteLine("4. Retornar ao menu principal");

            opcao = int.Parse(Console.ReadLine());

            if(opcao == 1){
                
                Console.Write("Digite o limite de estoque: ");
                int limite = int.Parse(Console.ReadLine());
                Console.WriteLine(limite);
                
                var produtosAbaixoLimite = produtosEstoque.Where(p => p.Quantidade < limite).ToList();

                Console.WriteLine("Produtos com quantidade em estoque abaixo do limite:");
                foreach (var produto in produtosAbaixoLimite)
                {
                    Console.WriteLine($"Código: {produto.Codigo}, Nome: {produto.Nome}, Quantidade: {produto.Quantidade}");
                } 

            } else if (opcao == 2){

                Console.Write("Digite o valor mínimo: ");
                double minimo = double.Parse(Console.ReadLine());

                Console.Write("Digite o valor máximo: ");
                double maximo = double.Parse(Console.ReadLine());

                var produtosPorValor = produtosEstoque.Where(p => p.Preco >= minimo && p.Preco <= maximo);

                Console.WriteLine($"Produtos com valor entre {minimo:C} e {maximo:C}:");
                foreach (var produto in produtosPorValor)
                {
                    Console.WriteLine($"Código: {produto.Codigo}, Nome: {produto.Nome}, Preço: {produto.Preco:C}");
                } 

            } else if (opcao == 3) {
                double valorTotalEstoque = produtosEstoque.Sum(p => p.Quantidade * p.Preco);

                Console.WriteLine($"Valor total do estoque: {valorTotalEstoque:C}");

                Console.WriteLine("\nValor total de cada produto de acordo com o estoque:");
                foreach (var produto in produtosEstoque)
                {
                    double valorTotalProduto = produto.Quantidade * produto.Preco;
                    Console.WriteLine($"Código: {produto.Codigo}, Nome: {produto.Nome}, Valor total: {valorTotalProduto:C}");
                }

            }

        } while (opcao != 4);
    }
}
public class Programa{
     static void Main(){
        int opcao;
        GerenciaEstoque gerenciaEstoque = new GerenciaEstoque();
        Relatorios relatorios = new Relatorios();
        do{
        Console.WriteLine("------ Menu ------");
        Console.WriteLine("1. Adicionar Produto");
        Console.WriteLine("2. Procurar Produto");
        Console.WriteLine("3. Atualizar Estoque");
        Console.WriteLine("4. Gerar relatórios");
        Console.WriteLine("5. Sair");

        Console.WriteLine("Escolha uma opcao (1-8)");
        opcao = int.Parse(Console.ReadLine());

        try {
            switch (opcao) {
                    case 1:
                        gerenciaEstoque.AdicionaEstoque();
                        break;
                    case 2:
                        gerenciaEstoque.ProcuraProduto();
                        break;
                    case 3:
                        gerenciaEstoque.AtualizarEstoque();
                        break;
                    case 4:
                        relatorios.GeraRelatorios(gerenciaEstoque.getProdutosEstoque());
                        break;
                    case 5:
                        Console.WriteLine("Programa encerrado");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        } while(opcao != 8);
    }
}
public class ProdutoNaoEncontradoException : Exception
{
    public ProdutoNaoEncontradoException(string message) : base(message) { }
}
class QuantidadeInsuficienteException : Exception
{
    public QuantidadeInsuficienteException(string message) : base(message) { }
}




