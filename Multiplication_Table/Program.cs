/*
This program will outline:
-'For' loops for iterating
-'DoWhile' loops combined with.. 
-'TryParse' for advanced input handling.

Application goals:
- Gather User Input for Starting/Ending values of both
the Rows and Columns.
- Display a Multiplication grid with the given ranges.
- each box on the grid will multiple the coresponding numbers.

HINT:
-To get rows and columns you will need to nest
a for loop inside another for loop.

*/

using System;

class multiplicationGrid
{
    public static void Main()
    {
        Console.Write("Enter starting value for rows: ");
         int startRow;
          int.TryParse(Console.ReadLine(),out startRow); // need to include TryParse correctly
          // this while loop will not let the user put anything but a int.
        Console.Write("Enter the ending value for rows: ");
         int endRow;
          int.TryParse(Console.ReadLine(),out endRow);
        Console.Write("Enter the starting value for columns: ");
         int startColumn;
          int.TryParse(Console.ReadLine(),out startColumn);
        Console.Write("Enter the ending vlaue for columns: ");
         int endColumn;
          int.TryParse(Console.ReadLine(),out endColumn);
  
        Console.Write("\t");
          for (int c= startColumn; c <= endColumn; c++)
          {
            Console.Write($"{c}\t");
          }
        Console.WriteLine("\n==================================================");
    // This marks the begining of the grid
         for(int r = startRow; r <= endRow; r++)
         { 
          Console.Write($"{r}\t");
           for(int c = startColumn; c <= endColumn; c++)
          {
            Console.Write($"{r*c}\t"); // should print the row array as the first column
          }// Nested for loop
            Console.WriteLine();
          } // first for loop
    } // ends main block
} // ends class block