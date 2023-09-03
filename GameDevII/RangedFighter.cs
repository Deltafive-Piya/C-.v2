public class RangedFighter : Enemy
{
    public int Distance { get; private set; }

    public RangedFighter(string name) : base(name)
    {
        // Set health, distance, and add ranged fighter attacks
        health = 100;
        Distance = 5;
        AddAttack(new Attack("BB bullets", 20));
        AddAttack(new Attack("Slingshot", 15));
    }

    public void Dash()
    {
        // Perform a dash and set distance to 20
        Distance = 20;
        Console.WriteLine($"{Name} performs a dash and sets distance to {Distance}.");
    }
}