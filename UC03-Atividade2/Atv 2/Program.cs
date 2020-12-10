using System;

namespace Atv_2
{
    class Program
    {
        static void Main(string[] args)
        {
          string nome;
                  
          Console.WriteLine("Programa para gerar uma senha para o usuário");
          Console.Write("Informe o Nome:");          
          nome = Console.ReadLine();
          Console.WriteLine("Informe sua Data de Nascimento digitando o :");
          Console.Write("Dia: ");
          int dia = int.Parse(Console.ReadLine());
          Console.Write("Mês: ");
          int mes = int.Parse(Console.ReadLine());
          Console.Write("Ano: ");
          int ano = int.Parse(Console.ReadLine());

          Console.WriteLine("O nome do usuário é: " + nome);
          Console.WriteLine("Nascido em " + dia + "/"+ mes + "/" + ano);
          int idade = (DateTime.Now.Year - ano);
          Console.WriteLine("Tem " + idade + " anos.");

          if (idade < 18){
              Console.WriteLine("O usuário é menor de idade a senha gerada é: " + nome + idade);
          } else{
              Console.WriteLine("O usuário é maior de idade a senha gerada é: " + idade + nome);
          }        
        }
    }
}
