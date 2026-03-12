namespace slot_machine.Models;

public class Jogo
{
    private float credito = 0;


    public void Jogar()
    {
        
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

}

