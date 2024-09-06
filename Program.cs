/********************************************************************
*Caleb Roskelley
*Lab 3: Mastermind
*Date Started: 9/4/2024
*Date Finished:
********************************************************************/
Console.Clear();
Console.WriteLine("Hello! This is a guessing game similar to wordle, except it won't be real word" +
" instead 4 letters between 'a' and 'g' will be chosen at random, after you guess you will be told how many letters a" +
"re in the right place and how many letters are in the wrong place");
//Create a random number generator
Random rand = new Random();
//create a list to store the 4 randomly selected characters
//give the list 4 values that won't be selected by the random generator
List<char> randLetters = new List<char>{'k', 'k', 'k', 'k'};
//a for loop that runs 4 times to get 4 numbers and convert them to a char then add them to the list
for(int i = 0; i < 4; i++)
{
    //temp will randomly select a letter a through g
    //new letter each iteration of the for loop
    char temp = (char) rand.Next(97,104);
    //if statement to check if the letter in temp is already contained in the list
    if(!randLetters.Contains(temp))
    {
        randLetters.Add(temp);
        //remove all the dummy values in the list
        for(int j = 0; j < 4; j++)
        {
            randLetters.Remove('k');
        }
    }
    else{
        //if the loop doesn't add a letter that iteration, i must be decremented so that 4 letters will still be added
        i--;
    }
}
//for trouble shooting purposes to make sure 4 unique letters are being put into the list
foreach(var letter in randLetters){
    Console.Write(letter);
}
//counters for the number of letters in the correct position and the number of letters correct but in the wrong spot
int lettersCorrectPosition = 0;
int lettersIncorrectPosition = 0;
//boolean to loop program if an invalid answer is given
bool redoAnswer = true;
Console.WriteLine("");
Console.WriteLine("Please guess a sequence of 4 lowercase letters with no spaces.");
while(redoAnswer){
    redoAnswer = false;
    string usersAnswer = Console.ReadLine();
    //test to make sure user gives valid answer
    if(usersAnswer.Length == 4)
    {
        //iterates through each letter of the users answer and letter in the list
        for(int i = 0; i < 4; i++)
        {
            foreach(char letter in randLetters)
            {
                if(usersAnswer[i].Equals(randLetters[i]))
                {
                    lettersCorrectPosition++;
                }
                else if(usersAnswer[i].Equals(letter)){
                    lettersIncorrectPosition++;
                }
            }
        }
        //since userAnswer is a string each letter takes up the space of 4 char, so we must divide by 4 to get correct number
        Console.WriteLine($"{lettersCorrectPosition/4} letters in the correct position");
        Console.WriteLine($"{lettersIncorrectPosition} letters in the incorrect position");
    }
    else{
        Console.WriteLine("Invalid Answer Please guess again");
        redoAnswer = true;
    }
}