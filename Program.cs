/********************************************************************
*Caleb Roskelley
*Lab 3: Mastermind
*Date Started: 9/4/2024
*Date Finished:
********************************************************************/
/*******************************************************************
*Things left to do in program:
*
*
********************************************************************/
using System.Reflection.PortableExecutable;

Console.Clear();
Console.WriteLine("Hello! This is a guessing game similar to wordle, except it won't be real word" +
" instead a chosen number of letters between 'a' and 'z' will be chosen at random, after you guess you will be told how many letters a" +
"re in the right place and how many letters are in the wrong place");
Console.WriteLine("You can stop anytime by typing stop");
//Create a random number generator
Random rand = new Random();
//boolean for a while loop that allows player to play game again after winning
bool playAgain = true;
while(playAgain)
{
    //default to only playing once
    playAgain = false;
    Console.WriteLine("Please enter how many letters you would like to be in the secret sequence. Maximum of 26");
    string howManyLetters = Console.ReadLine();
    int numOfLetters = Convert.ToInt32(howManyLetters);
    //create a list to store the randomly selected characters
    //give the list a dummy value that won't be selected by the random generator
    List<char> randLetters = new List<char>{'k'};
    //a for loop that runs 4 times to get 4 numbers and convert them to a char then add them to the list
    for(int i = 0; i < numOfLetters; i++)
    {
        //temp will randomly select a letter a through g
        //new letter each iteration of the for loop
        char temp = (char) rand.Next(97,124);
        //if statement to check if the letter in temp is already contained in the list
        if(!randLetters.Contains(temp))
        {
            randLetters.Add(temp);
            //remove all the dummy values in the list
            randLetters.Remove('k');
        }
        else{
            //if the loop doesn't add a letter that iteration, i must be decremented so that 4 letters will still be added
            i--;
        }
    }
    foreach(var letter in randLetters)
    {
        Console.Write(letter);
    }
    //counter for number of guesses
    int guessCounter = 1;
    //boolean to loop program if an invalid answer is given and if user doesn't get correct answer
    bool redoAnswer = true;
    //boolean contributing to valid answers, used when making sure there aren't repeats
    bool noRepeats = true;
    Console.WriteLine("");
    while(redoAnswer){
        redoAnswer = false;
        
        Console.Write($"Guess #{guessCounter}: ");
        Console.WriteLine($"Please guess a sequence of {numOfLetters} lowercase letters with no spaces and no repeats.");
        string usersAnswer = Console.ReadLine();
        int lettersCorrectPosition = 0;
        int lettersIncorrectPosition = 0;
        //if user types stop program will not loop again
        if(usersAnswer.ToLower().Equals("stop"))
        {
            redoAnswer = false;
        }
        else{
            //iterate through the users answer making sure that when i != j the 2 seperate letters aren't the same
            for(int i = 0; i < numOfLetters; i++){
                for(int j = 0; j < numOfLetters; j++){
                    if(usersAnswer[i].Equals(usersAnswer[j]) && j != i)
                    {
                        noRepeats = false;
                    }
                }
            }
            //test to make sure user gives valid answer, no repeats and 4 letters long
            if(noRepeats && usersAnswer.Length == numOfLetters)
            {

                //increment guess counter only if user gives valid answer
                guessCounter++;
                //counters for the number of letters in the correct position and the number of letters correct but in the wrong spot
                lettersCorrectPosition = 0;
                lettersIncorrectPosition = 0;
                //iterates through each letter of the users answer and letter in the list
                for(int i = 0; i < numOfLetters; i++)
                {
                    char usersAnswerCharacter = Convert.ToChar(usersAnswer[i]);
                    if(usersAnswerCharacter.Equals(randLetters[i]))
                    {
                        lettersCorrectPosition++;
                    }
                    else{
                        foreach(char letter in randLetters)
                        {
                            if(usersAnswer[i].Equals(letter)){
                                lettersIncorrectPosition++;
                            }
                        }
                    }
                }
                Console.WriteLine($"{lettersCorrectPosition} letters in the correct position");
                Console.WriteLine($"{lettersIncorrectPosition} letters in the incorrect position");
                if(lettersCorrectPosition == numOfLetters)
                {
                    Console.WriteLine($"You guessed it in {guessCounter - 1} tries! The letters were {usersAnswer}!");
                }
                else{
                    redoAnswer = true;
                }
            }
            else{
                Console.WriteLine("Invalid Answer Please guess again");
                redoAnswer = true;
            }
        }
    }
    Console.WriteLine("Would you like to play again? Please answer yes or no");
    Console.WriteLine("Any other answers will be taken as a no");
    string playAgainAnswer = Console.ReadLine();
    if(playAgainAnswer.ToLower().Equals("yes"))
    {
        playAgain = true;
    }
}