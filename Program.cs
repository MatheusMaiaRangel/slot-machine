using slot_machine.Models;

Jogo jogo = new Jogo();

bool menu = true;

// Loop para a exibição do menu
while (menu == true)
{
    Console.Clear();
    Console.WriteLine("---- Bem vindo ao Maia Níquel! ----");
    Console.WriteLine("O que você deseja?\n");
    Console.WriteLine("[1] - Jogar");
    Console.WriteLine("[2] - Regras");
    Console.WriteLine("[3] - Carregar créditos");
    Console.WriteLine("[4] - Visualizar estatísticas");
    Console.WriteLine("[0] - Parar de jogar");

    switch (Console.ReadLine())
    {
        case "1":
            jogo.Jogar();
            break;

        case "2":
            jogo.Regras();
            break;

        case "3":
            jogo.CarregarCreditos();
            break;

        case "4":
            jogo.Estatisticas();
            break;

        case "0":
            menu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;        
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}
Console.WriteLine("Até a próxima");