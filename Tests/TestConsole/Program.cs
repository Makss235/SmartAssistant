using System.Text;
using TestConsole.Properties;

internal class Program
{
    private static void Main(string[] args)
    {
        byte[] g = (byte[])Resources.ResourceManager.GetObject("Greetings_RU");
        var str = Encoding.Default.GetString(g);
        Console.WriteLine(str);
    }
}