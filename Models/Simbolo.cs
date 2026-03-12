namespace slot_machine.Models;

public class Simbolo
{
    public string Emoji { get; set; }
    public int Probabilidade { get; set; }
    public int Multiplicador { get; set; }

    public Simbolo(string emoji, int probabilidade, int multiplicador)
    {
        Emoji = emoji;
        Probabilidade = probabilidade;
        Multiplicador = multiplicador;
    }

    public static readonly List<Simbolo> Simbolos = new List<Simbolo>()
    {
        // Cada um tendo uma probabilidade de cair
        new Simbolo("🍒", 40, 2),
        new Simbolo("🍋", 30, 3),
        new Simbolo("🍊", 20, 5),
        new Simbolo("⭐", 8, 10),
        new Simbolo("7️⃣ ", 2, 50) //Dei esse espaço pq esse emoji "come" um espaço da direita e deixa a grade torta
    };
}