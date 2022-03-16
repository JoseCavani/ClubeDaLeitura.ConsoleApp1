using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class FuncoesCrude
        {
           
            public void MostrarEmprestimos(GerenciadorEmprestimo gerenciadorEmprestimo, bool abertos)
            {
                if (abertos)
                {
                        gerenciadorEmprestimo.Mostrar(true);
                }
                else
                {
                        gerenciadorEmprestimo.Mostrar(false);
                }
            }

            public void RegistraEmprestimos(GerenciadorPessoa gerenciadorPessoas, GerenciadorRevista gerenciadorRevista, GerenciadorEmprestimo gerenciadorEmprestimo, Revista[] revistas, Pessoa[] pessoas, AcharPosicao acharPosicao, Emprestimo[] emprestimos)
            {
                int posicao = acharPosicao.AcharPosicaoNulo(emprestimos);
                emprestimos[posicao] = new Emprestimo();
                gerenciadorEmprestimo.Registrar(gerenciadorPessoas, gerenciadorRevista, revistas, pessoas, posicao);
            }

            public void Editar(dynamic gerenciador,Menu menu, dynamic[] objeto)
            {
                Mostrar(gerenciador);
                int numeroEditar = menu.EditarQual(objeto);
                Console.Clear();
                gerenciador.Editar(numeroEditar);
            }
            public void EditarEmprestimo(dynamic gerenciador, Menu menu, dynamic[] objeto, Pessoa[] pessoas, Revista[] revista)
            {
                Mostrar(gerenciador);
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
                Mostrar(gerenciadorRevista);
                int numeroEditar = menu.EditarQual(revista);
                Console.Clear();
                gerenciadorRevista.EditarRevista(caixa,numeroEditar);
            }
            public void ExcluirEmprestimo(GerenciadorCaixa gerenciadorCaixa, GerenciadorEmprestimo gerenciadorEmprestimo, Emprestimo[] emprestimo, Mensagen mensagen, Pessoa[] pessoas, Revista[] revistas)
            {
                bool houveErro = false;
                Mensagen mensagens = new Mensagen();
                int posicao;
                Mostrar(gerenciadorEmprestimo);
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

                Mostrar(gerenciadorCaixa);
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
                Mostrar(gerenciador);
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

            public void Mostrar(dynamic gerenciador)
            {
                    gerenciador.Mostrar();
            }
        }

    }
}
