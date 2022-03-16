using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class Revista
        {
            public bool disponivel;
            public int numeroCaixa, numeroEditar, ano;
            public string tipoColecao, numeroEdicao;
            public Caixa caixaDaRevista;
            public Mensagen mensagens = new();
            public Menu menu = new();
            bool houveErro = false;

            public void Registar(Caixa[] caixa)
            {
                disponivel = true;
                Console.WriteLine("tipo de colecao");
                tipoColecao = Console.ReadLine();
                Console.Clear();
                for (int i = 0; i < caixa.Length; i++)
                {
                    if (caixa[i] == null)
                        continue;
                    Console.WriteLine($"ID : {i}");
                    caixa[i].Mostrar();
                    Console.WriteLine();
                }
                houveErro = false;
                do
                {
                    if (houveErro != false)
                        mensagens.Erro("caixa invalida ou nao existe");
                    Console.WriteLine("qual caixa deseja registrar para essa revista");
                    houveErro = true;

                } while (!(int.TryParse(Console.ReadLine(), out numeroCaixa)) || caixa[numeroCaixa] == null);
                caixaDaRevista = caixa[numeroCaixa];
                houveErro = false;
                do
                {
                    if (houveErro == true)
                        mensagens.Erro("ano invalido");
                    Console.WriteLine("ano");
                    houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out ano)));

                Console.WriteLine("numero de edicao");
                numeroEdicao = Console.ReadLine();
                mensagens.Sucesso("Revista registrado com sucesso");
            }

            public void Mostrar()
            {
                Console.WriteLine($"Numero de edição = {numeroEdicao}\n" +
                    $"ano = {ano}\n" +
                    $"tipo de coleção = {tipoColecao}\n" +
                    $"caixa da revista = {caixaDaRevista.numero}\n" +
                    $"disponivel? = {disponivel}\n");
            }
            public void EditarRevista(Caixa[] caixa)
            {

                numeroEditar = menu.EditarOQue($"Numero de edição = 1\n" +
                          $"ano = 2\n" +
                          $"tipo de coleção = 3\n" +
                          $"caixa da revista = 4\n" +
                          $"voltar = 5\n", 5);


                switch (numeroEditar)
                {
                    case 1:
                        Console.WriteLine("numero de edicao");
                        numeroEdicao = Console.ReadLine();
                        break;
                    case 2:
                        houveErro = false;
                        do
                        {
                            if (houveErro)
                                mensagens.Erro("ano invalido");
                            Console.WriteLine("ano");
                            houveErro = true;
                        } while (!(int.TryParse(Console.ReadLine(), out ano)));
                        break;
                    case 3:
                        Console.WriteLine("tipo de colecao");
                        tipoColecao = Console.ReadLine();
                        break;
                    case 4:
                        for (int i = 0; i < caixa.Length; i++)
                        {
                            if (caixa[i] == null)
                                continue;
                            Console.WriteLine($"caixa {caixa[i].numero}, {caixa[i].cor},{caixa[i].etiqueta} = {i}");
                        }
                        houveErro = false;
                        do
                        {
                            if (houveErro)
                                mensagens.Erro("caixa invalida");
                            Console.WriteLine("qual caixa deseja registrar para essa revista");
                            houveErro = true;
                        } while (!(int.TryParse(Console.ReadLine(), out numeroCaixa)) || caixa[numeroCaixa] == null);
                        caixaDaRevista = caixa[numeroCaixa];
                        break;
                    case 5:
                        return;
                }
                mensagens.Sucesso("Revista editado com sucesso");
            }

        }
    }
}
