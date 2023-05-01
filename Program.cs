using System.Diagnostics;

namespace NtAuthority
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length < 1)
        throw new Exception("Must specify BinPath");
      string binaryPath = args[0];
      string ProcessToSpoof = args.Length > 1 ? args[1] : "winlogon";
      int parentProcessId;
      Process[] explorerproc = Process.GetProcessesByName(ProcessToSpoof);
      parentProcessId = explorerproc[0].Id;
      Elevator.Run(parentProcessId, binaryPath, args.Length > 2 ? (args[2] == "hidden" || args[2] == "hide" || args[2] == "noshow") : false);
    }
  }
}
