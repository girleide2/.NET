﻿using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Medico{

    private List<(string Nome, int DataNascimento, string CPF, string CRM)> DadosMedico = new List<(string Nome, int DataNascimento, string CPF, string CRM)>();
    public List<( string Nome, int DataNascimento, string CPF, string CRM)> getDadosMedico(){
    return DadosMedico;
    }

    public void pegaDadosMedico(){

        Console.WriteLine($"Digite o nome do medico:");
        string Nome = Console.ReadLine();
        Console.WriteLine($"Digite a data de nascimento:");
        int DataNascimento = int.Parse(Console.ReadLine());
        Console.WriteLine($"Digite o CPF (Apenas numeros):");
        string CPF = Console.ReadLine();
        Console.WriteLine($"Digite o CRM");
        string CRM = Console.ReadLine();
        var novoMedico = (Nome, DataNascimento, CPF, CRM);
        DadosMedico.Add(novoMedico);
    }

public class Paciente{
    private List<(string Nome, int DataNascimento, string CPF, string Sexo, string Sintomas)> DadosPaciente = new List<(string Nome, int DataNascimento, string CPF, string Sexo, string Sintomas)>();
    public List<( string Nome, int DataNascimento, string CPF, string Sexo, string Sintomas)> getDadosPaciente(){
    return DadosPaciente;

    public void 
}

}