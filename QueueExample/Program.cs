using System.Collections.Generic;
using System;

class OrderQueue{
    private Queue<PancakeOrder> _orders = new Queue<PancakeOrder>();
    private int _pancakes = 0;
    
    // Add Pancakes
    public void AddPancakes(int num){
        // This method adds pancakes that are ready to ber served
        _pancakes += num;
        Console.WriteLine($"You added {num} pancakes. You now have {_pancakes} ready to serve.");
    }

    // Pancakes Count
    public void CountPancakes(){
        // Returns the number of pancakes available
        Console.WriteLine($"There are {_pancakes} pancakes ready to serve!");
    }

    // Serve Customer
    public void ServePancakes(){
        // TODO: Write code to serve the next customer in the list. 
        // You will need to check and make sure there are enough pancakes to serve the customer. 
        // If there are, you will serve the customer and remove them from the queue. 
        // Make sure to remove pancakes from the total count! 
        // HINT: You will need to use Peek() to do this. 

    }

    // Add Customer
    public void AddOrder(string name, int count) {
        // TODO: Write code that adds a new order to the queue
        // This method should create a new instance of PancakeOrder and
        // enqueue it to the order queue. 
        // It should print a string that tells the user the customer's order
        // has been added to the queue. 

    }

    // Customer Count
    public void CountOrders() {
        // TODO: Write code that prints the number of orders in the queue. 

    }

}

class PancakeOrder(string name, int count) {
    private string _name = name;
    private int _count = count;

    public string getName() {
        return _name;
    }
    
    public int getCount() {
        return _count;
    }
}

class Program {
    static void Main() {
        OrderQueue pancakeOrders = new OrderQueue();
        pancakeOrders.AddPancakes(10);
        pancakeOrders.AddOrder("Sam", 3);
        pancakeOrders.AddOrder("Jason", 4);
        pancakeOrders.AddOrder("Tyler", 15);
        pancakeOrders.CountOrders();
        pancakeOrders.ServePancakes();
        pancakeOrders.ServePancakes();
        pancakeOrders.ServePancakes();
        pancakeOrders.CountPancakes();
        pancakeOrders.AddPancakes(20);
        pancakeOrders.ServePancakes();
        pancakeOrders.CountOrders();
    }
}