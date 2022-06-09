using System.Collections.Generic;
using Adventure.Core.Scenes;
using Adventure.Core.UserInterface.Interfaces;
using NSubstitute;
using Xunit;

namespace Adventure.Core.UnitTests.Scenes;

public class TitleScreenTests
{
    #region ProcessTitleScreen

    [Fact]
    public void ProcessTitleScreen_WhenCalled_DisplaysOptionsViaMessageReader()
    {
        // Arrange / Act
        this.GetSystemUnderTest().ProcessTitleScreen();
        
        // Assert
        this.MessageReader.Received(1).ShowChoices(Arg.Any<List<string>>());
    }

    #endregion
    
    #region Setup

    private TitleScreen GetSystemUnderTest() => new(this.MessageReader);

    private IMessageReader MessageReader { get; } = Substitute.For<IMessageReader>();

    #endregion
}