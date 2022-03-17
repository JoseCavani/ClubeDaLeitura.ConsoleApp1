namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class Revista
        {
            public bool disponivel;
            public int numeroCaixa, numeroEditar,numeroCategoria, ano;
            public string tipoColecao, numeroEdicao;
            public Caixa caixaDaRevista;
            public bool houveErro = false;
            public Categoria categoria;

        }
    }
}
