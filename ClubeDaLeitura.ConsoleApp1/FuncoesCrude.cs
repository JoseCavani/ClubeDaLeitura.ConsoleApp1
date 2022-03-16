using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class FuncoesCrude
        {
            bool houveErro;
            Mensagen mensagens = new Mensagen();
            int posicao;
            public void MostrarEmprestimos(GerenciadorEmprestimo gerenciadorEmprestimo, Emprestimo[] emprestimos, bool abertos)
            {
                if (abertos)
                {
                    for (int i = 0; i < emprestimos.Length; i++)
                    {
                        if (emprestimos[i] == null || emprestimos[i].aberto == false)
                            continue;
                        Console.WriteLine($"ID : {i}");
                        gerenciadorEmprestimo.Mostrar(i);
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
                        gerenciadorEmprestimo.Mostrar(i);
                    }
                }
                Console.ReadKey();
            }

            public void RegistraEmprestimos(GerenciadorPessoa gerenciadorPessoas, GerenciadorRevista gerenciadorRevista, GerenciadorEmprestimo gerenciadorEmprestimo, Revista[] revistas, Pessoa[] pessoas, AcharPosicao acharPosicao, Emprestimo[] emprestimos)
            {
                int posicao = acharPosicao.AcharPosicaoNulo(emprestimos);
                emprestimos[posicao] = new Emprestimo();
                gerenciadorEmprestimo.Registrar(gerenciadorPessoas, gerenciadorRevista, revistas, pessoas, posicao);
            }

            public void Editar(dynamic gerenciador,Menu menu, dynamic[] objeto)
            {
                Mostrar(gerenciador,objeto);
                int numeroEditar = menu.EditarQual(objeto);
                Console.Clear();
                gerenciador.Editar(numeroEditar);
            }
            public void EditarEmprestimo(dynamic gerenciador, Menu menu, dynamic[] objeto, Pessoa[] pessoas, Revista[] revista)
            {
                Mostrar(gerenciador, objeto);
                int numeroEditar = menu.EditarQual(objeto);
                Console.Clear();
                gerenciador.Editar(numeroEditar, revista, pessoas);
            }

            public void Registrar(dynamic gerenciador,dynamic[] objeto, AcharPosicao acharPosicao)
            {
                int posicao = acharPosicao.AcharPosicaoNulo(objeto);

                if (objeto is Caixa[])
                    objeto[posicao] = new Caixa();
                else if (objeto is Pessoa[])
                    objeto[posicao] = new Pessoa();
                gerenciador.Registrar(posicao);
            }

            public void EditarRevista(GerenciadorRevista gerenciadorRevista, Menu menu, Revista[] revista, Caixa[] caixa)
            {
                Mostrar(gerenciadorRevista, revista);
                int numeroEditar = menu.EditarQual(revista);
                Console.Clear();
                gerenciadorRevista.EditarRevista(caixa,numeroEditar);
            }
            public void ExcluirEmprestimo(GerenciadorCaixa gerenciadorCaixa, GerenciadorEmprestimo gerenciadorEmprestimo, Emprestimo[] emprestimo, Mensagen mensagen, Pessoa[] pessoas, Revista[] revistas)
            {
                Mostrar(gerenciadorEmprestimo, emprestimo);
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

                Console.Clear();

                Mostrar(gerenciadorCaixa, gerenciadorCaixa.caixas);
                do
                {
                    if (houveErro == true)
                        mensagens.Erro("ID invalido");
                    Console.WriteLine("ID da caixa para colocar a revista");
                    houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out posicao)));

                Console.Clear();

                foreach (var item in revistas)
                {
                    if (item == null)
                        continue;
                    if (item.numeroEdicao == emprestimo[posicaoExluir].revista.numeroEdicao)
                    {
                        item.disponivel = true;
                        item.caixaDaRevista = gerenciadorCaixa.caixas[posicao];
                        break;
                    }
                }
                mensagen.Sucesso("fechado com sucesso");
                Console.Clear();

            }
            public void Excluir(dynamic gerenciador,dynamic[] objeto, Mensagen mensagen)
            {
                Mostrar(gerenciador, objeto);
                int posicaoExluir = mensagen.Excluir(objeto, "qual o ID que deseja excluir");


                objeto[posicaoExluir] = null;
                mensagen.Sucesso("removido com sucesso");

                Console.ReadKey();
            }

            public void RegistrarNovaRevista(GerenciadorCaixa gerenciadorCaixa, GerenciadorRevista gerenciadorRevista, Revista[] revista, Caixa[] caixa, AcharPosicao acharPosicao)
            {
                int posicao = acharPosicao.AcharPosicaoNulo(revista);
                revista[posicao] = new();
                gerenciadorRevista.Registar(gerenciadorCaixa, posicao, caixa);
            }

            public void Mostrar(dynamic gerenciador,dynamic[] objeto)
            {
                for (int i = 0; i < objeto.Length; i++)
                {
                    if (objeto[i] == null)
                        continue;
                    Console.WriteLine($"ID : {i}");
                    gerenciador.Mostrar(i);
                }

                Console.ReadKey();
            }
        }

    }
}
