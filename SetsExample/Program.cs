class CerealStock{
    private HashSet<string> _cereals = new HashSet<string>();

    public void AddCereal(string cereal){
        // STEP 1: 
        // Add the new cereal to the set and let the user know if the cereal was added
        // or if the cereal was already in the set. 
    }

    public void RemoveCereal(string cereal){
        // STEP 2:
        // Remove new cereal from the set and let the user know if the cereal was removed
        // or if the cereal wasn't in the set at all. 
    }

    public void CheckCereal(string cereal){
        // STEP 3: 
        // Check to see if the cereal is in the set and let the user know if it is.
        // This should not change the set at all. 
    }

    public void CerealCount(){
        // STEP 4: 
        // Check how many different cereals are in the set and let the user know.
        // This should not change the set at all.
    }

    public void PrintCereals(){
        // STEP 5: 
        // Print out a list of all the cereals for the user. 
        // This should not change the set of cereals at all. 
        // The list of cereals should be printed to the terminal for the user in a neat matter. 
        // You will likely have to use a loop for this. 
    }
}

class Program {
    CerealStock cerealSet = new CerealStock();
    cerealSet.Add("Sail'r Crunch");
    cerealSet.Add("Choco Puffs");
    cerealSet.Add("Happy O's")
    cerealSet.Add("Honey Clumps of Oats");
    cerealSet.Add("Frosted Chips");
    Console.WriteLine();

    cerealSet.CerealCount();
    Console.WriteLine();

    CerealSet.CheckCereal("Honey Clumps of Oats");
    CerealSet.Remove("Honey Clumps of Oats");
    CerealSet.CheckCereal("Honey Clumps of Oats");
    Console.WriteLine();
    
    cerealSet.PrintCereals();
    cerealSet.CerealCount();
}



