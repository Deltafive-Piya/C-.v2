public class MeleeFighter : Enemy
{
    public MeleeFighter(string name) : base(name)
    {
        // Set health and add melee fighter attacks
        health = 120;
        AddAttack(new Attack("Spinning Elbow", 20));
        AddAttack(new Attack("Flying Backkick", 15));
        AddAttack(new Attack("Superman Punch", 25));
    }

    public void Rage()
    {
        // Action- New Random (attack +10DA)
        Random random = new Random();
        int randomIndex = random.Next(AttackList.Count);
        Attack chosenAttack = AttackList[randomIndex];
        chosenAttack.DamageAmount += 10;
        PerformAttack(this, chosenAttack);
    }
}