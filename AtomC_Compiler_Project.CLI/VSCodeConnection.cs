namespace AtomC_Compiler_Project.CLI;

public class VsCodeConnection
{
    private static readonly string[] SupportedExtensions=  { ".atomc", ".c" ,".txt"};

    public static string GetSourceCode()
    {
        string baseDirectory =Directory.GetCurrentDirectory();
        var sourceFile = Directory
            .EnumerateFiles(baseDirectory)
            .FirstOrDefault(f => SupportedExtensions.Contains(Path.GetExtension(f)));

        if (sourceFile == null)
        {
            Console.Error.WriteLine("Source file not found");
            Environment.Exit(1);
        }
        return File.ReadAllText(sourceFile);
    }
}