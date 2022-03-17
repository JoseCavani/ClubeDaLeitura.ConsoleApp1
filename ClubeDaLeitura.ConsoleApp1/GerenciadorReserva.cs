using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class GerenciadorReserva
        {
            public Reserva[] reserva = new Reserva[100];
            private Mensagen mensagens = new();
            private Menu menu = new Menu();

            public void Registrar(int posicao, GerenciadorPessoa gerenciadorPessoa, GerenciadorRevista gerenciadorRevista)
            {
                FuncoesCrude funcaoCrude = new();
                int numeroPosicao;
                bool houveErro;
                reserva[posicao] = new Reserva();
                TimeSpan dias;

                houveErro = false;
                do {
                    if (houveErro == true)
                        mensagens.Erro("dias maior que maximo permitdo pela categoria");
                    do
                    {
                        Console.Clear();
                        if (houveErro == true)
                            mensagens.Erro("data invalida");
                        Console.WriteLine("data do emprestimo");
                        houveErro = true;
                    } while (!(DateTime.TryParse(Console.ReadLine(), out reserva[posicao].dataReserva)));
                     dias = DateTime.Today - reserva[posicao].dataReserva;
                    houveErro = true;
                } while (dias.Days > reserva[posicao].revista.categoria.diasEmprestimo);
                Console.Clear();



                funcaoCrude.Mostrar(gerenciadorRevista);

                houveErro = false;
               

                do
                {
                    if (houveErro == true)
                        mensagens.Erro("revista invalida");
                    Console.WriteLine("qual revista deseja reservar");
                    houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out numeroPosicao)) || gerenciadorRevista.revistas[numeroPosicao] == null || gerenciadorRevista.revistas[numeroPosicao].disponivel == false);

                reserva[posicao].revista = gerenciadorRevista.revistas[numeroPosicao];

                gerenciadorRevista.revistas[numeroPosicao].disponivel = false;

                funcaoCrude.Mostrar(gerenciadorPessoa);

                houveErro = false;
                do
                {
                    if (houveErro == true)
                        mensagens.Erro("revista invalida");
                    Console.WriteLine("qual revista deseja reservar");
                    houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out numeroPosicao)) || gerenciadorPessoa.pessoas[numeroPosicao] == null || gerenciadorPessoa.pessoas[numeroPosicao].temEmprestimo == true);
                reserva[posicao].amigo = gerenciadorPessoa.pessoas[numeroPosicao];
                gerenciadorPessoa.pessoas[numeroPosicao].temEmprestimo = true;

               

                mensagens.Sucesso("registrado com sucesso");
            }

            public void Mostrar()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,0} | {1,0} | {2,0} | {3,0} ", "ID".PadRight(3, ' '), "nome do amigo".PadRight(20, ' '), "Revista numero edicao".PadRight(20, ' '), "data de reserva".PadRight(20, ' '));

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();

                for (int i = 0; i < reserva.Length; i++)
                {
                    if (reserva[i] == null)
                        continue;
                    TimeSpan dias = DateTime.Today - reserva[i].dataReserva;
                    if (dias.Days > 2)
                    {
                        reserva[i] = default;
                        continue;
                    }
                    Console.WriteLine("{0,0} | {1,0} | {2,0} | {3,0} ", i.ToString().PadRight(3, ' '), reserva[i].amigo.nome.PadRight(20, ' '), reserva[i].revista.numeroEdicao.PadRight(20, ' '), reserva[i].dataReserva.ToShortDateString());
                    Console.WriteLine();
                }

                Console.ResetColor();
                Console.ReadKey();
            }

            public void Editar(GerenciadorPessoa gerenciadorPessoa, GerenciadorRevista gerenciadorRevista, int posicao)
            {
                bool houveErro;
                int numeroRevista, numeroPessoa;
                reserva[posicao].numeroEditar = menu.EditarOQue($"data = 1\n" +
                                $"revista = 2\n" +
                                $"amigo = 3\n" +
                                $"voltar = 4\n", 4);

                switch (reserva[posicao].numeroEditar)
                {
                    case 1:
                        houveErro = false;
                        do
                        {
                            if (houveErro)
                                mensagens.Erro("data invalida");
                            Console.WriteLine("data do emprestimo");
                            houveErro = true;
                        } while (!(DateTime.TryParse(Console.ReadLine(), out reserva[posicao].dataReserva)));
                        break;
                    case 2:
                        gerenciadorRevista.Mostrar();

                        foreach (var item in gerenciadorRevista.revistas)
                        {
                            if (item == null)
                                continue;
                            if (item.numeroEdicao == reserva[posicao].revista.numeroEdicao)
                            {
                                item.disponivel = true;
                                break;
                            }
                        }


                        houveErro = false;
                        do
                        {
                            if (houveErro)
                                mensagens.Erro("revista invalida");
                            Console.WriteLine("qual revista deseja emprestar");
                            houveErro = true;

                        } while (!(int.TryParse(Console.ReadLine(), out numeroRevista)) || gerenciadorRevista.revistas[numeroRevista] == null || gerenciadorRevista.revistas[numeroRevista].disponivel == false);
                        reserva[posicao].revista = gerenciadorRevista.revistas[numeroRevista];
                        gerenciadorRevista.revistas[numeroRevista].disponivel = false;
                        break;
                    case 3:

                        gerenciadorPessoa.Mostrar();

                        foreach (var item in gerenciadorPessoa.pessoas)
                        {
                            if (item == null)
                                continue;
                            if (item.nome == reserva[posicao].amigo.nome)
                            {
                                item.temEmprestimo = false;
                                break;
                            }
                        }


                        houveErro = false;
                        do
                        {
                            if (houveErro)
                                mensagens.Erro("pessoa invalida");
                            Console.WriteLine("qual pessoa quer emprestar");
                            houveErro = true;
                        } while (!(int.TryParse(Console.ReadLine(), out numeroPessoa)) || gerenciadorPessoa.pessoas[numeroPessoa] == null || gerenciadorPessoa.pessoas[numeroPessoa].temEmprestimo == true);
                        reserva[posicao].amigo = gerenciadorPessoa.pessoas[numeroPessoa];
                        gerenciadorPessoa.pessoas[numeroPessoa].temEmprestimo = true;
                        break;
                    case 4:
                        return;
                }
                mensagens.Sucesso("registrado com sucesso");
            }

        }
    }
}


