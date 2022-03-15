using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class Menu
        {
            int numeroEditar;
            int numero;
            public int MenuPrincipal() 
            {
                do
                {
                    Console.WriteLine("1 = Revista\n" +
                        "2 = Caixa\n" +
                        "3 = Pessoas\n" +
                        "4 = Emprestimos\n" +
                        "5 = sair\n");
                } while (!(int.TryParse(Console.ReadLine(), out numero))|| numero > 5 || numero <0);
               return numero;
            }
            public int MenuSecundarioGeral()
            {
                Console.WriteLine("1 = Registrar\n" +
                    "2 = Mostrar \n" +
                    "3 = Excluir \n" +
                    "4 = Editar \n");
                while (!(int.TryParse(Console.ReadLine(), out numero)) || numero > 4 || numero < 0) ;
                return numero;
            }
            public int MenuSecundarioEmprestimo()
            {
                Console.WriteLine("1 = Registrar\n" +
                    "2 = Mostrar emprestimos abertos \n" +
                    "3 = Fechar \n" +
                    "4 = Editar \n" +
                    "5 = Mostrar emprestimos do mes\n");
                while (!(int.TryParse(Console.ReadLine(), out numero)) || numero > 5 || numero < 0) ;
                return numero;
            }
            public int Editar(dynamic[] objeto)
            {
                do
                {
                    Console.WriteLine("qual o ID que deseja editar");
                } while (!(int.TryParse(Console.ReadLine(), out numeroEditar)) || objeto[numeroEditar] == null);
                return numeroEditar;
            }
        }
    }
}
