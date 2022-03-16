using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class Menu
        {
            int numeroEditar;
            int numero;
            Mensagen mensagen = new Mensagen();
            bool houveErro = false;
            public int MenuPrincipal() 
            {
                houveErro = false;
                do
                {
                    if (houveErro == true)
                        mensagen.Erro("opção invalido");
                    Console.WriteLine("1 = Revista\n" +
                        "2 = Caixa\n" +
                        "3 = Pessoas\n" +
                        "4 = Emprestimos\n" +
                        "5 = sair\n");
                    houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out numero))|| numero > 5 || numero <0);
               return numero;
            }
            public int MenuSecundarioGeral()
            {
                houveErro = false;
                do
                {
                    if (houveErro == true)
                        mensagen.Erro("opção invalido");
                    Console.WriteLine("1 = Registrar\n" +
                        "2 = Mostrar \n" +
                        "3 = Excluir \n" +
                        "4 = Editar \n" +
                        "5 = voltar\n");
                    houveErro = true;
                }
                while (!(int.TryParse(Console.ReadLine(), out numero)) || numero > 4 || numero < 0);
                return numero;
            }
            public int MenuSecundarioEmprestimo()
            {
                houveErro = false;
                do
                {
                    if (houveErro == true)
                        mensagen.Erro("opção invalido");
                    Console.WriteLine("1 = Registrar\n" +
                        "2 = Mostrar emprestimos abertos \n" +
                        "3 = Fechar \n" +
                        "4 = Editar \n" +
                        "5 = Mostrar emprestimos do mes\n" +
                        "6 = voltar\n");
                    houveErro = true;
                }
                while (!(int.TryParse(Console.ReadLine(), out numero)) || numero > 6 || numero < 0);
                return numero;
            }
            public int Editar(dynamic[] objeto)
            {
                 houveErro = false;
                do
                {
                    if (houveErro == true)
                        mensagen.Erro("ID invalido");
                    Console.WriteLine("qual o ID que deseja editar");
                    houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out numeroEditar)) || objeto[numeroEditar] == null);
                return numeroEditar;
            }
        }
    }
}
