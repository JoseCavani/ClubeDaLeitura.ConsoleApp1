using System;
namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class GerenciadorPessoa
        {
            Mensagen mensagen = new();
            Menu menu = new Menu();
           public Pessoa[] pessoas = new Pessoa[100];
            public void Registrar(int i)
            {
                pessoas[i] = new Pessoa();
                Console.WriteLine("telefone");
                pessoas[i].telefone = Console.ReadLine();
                Console.WriteLine("nome do responsavel");
                pessoas[i].nomeResponsavel = Console.ReadLine();
                Console.WriteLine("nome");
                pessoas[i].nome = Console.ReadLine();
                Console.WriteLine("endereço");
                pessoas[i].endereço = Console.ReadLine();
                mensagen.Sucesso("pessoa registrada com sucesso");
            }
         
            public void Mostrar()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,0} | {1,0} | {2,0} | {3,0} | {4,0} | {5,0} | {6,0}", "ID".PadRight(3,' '), "telefone".PadRight(10, ' '), "nome do responsavel".PadRight(20, ' '), "nome".PadRight(10, ' '), "endereço".PadRight(20, ' '), "tem emprestimo?".PadRight(20, ' '),"tem multa?");

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                for (int i = 0; i < pessoas.Length; i++)
                {
                    if (pessoas[i] == null)
                        continue;
                    Console.WriteLine("{0,0} | {1,0} | {2,0} | {3,0} | {4,0} | {5,0} | {6,0} ", i.ToString().PadRight(3,' '), pessoas[i].telefone.PadRight(10, ' '), pessoas[i].nomeResponsavel.PadRight(20, ' '), pessoas[i].nome.PadRight(10, ' '), pessoas[i].endereço.PadRight(20, ' '), pessoas[i].temEmprestimo.ToString().PadRight(20, ' '), pessoas[i].multa);
                    Console.WriteLine();
                }
            }
            public void Editar(int i)
            {

                pessoas[i].numeroEditar = menu.EditarOQue($"telefone = 1\n" +
                          $"nome do responsavel = 2\n" +
                          $"nome = 3\n" +
                          $"endereço = 4\n" +
                          $"5 = voltar\n", 5);

                switch (pessoas[i].numeroEditar)
                {
                    case 1:
                        Console.WriteLine("telefone");
                        pessoas[i].telefone = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("nome do responsavel");
                        pessoas[i].nomeResponsavel = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("nome");
                        pessoas[i].nome = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("endereço");
                        pessoas[i].endereço = Console.ReadLine();
                        break;
                    case 5:
                        return;
                }
                mensagen.Sucesso("pessoa editada com sucesso");
            }
        }
    }
}
