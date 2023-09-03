class Program
{
    static void Main(string[] args)
    {
        // Create an instance of an Enemy
        Enemy enemy = new Enemy("Bandit");

        // Create 3 instances of Attacks
        Attack fireball = new Attack("Fireball", 20);
        Attack punch = new Attack("Punch", 10);
        Attack throwAttack = new Attack("Throw", 15);

        // Add these Attacks to the Enemy's Attack List
        enemy.AddAttack(fireball);
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