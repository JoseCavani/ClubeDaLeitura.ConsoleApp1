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
                Mensagen mensagen = new();
                 bool haRevistas = false;
                foreach (var item in revistas)
                {
                    if (item != null && item.disponivel == true)
                    {
                        haRevistas = true;
                        break;
                    }
                }
                if (haRevistas == false)
                {
                    mensagen.Erro("não ha revistas disponiveis");
                    return;
                }

                bool haPessoas = false;
                foreach (var item in pessoas)
                {
                    if (item != null && item.temEmprestimo == false)
                    {
                        haPessoas = true;
                        break;
                    }
                }
                if (haPessoas == false)
                {
                    mensagen.Erro("não ha pessoas para emprestar disponiveis");
                    return;
                }



                int posicao = acharPosicao.AcharPosicaoNulo(emprestimos);
                emprestimos[posicao] = new Emprestimo();
                gerenciadorEmprestimo.Registrar(gerenciadorPessoas, gerenciadorRevista, revistas, pessoas, posicao);
            }

            public void Editar(dynamic gerenciador,Menu menu, dynamic[] objeto)
            {
                Mensagen mensagen = new();
                bool haObjetos = false;
                foreach (var item in objeto)
                {
                    if(item != null)
                    {
                        haObjetos = true;
                        break;
                    }
                }
                if(haObjetos == false)
                {
                    mensagen.Erro("não ha nada para editar");
                    return;
                }

                Mostrar(gerenciador);
                int numeroEditar = menu.EditarQual(objeto);
                Console.Clear();
                gerenciador.Editar(numeroEditar);
            }
            public void EditarEmprestimo(dynamic gerenciador, Menu menu, dynamic[] objeto, Pessoa[] pessoas, Revista[] revista)
            {
                Mensagen mensagen = new();
                bool haObjetos = false;
                foreach (var item in objeto)
                {
                    if (item != null)
                    {
                        haObjetos = true;
                        break;
                    }
                }
                if (haObjetos == false)
                {
                    mensagen.Erro("não ha nada para editar");
                    return;
                }

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

                Mensagen mensagen = new();
                bool haCaixa = false;
                foreach (var item in caixa)
                {
                    if (caixa != null)
                    {
                        haCaixa = true;
                        break;
                    }
                }
                if (haCaixa == false)
                {
                    mensagen.Erro("não ha caixas");
                    return;
                }

                bool haRevista = false;
                foreach (var item in revista)
                {
                    if (revista != null)
                    {
                        haRevista = true;
                        break;
                    }
                }
                if (haRevista == false)
                {
                    mensagen.Erro("não ha caixas");
                    return;
                }


                Mostrar(gerenciadorRevista);
                int numeroEditar = menu.EditarQual(revista);
                Console.Clear();
                gerenciadorRevista.EditarRevista(caixa,numeroEditar);
            }
            public void ExcluirEmprestimo(GerenciadorCaixa gerenciadorCaixa, GerenciadorEmprestimo gerenciadorEmprestimo, Emprestimo[] emprestimo, Mensagen mensagen, Pessoa[] pessoas, Revista[] revistas)
            {
                bool haEmprestimos = false;
                foreach (var item in emprestimo)
                {
                    if(emprestimo != null)
                    {
                        haEmprestimos = true;
                        break;
                    }
                }
                if ( haEmprestimos == false)
                {
                    mensagen.Erro("não ha emprestimos");
                    return;
                }

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
                bool haObjeto = false;

                foreach (var item in objeto)
                {
                    if (item != null)
                    {
                        haObjeto = true;
                        break;
                    }
                }
                if (haObjeto == false)
                {
                    mensagen.Erro("não ha nada para excluir");
                        return;
                }

                Mostrar(gerenciador);
                int posicaoExluir = mensagen.Excluir(objeto, "qual o ID que deseja excluir");


                objeto[posicaoExluir] = null;
                mensagen.Sucesso("removido com sucesso");

                Console.ReadKey();
            }

            public void RegistrarNovaRevista(GerenciadorCaixa gerenciadorCaixa, GerenciadorRevista gerenciadorRevista, Revista[] revista, Caixa[] caixa, AcharPosicao acharPosicao)
            {
                Mensagen mensagen = new();
               

                bool haCaixa = false;
                foreach (var item in caixa)
                {
                    if (item != null)
                    {
                        haCaixa = true;
                        break;
                    }
                }
                if (haCaixa == false)
                {
                    mensagen.Erro("não ha caixas disponiveis");
                    return;
                }




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
