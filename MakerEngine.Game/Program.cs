using MakerEngine.Core;

namespace MakerEngine.Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Initialize();
            Console.WriteLine("Hello, World!");
            engine.Shutdown();
        }
    }
}
