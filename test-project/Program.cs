// See https://aka.ms/new-console-template for more information
using System.Globalization;

// Console.WriteLine("Hello, World!");
// List<string> myList = new List<string>();
// myList.Add("Cats"); // Index 0
// myList.Add("Dogs"); // Index 1
// myList.Add("Butterflies"); // Index 2
// myList[2] = "Caterpillar"; // Also Index = 2

// string critter = "cat";
// Console.WriteLine(critter.GetHashCode());

// HashSet<int> mySet = new HashSet<int>();
// int number = 1;
// mySet.Add(number); // Adds the number to the set
// mySet.Contains(number); // Returns True if it contains number, false if not
// mySet.Count(); // Returns the number of items in the set
// mySet.Remove(number); // Removes the provided number



class PetStock{
    private HashSet<string> _pets = new HashSet<string>(); // This creates our set. 

    public void AddPet(string pet){
        bool wasAdded = _pets.Add(pet); // Will attempt to add the pet and return true/false
        if (wasAdded){
            Console.WriteLine($"{pet} was added to the list!");
        }
        else {
            Console.WriteLine($"{pet} is already in the list.");
        }
    }

    public void RemovePet(string pet){
        bool wasRemoved = _pets.Remove(pet); // Will attempt to remove the pet and return true/false
        if (wasRemoved){
            Console.WriteLine($"{pet} was removed from the list!");
        }
        else {
            Console.WriteLine($"{pet} isn't in this list.");
        }
    }

    public void CheckPet(string pet){
        bool hasPet = _pets.Contains(pet); // Will return true if pet is in the set, and false if not
        if (hasPet){
            Console.WriteLine($"'{pet}' is available!");
        }
        else {
            Console.WriteLine($"'{pet}' is not available at this shop.");
        }
    }

    public void PetCount(){
        int petNum = _pets.Count(); // Returns number of items in _pets, as an int
        Console.WriteLine($"There are {petNum} pets offered at this shop. ");
    }
}

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



