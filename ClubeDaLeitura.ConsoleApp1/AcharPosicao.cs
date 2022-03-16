namespace ClubeDaLeitura.ConsoleApp1
{
    internal partial class Program
    {
        public class AcharPosicao
        {
            public int AcharPosicaoNulo(dynamic array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != null)
                        continue;
                    return i;
                }
                return 0;
            }
        }
    }
}
