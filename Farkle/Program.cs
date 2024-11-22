/* Functions of game.
 *
 * Game will simulate rolling five six sided dice.
 * The user is allowed to roll one or more dice up to two times.
 * the goal is to get the highest score possible based off of the sum.
 * bonus points awarded for rolling multiples of the same value.
 *
 * Requirements
 *
 * the 5 dice rolls must be represented as an int array.
 * Utilize a Random object to simulate rolling the dice.
 * display inital dice roll with display that labels each roll
 * on a seperate line to name them.
 * to reroll user input will be gathered and sperated with ",".
 * allow for two rerolls
 * utilize each of these loops at least once, 
    - while  - for  - if  -switch
 * clear screen between each prompt for a new roll.
 * insure that the program does not crash due to bad input.
 * rather they will loose their reroll. 
 *
 * Scoring
 *
 * When rolling the score will be tallied gathering the sum
 * of each dice rolled.
 * Then the program should verify if any dice match, for
 * each matching pair add the following bonus points.
 *
 *  two dice with the same value: 
 *  three dice with the same value:
 *  four dice with the same value: 
 *  five dice with the same value
 */

 using System;

 namespace Farkle
 {
    class GamePlay
    {
        public static void Main()
        {
            Random rand = new Random(); // our random function
            int roll = rand.Next( 1, 7);
            int[] hand = new int[5]; // the array that holds the dice
            int reRoll = 2;

            RollDice(hand, rand);// initializes
            DisplayHand(hand, "Initial Roll"); 
            
            foreach (int dice in hand)
             {
                
                Console.WriteLine("Initial Roll: ")
             }
            // needs togather the sum of the roll
        }
    }
 }