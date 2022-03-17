using System;
namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class GerenciadorCategoria
        {
            public Categoria[] categoria = new Categoria[100];

            public void Registrar(int posicao)
            {
                bool Erro = false;
                Mensagen mensagen = new Mensagen();
                categoria[posicao] = new();

                Console.WriteLine("nome");
                categoria[posicao].nome = Console.ReadLine();

                do
                {
                    if (Erro == true)
                        mensagen.Erro("invalido");
                    Console.WriteLine("dias para emprestar");
                    Erro = true;
                } while (!(int.TryParse(Console.ReadLine(), out categoria[posicao].diasEmprestimo)));
                Console.Clear();
                mensagen.Sucesso("categoria cadastrado com successo");
            }
            public void Mostrar()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,0} | {1,0} | {2,0}", "ID".PadRight(3, ' '), "nome".PadRight(16, ' '), "dias".PadRight(16, ' '));

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                for (int i = 0; i < categoria.Length; i++)
                {
                    if (categoria[i] == null)
                        continue;
                    Console.WriteLine("{0,0} | {1,0} | {2,0}", i.ToString().PadRight(3, ' '), categoria[i].nome.PadRight(16, ' '), categoria[i].diasEmprestimo.ToString().PadRight(16, ' '));
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
            public void Editar(int i)
            {
                Menu menu = new Menu();
                bool houveErro;
                Mensagen mensagen = new Mensagen();
                int numeroEditar = menu.EditarOQue($"nome = 1\n" +
                              $"diasParaEmprestimo = 2\n" +
                              $"voltar = 3", 3);
                switch (numeroEditar)
                {
                    case 1:
                        Console.WriteLine("nome");
                        categoria[i].nome = Console.ReadLine();
                        break;
                    case 2:
                        houveErro = false;
                        do
                        {
                            if (houveErro)
                                mensagen.Erro("numero invalido");
                            Console.WriteLine("numero");
                            houveErro = true;
                        } while (!(int.TryParse(Console.ReadLine(), out categoria[i].diasEmprestimo)));
                        break;
                    case 3:
                        return;
                }
                mensagen.Sucesso("categoria editado com sucesso");
            }
        }
    }
}

