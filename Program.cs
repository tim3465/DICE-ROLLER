using System;
using System.Drawing;

Console.WriteLine("Welcome to the Grand Circus Casino!");
int diceSide = 0;

//Gets the user input on how many sides the dice should have
//the try catch won't allow anything less than 4 sides and it will only allow numbers 
while (true)
{
    try
    {
        Console.WriteLine("How many sides should each die have?");
       diceSide = int.Parse(Console.ReadLine());
        if (diceSide < 4)
        {
            throw new Exception("number to low");
        }
        break;
    }
    catch (FormatException e)
    {
        Console.WriteLine(e);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

bool proceed = true;
while (proceed)
{
    //Displays whether you win or lose dice Jardin 
    int diceOne = RandomDice(diceSide);
    int diceTwo = RandomDice(diceSide);
    Console.WriteLine($"You rolled a {diceOne} and a {diceTwo} ({diceOne + diceTwo} total)");
    Console.WriteLine(DiceJargin(diceSide, diceOne, diceTwo) + score(diceOne,diceTwo));
   
    //Gatekeeper 
    //Gives the user an option to continue or to end the program 
    while (true)
    {  
        Console.Write("Roll again? (y/n) :");
        string entry= Console.ReadLine().ToLower().Trim();
        if (entry =="y"||entry =="n")
        {
            if (entry=="n")
            {
                proceed = false;
                break;
            }
            else
            {
                break;
            }
        }
        else
        {
            Console.WriteLine("Invalid entry please enter (y/n)");
        }
    }
}
Console.WriteLine("Thanks for playing ");

//Metheds
//------------------------------------------------------------------------------------------------------
//This method generates the dice roll. 
static int RandomDice(int sides)
{
    Random random = new Random();
    int roll=random.Next(1,sides+1);
    return roll;
}

//This method Determines if you have a six sided dice
//will display the jargon associated with the dice roll if applicable 
static string DiceJargin(int diceSide,int diceOne,int diceTwo)
{
    if (diceSide == 6)
    {
        if (diceOne == 1 && diceTwo == 1)
            return "Snake Eyes\n";
        else if ((diceOne == 1 && diceTwo == 2) || (diceOne == 2 && diceTwo == 1))
            return "Ace Deuce\n";
        else if (diceOne == 6 && diceTwo == 6)
            return "Box Cars\n";
        else
            return "";
    }
    else
    {
        return "";
    }
}

//Will determine your score 
static string score(int diceOne,int diceTwo)
{
    int totle=diceOne+diceTwo;
    if (totle == 7 || totle == 11)
        return "You Win!!\n";
    else if (totle == 2 || totle == 3 || totle == 12)
        return "Craps!\n";
    else
        return "";
}


