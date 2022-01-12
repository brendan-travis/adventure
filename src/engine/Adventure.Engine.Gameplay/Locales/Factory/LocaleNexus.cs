using Adventure.Core.GameplayEngine;
using Adventure.Engine.Gameplay.Locales.Towns.Interfaces;

namespace Adventure.Engine.Gameplay.Locales.Factory;

public class LocaleNexus : ILocaleNexus
{
    public LocaleNexus(ITutorialTowerFloor3 tutorialTowerFloor3)
    {
        TutorialTowerFloor3 = tutorialTowerFloor3;
    }

    private ITutorialTowerFloor3 TutorialTowerFloor3 { get; }
    
    public Type GoToLocale(Type locale)
    {
        this.TutorialTowerFloor3.Process();
        
        return locale;
    }
}