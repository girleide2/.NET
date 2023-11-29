using System.Security.Cryptography;
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

}

public class Paciente{
    private List<(string Nome, int DataNascimento, string CPF, string Sexo, string Sintomas)> DadosPaciente = new List<(string Nome, int DataNascimento, string CPF, string Sexo, string Sintomas)>();
    public List<( string Nome, int DataNascimento, string CPF, string Sexo, string Sintomas)> getDadosPaciente(){
    return DadosPaciente;
}

    public void pegaDadosPaciente(){
        Console.WriteLine($"Digite o nome do paciente:");
        string Nome = Console.ReadLine();
        Console.WriteLine($"Digite a data de nascimento:");
        int DataNascimento = int.Parse(Console.ReadLine());
        Console.WriteLine($"Digite o CPF (Apenas numeros):");
        string CPF = Console.ReadLine();
        //var CPFs = DadosPaciente.Where(p => p.CPF == CPF);
        Console.WriteLine($"Digite o sexo do paciente");
        string Sexo = Console.ReadLine();
        Console.WriteLine($"Digite os sintomas do paciente");
        string Sintomas = Console.ReadLine();
        var novoPaciente = (Nome, DataNascimento, CPF, Sexo, Sintomas);
        DadosPaciente.Add(novoPaciente);
    }

public class Relatorios{
    Medico medico = new Medico();
    Paciente paciente = new Paciente();

public void RelatorioIdadeMedico(){
var DadosMedico = DadosMedico.Where(p => p.Idade >= minimo && p.Idade<= maximo);

                Console.WriteLine($"Medicos com idade entre {minimo} e {maximo}:");
                foreach (var med in DadosMedico)
                {
                    Console.WriteLine($"Nome: {med.Nome}, Data de nascimento: {med.DataNascimento}, CPF: {med.CPF}, CRM");
                } 
}
public void RelatorioIdadePaciente(){

}
public void PacienteSexo(){

}
public void PacienteOrdemAlfabetica(){

}

public void PacienteSintoma(){

}
}
public class Program{

    static void Main(){
        Medico medico = new Medico();
        Paciente paciente = new Paciente();

    }
}


}
