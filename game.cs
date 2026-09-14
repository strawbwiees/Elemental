public class game
{
    private Character player1;
    private Character player2;

    public void StartGame()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("              ELEMENTAL ");
            Console.WriteLine("======================================");
            Console.WriteLine();
            Console.WriteLine("             MAIN MENU");
            Console.WriteLine();
            Console.WriteLine("          [1] START GAME");
            Console.WriteLine("          [2] EXIT");
            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartBattle();
                    break;

                case "2":
                    Console.WriteLine();
                    Console.WriteLine("Exit");
                    running = false;
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice!");
                    Console.WriteLine("Press ENTER to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void StartBattle()
    {
        Console.Clear();

        player1 = ChooseCharacter("PLAYER 1");

        Console.WriteLine();
        Console.WriteLine("Player 1 selected: " + player1.GetName() + " [" + player1.GetElement() + "]");

        Console.WriteLine();
        Console.WriteLine("Press ENTER for Player 2...");
        Console.ReadLine();

        Console.Clear();

        player2 = ChooseCharacter("PLAYER 2");

        Console.WriteLine();
        Console.WriteLine("Player 2 selected: " + player2.GetName() + " [" + player2.GetElement() + "]");

        Console.WriteLine();
        Console.WriteLine("Press ENTER to begin the battle...");
        Console.ReadLine();

        Battle();
    }

    private Character ChooseCharacter(string player)
    {
        Console.WriteLine("======================================");
        Console.WriteLine("          CHOOSE YOUR CHARACTER");
        Console.WriteLine("              " + player);
        Console.WriteLine("======================================");
        Console.WriteLine();
        Console.WriteLine("[1] Lumen   - Fire");
        Console.WriteLine("[2] Ripple  - Water");
        Console.WriteLine("[3] Gale  - Air");
        Console.WriteLine("[4] Grunchwood   - Earth");
        Console.WriteLine();
        Console.Write("Choose your character: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                return new Character("Lumen", "Fire", 20);

            case "2":
                return new Character("Ripple", "Water", 20);

            case "3":
                return new Character("Gale", "Air", 20);

            case "4":
                return new Character("Grunchwood", "Earth", 20);

            default:
                Console.WriteLine();
                Console.WriteLine("Invalid choice!");
                Console.WriteLine("Lumen has been selected.");
                return new Character("Lumen", "Fire", 20); 
        }
    }

    private void Battle()
    {
        Character attacker = player1;
        Character defender = player2;

        Console.Clear();

        Console.WriteLine("======================================");
        Console.WriteLine("            BATTLE START!");
        Console.WriteLine("======================================");
        Console.WriteLine();
        Console.WriteLine(player1.GetName() + " [" + player1.GetElement() + "]");
        Console.WriteLine("VS");
        Console.WriteLine(player2.GetName() + " [" + player2.GetElement() + "]");

        Console.WriteLine();
        Console.WriteLine("Press ENTER to start...");
        Console.ReadLine();

        while (player1.IsAlive() && player2.IsAlive())
        {
            Console.Clear();

            PlayerTurn(attacker, defender);

            if (player1.IsAlive() && player2.IsAlive())
            {
                Character temp = attacker;
                attacker = defender;
                defender = temp;

                Console.WriteLine();
                Console.WriteLine("Press ENTER for the next turn...");
                Console.ReadLine();
            }
        }

        ShowWinner();
    }

    private void PlayerTurn(Character attacker, Character defender)
    {
        bool validAction = false;

        while (!validAction)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("           " + attacker.GetName() + "'s Turn");
            Console.WriteLine("======================================");

            Console.WriteLine();
            Console.WriteLine("Your HP: " + attacker.GetHealth() + "/100");
            Console.WriteLine();
            Console.WriteLine("Opponent: " + defender.GetName());
            Console.WriteLine("Opponent HP: " + defender.GetHealth() + "/100");

            Console.WriteLine();
            Console.WriteLine("[1] Basic Attack");
            Console.WriteLine("[2] Special Attack");
            Console.WriteLine("[3] Defend");
            Console.WriteLine("[4] Stats");

            Console.WriteLine();
            Console.Write("Choose an action: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BasicAttack(attacker, defender);
                    validAction = true;
                    break;

                case "2":
                    validAction = SpecialAttack(attacker, defender);
                    break;

                case "3":
                    attacker.Defend();
                    validAction = true;
                    break;

                case "4":
                    attacker.DisplayStatus();
                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to return to your turn.");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void BasicAttack(Character attacker, Character defender)
    {
        string attackName = GetBasicAttackName(attacker.GetElement());

        int damage = attacker.BasicAttack();

        Console.WriteLine();
        Console.WriteLine(attacker.GetName() + " used "
            + attackName + "!");

        Console.WriteLine("Damage: " + damage);

        defender.TakeDamage(damage);
    }

    private bool SpecialAttack(Character attacker, Character defender)
    {
        string attackName = GetSpecialAttackName(attacker.GetElement());

        int damage = attacker.SpecialAttack();

        if (damage > 0)
        {
            Console.WriteLine();
            Console.WriteLine(attacker.GetName() + " used "
                + attackName + "!");

            Console.WriteLine("Damage: " + damage);

            defender.TakeDamage(damage);

            return true;
        }

        Console.WriteLine();
        Console.WriteLine("All spec9al attacks has been used!");
        Console.WriteLine("Choose another action.");

        return false;
    }

    private string GetBasicAttackName(string element)
    {
        switch (element)
        {
            case "Fire":
                return "Fireball";

            case "Water":
                return "tidal wave";

            case "Air":
                return "swoosh";

            case "Earth":
                return "darocksmash";

            default:
                return "Elemental Strike";
        }
    }

    private string GetSpecialAttackName(string element)
    {
        switch (element)
        {
            case "Fire":
                return "Lava pool";

            case "Water":
                return "Toilet flush";

            case "Air":
                return "Tornado";

            case "Earth":
                return "Earthquake";

            default:
                return "Elemental Burst";
        }
    }



    private void ShowWinner()
    {
        Console.Clear();

        Console.WriteLine("======================================");
        Console.WriteLine("              GAME OVER");
        Console.WriteLine("======================================");

        Console.WriteLine();

        if (player1.IsAlive())
        {
            Console.WriteLine("WINNER: " + "Player 1: " + player1.GetName());
            Console.WriteLine("Element: " + player1.GetElement());
        }
        else
        {
            Console.WriteLine("WINNER: " + "Player 2: " + player2.GetName());
            Console.WriteLine("Element: " + player2.GetElement());
        }

        Console.WriteLine();

        Console.WriteLine("--------------------------------------");
        Console.WriteLine("          FINAL STATS");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Player 1: " + player1.GetName() + " - Health: " + player1.GetHealth() + "/100");
        Console.WriteLine("Player 2: " + player2.GetName() + " - Health: " + player2.GetHealth() + "/100");

        Console.WriteLine();
        Console.WriteLine("======================================");
        Console.WriteLine("Press ENTER to return to Main Menu.");
        Console.WriteLine("======================================");

        Console.ReadLine();
    }
}