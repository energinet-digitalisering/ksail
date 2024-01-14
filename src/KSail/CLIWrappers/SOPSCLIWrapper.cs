using CliWrap;
using System.Runtime.InteropServices;

namespace KSail.CLIWrappers;

static class SOPSCLIWrapper
{
  static Command SOPS
  {
    get
    {
      string binary = (Environment.OSVersion.Platform, RuntimeInformation.ProcessArchitecture, RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) switch
      {
        (PlatformID.Unix, Architecture.X64, true) => "sops_darwin-amd64",
        (PlatformID.Unix, Architecture.Arm64, true) => "sops_darwin-arm64",
        (PlatformID.Unix, Architecture.X64, false) => "sops_linux-amd64",
        (PlatformID.Unix, Architecture.Arm64, false) => "sops_linux-arm64",
        _ => throw new PlatformNotSupportedException()
      };
      return Cli.Wrap($"{AppContext.BaseDirectory}assets/binaries/{binary}");
    }
  }

  internal static async Task DecryptAsync(string decrypt)
  {
    if (!File.Exists(decrypt))
    {
      Console.WriteLine($"✖ File '{decrypt}' does not exist");
      Environment.Exit(1);
    }
    var cmd = SOPS.WithArguments($"-d -i {decrypt}");
    _ = await CLIRunner.RunAsync(cmd, silent: true);
  }
  internal static async Task EncryptAsync(string encrypt)
  {
    if (!File.Exists(encrypt))
    {
      Console.WriteLine($"✖ File '{encrypt}' does not exist");
      Environment.Exit(1);
    }
    var cmd = SOPS.WithArguments($"-e -i {encrypt}");
    _ = await CLIRunner.RunAsync(cmd, silent: true);
  }
}