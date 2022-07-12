namespace Adventure.Main.Scenes.Interfaces;

/// <summary>
/// The top level menu serving as the first user-controllable entry point of the application.
/// </summary>
public interface ITitleScene
{
    /// <summary>
    /// Presents the user with a list of actions and branches out from the selected option.
    /// </summary>
    public void ProcessTitleScene();
}