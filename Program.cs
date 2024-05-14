using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Task task1 = RunDotnetTest("--environment \"browser=chrome\"");
        Task task2 = RunDotnetTest("--environment \"browser=firefox\"");

        await Task.WhenAll(task1, task2);

        Console.WriteLine("Both dotnet test commands have completed.");
    }

    static async Task RunDotnetTest(string arguments)
    {
        Process process = new Process();
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = $"test {arguments}";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;

        process.Start();

        string output = await process.StandardOutput.ReadToEndAsync();
        process.WaitForExit();

        Console.WriteLine($"Output of 'dotnet test {arguments}':");
        Console.WriteLine(output);
    }
}
