// See https://aka.ms/new-console-template for more information
using SnakesAndLadders;
Console.WriteLine("TEST SNAKES AND LADDERS");

Console.WriteLine("Selecciona un test: 1-9");
Console.WriteLine("1. Juego completo manualmente");
Console.WriteLine("2. Juego completo automaticamente");
Console.WriteLine("3. US1_UAT1");
Console.WriteLine("4. US1_UAT2");
Console.WriteLine("5. US1_UAT3");
Console.WriteLine("6. US2_UAT1");
Console.WriteLine("7. US2_UAT2");
Console.WriteLine("8. US3_UAT1");
Console.WriteLine("9. US3_UAT2");
int test=Convert.ToInt32(Console.ReadLine());
switch (test)
{
    case 1:
        ManualFullGame();
        break;
    case 2:
        AutomaticFullGame();
        break;
    case 3:
        US1_UAT1();
        break;
    case 4:
        US1_UAT2();
        break;
    case 5:
        US1_UAT3();
        break;
    case 6:
        US2_UAT1();
        break;
    case 7:
        US2_UAT2();
        break;
    case 8:
        US3_UAT1();
        break;
    case 9:
        US3_UAT2();
        break;
    default:
        Console.WriteLine("Error. Fin de la ejecución");
        break;

}





void US1_UAT1()
{
    Game g = new Game(100, 2);
    g.NewRoll(1);
}

void US1_UAT2()
{
    Game g = new Game(100, 2);
    g.NewRoll(1,3);
}

void US1_UAT3()
{
    Game g = new Game(100, 2);
    g.NewRoll(1, 3);
    g.NewRoll(1, 4);
}

void US2_UAT1()
{
    Game g = new Game(100, 2);
    g.players[0].position = g.board.squares[96];
    g.NewRoll(1, 3);
}

void US2_UAT2()
{
    Game g = new Game(100, 2);
    g.players[0].position = g.board.squares[96];
    g.NewRoll(1, 4);
}

void US3_UAT1()
{
    Game g = new Game(100, 2);
    g.players[0].position = g.board.squares[20];
    g.NewRoll(1);
}

void US3_UAT2()
{
    Game g = new Game(100, 2);
    g.NewRoll(1,4);
}


void ManualFullGame()
{
    Game g = new Game(100, 2);
    do
    {
        NuevoCicloMenu(g);
    }
    while (!g.IsFinished());
};

void AutomaticFullGame()
{
    Game g = new Game(100, 2);
    while (!g.IsFinished())
    {
        if (!g.IsFinished())
        {
            DoMovement(1,g);
        }
        if (!g.IsFinished())
        {
            DoMovement(2,g);
        }
    }
};

void NuevoCicloMenu(Game g)
{
    Console.WriteLine("Tablero Inicial");
    Console.WriteLine(g.board.ToString());
    foreach (Player p in g.players)
    {
        Console.WriteLine(p.name + " en posicion " + p.position.display.ToString());

    }
    Console.WriteLine("Seleccionar Opcion:");
    int opcion = 1;
    foreach (Player p in g.players)
    {
        Console.WriteLine(opcion.ToString() + ". Lanzar dado " + p.name);
        opcion++;
    }

    int selectedOption = -1;
    do
    {
        try
        {
            selectedOption = Convert.ToInt32(Console.ReadLine());

        }
        catch (Exception e)
        {
            selectedOption = -1;
        }
    } while (IncorrectSelection(selectedOption, opcion));
    //Console.Clear();
    DoMovement(selectedOption,g);

}

void DoMovement(int selectedOption,Game g)
{
    int idPlayer = selectedOption;
    g.NewRoll(idPlayer);
}

bool IncorrectSelection(int selectedOption, int opcion)
{
    bool res = false;
    if (selectedOption < 1 || selectedOption > opcion)
    {
        res = true;
    }

    return res;
}