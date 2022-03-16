using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            #region variaveis
            Menu menu = new();
            AcharPosicao acharPosicao = new();
            Mensagen mensagen = new();
            FuncoesCrude funcaoCrude = new();
            GerenciadorRevista gerenciadorRevista = new();
            GerenciadorCaixa gerenciadorCaixa = new();
            GerenciadorPessoa gerenciadorPessoas = new();
            GerenciadorEmprestimo gerenciadorEmprestimo = new();
            #endregion

            #region valores
            gerenciadorCaixa.caixas[0] = new();
            gerenciadorCaixa.caixas[0].cor = "verde";
            gerenciadorCaixa.caixas[0].numero = 1;
            gerenciadorCaixa.caixas[0].etiqueta = "etiqueta 1";

            gerenciadorRevista.revistas[0] = new();
            gerenciadorRevista.revistas[0].ano = 2022;
            gerenciadorRevista.revistas[0].disponivel = true;
            gerenciadorRevista.revistas[0].tipoColecao = "tipo1";
            gerenciadorRevista.revistas[0].numeroEdicao = "numeroEdicao1";
            gerenciadorRevista.revistas[0].caixaDaRevista = gerenciadorCaixa.caixas[0];

            gerenciadorPessoas.pessoas[0] = new();
            gerenciadorPessoas.pessoas[0].telefone = "tel1";
            gerenciadorPessoas.pessoas[0].endereço = "end1";
            gerenciadorPessoas.pessoas[0].nome = "nome1";
            gerenciadorPessoas.pessoas[0].nomeResponsavel = "nomeRes1";

            #endregion

            do
            {
                Console.Clear();
                switch (menu.MenuPrincipal())
                {
                    case 1:
                        Console.Clear();
                        switch (menu.MenuSecundarioGeral())
                        {
                            case 1:
                                funcaoCrude.RegistrarNovaRevista(gerenciadorCaixa, gerenciadorRevista, gerenciadorRevista.revistas, gerenciadorCaixa.caixas, acharPosicao);
                                break;
                            case 2:
                                funcaoCrude.Mostrar(gerenciadorRevista);
                                break;
                            case 3:
                                funcaoCrude.Excluir(gerenciadorRevista, gerenciadorRevista.revistas, mensagen);
                                break;
                            case 4:
                                funcaoCrude.EditarRevista(gerenciadorRevista,menu, gerenciadorRevista.revistas, gerenciadorCaixa.caixas);
                                break;
                            case 5:
                                break;
                            default:
                                mensagen.Erro("invalido");
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        switch (menu.MenuSecundarioGeral())
                        {
                            case 1:
                                funcaoCrude.Registrar(gerenciadorCaixa,gerenciadorCaixa.caixas, acharPosicao);
                                break;
                            case 2:
                                funcaoCrude.Mostrar(gerenciadorCaixa);
                                break;
                            case 3:
                                funcaoCrude.Excluir(gerenciadorCaixa, gerenciadorCaixa.caixas, mensagen);
                                break;
                            case 4:
                                funcaoCrude.Editar(gerenciadorCaixa,menu, gerenciadorCaixa.caixas);
                                break;
                            case 5:
                                break;
                            default:
                                mensagen.Erro("invalido");
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        switch (menu.MenuSecundarioGeral())
                        {
                            case 1:
                                funcaoCrude.Registrar(gerenciadorPessoas, gerenciadorPessoas.pessoas, acharPosicao);
                                break;
                            case 2:
                                funcaoCrude.Mostrar(gerenciadorPessoas);
                                break;
                            case 3:
                                funcaoCrude.Excluir(gerenciadorPessoas, gerenciadorPessoas.pessoas, mensagen);
                                break;
                            case 4:
                                funcaoCrude.Editar(gerenciadorPessoas,menu, gerenciadorPessoas.pessoas);
                                break;
                            case 5:
                                break;
                            default:
                                mensagen.Erro("invalido");
                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        switch (menu.MenuSecundarioEmprestimo())
                        {
                            case 1:
                                funcaoCrude.RegistraEmprestimos(gerenciadorPessoas, gerenciadorRevista, gerenciadorEmprestimo, gerenciadorRevista.revistas, gerenciadorPessoas.pessoas, acharPosicao, gerenciadorEmprestimo.emprestimos);
                                break;
                            case 2:
                                funcaoCrude.MostrarEmprestimos(gerenciadorEmprestimo, gerenciadorEmprestimo.emprestimos, true);
                                break;
                            case 3:
                                funcaoCrude.ExcluirEmprestimo(gerenciadorCaixa, gerenciadorEmprestimo,gerenciadorEmprestimo.emprestimos, mensagen, gerenciadorPessoas.pessoas, gerenciadorRevista.revistas);
                                break;
                            case 4:
                                funcaoCrude.EditarEmprestimo(gerenciadorEmprestimo, menu, gerenciadorEmprestimo.emprestimos, gerenciadorPessoas.pessoas, gerenciadorRevista.revistas);
                                break;
                            case 5:
                                funcaoCrude.MostrarEmprestimos(gerenciadorEmprestimo, gerenciadorEmprestimo.emprestimos, false);
                                break;
                            case 6:
                                break;
                            default:
                                mensagen.Erro("invalido");
                                break;
                        }
                        break;
                    case 5:
                        return;
                    default:
                        mensagen.Erro("invalido");
                        break;
                }
            } while (true);
        }
    }
}
