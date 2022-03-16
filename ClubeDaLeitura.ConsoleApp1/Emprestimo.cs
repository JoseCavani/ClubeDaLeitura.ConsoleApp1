using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class Emprestimo
        {
          public  DateTime dataEmprestimo,dataDevolucao;
           public bool aberto;
            public Revista revista;
            public Pessoa amigo;
            int numeroRevista, numeroPessoa, numeroEditar;
            private Mensagen mensagen = new();
            bool houveErro = false;

            public void Registrar(Revista[] revistas,Pessoa[] amigos)
            {
                houveErro = false;
                aberto = true;
                do
                {
                    Console.Clear();

                    if (houveErro == true)
                        mensagen.Erro("data invalida");
                    Console.WriteLine("data do emprestimo");
                    houveErro = true;
                } while (!(DateTime.TryParse(Console.ReadLine(), out  dataEmprestimo)));
                Console.Clear();
                for (int i = 0; i < revistas.Length; i++)
                {
                    if (revistas[i] == null || revistas[i].disponivel == false)
                        continue;
                    Console.WriteLine($"ID : {i}");
                    revistas[i].Mostrar();
                }
                houveErro = false;
                do
                {
                    if (houveErro == true)
                        mensagen.Erro("data invalida");
                    Console.WriteLine("qual revista deseja emprestar");
                    houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out numeroRevista)) || revistas[    numeroRevista] == null|| revistas[numeroRevista].disponivel == false);
                revista = revistas[numeroRevista];
                revistas[numeroRevista].disponivel = false;



                Console.Clear();
                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] == null)
                        continue;
                    Console.WriteLine($"ID : {i}");
                    amigos[i].Mostrar();
                }
                houveErro = false;
                do
                {
                    Console.WriteLine();
                    if (houveErro == true)
                        mensagen.Erro("pessoa ja tem emprestimo ou nao existe");
                    Console.WriteLine("qual pessoa quer emprestar");
                    houveErro = true;

                } while (!(int.TryParse(Console.ReadLine(), out numeroPessoa)) || amigos[numeroPessoa] == null || amigos[numeroPessoa].temEmprestimo == true);
                amigo = amigos[numeroPessoa];
                amigos[numeroPessoa].temEmprestimo = true;

                mensagen.Sucesso("registrado com sucesso");
            }

            public void Mostrar()
            {
                Console.WriteLine($"Data de emprestimo = {dataEmprestimo}\n" +
                        $"revista numero de edicao = {revista.numeroEdicao}\n" +
                        $"nome do amigo = {amigo.nome}\n" +
                        $"emprestado ainda? = {aberto}\n");
                if (aberto == false)
                {
                    Console.WriteLine($"data devolução {dataDevolucao}");
                }
            }
            public void Editar(Revista[] revistas, Pessoa[] amigos)
            {
                do
                {
                    Console.WriteLine($"data do emprestimo = 1\n" +
                              $"revista = 2\n" +
                              $"pessoa = 3\n" +
                              $"data de emprestimo = 4");
                } while (!(int.TryParse(Console.ReadLine(), out numeroEditar)) || numeroEditar > 3 || numeroEditar < 0);
                switch (numeroEditar)
                {
                    case 1:
                    do
                {
                    Console.Clear();
                    Console.WriteLine("data do emprestimo");
                } while (!(DateTime.TryParse(Console.ReadLine(), out dataEmprestimo)));
                        break;
                    case 2:
                for (int i = 0; i < revistas.Length; i++)
                {
                    if (revistas[i] == null || revistas[i].disponivel == false)
                        continue;
                    Console.WriteLine($"revista Tipo colecao: {revistas[i].tipoColecao}, ano: {revistas[i].ano}, numero de edicao{revistas[i].numeroEdicao} = {i}");
                }
                do
                {
                    Console.WriteLine("qual revista deseja emprestar");

                } while (!(int.TryParse(Console.ReadLine(), out numeroRevista)) || revistas[numeroRevista] == null || revistas[numeroRevista].disponivel == false);
                revista = revistas[numeroRevista];


                        break;
                    case 3:


                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] == null)
                        continue;
                    Console.WriteLine($"pessoa nome: {amigos[i].nome}, telefone: {amigos[i].telefone}, endereço{amigos[i].endereço} = {i}");
                }
                do
                {
                    Console.WriteLine("qual pessoa quer emprestar");

                } while (!(int.TryParse(Console.ReadLine(), out numeroPessoa)) || amigos[numeroPessoa] == null);
                amigo = amigos[numeroPessoa];
                        break;
                    case 4:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("data do emprestimo");
                        } while (!(DateTime.TryParse(Console.ReadLine(), out dataEmprestimo)));
                        break;
                }


            mensagen.Sucesso("registrado com sucesso");
            }

        }
    }
}
