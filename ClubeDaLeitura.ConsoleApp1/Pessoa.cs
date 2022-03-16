using System;
namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class Pessoa
        {
           
           public int numeroEditar;
            public string telefone, nomeResponsavel, nome, endereço;
            public bool temEmprestimo;
           
        }
        public class GerenciadorPessoa
        {
            Mensagen mensagen = new();
            Menu menu = new Menu();
           public Pessoa[] pessoas = new Pessoa[100];
            public void Registrar(int i)
            {
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
            public void Mostrar(int i)
            {
                Console.WriteLine($"telefone = { pessoas[i].telefone}\n" +
                        $"nome do responsavel = { pessoas[i].nomeResponsavel}\n" +
                        $"nome = { pessoas[i].nome}\n" +
                        $"endereço = { pessoas[i].endereço}\n" +
                        $"tem emprestimo? { pessoas[i].temEmprestimo}\n");
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
