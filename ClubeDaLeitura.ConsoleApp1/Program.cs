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
                                Console.Clear();
                                RegistrarNovaRevista(revistas, caixas, acharPosicao);
                                break;
                            case 2:
                                Console.Clear();
                                Mostrar(revistas);
                                break;
                            case 3:
                                Console.Clear();
                                Excluir(revistas, mensagen);
                                break;
                            case 4:
                                Console.Clear();
                                EditarRevista(menu, revistas, caixas);
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
                                Registrar(caixas, acharPosicao);
                                break;
                            case 2:
                                Mostrar(caixas);
                                Console.ReadKey();
                                break;
                            case 3:
                                Excluir(caixas,mensagen);
                                break;
                            case 4:
                                Editar(menu, caixas);
                                return;
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
                                Registrar(pessoas, acharPosicao);
                                break;
                            case 2:
                                Mostrar(pessoas);
                                Console.ReadKey();
                                break;
                            case 3:
                                Excluir(pessoas, mensagen);
                                break;
                            case 4:
                                Editar(menu, pessoas);
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
                                RegistraEmprestimos(revistas, pessoas, acharPosicao, emprestimos);
                                break;
                            case 2:
                                MostrarEmprestimosAbertos(emprestimos,true);
                                Console.ReadKey();
                                break;
                            case 3:
                                Excluir(emprestimos, mensagen);
                                break;
                            case 4:
                               Editar(menu, emprestimos);
                                break;
                            case 5:
                                MostrarEmprestimosAbertos(emprestimos, false);
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

        private static void MostrarEmprestimosAbertos(Emprestimo[] emprestimos,bool abertos)
        {
            if (abertos) {
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
                    TimeSpan diff = DateTime.Today - emprestimos[i].dataEmprestimo;
                    if (diff.Days > 30)
                        continue;
                    Console.WriteLine($"ID : {i}");
                    emprestimos[i].Mostrar();
                    Console.ReadKey();
                }
            }
        }

        private static void RegistraEmprestimos(Revista[] revistas, Pessoa[] pessoas, AcharPosicao acharPosicao, Emprestimo[] emprestimos)
        {
            int posicao = acharPosicao.AcharPosicaoParaOObjeto(emprestimos);
            emprestimos[posicao] = new Emprestimo();
            emprestimos[posicao].Registrar(revistas, pessoas);
        }

        private static void Editar(Menu menu, dynamic[] objeto)
        {
            Mostrar(objeto);
            int numeroEditar = menu.Editar(objeto);
            Console.Clear();
            objeto[numeroEditar].Editar();
        }

        private static void Registrar(dynamic[] objeto, AcharPosicao acharPosicao)
        {
            int posicao = acharPosicao.AcharPosicaoParaOObjeto(objeto);
           
                if (objeto is Caixa[])
                    objeto[posicao] = new Caixa();
            else if (objeto is Pessoa[])
                objeto[posicao] = new Pessoa();
            objeto[posicao].Registrar();
        }

        private static void EditarRevista(Menu menu, Revista[] revista, Caixa[] caixa)
        {
            Mostrar(revista);
            int numeroEditar = menu.Editar(revista);
            Console.Clear();
            revista[numeroEditar].EditarRevista(caixa);
        }

        private static void Excluir(dynamic[] objeto, Mensagen mensagen)
        {
            Mostrar(objeto);
            int posicaoExluir = mensagen.Excluir(objeto, "qual o ID que deseja excluir");
            if (objeto is Emprestimo[])
            {
                objeto[posicaoExluir].aberto = false;
                objeto[posicaoExluir].dataDevolucao = DateTime.Now;
                mensagen.Sucesso("fechado com sucesso");
            }
            else {
                objeto[posicaoExluir] = null;
                mensagen.Sucesso("removido com sucesso");
            }
            Console.ReadKey();
        }

        private static void RegistrarNovaRevista(Revista[] revista, Caixa[] caixa, AcharPosicao acharPosicao)
        {
            int posicao = acharPosicao.AcharPosicaoParaOObjeto(revista);
            revista[posicao] = new();
            revista[posicao].Registar(caixa);
        }

        private static void Mostrar(dynamic[] objeto)
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
