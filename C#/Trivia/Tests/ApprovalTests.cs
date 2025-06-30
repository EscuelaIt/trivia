using System;
using System.IO;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace Tests;

[UseReporter(typeof(DiffReporter))]
public class ApprovalTests
{
    [Fact]
    public void GameRunnerEntryPointTest()
    {
        // Redirect console output
        var writer = new StringWriter();
        Console.SetOut(writer);

        // Run the game
        Trivia.GameRunner.Main(Array.Empty<string>());

        // Capture the output
        var output = writer.ToString();

        // Verify the output against the approved file
        Approvals.Verify(output);
    }
}