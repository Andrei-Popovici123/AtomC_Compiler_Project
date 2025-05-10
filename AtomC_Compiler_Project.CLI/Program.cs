namespace AtomC_Compiler_Project.CLI;

public class Program
{
    public static void Main(string[] args)
    {
        string code = VsCodeConnection.GetSourceCode();

        Console.WriteLine("=== AtomC Source ===");
        Console.WriteLine(code);
        Console.WriteLine("====================");

    }
}