using System;
namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class Pessoa
        {
            Mensagen mensagen = new();
            Menu menu = new Menu();
            int numeroEditar;
            public string telefone, nomeResponsavel, nome, endereço;
            public bool temEmprestimo;
            public void Registrar()
            {
                Console.WriteLine("telefone");
                telefone = Console.ReadLine();
                Console.WriteLine("nome do responsavel");
                nomeResponsavel = Console.ReadLine();
                Console.WriteLine("nome");
                nome = Console.ReadLine();
                Console.WriteLine("endereço");
                endereço = Console.ReadLine();
            }
            public void Mostrar()
            {
                Console.WriteLine($"telefone = {telefone}\n" +
                        $"nome do responsavel = {nomeResponsavel}\n" +
                        $"nome = {nome}\n" +
                        $"endereço = {endereço}\n" +
                        $"tem emprestimo? {temEmprestimo}");
            }
            public void Editar()
            {

                numeroEditar = menu.EditarOQue($"telefone = 1\n" +
                          $"nome do responsavel = 2\n" +
                          $"nome = 3\n" +
                          $"endereço = 4\n" +
                          $"5 = voltar\n", 5);

                switch (numeroEditar)
                {
                    case 1:
                        Console.WriteLine("telefone");
                        telefone = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("nome do responsavel");
                        nomeResponsavel = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("nome");
                        nome = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("endereço");
                        endereço = Console.ReadLine();
                        break;
                    case 5:
                        return;
                }
                mensagen.Sucesso("pessoa editada com sucesso");
            }
        }
    }
}
