using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class FuncoesCrude
        {
            public void MostrarEmprestimos(Emprestimo[] emprestimos, bool abertos)
            {
                if (abertos)
                {
                    for (int i = 0; i < emprestimos.Length; i++)
                    {
                        if (emprestimos[i] == null || emprestimos[i].aberto == false)
                            continue;
                        Console.WriteLine($"ID : {i}");
                        emprestimos[i].Mostrar();
                    }
                }
                else
                {
                    for (int i = 0; i < emprestimos.Length; i++)
                    {
                        if (emprestimos[i] == null)
                            continue;
                        TimeSpan dias = DateTime.Today - emprestimos[i].dataEmprestimo;
                        if (dias.Days > 30)
                            continue;
                        Console.WriteLine($"ID : {i}");
                        emprestimos[i].Mostrar();
                    }
                }
                Console.ReadKey();
            }

            public void RegistraEmprestimos(Revista[] revistas, Pessoa[] pessoas, AcharPosicao acharPosicao, Emprestimo[] emprestimos)
            {
                int posicao = acharPosicao.AcharPosicaoNulo(emprestimos);
                emprestimos[posicao] = new Emprestimo();
                emprestimos[posicao].Registrar(revistas, pessoas);
            }

            public void Editar(Menu menu, dynamic[] objeto)
            {
                Mostrar(objeto);
                int numeroEditar = menu.EditarQual(objeto);
                Console.Clear();
                objeto[numeroEditar].Editar();
            }

            public void Registrar(dynamic[] objeto, AcharPosicao acharPosicao)
            {
                int posicao = acharPosicao.AcharPosicaoNulo(objeto);

                if (objeto is Caixa[])
                    objeto[posicao] = new Caixa();
                else if (objeto is Pessoa[])
                    objeto[posicao] = new Pessoa();
                objeto[posicao].Registrar();
            }

            public void EditarRevista(Menu menu, Revista[] revista, Caixa[] caixa)
            {
                Mostrar(revista);
                int numeroEditar = menu.EditarQual(revista);
                Console.Clear();
                revista[numeroEditar].EditarRevista(caixa);
            }
            public void ExcluirEmprestimo(Emprestimo[] emprestimo, Mensagen mensagen, Pessoa[] pessoas, Revista[] revistas)
            {
                Mostrar(emprestimo);
                int posicaoExluir = mensagen.Excluir(emprestimo, "qual o ID que deseja excluir");

                emprestimo[posicaoExluir].aberto = false;
                emprestimo[posicaoExluir].dataDevolucao = DateTime.Now;
                foreach (var item in pessoas)
                {
                    if (item == null)
                        continue;
                    if (item.nome == emprestimo[posicaoExluir].amigo.nome)
                    {
                        item.temEmprestimo = false;
                        break;
                    }
                }
                foreach (var item in revistas)
                {
                    if (item == null)
                        continue;
                    if (item.numeroEdicao == emprestimo[posicaoExluir].revista.numeroEdicao)
                    {
                        item.disponivel = true;
                        break;
                    }
                }
                mensagen.Sucesso("fechado com sucesso");

            }
            public void Excluir(dynamic[] objeto, Mensagen mensagen)
            {
                Mostrar(objeto);
                int posicaoExluir = mensagen.Excluir(objeto, "qual o ID que deseja excluir");


                objeto[posicaoExluir] = null;
                mensagen.Sucesso("removido com sucesso");

                Console.ReadKey();
            }

            public void RegistrarNovaRevista(Revista[] revista, Caixa[] caixa, AcharPosicao acharPosicao)
            {
                int posicao = acharPosicao.AcharPosicaoNulo(revista);
                revista[posicao] = new();
                revista[posicao].Registar(caixa);
            }

            public void Mostrar(dynamic[] objeto)
            {
                for (int i = 0; i < objeto.Length; i++)
                {
                    if (objeto[i] == null)
                        continue;
                    Console.WriteLine($"ID : {i}");
                    objeto[i].Mostrar();
                }

                Console.ReadKey();
            }
        }

    }
}
