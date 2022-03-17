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
         
         
            public int Menus(string mensagenInformativa,int numeroMaximo)
            {
                houveErro = false;
                do
                {
                    if (houveErro == true)
                        mensagen.Erro("opção invalido");
                    Console.WriteLine(mensagenInformativa);
                    houveErro = true;
                }
                while (!(int.TryParse(Console.ReadLine(), out numero)) || numero > numeroMaximo || numero < 0);
                return numero;
            }
           
            public int PegaID(dynamic[] objeto)
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
            public int EditarOQue(string mensagenDoMenu, int numeroMaximo)
            {
                houveErro = false;
                do
                {
                    if (houveErro == true)
                        mensagen.Erro("ID invalido");
                    Console.WriteLine(mensagenDoMenu);
                    houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out numeroEditar)) || numeroEditar > numeroMaximo || numeroEditar <= 0);
                return numeroEditar;
            }
        }
    }
}
