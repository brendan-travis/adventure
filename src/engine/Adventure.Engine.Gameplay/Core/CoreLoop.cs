using Adventure.Core.GameplayEngine;
using Adventure.Engine.Gameplay.Locales.Towns;

namespace Adventure.Engine.Gameplay.Core;

public class CoreLoop : ICoreLoop
{
    public CoreLoop(ILocaleNexus localeNexus)
    {
        LocaleNexus = localeNexus;
    }

    private Type CurrentLocale { get; set; } = typeof(TutorialTowerFloor3);

    private ILocaleNexus LocaleNexus { get; }
    
    public void StartLoop()
    {
        while (true)
        {
            this.CurrentLocale = this.LocaleNexus.GoToLocale(this.CurrentLocale);
        }
    }
}