using System.Collections;

namespace BinaryTree;

class Bingo(){
    private BinarySearchTree _calledNumbers = new BinarySearchTree();
    private Random _rand = new Random(); // Define _rand here

    // Print numbers called
    public void PrintNums() {
        // TODO: Print out the numbers that have been called
        
        Console.Write("Numbers: ");
        foreach (int num in _calledNumbers) {
            Console.Write($"{num}, ");
        }
        Console.WriteLine();
    }


    // Generate new number
    public void NextNumber(){
        // Generates a random number from the bingo pool
        // and adds it to the tree
        // Written with a lot of help from ChatGPT
        int number;
        do
        {
            // Generate a random number from 1 to 75
            number = _rand.Next(1, 76);
        } while (_calledNumbers.Contains(number)); // Ensure the number is unique

        // TODO: Add the generate number to the tree and let the user
        // know what number has been added
        _calledNumbers.Insert(number);
        
        Console.WriteLine($"The next number is {number}!");
    }

    // Check to see if a number is in the tree

    public void IsCalled(int num) {
        // TODO: Write code to check to see if a number has been called yet. 
        // Print a statement saying if the number has or has not been called. 

        bool hasNumber = _calledNumbers.Contains(num);

        if (hasNumber) {
            Console.WriteLine($"The number {num} has been called!");
        }
        else {
            Console.WriteLine($"The number {num} has not been called.");
        }
    }   
}


class Program {
    static void Main(string[] args) {

        Bingo bingoGame = new Bingo();

        // Tests written with ChatGPT
        Console.WriteLine("Calling numbers...");
        bingoGame.NextNumber();  // Generate and add a random number
        bingoGame.NextNumber();  // Generate and add another random number
        bingoGame.NextNumber();  // Generate and add a third random number

        bingoGame.PrintNums();

        bingoGame.IsCalled(5);  // Check if number 5 has been called (you can change the number)
        bingoGame.IsCalled(50); // Check if number 50 has been called (you can change the number)
        bingoGame.IsCalled(75); // Check if number 75 has been called (you can change the number)
        
        bingoGame.NextNumber();
        bingoGame.NextNumber();

        bingoGame.PrintNums();
        }

}