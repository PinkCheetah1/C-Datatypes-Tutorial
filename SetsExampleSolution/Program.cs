class CerealStock{
    private HashSet<string> _cereals = new HashSet<string>();

    public void AddCereal(string cereal){
        bool wasAdded = _cereals.Add(cereal);
        if (wasAdded){
            Console.WriteLine($"{cereal} is now in stock.");
        }
        else {
            Console.WriteLine($"{cereal} is already in stock.");
        }
    }

    public void RemoveCereal(string cereal){
        bool wasRemoved = _cereals.Remove(cereal);
        if (wasRemoved){
            Console.WriteLine($"{cereal} is not longer in stock. ");
        }
        else{
            Console.WriteLine($"{cereal} is already out of stock. ");
        }
    }

    public void CheckCereal(string cereal){
        bool hasCereal = _cereals.Contains(cereal);
        if (hasCereal){
            Console.WriteLine($"{cereal} is in stock!");    
        }
        else{
            Console.WriteLine($"{cereal} is not in stock.");
        }
    }

    public void CerealCount(){
        int cerealNum = _cereals.Count();
        Console.WriteLine("There are {cerealNum} cereal(s) in stock! ");
    }

    public void PrintCereals(){
        Console.WriteLine("The following cereals are in stock: ");
        foreach (string cereal in _cereals){
            Console.WriteLine(cereal);
        }
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