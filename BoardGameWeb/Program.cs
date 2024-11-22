using System;
using BoardGameLib;

namespace SnakesAndLaddersGame
{
    class GameFlow
    {
        
    
        static void Main(string[] args)
        {
            // Create a new instance of the Snakes and Ladders game
            SnakesAndLadders game = new SnakesAndLadders();

            // Display game information
            game.DisplayInfo();

            // Start the game
            game.Start();

            // Run the game turns
            game.PlayerTurn();

            // End the game and display the winning lineup
            game.End();
        }
        
    }
}