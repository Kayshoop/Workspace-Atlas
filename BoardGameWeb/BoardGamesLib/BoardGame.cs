using System;
using System.Collections.Generic;

namespace BoardGameLib
{
    public class BoardGame
    {
        // Properties
        public string Name { get; set; } // BoardGame's name
        public int MinPlayers { get; set; } // Min players allowed
        public int MaxPlayers { get; set; } // Max players allowed
        public int[] BoardSpaces { get; set; } // Holds the amount of spaces on the board
        public List<int> PlayerPositions { get; set; } // Holds the positions of all players
        public List<int> WinningOrder { get; set; } // Holds the order in which players won

        // Constructor
        public BoardGame(string name, int minPlayers, int maxPlayers, int[] boardSpaces)
        {
            Name = name;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            BoardSpaces = boardSpaces;
            PlayerPositions = new List<int>();
            WinningOrder = new List<int>();
        }

        // Method to display game info
        public void DisplayInfo()
        {
            Console.Clear();
            Console.WriteLine("__Game Info__");
            Console.WriteLine($"Game: {Name}");
            Console.WriteLine($"Allowed Players \nAt least: {MinPlayers} \nMax: {MaxPlayers}");
            Console.WriteLine($"\nFirst player to position {BoardSpaces.Length} wins!");
            Console.WriteLine("Ready? Press a key to start the game!");
            Console.ReadKey(); // allowing a pause
            Console.Clear();
        }

        // Method to roll the dice
        public int Dice()
        {
            Random rand = new Random();
            return rand.Next(1, 7);
        }

        // Virtual method to play the game
        public virtual void Play(ref int playerPosition, int playerNumber)
        {
            Console.Clear();
            Console.WriteLine($"\nPlayer {playerNumber}'s turn, Ready? (Press any key to continue):");
            Console.ReadLine(); // allowing a pause 
            int diceRoll = Dice();
            Console.WriteLine($"Player {playerNumber} rolled a {diceRoll} \nMoving Player..");
            playerPosition = MovePlayer(playerPosition, diceRoll);
            Console.WriteLine($"Player {playerNumber} is now on space {playerPosition} \n(Press A Key to Continue)");
            Console.ReadKey(); //allowing another pause.
            Console.Clear();
        }

        // Method to move the player (to be overridden in derived classes)
        public virtual int MovePlayer(int currentPosition, int diceRoll)
        {
            int newPosition = currentPosition + diceRoll;
            if (newPosition > BoardSpaces.Length)
            {
                newPosition = BoardSpaces.Length;
            }
            return newPosition;
        }

        // Method to start the game
        public void Start()
        {
            PlayerPositions.Clear();
            for (int i = 0; i < MaxPlayers; i++)
            {
                PlayerPositions.Add(0);
            }
            Console.WriteLine("Game started! All players are at the starting position.");
            Console.Clear();
        }

        // Method to alternate which player to move
        public void PlayerTurn()
        {
            bool gameWon = false;
            int currentPlayer = 0;

            while (!gameWon)
            {
                int playerPosition = PlayerPositions[currentPlayer];
                Play(ref playerPosition, currentPlayer + 1);
                PlayerPositions[currentPlayer] = playerPosition;

                if (PlayerPositions[currentPlayer] == BoardSpaces.Length)
                {
                    Console.WriteLine($"Player {currentPlayer + 1} wins!");
                    WinningOrder.Add(currentPlayer + 1);
                    gameWon = true;
                }
                End();
            }
        }
        // Method to display the winning lineup
        public void WinningLineUp()
        {
            Console.Clear();
            Console.WriteLine("Winning Lineup:");
            for (int i = 0; i < WinningOrder.Count; i++)
            {
                string position;
                switch (i)
                {
                    case 0:
                        position = "Winner";
                        break;
                    case 1:
                        position = "Second";
                        break;
                    case 2:
                        position = "Third";
                        break;
                    default:
                        position = $"{i + 1}th";
                        break;
                }
                Console.WriteLine($"{position}: Player {WinningOrder[i]}");
            }
        }
        //Method determining the end of the game and displaying winners.
        public void End()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.WriteLine("Press a key to get the winners Line Up!");
            Console.ReadKey();
            WinningLineUp();
        }
    }

    public class SnakesAndLadders : BoardGame
    {
        // The Dictionary keyword is an array that will hold the location pairs for snakes and ladders
        private Dictionary<int, int> snakes;
        private Dictionary<int, int> ladders;

        // Constructor
        public SnakesAndLadders() : base("Snakes and Ladders", 2, 4, new int[100])
        { // the typical game will include 10 spaces for each Snake and ladder pair **yes these are the real locations**
            snakes = new Dictionary<int, int>
            {
                { 16, 6 },
                { 47, 26 },
                { 49, 11 },
                { 56, 53 },
                { 62, 19 },
                { 61, 60 },
                { 87, 24 },
                { 93, 43 },
                { 95, 75 },
                { 98, 78 }
            };

            ladders = new Dictionary<int, int>
            {
                { 1, 38 },
                { 4, 14 },
                { 9, 31 },
                { 21, 42 },
                { 28, 84 },
                { 36, 44 },
                { 51, 67 },
                { 71, 91 },
                { 80, 100 }
            };
        }

        // Override the Play method
        public override void Play(ref int playerPosition, int playerNumber)
        {
            Console.Clear();
            Console.WriteLine("Climb the ladders and avoid the snakes!");
            base.Play(ref playerPosition, playerNumber);
            Console.Clear();
        }

        // Override the MovePlayer method
        public override int MovePlayer(int currentPosition, int diceRoll)
        {
            int newPosition = currentPosition + diceRoll;

            if (newPosition > BoardSpaces.Length)
            {
                newPosition = BoardSpaces.Length;
            }

            if (snakes.ContainsKey(newPosition))
            {
                Console.WriteLine($"Oh no! You landed on a snake. Sliding down to space {snakes[newPosition]}. \n(Press A Key to Continue.)");
                Console.ReadKey();
                newPosition = snakes[newPosition];
                Console.Clear();
            }
            else if (ladders.ContainsKey(newPosition))
            {
                Console.WriteLine($"You landed on a ladder! You can now climb up to {ladders[newPosition]}. \n(Press A Key to Continue.)");
                Console.ReadKey();
                newPosition = ladders[newPosition];
                Console.Clear();
            }

            return newPosition;
        }
    }
}
