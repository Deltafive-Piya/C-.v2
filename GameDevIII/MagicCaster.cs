public class MagicCaster : Enemy
{
    public MagicCaster(string name) : base(name)
    {
        // Set health and add magic caster attacks
        health = 80;
        AddAttack(new Attack("Fireball", 25));
        AddAttack(new Attack("Lightning Bolt", 20));
        AddAttack(new Attack("Staff Strike", 10));
    }

    public void Heal(Enemy target)
    {
        // Heal target character 40 health
        target.health += 40;
        Console.WriteLine($"{Name} heals {target.Name} for 40 health. {target.Name}'s health is now {target.health}.");
    }
}