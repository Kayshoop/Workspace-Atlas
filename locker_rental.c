#include<stdio.h>
#include<string.h>
#include<stdlib.h>

    //Constant Variables
#define MAX_LOCKERS 100
#define MAX_ITEM_lENGTH 50

    //FUNCTION PROTOTYPES

void lockerArray(char lockers[MAX_LOCKERS][MAX_ITEM_lENGTH]); // This is initalizing the lockers 1-100 and placing them into an array that allows for input.
int lockerFile(Lockers *lockers, const char *lockerContentFile); // This is where we will create the file for lockers
int lockerValidity(char lockers[MAX_LOCKERS][MAX_ITEM_lENGTH], int lockerNum); // Verifies if input is between 1-100
int lockerRental(); //This verifies if the locker is avaliable. If avaliable then it will request items being stored then mark as rented. 
int terminateRental(); // Verifies if the locker is rented, if so then empty locker and mark locker empty.
int displayAll(); // Will display all rented lockers then


    //Building Functions
typedef struct { 
    // Creates a struct (A function that can hold more than 1 data type)
    int locker[MAX_LOCKERS]; // first array that creates locker # 1-100
    char contents[MAX_LOCKERS][MAX_ITEM_lENGTH];
} Lockers; // the typedef name?

/* void lockerArray(char lockers[MAX_LOCKERS][MAX_ITEM_lENGTH]){
    // This function is making the array for lockers.
    for (int i =0; i <MAX_LOCKERS; i++){
        lockers[i][0] ='\0'; 
    }
}*/

int lockerFile(Lockers *lockers, const char *lockerContentFile) {
    //Creates the file that will hold the 2D array.
    FILE *lockerContentFile;
    lockerContentFile = fopen(lockerContentFile, "a");
     if (lockerContentFile == NULL) {
        perror("STAPH WHAT ARE YOU DOING!? Respectfully, file did not open...\n");
      return 1;
     }
     for (int i = 0; i < MAX_LOCKERS; i++) {
        fprintf(lockerContentFile, "Locker %d: %s\n", Lockers.Locker[i], Lockers.Contents[i]);
     }
             fclose(lockerContentFile);
      return 0;
}


int lockerValidity(char lockers[MAX_LOCKERS][MAX_ITEM_lENGTH], int lockerNum) {
 char itemInput[MAX_ITEM_lENGTH];
 printf("Enter locker number (1-100): \n");
 scanf("%d", &lockerNum);
    if (lockerNum < 1 || lockerNum > MAX_LOCKERS){ 
        // handles invalid input.
        printf("Sorry, there are only 100 lockers available.\n");
            return -1; // indicates that locker # is invalid.
    } else
        return 0;
}

int lockerRental();{

    if (lockers[lockerNum - 1][0] == '\0') {
     printf("Enter the item you want to store in the locker: \n");
     scanf("%s", itemInput); 
          
     strncpy(lockers[lockerNum -1], itemInput, MAX_ITEM_lENGTH -1);

     lockers[lockerNum - 1][MAX_ITEM_lENGTH - 1] = '\0'; // adds in the null terminator 
        printf("Locker %d has been rented for %s storage.\n", lockerNum, itemInput);
         lockerFile(lockers, "lockerContent.txt"); // appends the new information back into the file.

    } else {
        printf("Sorry, but locker %d has already been rented!\n", lockerNum);
         }
    return 0; // Indicates function ran sucessfully
}


int main(){

    //Variables
int menuInput;
int *menuInput_prt;
int lockerRented;
int lockerNum;
char lockers;
char itemInput;
char *itemInput_ptr;

do {
    //Displays user menu then updated the value of menuInput.
 printf("\n");
 printf("Locker Rental Menu\n");
 printf("=============================\n");
 printf("1. View a locker\n");
 printf("2. Rent a locker\n");
 printf("3. End a locker rental\n");
 printf("4. List all locker contents\n");
 printf("5. Quit\n");
 printf("\n");
 printf("\n");
 printf("Enter your choice (1-5): \n");
  
  scanf("%d", menuInput);

    switch (*menuInput_prt){
        case 1: // view a locker
         printf("Enter locker number 1-100): \n");
         scanf("%d", &lockerNum);

         int result = lockerValidity(lockers, lockerNum); 
          if (result == 0) {
            printf("Locker %d contents: %s\n", lockerNum, lockers[lockerNum -1]);
          } else 
            printf("Locker %d is EMPTY.", lockerNum);
            
             break;

        case 2: // rent a locker
         printf("Enter locker number 1-100): \n");
         scanf("%d", &lockerNum);
         printf("Enter the item you want to store in the locker: '%s'\n", &contents);
            break;

        case 3: // End a locker rental
            
            break;

        case 4: // list all locker contents
            
            break;

        case 5: // quit 
            
            break;

         default:
            printf("The number you have selected is out of my comprehension..\n");
            continue;
    }// ends the switch cases

} while (menuInput == 5);
    {
     printf("Exiting the program. Goodbye!\n");
    //TERMINATE
    }
    return 0;
} // ENDS MAIN FUNCTION


/*

 - menu options and their functions
    case 1:
        use UI to display locker contents
        IF locker is empty display "Locker ## is EMPTY.\n"
        break;

    case 2:
        void menuChoice(int lockerRented, int lockerNum); //FUNCTION..
        print "Enter the item you want to store in the locker: \n"
        IF locker is rented, display "Sorry, but locker ## has already been rented!\n"
        break;

    case 3:
        print "Enter locker number (1-100): \n"
        IF locker != rented,
        print "Locker ## is not currently rented.\n"
        ELSE -TERMINATE the locker rental
        print "Locker ## rental has ended, please take your Backpack.\n"
        break;

    case 4:
         Display the contents of ALL rented lockers.
         IF no lockers are rented display "There are curently no rented lockers...\n"
         break;
    
    case 5:
        display "Exiting the program. Goodbye!\n"
        Quits the program 
        break;
    default:
        
        continue;

        continue;
}

//BUILDING THE FUNCTIONS



NEEDS/BUGS to fix
-----------------


*/