using System.CommandLine;
using KSail.Commands.List;
using KSail.Commands.Up;

namespace KSail.Tests.Integration.Commands.List;

/// <summary>
/// Tests for the <see cref="KSailUpCommand"/> class.
/// </summary>
public class KSailListCommandTests : IAsyncLifetime
{
  /// <inheritdoc/>
  public Task DisposeAsync() => Task.CompletedTask;
  /// <inheritdoc/>
  public Task InitializeAsync() => Task.CompletedTask;

  /// <summary>
  /// Tests that the <c>ksail up [clusterName]</c> command succeeds and creates a cluster.
  /// </summary>
  [Fact]
  public async Task KSailList_SucceedsAndListsClusters()
  {
    //Arrange
    var ksailListCommand = new KSailListCommand();

    //Act
    int exitCode = await ksailListCommand.InvokeAsync("");

    //Assert
    Assert.Equal(0, exitCode);
  }
}