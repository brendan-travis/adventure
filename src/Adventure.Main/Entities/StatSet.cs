namespace Adventure.Main.Entities;

public class StatSet
{
    public StatSet(int attack, int defence)
    {
        this.Attack = attack;
        this.Defence = defence;
    }

    public int Attack { get; set; }

    public int Defence { get; set; }

    public int TotalLevel => this.Attack + this.Defence;
}