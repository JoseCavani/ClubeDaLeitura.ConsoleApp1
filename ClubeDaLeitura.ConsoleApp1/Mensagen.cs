using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class Mensagen
        {
            int numeroExcluir;
            public void Erro(string mensagen)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(mensagen);
                Console.ResetColor();
                Console.ReadKey();
            }
            public void Sucesso(string mensagen)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(mensagen);
                Console.ResetColor();
                Console.ReadKey();
            }
            public int Excluir(dynamic[] objeto, string mensagen)
            {
                do
                {
                    Console.WriteLine(mensagen);
                }
                while (!(int.TryParse(Console.ReadLine(), out numeroExcluir)) || objeto[numeroExcluir] == null);
                return numeroExcluir;
            }
        }
    }
}
