using System.Globalization;

namespace Adventure.Main.Entities;

public class Skill
{
    private readonly string _name;
    private readonly TextInfo _textInfo = CultureInfo.CurrentCulture.TextInfo;

    public Skill(string name)
    {
        this._name = name;
    }

    public string Name => this._textInfo.ToTitleCase(this._name);
}