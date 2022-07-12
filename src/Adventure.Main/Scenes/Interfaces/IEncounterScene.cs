using Adventure.Main.Entities;

namespace Adventure.Main.Scenes.Interfaces;

public interface IEncounterScene
{
    void ProcessEncounter(Entity player, Entity opponent);
}