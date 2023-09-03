public class Attack
{
    //fields
    public string Name { get; }
    public int DamageAmount { get; }

    //Constructor
    public Attack(string name, int damageAmount)
    {
        Name = name;
        DamageAmount = damageAmount;
    }
}
