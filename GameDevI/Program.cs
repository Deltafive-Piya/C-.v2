class Program
{
    static void Main(string[] args)
    {
        // Create an instance of an Enemy
        Enemy enemy = new Enemy("Bandito Fuego");

        // Create 3 instances of Attacks
        Attack special = new Attack("Fireball", 20);
        Attack punch = new Attack("Chankla clap", 10);
        Attack throwAttack = new Attack("NageTobashi", 15);

        // Add these Attacks to the Enemy's Attack List
        enemy.AddAttack(special);
        enemy.AddAttack(punch);
        enemy.AddAttack(throwAttack);

        // Test RandomAttack method
        Console.WriteLine($"{enemy._Name}'s Health: {enemy.Health}");
        enemy.RandomAttack();
        enemy.RandomAttack();
        enemy.RandomAttack();
        Console.WriteLine($"{enemy._Name}'s Health: {enemy.Health}");
    }
}