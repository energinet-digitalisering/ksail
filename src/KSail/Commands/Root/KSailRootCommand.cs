using System.CommandLine;
using KSail.Commands.Check;
using KSail.Commands.Down;
using KSail.Commands.Lint;
using KSail.Commands.List;
using KSail.Commands.Root.Handlers;
using KSail.Commands.SOPS;
using KSail.Commands.Start;
using KSail.Commands.Stop;
using KSail.Commands.Up;
using KSail.Commands.Update;

namespace KSail.Commands.Root;

internal sealed class KSailRootCommand : RootCommand
{
  internal KSailRootCommand(IConsole? console = null) : base("KSail is a CLI tool for provisioning GitOps enabled K8s clusters in Docker.")
  {
    AddCommands();

    this.SetHandler(async () =>
      {
        KSailRootCommandHandler.Handle(console);
        _ = await this.InvokeAsync("--help", console);
      }
    );
  }

  private void AddCommands()
  {
    AddCommand(new KSailUpCommand());
    AddCommand(new KSailStartCommand());
    AddCommand(new KSailStopCommand());
    AddCommand(new KSailListCommand());
    AddCommand(new KSailDownCommand());
    AddCommand(new KSailUpdateCommand());
    AddCommand(new KSailLintCommand());
    AddCommand(new KSailCheckCommand());
    AddCommand(new KSailSOPSCommand());
  }
}