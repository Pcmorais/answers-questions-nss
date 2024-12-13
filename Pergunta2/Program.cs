namespace Pergunta2
{
    internal class Program
    {
        static void Main()
        {
            int codigoAluno;
            decimal nota1, nota2, nota3, media;

            while (true)
            {
                Console.Write("Informe o código do aluno (0 para encerrar): ");
                codigoAluno = int.Parse(Console.ReadLine());

                if (codigoAluno == 0)
                {
                    break;
                }

                Console.Write("Informe a primeira nota: ");
                nota1 = decimal.Parse(Console.ReadLine());

                Console.Write("Informe a segunda nota: ");
                nota2 = decimal.Parse(Console.ReadLine());

                Console.Write("Informe a terceira nota: ");
                nota3 = decimal.Parse(Console.ReadLine());

                decimal maiorNota = Math.Max(nota1, Math.Max(nota2, nota3));
                decimal somaNotas = nota1 + nota2 + nota3;
                media = (maiorNota * 4 + (somaNotas - maiorNota) * 3) / 10; 

                Console.WriteLine($"Código do aluno: {codigoAluno}");
                Console.WriteLine($"Notas: {nota1}, {nota2}, {nota3}");
                Console.WriteLine($"Média ponderada: {media:F2}");

                if (media >= 6)
                {
                    Console.WriteLine("Status: APROVADO");
                }
                else
                {
                    Console.WriteLine("Status: REPROVADO");
                }

                Console.WriteLine();
            }
        }
    }
}
