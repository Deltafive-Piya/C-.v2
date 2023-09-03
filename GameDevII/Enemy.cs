// public Enemy #1
public class Enemy
{
    // Every Enemy will consist of stats(.this):
    protected string Name;
    public string _Name { get { return Name; } } //implementation post-error CS0122: 'Enemy.Name' is inaccessible due to its protection level [C:\C#\GameDevI\GameDevI.csproj]
    protected int health;
    public int _health { get { return health; } }
    protected List<Attack> AttackList;

    // public instance
    public Enemy(string name)
    {
        Name = name;
        health = 100;
        AttackList = new List<Attack>();
    }

    // public instance( protected.health)
    public int Health
    {
        get { return health; }
    }

    // Method- Add +1 Fight knowledge
    public void AddAttack(Attack attack)
    {
        AttackList.Add(attack);
    }

    // Action- Random Attack
    public void RandomAttack()
    {
        if (AttackList.Count == 0)
        {
            Console.WriteLine($"{_Name} has no attacks available.");
            return;
        }

        Random random = new Random();
        int randomIndex = random.Next(AttackList.Count);
        Attack selectedAttack = AttackList[randomIndex];

        Console.WriteLine($"{_Name} performs {selectedAttack.Name} for {selectedAttack.DamageAmount} damage!");
    }

    // Action- New attack(target)
    public void PerformAttack(Enemy target, Attack chosenAttack)
    {
        // Reduce the target's health based on the chosen attack's damage amount
        target.health -= chosenAttack.DamageAmount;
        Console.WriteLine($"{Name} attacks {target.Name}, dealing {chosenAttack.DamageAmount} damage and reducing {target.Name}'s health to {target.health}!!");
    }

}