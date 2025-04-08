# Queues
When dealing with lots of tasks, it can be helpful to have an easy way to keep track of what tasks need attention next. For example, when handling a line of customers, you want to take care of customers in the order they came in, or when managing food stocks, you want to use the oldest food first so it doesn't go bad. These systems are called **queues**, and we use them in programming, too. 

## Why use a queue? 

Queues are useful when: 
- You want to follow a FIFO (first in - first out) order
- You can remove items as you deal with them
- You don't need to access items in the middle of the list

### Following FIFO (First In - First Out)

Let's use the example of customers at a store. 

When working with queues, we have a **Head** and a **Tail**. 

The **Head** is the item at the front of the list. When accessing a task in a Queue, you are accessing the head. 

| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|
| Values | 0  |  1 |  2 |    |    |    |    |    |
|        |Head|    |    |    |    |    |    |    |

(Small note: Queues don't use index like arrays do, but using an index to indicate where the items are in storage can be helpful for understanding how queues manage items. Just know that you'll never be referencing items with indexes.)

The **Tail** is the item at the back of the list. When you add an item to a queue, or **Enqueue,** you are always adding it to the back and it becomes the new tail. 

| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|
| Values | 0  |  1 |  2 |    |    |    |    |    |
|        |Head|    |Tail|    |    |    |    |    |

Adding to the queue: 

| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|
| Values | 0  |  1 |  2 | 3  |    |    |    |    |
|        |Head|    |    |Tail|    |    |    |    |

If this list represented our line of people, we would always take care of the person in the `head` spot first. We'll never take care of spot 2 or 3 before that first spot. 

Now, might be wondering, how do we access the rest of the items in the list if we only ever serve the first one? 

### Removing Items as You Take Care of Them (Dequeue)

In queues, in order to access a new item, you have to remove the one at the head. This is called **Dequeuing**. It would look something like this: 

| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|
| Values |~~-0-~~|  1 |  2 | 3  |    |    |    |    |
|        |Head|    |    |Tail|    |    |    |    |

Now, with value 0 gone, we move the head so that it's connected to the item at the front. 

| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|
| Values |    |  1 |  2 | 3  |    |    |    |    |
|        |    |Head|    |Tail|    |    |    |    |

We can keep going until we are all out of values. When we have something like this: 

| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|
| Values |    |    |    | 3  |    |    |    |    |
|        |    |    |    |Head/Tail|    |    |    |    |

the only remaining value becomes both the head and the tail. 

Because we have to remove items from our head to reach the rest of our queue, we want to use queues when we don't mind removing items as they are dealt with. 

### Accessing, or Adding, items to the middle

Generally, we don't add, remove, or access items in the middle of the list. Items are always added, or **Enqueued**, to the end of the list. Items are always removed, or **Dequeued**, from the beginning of the list. 

This preserves the efficiency of our queue because our program only ever has to find or deal with items at the beginning or end of the list, giving Enqueue and Dequeue both an efficiencey of O(1). 

The downside is that we can't get too fancy with changing items in the middle of our queue. 

Because of that, you want to use queues when you don't mind that restriction. 


## Using Queues

Let's write some code to demonstrate how we use Queues in C#

Because we're using Queues, we have to declare that we are using the namespace `System.Collections.Generic`. This is like the container that holds the template for Queues so that we can use it. 

Once we have that declared, we can make our queue: 

```csharp
using System.Collections.Generic;

Queue<int> myQueue = new Queue<int>();
```

You can make a queue using other datatypes, but for this example, we'll use `int`.

Now, let's trying Enqueue and Dequeue: 

```csharp
myQueue.Enqueue(1);
myQueue.Enqueue(2);
myQueue.Enqueue(3);
myQueue.Enqueue(4);
```

Right now, our list looks like this: 
| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|
| Values | 1  |  2 |  3 | 4  |    |    |    |    |
|        |Head|    |    |Tail|    |    |    |    |

We can remove an item at the front with Dequeue:

```csharp
myQueue.Dequeue();
```

Now our queue looks like this: 

| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|
| Values |    |  2 |  3 | 4  |    |    |    |    |
|        |    |Head|    |Tail|    |    |    |    |

Dequeue takes no arguments, because it only every removes the item at the head. It does, however, return the item that is dequeued. We can grab that item by doing something like this: 

```csharp
int item = myQueue.Dequeue();
```

Now, `item` will hold the number 2, and our queue will look like this: 

| Index  | 0  | 1  | 2  | 3  | 4  | 5  | 6  | 7  |
|--------|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|
| Values |    |    |  3 | 4  |    |    |    |    |
|        |    |    |Head|Tail|    |    |    |    |


## Efficiency of Common Operations

Because of how queues are set up, Enqueue, Dequeue, and many other operations are all O(1). 

This is because we don't have to look through lots of items to find the one we want, since we can look straight at head or tail for everything we need. 

Additionally, since we move head and tail, we don't have to shift items down the storage when we Dequeue like we'd have to with a list. 

.Count() (returns number of items in queue) = O(1)

.Peek() (tells you the next item in the queue without removing it) = O(1)

## Example Problem - Customers 

Before you give this a go on your own, let's walk through one more example of using queues. We have a line of customers and want to keep track of who we are serving next. 

Let's make the queue: 

```csharp
using System.Collections.Generic;

Queue<string> customerQueue = new Queue<string>();
```

This queue will keep track of our customers. Don't forget the first line, `using System.Collections.Generic;`. This is important for making and using a queue! 

Now, let's add some customers. 

```csharp
customerQueue.Enqueue("Sally");
customerQueue.Enqueue("Bethany");
customerQueue.Enqueue("Samuel");
customerQueue.Enqueue("Carl");
```

Now our queue looks like this: `"Sally", "Bethany", "Samuel", Carl"`.

Now, we want to announce that we are ready to serve that customer and remove their name from the queue. 

```csharp
string nextCustomer = customerQueue.Dequeue(); // Returns the next customer and removes them from the list. 
Console.WriteLine($"Now serving {nextCustomer}! ");
```

This will print: 

```
Now Serving Sally! 
```

Sally is now removed from the queue, since she has been served. 

Perhaps we want to give our customers a heads-up that we're almost ready, but don't want to remove their name just yet. 
To do this, we can use Peek(). 

```csharp
string soonCustomer = customerQueue.Peek(); // Returns next customer, but doesn't remove them yet
Console.WriteLine($"We will soon be ready to serve {soonCustomer}.");

string nextCustomer = customerQueue.Dequeue();  
Console.WriteLine($"Now serving {nextCustomer}! ");
```

This will print: 

```
We will soon be ready to serve Bethany.
Now serving Bethany! 
```

Now that we've served two customers, we want to know how many customers are left in the queue. We can do that by saying: 

```csharp
int customerCount = customerQueue.Count(); // Returns number of items in the queue
Console.WriteLine($"There are {customerCount} customers left in the queue.");
```
This will print:

```
There are 2 customers left in the queue.
```

## Practice Problem - Serving Pancakes

Let's imagine we're writing code for a breakfast restaurant. 

This restaurant serves a lot of pancakes and needs a way to keep track of orders coming in. 

In [QueueExample](QueueExample\Program.cs), there are three methods that need to be filled out: ServePancakes(), AddOrder(), and CountOrders(). Fill out these methods practicing queues to complete a program that helps the restaurant add, remove, and track orders. These methods will use all the basic operations of Queues that we've looked at so far. 
You can view the solution [here](QueueExampleSolution\Program.cs). Give the problem a go on your first and use the solution if you get stuck somewhere. Be sure to look at the solution at the end to see how your solution compares to the one provided. 

When you are done, you should be able to run the program and get roughly these outputs: 

```
You added 10 pancakes. You now have 10 ready to serve.
Adding Sam's order of 3 pancakes to the queue!
Adding Jason's order of 4 pancakes to the queue!
Adding Tyler's order of 15 pancakes to the queue!
There are 3 orders left to fulfill.
Served Sam 3 pancakes!
Served Jason 4 pancakes!
You need 12 more pancakes to fulfill Tyler's order!
There are 3 pancakes ready to serve!
You added 20 pancakes. You now have 23 ready to serve.
Served Tyler 15 pancakes!
There are 0 orders left to fulfill.
```