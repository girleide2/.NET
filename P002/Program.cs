using System;
using System.Collections.Generic;

class Program
{
    public class Tarefa
    {
        private string titulo;
        private string descricao;
        private bool concluida;
        private DateTime dataVencimento;

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public DateTime DataVencimento
        {
            get { return dataVencimento; }
            set { dataVencimento = value; }
        }

        public Tarefa(string Titulo, string Descricao)
        {
            this.titulo = Titulo;
            this.descricao = Descricao;
            this.dataVencimento = DateTime.MinValue;
            this.concluida = false;
        }

        public void CriaTitulo()
        {
            Console.WriteLine("Digite o título da tarefa");
            Titulo = Console.ReadLine();
        }

        public void CriaDescricao()
        {
            Console.WriteLine("Digite a descrição da tarefa");
            Descricao = Console.ReadLine();
        }
        public void CriaData(){
            Console.WriteLine("Digite a data de vencimento da tarefa (formato dd/MM/yyyy):");
            this.DataVencimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }

        public void MarcarComoConcluida()
        {
            concluida = true;
            Console.WriteLine("Tarefa marcada como concluída.");
        }
        public bool Concluida
        {
            get { return concluida; }
        }
        public bool ContemPalavraChave(string palavraChave)
        {
            return Titulo.Contains(palavraChave, StringComparison.OrdinalIgnoreCase) ||
                   Descricao.Contains(palavraChave, StringComparison.OrdinalIgnoreCase);
        }
    }

    static void Main(){
        List<Tarefa> listaDeTarefas = new List<Tarefa>();
        int opcao;
        do{
        Console.WriteLine("------ Menu ------");
        Console.WriteLine("1. Criar tarefa");
        Console.WriteLine("2. Listar tarefas");
        Console.WriteLine("3. Marcar tarefa como concluída");
        Console.WriteLine("4. Buscar tarefa por palavra-chave");
        Console.WriteLine("5. Tarefas concluídas");
        Console.WriteLine("6. Tarefas pendentes");
        Console.WriteLine("7. Encerrar programa");

        opcao = int.Parse(Console.ReadLine());
        
        if (opcao == 1)
        {
            Tarefa novaTarefa = new Tarefa("", ""); 
            novaTarefa.CriaTitulo();
            novaTarefa.CriaDescricao();
            novaTarefa.CriaData();
            listaDeTarefas.Add(novaTarefa);
            Console.WriteLine("Tarefa criada - Título: " + novaTarefa.Titulo + ", Descrição: " + novaTarefa.Descricao);
        }
        else if (opcao == 2)
        {
            ListarTarefas(listaDeTarefas);
        }
        else if (opcao == 3)
        {
            ListarTarefas(listaDeTarefas);
            Console.WriteLine("Digite o número da tarefa que deseja marcar como concluída:");
            int numeroTarefa = int.Parse(Console.ReadLine());
            MarcarTarefaComoConcluida(listaDeTarefas, numeroTarefa);
        }
        else if (opcao == 4)
        {
            Console.WriteLine("Digite a palavra-chave:");
            string palavraChave = Console.ReadLine();
            BuscarTarefaPorPalavraChave(listaDeTarefas, palavraChave);
        }
        else if (opcao == 5)
        {
            ListarTarefasConcluidas(listaDeTarefas);
        }
        else if (opcao == 6)
        {
            ListarTarefasPendentes(listaDeTarefas);
        }
        else
        {
            Console.WriteLine("Encerrado");
        }

    } while(opcao != 7);
    }
     static void ListarTarefas(List<Tarefa> tarefas)
    {
        Console.WriteLine("Lista de Tarefas:");
        for (int i = 0; i < tarefas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Título: {tarefas[i].Titulo}, Descrição: {tarefas[i].Descricao}, Data de Vencimento: {tarefas[i].DataVencimento.ToShortDateString()}");
        }
    }
  static void MarcarTarefaComoConcluida(List<Tarefa> tarefas, int numeroTarefa)
    {
        if (numeroTarefa > 0 && numeroTarefa <= tarefas.Count)
        {
            tarefas[numeroTarefa - 1].MarcarComoConcluida();
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido.");
        }
    }

  static void ListarTarefasConcluidas(List<Tarefa> tarefas)
    {
        var tarefasConcluidas = tarefas.Where(tarefa => tarefa.Concluida).ToList();

        Console.WriteLine($"Total de Tarefas Concluídas: {tarefasConcluidas.Count}");
        Console.WriteLine("Tarefas Concluídas:");
        for (int i = 0; i < tarefasConcluidas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Título: {tarefasConcluidas[i].Titulo}, Descrição: {tarefasConcluidas[i].Descricao}, Data de Vencimento: {tarefasConcluidas[i].DataVencimento.ToShortDateString()}");
        }
    }

    static void ListarTarefasPendentes(List<Tarefa> tarefas)
    {
        var tarefasPendentes = tarefas.Where(tarefa => !tarefa.Concluida).ToList();
        tarefasPendentes.Sort((t1, t2) => t1.DataVencimento.CompareTo(t2.DataVencimento));

        Console.WriteLine($"Total de Tarefas Pendentes: {tarefasPendentes.Count}");
        Console.WriteLine("Tarefas Pendentes Ordenadas por Vencimento:");
        for (int i = 0; i < tarefasPendentes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Título: {tarefasPendentes[i].Titulo}, Descrição: {tarefasPendentes[i].Descricao}, Data de Vencimento: {tarefasPendentes[i].DataVencimento.ToShortDateString()}");
        }
    }
     static void BuscarTarefaPorPalavraChave(List<Tarefa> tarefas, string palavraChave)
    {
        var tarefasEncontradas = tarefas
            .Where(tarefa => tarefa.ContemPalavraChave(palavraChave))
            .ToList();

        if (tarefasEncontradas.Count > 0)
        {
            Console.WriteLine($"Tarefas encontradas com a palavra-chave '{palavraChave}':");
            for (int i = 0; i < tarefasEncontradas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Título: {tarefasEncontradas[i].Titulo}, Descrição: {tarefasEncontradas[i].Descricao}, Data de Vencimento: {tarefasEncontradas[i].DataVencimento.ToShortDateString()}");
            }
        }
        else
        {
            Console.WriteLine($"Nenhuma tarefa encontrada com a palavra-chave '{palavraChave}'.");
        }
    }

}
