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
                } while (!(int.TryParse(Console.ReadLine(), out int numero)));
                caixas[i].numero = int.Parse(Console.ReadLine());
                mensagen.Sucesso("caixa registrada com sucesso");
            }

            public void Mostrar(int i)
            {
                Console.WriteLine($"Cor = {caixas[i].cor}\n" +
                        $"Etiqueta = {caixas[i].etiqueta}\n" +
                        $"Numero = {caixas[i].numero}\n");
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


