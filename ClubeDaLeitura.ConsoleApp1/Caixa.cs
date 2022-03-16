using System;
namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class Caixa
        {
            public string cor, etiqueta;
            public int numero;
            int numeroEditar;
            Mensagen mensagen = new();
            bool houveErro = false;
            Menu menu = new();
            public void Registrar()
            {
                Console.WriteLine("cor");
                cor = Console.ReadLine();
                Console.WriteLine("etiqueta");
                etiqueta = Console.ReadLine();
                houveErro = false;
                do
                {
                    if (houveErro == true)
                        mensagen.Erro("numero invalido");
                    Console.WriteLine("numero");
                    houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out int numero)));
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

                numeroEditar = menu.EditarOQue($"cor = 1\n" +
                              $"numero = 2\n" +
                              $"etiqueta = 3\n" +
                              $"voltar = 4\n", 4);

                switch (numeroEditar)
                {
                    case 1:
                        Console.WriteLine("cor");
                        cor = Console.ReadLine();
                        break;
                    case 2:
                        houveErro = false;
                        do
                        {
                            if (houveErro)
                                mensagen.Erro("numero invalido");
                            Console.WriteLine("numero");
                            houveErro = true;
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


