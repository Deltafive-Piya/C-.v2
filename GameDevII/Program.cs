class Program
{
    static void Main(string[] args)
    {
    // Create instances of different enemy types
    MeleeFighter meleeFighter = new MeleeFighter("Melee Dude");
    RangedFighter rangedFighter = new RangedFighter("Archer");
    MagicCaster magicCaster = new MagicCaster("Wizard");

    // Perform actions as specified in the assignment
    meleeFighter.PerformAttack(rangedFighter, meleeFighter.AttackList[1]); // Kick attack
    meleeFighter.Rage();
    rangedFighter.PerformAttack(meleeFighter, rangedFighter.AttackList[0]); // ranged bb bullets (shouldn't work due to distance)
    rangedFighter.Dash();
    rangedFighter.PerformAttack(meleeFighter, rangedFighter.AttackList[0]); // successfull BB's
    magicCaster.PerformAttack(meleeFighter, magicCaster.AttackList[0]); // Fireball attack
    magicCaster.Heal(rangedFighter); // Heal ranged fighter
    magicCaster.Heal(magicCaster); // Heal self
}
}