namespace slot_machine.Models;

public class Jogo
{
    private float credito = 0;

    private List<Simbolo> linha1 = new List<Simbolo>();
    private List<Simbolo> linha2 = new List<Simbolo>();
    private List<Simbolo> linha3 = new List<Simbolo>();

    private Random random = new Random();

    public void Jogar()
    {
        Console.WriteLine("---- Maia Níquel ----");

        bool menuJogo = true;
        while (menuJogo)
        {
            Console.WriteLine($"Seu saldo: {credito} \n");
            Console.WriteLine("Quanto você quer jogar nessa rodada? Mínimo de 0.5: ");
            float creditoJogo = Convert.ToSingle(Console.ReadLine());

            if (creditoJogo >= 0.5 && creditoJogo <= credito)
            {
                credito -= creditoJogo;
                Console.WriteLine("---- Maia Níquel ----");
                Console.WriteLine("Girando...");
                Grade();

                if (Green())
                {
                    
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

    }

    public void Estatisticas()
    {

    }


    public void Grade()
    {
        linha1.Clear();
        linha2.Clear();
        linha3.Clear();

        for (int i = 0; i < 3; i++)
        {
            linha1.Add(Sortear());
            linha2.Add(Sortear());
            linha3.Add(Sortear());
        }

        foreach (var item in linha1)
            Console.Write(item.Emoji + " | ");
        Console.WriteLine();

        foreach (var item in linha2)
            Console.Write(item.Emoji + " | ");
        Console.WriteLine();

        foreach (var item in linha3)
            Console.Write(item.Emoji + " | ");
        Console.WriteLine();
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

    private bool Green()
    {
        if (linha1[0].Emoji == linha1[1].Emoji && linha1[1].Emoji == linha1[2].Emoji)
            return true;

        if (linha2[0].Emoji == linha2[1].Emoji && linha2[1].Emoji == linha2[2].Emoji)
            return true;

        if (linha3[0].Emoji == linha3[1].Emoji && linha3[1].Emoji == linha3[2].Emoji)
            return true;

        return false;
    }
}

