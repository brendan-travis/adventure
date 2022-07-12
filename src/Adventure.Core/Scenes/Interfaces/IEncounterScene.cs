using Adventure.Core.Entities;

namespace Adventure.Core.Scenes.Interfaces;

public interface IEncounterScene
{
    void ProcessEncounter(Entity player, Entity opponent);
}