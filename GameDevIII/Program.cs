class Program
{
    static void Main(string[] args)
    {
        // Spawn Fighters
        MeleeFighter meleeFighter = new MeleeFighter("Melee Fighter");
        RangedFighter rangedFighter = new RangedFighter("Ranged Fighter");
        MagicCaster magicCaster = new MagicCaster("Magic Caster");

        // Melee kicks Ranged
        meleeFighter.PerformAttack(rangedFighter, meleeFighter.AttackList[1]);

        // Melee rages Magic Caster
        meleeFighter.Rage(magicCaster);

        // Ranged BB's Melee
        rangedFighter.PerformAttack(meleeFighter, rangedFighter.AttackList[0]);

        // Ranged Dashes
        rangedFighter.Dash();

        // Ranged BB's Melee again
        rangedFighter.PerformAttack(meleeFighter, rangedFighter.AttackList[0]);

        // Magic Caster Fireballs Melee character
        magicCaster.PerformAttack(meleeFighter, magicCaster.AttackList[0]);

        // Magic Caster Heals Ranged
        magicCaster.Heal(rangedFighter);

        // Magic Caster Self-Heal
        magicCaster.Heal(magicCaster);

        // Turn status (HP)
        Console.WriteLine($"{meleeFighter.Name}'s Health: {meleeFighter.Health}");
        Console.WriteLine($"{rangedFighter.Name}'s Health: {rangedFighter.Health}");
        Console.WriteLine($"{magicCaster.Name}'s Health: {magicCaster.Health}");
    }
}