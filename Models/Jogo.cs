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
    {"7️⃣", 2}
};

    private Random random = new Random();

    public void Jogar()
    {
        Console.WriteLine("---- Maia Níquel ----");

        bool menuJogo = true;
        while (menuJogo)
        {
            Console.Clear();
            Console.WriteLine($"Seu saldo: {credito} \n");
            Console.WriteLine("Quanto você quer jogar nessa rodada? Mínimo de 0.5: ");
            float creditoJogo = Convert.ToSingle(Console.ReadLine());

            if (creditoJogo < 0.5)
            {
                Console.WriteLine("---- Maia Níquel ----");
                Console.WriteLine("Girando...");


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
                return simbolo.Key;
        }

        throw new Exception("Erro ao sortear símbolo");
    }
}

