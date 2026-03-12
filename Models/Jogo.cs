namespace slot_machine.Models;

public class Jogo
{
    private float credito = 0;

    private Simbolo[,] grade = new Simbolo[3, 3];

    private Random random = new Random();

    public void Jogar()
    {
        Console.WriteLine("---- Maia Níquel ----");

        bool menuJogo = true;
        while (menuJogo)
        {
            Console.WriteLine($"Seu saldo: {credito} \n");
            Console.WriteLine("Se quiser parar de jogar digite '0'");
            Console.WriteLine("Quanto você quer jogar nessa rodada? Mínimo de 0.5: ");
            float creditoJogo = Convert.ToSingle(Console.ReadLine());
            Console.Clear();
            if (creditoJogo == 0)
            {
                menuJogo = false;
                Console.WriteLine("Saindo do jogo...");
                break;
            }
            else if (creditoJogo >= 0.5 && creditoJogo <= credito)
            {
                credito -= creditoJogo;
                Console.WriteLine("---- Maia Níquel ----");
                Thread.Sleep(1000);
                Console.WriteLine($"Rodada de {creditoJogo} cŕeditos");
                Thread.Sleep(1000);
                Console.WriteLine("Girando...");
                Thread.Sleep(1000);
                Grade();

                var greens = VerificarGreens();

                if (greens.Count > 0)
                {
                    float premioTotal = 0;

                    foreach (var simbolo in greens)
                    {
                        float premio = creditoJogo * simbolo.Multiplicador;
                        premioTotal += premio;
                        Thread.Sleep(1000);
                        Console.WriteLine($"\nGreen de {simbolo.Emoji}! x{simbolo.Multiplicador}");
                    }

                    credito += premioTotal;
                    Thread.Sleep(1000);
                    Console.WriteLine($"\nVocê ganhou {premioTotal} créditos!");
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("\nNenhum green 😢");
                }
            }
        }
    }


    public void CarregarCreditos()
    {
        Console.WriteLine($"Você possui {credito} créditos\nDigite quantos reais você quer depositar (Digite '0' para voltar): ");
        credito += Convert.ToSingle(Console.ReadLine());
    }

    public void Regras()
    {
        Console.Clear();

        Console.WriteLine("---- REGRAS DO MAIA NÍQUEL ----\n");

        Console.WriteLine("Objetivo:");
        Console.WriteLine("Alinhar 3 símbolos iguais para ganhar créditos.\n");

        Console.WriteLine("Símbolos e multiplicadores:");

        foreach (var simbolo in Simbolo.Simbolos)
        {
            Console.WriteLine($"{simbolo.Emoji}  x{simbolo.Multiplicador}");
        }

        Console.WriteLine("\nLinhas vencedoras:");
        Console.WriteLine("• Horizontais");
        Console.WriteLine("• Verticais");
        Console.WriteLine("• Diagonais");

        Console.WriteLine("\nRegras de aposta:");
        Console.WriteLine("• Aposta mínima: 0.5 créditos");
        Console.WriteLine("• Prêmio = aposta X multiplicador");

        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    public void Estatisticas()
    {

    }


    public void Grade()
    {
        // Cria e sorteia a grade
        for (int linha = 0; linha < 3; linha++)
        {
            for (int coluna = 0; coluna < 3; coluna++)
            {
                grade[linha, coluna] = Sortear();
            }
        }
        // Escreve a grade        
        for (int linha = 0; linha < 3; linha++)
        {
            for (int coluna = 0; coluna < 3; coluna++)
            {
                Console.Write(grade[linha, coluna].Emoji + " | ");
            }

            Console.WriteLine();
        }
    }


    private Simbolo Sortear()
    {
        int total = Simbolo.Simbolos.Sum(s => s.Probabilidade);

        int numero = random.Next(total);

        int acumulado = 0;

        foreach (var simbolo in Simbolo.Simbolos)
        {
            acumulado += simbolo.Probabilidade;

            if (numero < acumulado)
                return simbolo;
        }

        throw new Exception("Erro ao sortear símbolo");
    }

    private List<Simbolo> VerificarGreens()
    {
        List<Simbolo> greens = new();

        // Verifica linhas
        for (int linha = 0; linha < 3; linha++)
        {
            if (grade[linha, 0].Emoji == grade[linha, 1].Emoji &&
                grade[linha, 1].Emoji == grade[linha, 2].Emoji)
            {
                greens.Add(grade[linha, 0]);
            }
        }

        //Verifica colunas
        for (int coluna = 0; coluna < 3; coluna++)
        {
            if (grade[0, coluna].Emoji == grade[1, coluna].Emoji &&
                grade[1, coluna].Emoji == grade[2, coluna].Emoji)
            {
                greens.Add(grade[0, coluna]);
            }
        }

        //Verifica diagonal descendo
        if (grade[0, 0].Emoji == grade[1, 1].Emoji &&
            grade[1, 1].Emoji == grade[2, 2].Emoji)
        {
            greens.Add(grade[0, 0]);
        }

        // Verifica diagonal subindo
        if (grade[0, 2].Emoji == grade[1, 1].Emoji &&
            grade[1, 1].Emoji == grade[2, 0].Emoji)
        {
            greens.Add(grade[0, 2]);
        }

        return greens;
    }
}

