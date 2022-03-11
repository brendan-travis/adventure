using Adventure.Locales.Base;
using Adventure.Locales.Towns.ArcViridian;
using Adventure.UserInterface;

UiManager.StatusBar.CharacterName = "Arven the Hero";
UiManager.StatusBar.Level = "1";
UiManager.StatusBar.HealthPoints = "48";
UiManager.StatusBar.HealthPointsTotal = "50";
UiManager.StatusBar.Stamina = "20";
UiManager.StatusBar.StaminaTotal = "20";

UiManager.DrawUi();


ILocale currentLocation = new ArcViridian();
while (true)
{
    currentLocation = currentLocation.GoTo();
}
