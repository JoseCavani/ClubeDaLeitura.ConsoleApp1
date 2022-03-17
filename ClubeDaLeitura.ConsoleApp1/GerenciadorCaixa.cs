using System;
namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class GerenciadorCaixa
        {
            Mensagen mensagen = new();
            Menu menu = new();
            public Caixa[] caixas = new Caixa[100];
            public void Registrar(int i)
            {
                caixas[i] = new Caixa();
                Console.WriteLine("cor");
                caixas[i].cor = Console.ReadLine();
                Console.WriteLine("etiqueta");
                caixas[i].etiqueta = Console.ReadLine();
                caixas[i].houveErro = false;
                do
                {
                    if (caixas[i].houveErro == true)
                       mensagen.Erro("numero invalido");
                    Console.WriteLine("numero");
                    caixas[i].houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out caixas[i].numero)));
                mensagen.Sucesso("caixa registrada com sucesso");
            }

            public void Mostrar()
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,0} | {1,0} | {2,0} | {3,0} ", "ID".PadRight(3, ' '), "cor".PadRight(16, ' '), "numero".PadRight(16, ' '), "etiqueta".PadRight(16, ' '));

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                for (int i = 0; i < caixas.Length; i++)
                {
                    if (caixas[i] == null)
                        continue;
                    Console.WriteLine("{0,0} | {1,0} | {2,0} | {3,0} ", i.ToString().PadRight(3, ' '), caixas[i].cor.PadRight(16, ' '), caixas[i].numero.ToString().PadRight(16, ' '), caixas[i].etiqueta.PadRight(16, ' '));
                    Console.WriteLine();
                }
            }

            public void Editar(int i)
            {

                caixas[i].numeroEditar = menu.EditarOQue($"cor = 1\n" +
                              $"numero = 2\n" +
                              $"etiqueta = 3\n" +
                              $"voltar = 4\n", 4);

                switch (caixas[i].numeroEditar)
                {
                    case 1:
                        Console.WriteLine("cor");
                        caixas[i].cor = Console.ReadLine();
                        break;
                    case 2:
                        caixas[i].houveErro = false;
                        do
                        {
                            if (caixas[i].houveErro)
                                mensagen.Erro("numero invalido");
                            Console.WriteLine("numero");
                            caixas[i].houveErro = true;
                        } while (!(int.TryParse(Console.ReadLine(), out caixas[i].numero)));
                        break;
                    case 3:
                        Console.WriteLine("etiqueta");
                        caixas[i].etiqueta = Console.ReadLine();
                        break;
                }
                mensagen.Sucesso("caixa editada com sucesso");
            }
        }
    }
}


