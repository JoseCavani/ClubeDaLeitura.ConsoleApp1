using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class GerenciadorRevista
        {
            public Revista[] revistas = new Revista[100];
            public Mensagen mensagens = new();
            public Menu menu = new();
            FuncoesCrude funcaoCrude = new();
            public void Registar(GerenciadorCaixa gerenciadorCaixa, int posicao,Caixa[] caixa)
            {
              
                revistas[posicao].disponivel = true;
                Console.WriteLine("tipo de colecao");
                revistas[posicao].tipoColecao = Console.ReadLine();
                Console.Clear();

                funcaoCrude.Mostrar(gerenciadorCaixa);

                   revistas[posicao].houveErro = false;
                do
                {
                    if (revistas[posicao].houveErro != false)
                        mensagens.Erro("caixa invalida ou nao existe");
                    Console.WriteLine("qual caixa deseja registrar para essa revista");
                    revistas[posicao].houveErro = true;

                } while (!(int.TryParse(Console.ReadLine(), out revistas[posicao].numeroCaixa)) || caixa[revistas[posicao].numeroCaixa] == null);
                revistas[posicao].caixaDaRevista = caixa[revistas[posicao].numeroCaixa];
                revistas[posicao].houveErro = false;
                do
                {
                    if (revistas[posicao].houveErro == true)
                        mensagens.Erro("ano invalido");
                    Console.WriteLine("ano");
                    revistas[posicao].houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out revistas[posicao].ano)));

                Console.WriteLine("numero de edicao");
                revistas[posicao].numeroEdicao = Console.ReadLine();
                mensagens.Sucesso("Revista registrado com sucesso");
            }

            public void Mostrar()
            {
              Console.ForegroundColor  = ConsoleColor.Green;
                Console.WriteLine("{0,0} | {1,0} | {2,0} | {3,0} | {4,0} |{5,0} ","ID".PadRight(3, ' '), "Numero de Edicao", "Ano".PadRight(16, ' '), "Tipo de coleção".PadRight(16, ' '), "numero da caixa".PadRight(16, ' '), "disponivel?");

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                for (int i = 0; i < revistas.Length; i++)
                {
                    if (revistas[i] == null)
                        continue;
                    Console.WriteLine("{0,0} | {1,0} | {2,0} | {3,0} | {4,0} |{5,0} ", i.ToString().PadRight(3,' ') ,revistas[i].numeroEdicao.PadRight(16, ' '), revistas[i].ano.ToString().PadRight(16, ' '), revistas[i].tipoColecao.PadRight(16, ' '), revistas[i].caixaDaRevista.numero.ToString().PadRight(16, ' '), revistas[i].disponivel);
                    Console.WriteLine();
                }

               
            }
            public void EditarRevista(Caixa[] caixa,int numeroEditar)
            {

                revistas[numeroEditar].numeroEditar = menu.EditarOQue($"Numero de edição = 1\n" +
                          $"ano = 2\n" +
                          $"tipo de coleção = 3\n" +
                          $"caixa da revista = 4\n" +
                          $"voltar = 5\n", 5);


                switch (revistas[numeroEditar].numeroEditar)
                {
                    case 1:
                        Console.WriteLine("numero de edicao");
                        revistas[numeroEditar].numeroEdicao = Console.ReadLine();
                        break;
                    case 2:
                        revistas[numeroEditar].houveErro = false;
                        do
                        {
                            if (revistas[numeroEditar].houveErro)
                                mensagens.Erro("ano invalido");
                            Console.WriteLine("ano");
                            revistas[numeroEditar].houveErro = true;
                        } while (!(int.TryParse(Console.ReadLine(), out revistas[numeroEditar].ano)));
                        break;
                    case 3:
                        Console.WriteLine("tipo de colecao");
                        revistas[numeroEditar].tipoColecao = Console.ReadLine();
                        break;
                    case 4:
                        for (int i = 0; i < caixa.Length; i++)
                        {
                            if (caixa[i] == null)
                                continue;
                            Console.WriteLine($"caixa {caixa[i].numero}, {caixa[i].cor},{caixa[i].etiqueta} = {i}");
                        }
                        revistas[numeroEditar].houveErro = false;
                        do
                        {
                            if (revistas[numeroEditar].houveErro)
                                mensagens.Erro("caixa invalida");
                            Console.WriteLine("qual caixa deseja registrar para essa revista");
                            revistas[numeroEditar].houveErro = true;
                        } while (!(int.TryParse(Console.ReadLine(), out revistas[numeroEditar].numeroCaixa)) || caixa[revistas[numeroEditar].numeroCaixa] == null);
                        revistas[numeroEditar].caixaDaRevista = caixa[revistas[numeroEditar].numeroCaixa];
                        break;
                    case 5:
                        return;
                }
                mensagens.Sucesso("Revista editado com sucesso");
            }
        }
    }
}
