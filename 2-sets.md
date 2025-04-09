# Sets

When working with data, numbers can get big. Large lists can easily exceed thousands or millions of values which can become difficult to sort through and can slow down a machine in no time. Also, while some data sets can allow for duplicates, others need to use unique values only. 
In cases like these, using sets can be valuable. 
Even more than that, understanding the concepts behind sets can unlock worlds of possibilities in using other, more complicated kinds of data structures and allow for larger, quicker programs that sort through data with ease.
This tutorial will cover **sets**, a data-organization technique called **hashing**, and the **efficiency** of sets and similar data structures.

## Why Use a Set?

Sets can be used when: 
- The data does not need to be kept in order
- Every value is unique 
- You want to access the information efficiently 

### 1. The data does not need to be kept in order
Sets are a lot like lists in that they store a collection of values. 
Sets use **hashing**, a technique that allows numbers to be simplified and put in their own, corresponding addresses in a chunk of storage. We'll talk more about hashing in a moment, but for now, just know that hashing makes sets possible for large, more complicated data types. 
For now, imagine we are working with a simple chunk of storage that can hold exactly 8 values. 
Consider the following code: 

```csharp
list<int> myList = new();
myList.Add(6);
myList.Add(2);
myList.Add(3);
myList.Add(1);
myList.Add(7);
```

In our chunk of data, the list might look like this: `6, 2, 3, 1, 7, _, _, _`
The last slots are empty, and the items are in the exact order we put them in.
Now, consider the following code using a set instead: 

```csharp
HashSet<int> mySet = new();
mySet.Add(6);
mySet.Add(2);
mySet.Add(3);
mySet.Add(1);
mySet.Add(7);
```

The set would order the values in the following way: `_, 1, 2, 3, _, _, 6, 7`
Notice how, unlike the list, the items are put in numerical order and there are three gaps. The numbers are each put in their corresponding index (number 1 is in index 1, etc.). This is how a set stores data. 
The downside to this is that data doesn't stay in the order we add it like it does with a normal list. 

### 2. Every value is unique

Consider the set we made above: `_, 1, 2, 3, _, _, 6, 7`
What would happen if we tried to add 7 again? 
```csharp
mySet.Add(7);
```
The slot `7` is already occupied by the value 7, so there's no space for it. 
The good news? Our program is smart enough to not break when this happens, so it simply moves on without changing the set. 
The bad news? We can only have one instance of 7 in our set. 
Because of this, we can only have unique values in sets. 

### 3. You want to be able to access information efficiently 

Let's go back to our list: `6, 2, 3, 1, 7, _, _, _`

If we wanted to find the number 7 in our list, we would have to go through each number in the list and check to see if it is equal to 7. This would result in an O(n) speed because the program has to go through every item in the list before it can find the right one.

Now, let's try finding 7 on our set: `_, 1, 2, 3, _, _, 6, 7`

This one is much faster, because we know that the number `7` will be in spot "7". The computer can navigate straight to spot 7 without having to look at the other spaces. This is very efficient, and results in an O(1) speed!

One downside to this system is that our set still takes up 8 spaces of data, even though we only have 5 numbers stored. But this is a small trade-off if we have to access those numbers thousands of times as quickly as possible.
This might seem like small fries for a set only 8-spaces long, but what if we had a million numbers? Imagine having to look through a million boxes and checking each one, individually, to see if the object inside is the right one. Wouldn't it be much easier to know ahead of time which box the object would be in? 

This sort of data storage makes looking through big numbers much faster. 

Awesome, now we know why we use sets! However, we've only looked at small numbers that fit neatly in a small chunk of storage. What happens when we start using big numbers, or even strings? 

## Hashing

Very rarely will you be working with data that fits so neatly together. Our examples so far have only covered `int`s. Strings can be sorted into sets by something called `serialization`. This is just the process of turning a string into a big number. For example, the word "cat" would be turned into the number 154282074. That can then be put into storage like we did before. However, in order to store the word "cat," we would need at least 154282075 slots of storage in our set. That's a lot of space! This is when we'd use **hashing.**

**Hashing** is a technique that allows data to be simplified and stored in a smaller chunk of data. 
Imagine we're using the same 8-space data chunk, but we want to store the numbers 0, 11, 102, and 1004. 
| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|----|----|----|----|----|----|----|----|
| Values | 0  |    |    |    |    |    |    |    |

The 0 fits nicely, but what about the other three numbers? 
We'd need a chunk of data that holds at least 1005 values in order to store them all as they are. 

What if there was a simple way to store and access these numbers without having to take up so much storage?
Let's try this: 

What if we got the remainder of these numbers after dividing them by 10? This can be done by using the Modulo operator, or the `%`. This divides a number by another number and returns the remainder, or whatever couldn't be divided neatly after the division.

0 % 10 is just 0

11 % 10 is 1

102 % 10 is 2

1004 % 10 is 4 

We would be left with 0, 1, 2, and 4. 
Those numbers line up with the spaces we have in our data cells! 
This is called **hashing**. This is a system used to simplify big numbers and store them without having to take up so much storage. 
Now our data looks like this: 

| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|----|----|----|----|----|----|----|----|
| Values | 0  | 11 | 102|    |1004|    |    |    |

(NOTE: You might notice we don't have a spot for numbers that end in 8 or 9. Realistically, you'd want to divide by the number of slots in storage. For example, if you have 8 slots like we have here, you would divide the number by 8. If you have 64 slots, you would divide by 64. However, for this example, we're simplifying by dividing by 10 so you can easily see what slots the values would fit into.)

Now, let's try finding our values. 

Let's look for 102. 

First, try 102 % 10 to get 2, which is the spot 102 should be in. 

Count through the indexes till we reach index 2, and check the value in the cell. Our stored value is 102, which is what we are looking for. 

What if we tried to find 10,006? 

10,006 % 10 is 6, so we look in spot 6. There's nothing there, so we know that 10,006 isn't in our set.

Now, you might see a problem with this. What if we tried to put 14 in our list? 
14 % 10 = 4, so we look in index 4. But we already have 1004 in there. 
This is a problem, and one that is solved two different ways: **Chaining** and **Open Addressing**. 

## Chaining and Open Addressing

**Chaining** and **Open Addressing** are ways we solve **conflicts**, or when two items are hashed into the same spot in storage. 
First, **Open Addressing**. 
You might notice that, in our storage, there is an open space right next to slot 4. One possible solution is to stick 14 in that spot. 
Our storage would look like this: 
| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|----|----|----|----|----|----|----|----|
| Values | 0  | 11 | 102|    |1004| 14 |    |    |

However, things can start to get ugly fast. 
Perhaps we want to add 10 to our list now. 

10 % 10 = 0, so we try to put 10 in spot 0. Unfortunately, 0 is already taken. So we look to spot 1. 
Spot 1 is taken, and so is spot 2, but spot 3 is open. So we stick number 10 in spot 3. 
Now our table looks like this: 
| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|----|----|----|----|----|----|----|----|
| Values | 0  | 11 | 102| 10 |1004| 14 |    |    |

Let's try to find value 10. 
First, 10 % 10 is 0, so we check spot 0. There's something in spot 0, but it's not equal to 10. Now we know that the value 10 could be somewhere else down the list, so we need to start looking. It's not in spot 1 or 2, either, but we find it in spot 3. That's pretty good, since we still only had to check four spots to find number 10 when a list would have taken 6 tries with number 10 at the end of the list. 

But now we have a different issue. Suppose we want to add numbers to index 3 or 5. Those spots are taken, but not by numbers that go in them. Things can get really hairy this way, so we have another system for dealing with this. 

That system is called **Chaining**. 
**Chaining** allows us to put a list of values at an index when there are multiple values that go in the same spot. 

For example, let's go back to our set before we had conflicts: 
| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|----|----|----|----|----|----|----|----|
| Values | 0  | 11 | 102|    |1004|    |    |    |

We want to add the value 14. We know 14 goes in spot 4, so we look in that cell and find 1004. Unfortunately, that means we can't stick 14 in there. 
But we can put something else in the box that substitutes for 14 and 1004. This 'something else' is like a forwarding address that tells spot 4 to send all inquiries to a new location. We do this because we can't fit a full list in box 4, but we can still send our program to the right location where it can find everything that belongs at index 4. 

Our storage might look something like this. 
| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|----|----|----|----|----|----|----|----|
| Values | 0  | 11 | 102|    | ** |    |    |    |
** 14, 1004

This prevents conflicts in other areas that might be caused by Open Addressing. 
| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|----|----|----|----|----|----|----|----|
| Values | ***  | 11 | 102| 3  | ** | 15 |    |    |
** 1004, 14
*** 0, 10

## Using Sets 

Let's go over some of the common syntax for sets in C#. 
C# uses the keyword `HashSet` for creating sets. 

```csharp
HashSet<int> mySet = new HashSet<int>();
```

This makes an empty set. To add something new, we need to do: 

```csharp
mySet.Add(1);
```

Now, our set has the number `1` in it. 
Here are some more things you can do with sets: 

```csharp
mySet.Contains(number); // Returns True if it contains number, false if not
mySet.Count(); // Returns the number of items in the set
mySet.Remove(number); // Removes the provided number
```

## Efficiency of Operations

The Big O notation for all of these is O(1) because of how efficient Sets are. 

## Example Problem

Let's make a program for a pet shop using sets. 
Our pet shop wants to keep track of what pets they offer. We're going to make a set that lets them add and remove pets from the list, check if a pet is available, and see how many pets are offered total. 

First, we need a set. We're going to put it in a class so we can use methods to interact with it. 
```csharp
class PetStock{
    private HashSet<string> _pets = new HashSet<string>(); // This creates our set. 
}
```

Now, we're going to add a method in our class to add pets. 
```csharp
    public void AddPet(string pet){
        bool wasAdded = _pets.Add(pet); // Will attempt to add the pet and return true/false
        if (wasAdded){
            Console.WriteLine($"{pet} was added to the list!");
        }
        else {
            Console.WriteLine($"{pet} is already in the list.");
        }
    }
```

This method will attempt to add the pet and, if successful (i.e. that pet isn't already in the list), will let the user know the pet has been added. Since the `Add` method returns true if the pet is added and false if the pet is already in the set, we just added a boolean variable to grab the true/false that was returned by the `Add` method. However, you can use `Add` without a variable grabbing the true/false return. 

Let's make a similar method to remove a pet. 

```csharp
    public void RemovePet(string pet){
        bool wasRemoved = _pets.Remove(pet); // Will attempt to remove the pet and return true/false
        if (wasRemoved){
            Console.WriteLine($"{pet} was removed from the list!");
        }
        else {
            Console.WriteLine($"{pet} isn't in this list.");
        }
    }
```

This method removes a pet and lets the user know, just like in our `AddPet` method. 

Let's try calling these methods! 

```csharp
class Program {
    static void Main() {
        PetStock pets = new PetStock();
        pets.AddPet("Puppy");
        pets.AddPet("Cat");
        
        pets.RemovePet("Puppy");
        pets.RemovePet("Unicorn");
    }
}
```
We will have the following outputs: 
```
Puppy was added to the list!
Cat was added to the list!
Puppy was removed from the list!
Unicorn isn't in this list.
```

Now, we just need two more methods: one to check if a pet is offered, and one to check how many pets are offered total. 

This method will check if a pet is available for us: 

```csharp
    public void CheckPet(string pet){
        bool hasPet = _pets.Contains(pet); // Will return true if pet is in the set, and false if not
        if (hasPet){
            Console.WriteLine($"'{pet}' is available!");
        }
        else {
            Console.WriteLine($"'{pet}' is not available at this shop.");
        }
    }
```
`_pets.Contains(pet)` will return true/false but won't change anything in our set. 

This method will tell us how many pets are offered total: 

```csharp
    public void PetCount(){
        int petNum = _pets.Count(); // Returns number of items in _pets, as an int
        Console.WriteLine($"There are {petNum} pets offered at this shop. ");
    }
```

Again, `_pets.Count()' will return an int, but won't change our set. 

Let's try calling them! 
```csharp
class Program {
    static void Main() {
        PetStock pets = new PetStock();
        pets.AddPet("Puppy");
        pets.AddPet("Cat");
        
        pets.PetCount();
        pets.CheckPet("Puppy");
        pets.CheckPet("Unicorn");
        pets.PetCount();
    }
}
```

This will result in the following outputs:

```
Puppy was added to the list!
Cat was added to the list!
There are 2 pets offered at this shop. 
'Puppy' is available!
'Unicorn' is not available at this shop.
There are 2 pets offered at this shop. 
``` 

As you can see, our set only has two pets available: Puppy and Cat. 
Our program lets the user know that 'Unicorn' was not available. After checking for two pets, our set remains unchanged. 

## Practice Problem - Ingredients Dictionary

Now you get to give it a try. 

Let's make something else for our breakfast restaurant. 
At Breakfast Rush, we offer lots of cereals. We want an easy way to update our cereal stock and check what's available. 
You're provided some simple code with empty methods for each of them.
You can find the practice problem [here](SetsExample\Program.cs) and the solution to the practice [here](SetsExampleSolution\Program.cs).

Try to complete the example problem on your own before looking through the solution.

When you're done, you should be able to run the program and get, roughly, these results in the terminal: 
```
Sail'r Crunch is now in stock.
Choco Puffs is now in stock.
Happy O's is now in stock.
Honey Clumps of Oats is now in stock.
Frosted Chips is now in stock.

There are 5 cereal(s) in stock!

Honey Clumps of Oats is in stock!
Honey Clumps of Oats is not longer in stock.
Honey Clumps of Oats is not in stock.

The following cereals are in stock:
Sail'r Crunch
Choco Puffs
Happy O's
Frosted Chips
There are 4 cereal(s) in stock!
```

Return to [Home](0-welcome.md)