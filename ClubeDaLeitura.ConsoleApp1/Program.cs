using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            #region variaveis
            Menu menu = new();
            Revista[] revistas = new Revista[100];
            Caixa[] caixas = new Caixa[100];
            Pessoa[] pessoas = new Pessoa[100];
            AcharPosicao acharPosicao = new();
            Mensagen mensagen = new();
            Emprestimo[] emprestimos = new Emprestimo[100];
            FuncoesCrude funcaoCrude = new();
            #endregion

            #region valores
            caixas[0] = new();
            caixas[0].cor = "verde";
            caixas[0].numero = 1;
            caixas[0].etiqueta = "etiqueta 1";

            revistas[0] = new();
            revistas[0].ano = 2022;
            revistas[0].disponivel = true;
            revistas[0].tipoColecao = "tipo1";
            revistas[0].numeroEdicao = "numeroEdicao1";
            revistas[0].caixaDaRevista = caixas[0];

            pessoas[0] = new();
            pessoas[0].telefone = "tel1";
            pessoas[0].endereço = "end1";
            pessoas[0].nome = "nome1";
            pessoas[0].nomeResponsavel = "nomeRes1";

            #endregion

            do {
                Console.Clear();
                switch (menu.MenuPrincipal())
                {
                    case 1:
                        Console.Clear();
                        switch (menu.MenuSecundarioGeral())
                        {
                            case 1:
                                funcaoCrude.RegistrarNovaRevista(revistas, caixas, acharPosicao);
                                break;
                            case 2:
                                funcaoCrude.Mostrar(revistas);
                                break;
                            case 3:
                                funcaoCrude.Excluir(revistas, mensagen);
                                break;
                            case 4:
                                funcaoCrude.EditarRevista(menu, revistas, caixas);
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
                                funcaoCrude.Registrar(caixas, acharPosicao);
                                break;
                            case 2:
                                funcaoCrude.Mostrar(caixas);
                                break;
                            case 3:
                                funcaoCrude.Excluir(caixas,mensagen);
                                break;
                            case 4:
                                funcaoCrude.Editar(menu, caixas);
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
                                funcaoCrude.Registrar(pessoas, acharPosicao);
                                break;
                            case 2:
                                funcaoCrude.Mostrar(pessoas);
                                break;
                            case 3:
                                funcaoCrude.Excluir(pessoas, mensagen);
                                break;
                            case 4:
                                funcaoCrude.Editar(menu, pessoas);
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
                                funcaoCrude.RegistraEmprestimos(revistas, pessoas, acharPosicao, emprestimos);
                                break;
                            case 2:
                                funcaoCrude.MostrarEmprestimos(emprestimos,true);
                                break;
                            case 3:
                                funcaoCrude.ExcluirEmprestimo(emprestimos, mensagen, pessoas, revistas);
                                break;
                            case 4:
                                funcaoCrude.Editar(menu, emprestimos);
                                break;
                            case 5:
                                funcaoCrude.MostrarEmprestimos(emprestimos, false);
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
            }while (true);
        }
    }
}
