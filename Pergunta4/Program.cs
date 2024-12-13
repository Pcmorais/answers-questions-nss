using System;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Informe a data de vencimento original (dd/mm/aaaa): ");
        DateTime dataVencimento = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Informe a data de pagamento (dd/mm/aaaa): ");
        DateTime dataPagamento = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Informe o valor do boleto: ");
        double valorBoleto = double.Parse(Console.ReadLine());

        double multa = 2.00;
        double jurosPorDia = 0.03;

        double valorTotal = valorBoleto;
        int numDias = 0;
        double juros = 0;

        if (dataPagamento < dataVencimento)
        {
            Console.WriteLine("Não será cobrado juros nem multa. Valor a pagar: R$ " + valorBoleto.ToString("F2"));
            return;
        }

        if (VerificaFinalDeSemana(dataVencimento) || VerificaFeriado(dataVencimento))
        {
            DateTime proximoDiaUtil = ProximoDiaUtil(dataVencimento);
            if (dataPagamento == proximoDiaUtil)
            {
                Console.WriteLine("Não será cobrado juros nem multa. Valor a pagar: R$ " + valorBoleto.ToString("F2"));
                return;
            }
            else
            {
                numDias = (dataPagamento - proximoDiaUtil).Days;
                juros = numDias * jurosPorDia;
                valorTotal = valorBoleto + juros + multa;
            }
        }
        else
        {
            if (dataPagamento == dataVencimento)
            {
                Console.WriteLine("Não será cobrado juros nem multa. Valor a pagar: R$ " + valorBoleto.ToString("F2"));
                return;
            }
            else if (dataPagamento == dataVencimento.AddDays(1))
            {
                juros = jurosPorDia;
                valorTotal = valorBoleto + juros + multa;
            }
            else
            {
                numDias = (dataPagamento - dataVencimento).Days;
                juros = numDias * jurosPorDia;
                valorTotal = valorBoleto + juros + multa;
            }
        }

        Console.WriteLine($"Valor do boleto recalculado: R$ {valorTotal:F2} (Juros: R$ {juros:F2}, Multa: R$ {multa:F2})");
    }

    static bool VerificaFinalDeSemana(DateTime data)
    {
        return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
    }

    static bool VerificaFeriado(DateTime data)
    {
        return (data.Month == 5 && data.Day == 1) || (data.Month == 04 && data.Day == 21);
    }

    static DateTime ProximoDiaUtil(DateTime data)
    {
        DateTime proximoDia = data.AddDays(1);
        while (VerificaFinalDeSemana(proximoDia) || VerificaFeriado(proximoDia))
        {
            proximoDia = proximoDia.AddDays(1);
        }
        return proximoDia;
    }
}
