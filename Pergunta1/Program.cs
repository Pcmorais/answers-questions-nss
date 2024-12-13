namespace Pergunta1
{
    internal class Program
    {
        static void Main()
        {
            int anoCarro, totalCarrosAte2000 = 0, totalCarros = 0;
            decimal precoCarro, desconto, valorAPagar;
            string continuar;

            do
            {
                Console.Write("Informe o ano do carro: ");
                anoCarro = int.Parse(Console.ReadLine());

                Console.Write("Informe o preço do carro: R$ ");
                precoCarro = decimal.Parse(Console.ReadLine());

                if (anoCarro <= 2000)
                {
                    desconto = precoCarro * 0.12m; 
                    totalCarrosAte2000++;
                }
                else
                {
                    desconto = precoCarro * 0.07m; 
                }

                valorAPagar = precoCarro - desconto;

                Console.WriteLine($"Desconto: R$ {desconto:F2}");
                Console.WriteLine($"Valor a pagar: R$ {valorAPagar:F2}");

                totalCarros++;

                Console.Write("Deseja continuar calculando (S/N)? ");
                continuar = Console.ReadLine().ToUpper();

            } while (continuar == "S");

            // Exibir totais
            Console.WriteLine($"\nTotal de carros com ano até 2000: {totalCarrosAte2000}");
            Console.WriteLine($"Total geral de carros: {totalCarros}");
        }
    }
}
