﻿using Adventure.Core.GameplayEngine;
using Adventure.Core.Ui;
using Adventure.Core.Ui.Constants;
using Adventure.Engine.Gameplay.Locales.Towns.TownOfBeginnings.Interfaces;

namespace Adventure.Engine.Gameplay.Core;

public class GameplayManager : IGameplayManager
{
    public GameplayManager(ITitleScreen titleScreen, IMessageWriter messageWriter, ITutorialTower tutorialTower)
    {
        this.TitleScreen = titleScreen;
        MessageWriter = messageWriter;
        TutorialTower = tutorialTower;
    }

    private ITitleScreen TitleScreen { get; }

    private IMessageWriter MessageWriter { get; }

    private ITutorialTower TutorialTower { get; }

    public void StartGame()
    {
        this.TitleScreen.DrawTitleScreen();

        string? chosenOption = null;
        while (chosenOption == null)
        {
            chosenOption = this.TitleScreen.ShowTitleScreenOptions();

            switch (chosenOption)
            {
                case TitleScreenOptions.NewGame:
                    this.MessageWriter.WriteMessage("And so, your adventure begins...");
                    this.MessageWriter.NewSection();
                    this.TutorialTower.InitialFloor();
                    break;
                case TitleScreenOptions.LoadGame:
                    this.MessageWriter.WriteMessage("Loading is not yet implemented, try again later.");
                    this.MessageWriter.WriteBlankLine();
                    chosenOption = null;
                    break;
                case TitleScreenOptions.Debug:
                    this.MessageWriter.WriteMessage("Nothing to debug.");
                    this.MessageWriter.WriteBlankLine();
                    chosenOption = null;
                    break;
                case TitleScreenOptions.Exit:
                    this.MessageWriter.WriteMessage("Shutting down, thanks for playing!");
                    break;
                default:
                    chosenOption = null;
                    break;
            }
        }
    }
}