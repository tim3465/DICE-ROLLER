using System;
using System.Drawing;


Console.WriteLine("Welcome to the Grand Circus Casino!");

int diceSide = 0;

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
    int diceOne = RandomDice(diceSide);
    int diceTwo = RandomDice(diceSide);
    Console.WriteLine($"You rolled a {diceOne} and a {diceTwo} ({diceOne + diceTwo} total)");
    Console.WriteLine(DiceJargen(diceSide, diceOne, diceTwo) + score(diceOne,diceTwo));
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

//Create a static method to generate the random numbers.
//Proper method header: 2 points
//Program generates random numbers validly within the user-specified range: 1 point
//Method returns meaningful value of proper type: 1 poin

static int RandomDice(int sides)
{
    Random random = new Random();
    int roll=random.Next(1,sides+1);
    return roll;
}
//Create a static method for six - sided dice that takes two dice values as parameters, and returns a string for one of the valid combinations(e.g.Snake Eyes, etc.) or an empty string if the dice don’t match one of the combinations.
//Snake Eyes: Two 1s
//Ace Deuce: A 1 and 2
//Box Cars: Two 6s
//Or empty string if no matching combos

static string DiceJargen(int diceSide,int diceOne,int diceTwo)
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
//Create a static method for six - sided dice that takes two dice
//values as parameters,
//and returns a string for one of the valid totals(e.g.Win, etc.) or
//an empty string if the dice don’t match one of the totals.
//Win: A total of 7 or 11
//Craps: A total of 2, 3, or 12
//Or empty string if no matching combos
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


