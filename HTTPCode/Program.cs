using System;
class HTTP
{
    static void Main()
    {
     Console.WriteLine("Enter a Response Code: ");
      string userInput;
      userInput = Console.ReadLine(); // stores the User Input into a variable
      int codeHTTP; // This is where the int value of the string will be stored.

        if (int.TryParse(userInput, out codeHTTP)) 
        // This Boolean takes the string and converts it to an int.
        {
            string category;
            category = GetCategory(codeHTTP);
             if (category != null)
             {
                Console.WriteLine($"{codeHTTP} is a {category} Response.\n");
             } else {
                Console.WriteLine($"{codeHTTP} is not a valid response.\n");
             }
        } else {
            Console.WriteLine($"{userInput} is not a valid Response.\n");
        }
    }
    static string GetCategory(int codeHTTP) // this is the function holding all the responses for the above menu
    {
     if (codeHTTP >= 100 && codeHTTP < 200)
      {
        return "Informational\n";
     } else if (codeHTTP >= 200 && codeHTTP < 300)
      {
        return "Successful\n";
     } else if (codeHTTP >= 300 && codeHTTP < 400)
      {
        return "Redirection\n";
     } else if (codeHTTP >= 400 && codeHTTP < 500)
      {
        return "Client Error\n";
     } else if (codeHTTP >= 500 && codeHTTP < 600)
      {
        return "Server Error\n";
     } else
      {
        return (null);
     }
    }
}