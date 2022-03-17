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

            public void QuitarMulta(GerenciadorPessoa gerenciadorPessoas)
            {
                Menu menu = new Menu();
                Mensagen mensagen = new();
                bool naohaMulta = false;
                foreach (var item in gerenciadorPessoas.pessoas)
                {
                    if (item == null)
                        continue;
                    if (item.multa)
                     naohaMulta = true;
                }
                if (naohaMulta)
                {
                    mensagen.Erro("nao ha multas");
                    Console.ReadKey();
                        return;
                }
                Mostrar(gerenciadorPessoas);
              int id =  menu.PegaID(gerenciadorPessoas.pessoas);
                gerenciadorPessoas.pessoas[id].multa = false;
                mensagen.Sucesso("multa quitado");
                Console.ReadKey();
            }
            public void RegistraEmprestimos(GerenciadorPessoa gerenciadorPessoas, GerenciadorRevista gerenciadorRevista, GerenciadorEmprestimo gerenciadorEmprestimo, Revista[] revistas, Pessoa[] pessoas, AcharPosicao acharPosicao, Emprestimo[] emprestimos)
            {
                bool tudoCerto;

                tudoCerto = VerSeHaPessoasERevistas(revistas, pessoas);

                if (tudoCerto == false)
                    return;

                int posicao = acharPosicao.AcharPosicaoNulo(emprestimos);
                emprestimos[posicao] = new Emprestimo();
                gerenciadorEmprestimo.Registrar(gerenciadorPessoas, gerenciadorRevista, revistas, pessoas, posicao);
            }

            public bool VerSeHaPessoasERevistas(Revista[] revistas, Pessoa[] pessoas)
            {
                Mensagen mensagen = new();
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
                    return false;
                }

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
                    return false;
                }
                return true;
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
                int numeroEditar = menu.PegaID(objeto);
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
                int numeroEditar = menu.PegaID(objeto);
                Console.Clear();
                gerenciador.Editar(numeroEditar, revista, pessoas);
            }

            public void Registrar(dynamic gerenciador,dynamic[] objeto, AcharPosicao acharPosicao)
            {
                int posicao = acharPosicao.AcharPosicaoNulo(objeto);

                gerenciador.Registrar(posicao);
            }
            public void RegistrarReserva(dynamic gerenciador, dynamic[] objeto, AcharPosicao acharPosicao, GerenciadorPessoa gerenciadorPessoas, GerenciadorRevista gerenciadorRevista)
            {
                bool tudoCerto;

                tudoCerto = VerSeHaPessoasERevistas (gerenciadorRevista.revistas, gerenciadorPessoas.pessoas);

                if (tudoCerto == false)
                    return;

                int posicao = acharPosicao.AcharPosicaoNulo(objeto);

                gerenciador.Registrar(posicao, gerenciadorPessoas, gerenciadorRevista);
            }
            public void EditarReserva(GerenciadorReserva gerenciadorReserva, Menu menu, dynamic[] objeto, GerenciadorPessoa gerenciadorPessoa, GerenciadorRevista gerenciadorRevista)
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


                Mostrar(gerenciadorReserva);
                int numeroEditar = menu.PegaID(objeto);

               
                Console.Clear();
                gerenciadorReserva.Editar(gerenciadorPessoa, gerenciadorRevista, numeroEditar);
            }
            public void EditarRevista(GerenciadorCategoria gerenciadorCategoria,GerenciadorRevista gerenciadorRevista, Menu menu, Revista[] revista, Caixa[] caixa)
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
                int numeroEditar = menu.PegaID(revista);
                Console.Clear();
                gerenciadorRevista.EditarRevista(gerenciadorCategoria, caixa,numeroEditar);
            }
            public void FecharEmprestimo(GerenciadorCaixa gerenciadorCaixa, GerenciadorEmprestimo gerenciadorEmprestimo, Emprestimo[] emprestimo, Mensagen mensagen, Pessoa[] pessoas, Revista[] revistas)
            {
                bool haEmprestimos = false;
                foreach (var item in emprestimo)
                {
                    if(item != null)
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
                MostrarEmprestimos(gerenciadorEmprestimo,false);
                int posicaoExluir = mensagen.Excluir(emprestimo, "qual o ID que deseja fechar");

                emprestimo[posicaoExluir].aberto = false;

                do
                {
                    if (houveErro == true)
                        mensagens.Erro("data invalida");
                    Console.WriteLine("data de devolução");
                    houveErro = true;
                } while (!(DateTime.TryParse(Console.ReadLine(), out emprestimo[posicaoExluir].dataDevolucao)));

                TimeSpan dias =  emprestimo[posicaoExluir].dataDevolucao - DateTime.Today;
                foreach (var item in pessoas)
                {
                    if (item == null)
                        continue;
                    if (item.nome == emprestimo[posicaoExluir].amigo.nome)
                    {
                        item.temEmprestimo = false;
                        if (dias.Days > emprestimo[posicaoExluir].revista.categoria.diasEmprestimo)
                        {
                            mensagen.Erro("devolvido com multa");
                            item.multa = true;
                        }
                        break;
                    }
                }
                houveErro = false;
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
            public void ExcluirReserva(GerenciadorRevista gerenciadorRevista, GerenciadorReserva gerenciadorReserva,GerenciadorPessoa gerenciadorPessoa)
            {
                Mensagen mensagen = new();
                    bool haReserva = false;
                foreach (var item in gerenciadorReserva.reserva)
                {
                    if (item != null)
                    {
                        haReserva = true;
                        break;
                    }
                }
                if (haReserva == false)
                {
                    mensagen.Erro("não ha reservas");
                    return;
                }

                Mensagen mensagens = new Mensagen();
                Mostrar(gerenciadorReserva);
                int posicaoExluir = mensagen.Excluir(gerenciadorReserva.reserva, "qual o ID que deseja excluir");

                gerenciadorReserva.reserva[posicaoExluir] = default;
                foreach (var item in gerenciadorPessoa.pessoas)
                {
                    if (item == null)
                        continue;
                    if (item.nome == gerenciadorReserva.reserva[posicaoExluir].amigo.nome)
                    {
                        item.temEmprestimo = false;
                        break;
                    }
                }

                Console.Clear();

                foreach (var item in gerenciadorRevista.revistas)
                {
                    if (item == null)
                        continue;
                    if (item.numeroEdicao == gerenciadorRevista.revistas[posicaoExluir].numeroEdicao)
                    {
                        item.disponivel = true;
                        break;
                    }
                }
                mensagen.Sucesso("fechado com sucesso");
                Console.Clear();
            }

            public void RegistrarNovaRevista(GerenciadorCategoria gerenciadorCategoria, GerenciadorCaixa gerenciadorCaixa, GerenciadorRevista gerenciadorRevista, Revista[] revista, Caixa[] caixa, AcharPosicao acharPosicao)
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
                gerenciadorRevista.Registar(gerenciadorCategoria,gerenciadorCaixa, posicao, caixa);
            }

            public void Mostrar(dynamic gerenciador)
            {
                    gerenciador.Mostrar();
            }
            public void NovoEmprestimoComReserva(GerenciadorEmprestimo gerenciadorEmprestimo,Pessoa[] amigos, Revista[] revistas, GerenciadorReserva gerenciadorReserva)
            {
                AcharPosicao acharPosicao = new();
                Menu menu = new();
                int posicao = acharPosicao.AcharPosicaoNulo(gerenciadorEmprestimo.emprestimos);

                gerenciadorReserva.Mostrar();
               int ID = menu.PegaID(gerenciadorReserva.reserva);

                gerenciadorEmprestimo.emprestimos[posicao] = new Emprestimo();
                gerenciadorEmprestimo.RegistrarComReserva(amigos, revistas, gerenciadorReserva.reserva[ID],posicao);
            }
        }

    }
}
