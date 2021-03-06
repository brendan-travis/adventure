using System.Globalization;

namespace Adventure.Main.Entities;

public class Skill
{
    private readonly string _name;
    private readonly TextInfo _textInfo = CultureInfo.CurrentCulture.TextInfo;

    public Skill(string name, float minimumDamageModifier, float maximumDamageModifier, int staminaCost)
    {
        this._name = name;
        this.MinimumDamageModifier = minimumDamageModifier;
        this.MaximumDamageModifier = maximumDamageModifier;
        this.StaminaCost = staminaCost;
    }

    public string Name => this._textInfo.ToTitleCase(this._name);

    public float MinimumDamageModifier { get; }
    
    public float MaximumDamageModifier { get; }

    public int StaminaCost { get; set; }
}