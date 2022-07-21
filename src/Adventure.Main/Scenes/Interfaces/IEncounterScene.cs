using Adventure.Main.Entities;

namespace Adventure.Main.Scenes.Interfaces;

public interface IEncounterScene
{
    void ProcessEncounter(PlayableEntity player, IList<NonPlayableEntity> opponents);
}