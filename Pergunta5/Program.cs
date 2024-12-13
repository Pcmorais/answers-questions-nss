using System;

public class BoletoRecálculo
{
    static void Main(string[] args)
    {
        // Dados de entrada
        DateTime[] datasVencimentoOriginal =
        {
            new DateTime(2023, 5, 6),   // Exemplo: 06/05/2023
            new DateTime(2023, 5, 7),   // Exemplo: 07/05/2023
            new DateTime(2023, 5, 1),   // Exemplo: 01/05/2023
            new DateTime(2023, 4, 21),  // Exemplo: 21/04/2023
            new DateTime(2023, 4, 7),   // Exemplo: 07/04/2023
            new DateTime(2023, 5, 10),  // Exemplo: 10/05/2023
            new DateTime(2023, 5, 11),  // Exemplo: 11/05/2023
            new DateTime(2023, 5, 8)    // Exemplo: 08/05/2023
        };

        DateTime[] datasVencimentoNova =
        {
            new DateTime(2023, 5, 8),   // Exemplo: 08/05/2023
            new DateTime(2023, 5, 9),   // Exemplo: 09/05/2023
            new DateTime(2023, 5, 2),   // Exemplo: 02/05/2023
            new DateTime(2023, 4, 24),  // Exemplo: 24/04/2023
            new DateTime(2023, 4, 11),  // Exemplo: 11/04/2023
            new DateTime(2023, 5, 10),  // Exemplo: 10/05/2023
            new DateTime(2023, 5, 10),  // Exemplo: 10/05/2023
            new DateTime(2023, 5, 9)    // Exemplo: 09/05/2023
        };

        double valorBoletoOriginal = 100.00;
        double valorJurosPorDia = 0.03;  // Juros por dia
        double valorMulta = 2.00;        // Multa fixa

        for (int i = 0; i < datasVencimentoOriginal.Length; i++)
        {
            DateTime vencimentoOriginal = datasVencimentoOriginal[i];
            DateTime vencimentoNova = datasVencimentoNova[i];

            double jurosTotal = 0.0;
            double valorBoletoRecalculado = valorBoletoOriginal;
            bool aplicarMulta = false;

            // Verifica se houve atraso
            if (vencimentoNova > vencimentoOriginal)
            {
                int diasDeAtraso = (vencimentoNova - vencimentoOriginal).Days;

                // Aplica juros, se houver atraso
                jurosTotal = diasDeAtraso * valorJurosPorDia;
                valorBoletoRecalculado = valorBoletoOriginal + jurosTotal;

                // Aplica multa, conforme a tabela
                aplicarMulta = true;
            }

            // Ajusta o valor total de juros e multa
            if (aplicarMulta)
            {
                valorBoletoRecalculado += valorMulta;
            }

            // Exibir os resultados de acordo com o esperado
            Console.WriteLine($"Regra {i + 1}:");
            Console.WriteLine($"Data Vencimento Original: {vencimentoOriginal.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Data Vencimento Nova: {vencimentoNova.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Valor Boleto Original: R$ {valorBoletoOriginal:F2}");
            Console.WriteLine($"Valor Boleto Recalculado: R$ {valorBoletoRecalculado:F2}");
            Console.WriteLine($"Valor Total Juros: R$ {jurosTotal:F2}");
            Console.WriteLine($"Valor Total Multa: R$ {(aplicarMulta ? valorMulta : 0.00):F2}");
            Console.WriteLine();
        }
    }
}
