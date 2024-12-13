namespace Pergunta3
{
    internal class Program
    {
        static void Main()
        {
            // Teste A) a = 1, b = 2, c = 3
            TesteTriangulo(1, 2, 3);

            // Teste B) a = 3, b = 4, c = 5
            TesteTriangulo(3, 4, 5);

            // Teste C) a = 2, b = 2, c = 4
            TesteTriangulo(2, 2, 4);

            // Teste D) a = 4, b = 4, c = 4
            TesteTriangulo(4, 4, 4);

            // Teste E) a = 5, b = 3, c = 3
            TesteTriangulo(5, 3, 3);
        }

        static void TesteTriangulo(int a, int b, int c)
        {
            string mens;

            // Verificar se é possível formar um triângulo
            if (a < b + c && b < a + c && c < a + b)
            {
                if (a == b && b == c)
                {
                    mens = "Triângulo Equilátero";
                }
                else if (a == b || b == c || a == c)
                {
                    mens = "Triângulo Isósceles";
                }
                else
                {
                    mens = "Triângulo Escaleno";
                }
            }
            else
            {
                mens = "Não é possível formar um triângulo";
            }

            // Exibir o resultado
            Console.WriteLine($"Valores: a = {a}, b = {b}, c = {c}");
            Console.WriteLine(mens);
            Console.WriteLine();
        }
    }
}
