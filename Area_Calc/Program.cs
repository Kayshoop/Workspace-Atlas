/*
 This program will gather the length and width of either a 
 Rectangle, Triangle, or Circle to then calculate the 
 area in that shape. 

 How to determine the area of each shape:
 Rectangle - Multiply the Length * Width
 Triangle - Multiply the base by the height, then divide the result by 2
 Circle - Multiply by Pi

 Functions Utilized:
 while loop 
 switch statements
 Math type
 Math.Round()
 Math.Pi
*/

using System;

class MathOutput
{

  static void Main()
  {
    Console.Write("What type of shape (R)ectangle, (T)riangle, or (C)ircle?");

    char userInput;
    userInput = Console.ReadKey().KeyChar; // needs to take user input as a Char, then convert to uppercase
    char shapeInput = char.ToUpper(userInput);
    
    while (new char[] {'R', 'T', 'C'}.Contains(shapeInput)) // this places the options for UI into an array.

     // This line will take the user input and convert it to a uppercase letter
    {
      switch (shapeInput){
        case 'R':
         Console.Write("\nEnter the length: ");
          double length;
          length = Convert.ToDouble(Console.ReadLine()); // variable length updated to user input
         Console.WriteLine("Enter with width: ");
          double width;
          width = Convert.ToDouble(Console.ReadLine()); // variable width updated to user input
           double rectangleArea;
           rectangleArea = Math.Round(length * width, 2); // uses the math function to multiply the two inputs
         Console.WriteLine($"The area of this rectangle is {rectangleArea:F2}.");
         continue;
        case 'T': 
         Console.Write("\nEnter the base: ");
          double Base;
          Base = Convert.ToDouble(Console.ReadLine()); // varaible base updated to the users input
         Console.Write("\nEnter height: ");
          double height;
          height = Convert.ToDouble(Console.ReadLine()); // variable height updated to the users input
           double triangleArea;
           triangleArea = Math.Round( Base* height / 2, 2); // Math rounds to the integer, however you can also specify the # of decimal places you want to go.
         Console.WriteLine($"\nThe area of this triangle is {triangleArea:F2}.");
         continue;
        case 'C': 
         Console.Write("\nEnter the radius: ");
          double radius;
          radius = Convert.ToDouble(Console.ReadLine());
           double circleArea;
           circleArea = Math.Round(Math.PI * radius * radius, 2);
         Console.WriteLine($"\nThe area of this trianlge is {circleArea:F2}."); // the 'F2' of this function is the format specifier. 
         // A format specifier is a single alphabetic character that deffines how a numeric or date/time value should be formatted when converted to a string. 
         continue;
        default:  
        Console.WriteLine("\nInvalid Input, Please enter the letter associated with the shape you would like to use.");
         break;
      } // ends switch 
    }// Ends while loop
  }
}
/*
- Programs loop repears at "Enter length" on r setting.
- program needs an exit option other then crashing the program with default.
*/
