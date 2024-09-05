/********************************************************************
*Caleb Roskelley
*Lab 3: Mastermind
*Date Started: 9/4/2024
*Date Finished:
********************************************************************/
Console.WriteLine("Hello! This is a guessing game similar to wordle, except it won't be real word" +
" instead 4 letters between 'a' and 'g' will be chosen at random, after you guess you will be told how many letters a" +
"re in the right place and how many letters are in the wrong place");
//Create a random number generator
Random rand = new Random();
//create a list to store the 4 randomly selected characters
List<char> randLetters = new List<char>{};
//a for loop that runs 4 times to get 4 numbers and convert them to a char then add them to the list
for(int i = 0; i < 4; i++)
{
    char temp = (char) rand.Next(97,104);
    randLetters.Add(temp);
}
foreach(char letter in randLetters){
    Console.Write(letter);
}
Console.WriteLine("Please guess a sequence of 4 lowercase letters with no spaces.");
string usersAnswer = Console.ReadLine();
Console.WriteLine(usersAnswer[0]);