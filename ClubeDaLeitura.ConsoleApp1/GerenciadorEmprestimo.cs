﻿using System;

namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class GerenciadorEmprestimo
        {
            public Emprestimo[] emprestimos = new Emprestimo[100];
            Menu menu = new();
            private Mensagen mensagens = new();
            FuncoesCrude funcaoCrude = new();
            public void Registrar(GerenciadorPessoa gerenciadorPessoas, GerenciadorRevista gerenciadorRevista, Revista[] revistas, Pessoa[] amigos,int posicao)
            {
                emprestimos[posicao].houveErro = false;
                emprestimos[posicao].aberto = true;
                do
                {
                    Console.Clear();

                    if (emprestimos[posicao].houveErro == true)
                        mensagens.Erro("data invalida");
                    Console.WriteLine("data do emprestimo");
                    emprestimos[posicao].houveErro = true;
                } while (!(DateTime.TryParse(Console.ReadLine(), out emprestimos[posicao].dataEmprestimo)));
                Console.Clear();

                funcaoCrude.Mostrar(gerenciadorRevista,revistas);

                  emprestimos[posicao].houveErro = false;
                do
                {
                    if (emprestimos[posicao].houveErro == true)
                        mensagens.Erro("data invalida");
                    Console.WriteLine("qual revista deseja emprestar");
                    emprestimos[posicao].houveErro = true;
                } while (!(int.TryParse(Console.ReadLine(), out emprestimos[posicao].numeroRevista)) || revistas[emprestimos[posicao].numeroRevista] == null || revistas[emprestimos[posicao].numeroRevista].disponivel == false);
                 emprestimos[posicao].revista = revistas[emprestimos[posicao].numeroRevista];
                revistas[emprestimos[posicao].numeroRevista].disponivel = false;



                Console.Clear();

                funcaoCrude.Mostrar(gerenciadorPessoas, amigos);

                emprestimos[posicao].houveErro = false;
                do
                {
                    Console.WriteLine();
                    if (emprestimos[posicao].houveErro == true)
                        mensagens.Erro("pessoa ja tem emprestimo ou nao existe");
                    Console.WriteLine("qual pessoa quer emprestar");
                    emprestimos[posicao].houveErro = true;

                } while (!(int.TryParse(Console.ReadLine(), out emprestimos[posicao].numeroPessoa)) || amigos[emprestimos[posicao].numeroPessoa] == null || amigos[emprestimos[posicao].numeroPessoa].temEmprestimo == true);
                emprestimos[posicao].amigo = amigos[emprestimos[posicao].numeroPessoa];
                amigos[emprestimos[posicao].numeroPessoa].temEmprestimo = true;

                mensagens.Sucesso("registrado com sucesso");
            }

            public void Mostrar(int posicao)
            {
                Console.WriteLine($"Data de emprestimo = {emprestimos[posicao].dataEmprestimo}\n" +
                        $"revista numero de edicao = {emprestimos[posicao].revista.numeroEdicao}\n" +
                        $"nome do amigo = {emprestimos[posicao].amigo.nome}\n" +
                        $"emprestado ainda? = {emprestimos[posicao].aberto}\n");
                if (emprestimos[posicao].aberto == false)
                {
                    Console.WriteLine($"data devolução {emprestimos[posicao].dataDevolucao}");
                }
            }
            public void Editar(int posicao,Revista[] revistas, Pessoa[] amigos)
            {
                emprestimos[posicao].numeroEditar = menu.EditarOQue($"data do emprestimo = 1\n" +
                          $"revista = 2\n" +
                          $"pessoa = 3\n" +
                          $"data de Devolucao = 4\n" +
                          $"voltar = 5\n", 5);


                switch (emprestimos[posicao].numeroEditar)
                {
                    case 1:
                        emprestimos[posicao].houveErro = false;
                        do
                        {
                            if (emprestimos[posicao].houveErro)
                                mensagens.Erro("data invalida");
                            Console.WriteLine("data do emprestimo");
                            emprestimos[posicao].houveErro = true;
                        } while (!(DateTime.TryParse(Console.ReadLine(), out emprestimos[posicao].dataEmprestimo)));
                        break;
                    case 2:
                        for (int i = 0; i < revistas.Length; i++)
                        {
                            if (revistas[i] == null || revistas[i].disponivel == false)
                                continue;
                            Console.WriteLine($"revista Tipo colecao: {revistas[i].tipoColecao}, ano: {revistas[i].ano}, numero de edicao{revistas[i].numeroEdicao} = {i}");
                        }
                        emprestimos[posicao].houveErro = false;
                        do
                        {
                            if (emprestimos[posicao].houveErro)
                                mensagens.Erro("revista invalida");
                            Console.WriteLine("qual revista deseja emprestar");
                            emprestimos[posicao].houveErro = true;

                        } while (!(int.TryParse(Console.ReadLine(), out emprestimos[posicao].numeroRevista)) || revistas[emprestimos[posicao].numeroRevista] == null || revistas[emprestimos[posicao].numeroRevista].disponivel == false);
                        emprestimos[posicao].revista = revistas[emprestimos[posicao].numeroRevista];


                        break;
                    case 3:


                        for (int i = 0; i < amigos.Length; i++)
                        {
                            if (amigos[i] == null)
                                continue;
                            Console.WriteLine($"pessoa nome: {amigos[i].nome}, telefone: {amigos[i].telefone}, endereço{amigos[i].endereço} = {i}");
                        }
                        emprestimos[posicao].houveErro = false;
                        do
                        {
                            if (emprestimos[posicao].houveErro)
                                mensagens.Erro("pessoa invalida");
                            Console.WriteLine("qual pessoa quer emprestar");
                            emprestimos[posicao].houveErro = true;
                        } while (!(int.TryParse(Console.ReadLine(), out emprestimos[posicao].numeroPessoa)) || amigos[emprestimos[posicao].numeroPessoa] == null);
                        emprestimos[posicao].amigo = amigos[emprestimos[posicao].numeroPessoa];
                        break;
                    case 4:
                        emprestimos[posicao].houveErro = false;
                        do
                        {
                            if (emprestimos[posicao].houveErro)
                                mensagens.Erro("data invalida");
                            Console.WriteLine("data do Devolucao");
                            if (emprestimos[posicao].dataDevolucao == default)
                            {
                                mensagens.Erro("item nao devolvido");
                                break;
                            }
                            emprestimos[posicao].houveErro = true;
                        } while (!(DateTime.TryParse(Console.ReadLine(), out emprestimos[posicao].dataDevolucao)));
                        break;
                }
                mensagens.Sucesso("registrado com sucesso");
            }
        }
    }
}
