namespace slot_machine.Models;

public class Jogo
{
    private float credito = 0;
    private Dictionary<string, int> simbolos = new Dictionary<string, int>()
{
    // Cada um tendo uma probabilidade de cair
    {"🍒", 40},
    {"🍋", 30},
    {"🍊", 20},
    {"⭐", 8},
    {"7️⃣ ", 2} //Dei esse espaço pq esse emoji "come" um espaço da direita e deixa a grade torta
};

    private List<string> linha1 = new List<string>();
    private List<string> linha2 = new List<string>();
    private List<string> linha3 = new List<string>();

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

            if (creditoJogo >= 0.5)
            {
                Console.WriteLine("---- Maia Níquel ----");
                Console.WriteLine("Girando...");
                Grade();


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
            Console.Write(item + " | ");
        Console.WriteLine();

        foreach (var item in linha2)
            Console.Write(item + " | ");
        Console.WriteLine();

        foreach (var item in linha3)
            Console.Write(item + " | ");
        Console.WriteLine();
    }


    private string Sortear()
    {
        int totalProb = simbolos.Values.Sum(); //Soma das probabilidades (100)

        int numero = random.Next(totalProb); // "Escolhe" um emoji (com base na probabilidade) 

        int intervalo = 0;

        foreach (var simbolo in simbolos)
        {
            intervalo += simbolo.Value; // Verifica qual símbolo aquele número pertence

            if (numero < intervalo)
                return simbolo.Key; // "Key" referencia o emoji escolhido no símbolo
        }

        throw new Exception("Erro ao sortear símbolo");
    }

    private bool Green()
    {
        if (linha1[0] == linha1[1] && linha1[1] == linha1[2])
            return true;

        if (linha2[0] == linha2[1] && linha2[1] == linha2[2])
            return true;

        if (linha3[0] == linha3[1] && linha3[1] == linha3[2])
            return true;

        return false;
    }
}

