using System;
namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class Caixa
        {
            public string cor,etiqueta;
            public int numero;
             int numeroEditar;
            Mensagen mensagen = new();
            public void Registrar()
            {
                Console.WriteLine("cor");
                    cor = Console.ReadLine();
                Console.WriteLine("etiqueta");
                    etiqueta = Console.ReadLine();
                do
                {
                    Console.WriteLine("numero");
                }while (!(int.TryParse(Console.ReadLine(), out int numero)));
                numero = int.Parse(Console.ReadLine());
                mensagen.Sucesso("caixa registrada com sucesso");
            }

            public void Mostrar()
            {
                Console.WriteLine($"Cor = {cor}\n" +
                        $"Etiqueta = {etiqueta}\n" +
                        $"Numero = {numero}\n");
            }

            public void Editar()
            {
                do
                {
                    Console.WriteLine($"cor = 1\n" +
                              $"numero = 2\n" +
                              $"etiqueta = 3\n");
                } while (!(int.TryParse(Console.ReadLine(), out numeroEditar)) || numeroEditar > 3 || numeroEditar < 0);
                switch (numeroEditar)
                {
                    case 1:
                        Console.WriteLine("cor");
                        cor = Console.ReadLine();
                        break;
                    case 2:
                        do
                        {
                            Console.WriteLine("numero");
                        } while (!(int.TryParse(Console.ReadLine(), out numero)));
                        break;
                    case 3:
                        Console.WriteLine("etiqueta");
                        etiqueta = Console.ReadLine();
                        break;
                }
                mensagen.Sucesso("caixa editada com sucesso");
            }
        }
        }
    }


