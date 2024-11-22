using System;

class epicBattle
{
    static void Main()
    {
        // This is our intro into the game.
        Console.WriteLine("Hello adventurer!");
        Console.WriteLine("Your journey will not start from an inner conflict...");
        Console.WriteLine("No, this conflict is a bit more literal.");
        Console.WriteLine("OH NO! a convienetly placed Enemy NPC!");
        // Hero's initial stats
        int heroHP = 100;
        int heroAttack = 20;
        int heroDefense = 10;

        // Enemy characters' stats
        int[] enemyHP = { 50, 60, 70 };
        int[] enemyAttack = { 15, 10, 20 };
        int[] enemyDefense = { 5, 8, 12 };

        int enemyIndex = 0;

        // Generates a random number to determine if hit lands.
        Random rand = new Random();

        Console.WriteLine("Quick! Roll for dexterity!");
        Console.WriteLine();
        int dexterity = rand.Next(1, 21);
        while (heroHP != 0)
        {
            if (dexterity > 10)
            {
                int damageToEnemy = heroAttack - enemyDefense[enemyIndex];
                if (damageToEnemy > 0)
                {
                    enemyHP[enemyIndex] -= damageToEnemy;
                    Console.WriteLine($"Hero attacks enemy! {damageToEnemy} hit points were dealt.");
                    Console.WriteLine($"Enemy HP: {enemyHP[enemyIndex]}");
                }
                else
                {
                    Console.WriteLine("Hero is still too weak for this foe...");
                }
            }
            else
            {
                Console.WriteLine("Dexterity FAILED! Hero's attack missed!");
            }

            // Enemy attacks hero
            int enemyAttackRoll = rand.Next(1, 21); // Generate a random number between 1 and 20

            if (enemyAttackRoll > 10)
            {
                int damageToHero = enemyAttack[enemyIndex] - heroDefense;
                if (damageToHero > 0)
                {
                    heroHP -= damageToHero;
                    Console.WriteLine($"Enemy attacks hero for {damageToHero} damage.");
                    Console.WriteLine($"Hero HP: {heroHP}");
                }
                else
                {
                    Console.WriteLine("Enemy was to weak for our Hero!");
                }
            }
            else
            {
                Console.WriteLine("Enemy's attack missed!");
            }

            // Checking for whom was defeated
            if (heroHP <= 0)
            {
                Console.WriteLine("Hero is defeated!");
            }
            else if (enemyHP[enemyIndex] <= 0)
            {
                Console.WriteLine($"The Enemy was defeated!");
            }
            
            // Ask the user if they want to keep fighting
            Console.Write("Will you keep fighting? (yes/no)");
            string response = Console.ReadLine().ToLower();
            if (response != "yes")
            {
                Console.WriteLine("Hero has chosen to retreat!");
                break;
            }
        }
    }
}
