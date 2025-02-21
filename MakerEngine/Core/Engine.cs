using Serilog;
using System.Runtime.InteropServices;
using SDL2;

namespace MakerEngine.Core
{
    public class Engine
    {
        public bool IsDebug { get; private set; } = false;
        public string Platform { get; private set; } = string.Empty;

        public void Initialize()
        {
#if DEBUG
            IsDebug = true;
#endif

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Platform = "Windows";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Platform = "Linux";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Platform = "macOS";
            }
            else
            {
                Platform = "Unknown";
            }

            Console.WriteLine("Maker Engine is initializing");

            // Initialize the logger
            if (IsDebug)
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .WriteTo.Debug()
                    .CreateLogger();
            }
            else
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .WriteTo.Debug()
                    .CreateLogger();
            }

            Log.Information("Logger created succesfully");
            Log.Information($"Running in debug mode: {IsDebug.ToString()}");
            Log.Information($"Running on platform: {Platform}");
            // Initialize SDL2
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Log.Fatal($"Failed to initialize SDL2: {SDL.SDL_GetError()}");
                throw new Exception($"Failed to initialize SDL2: {SDL.SDL_GetError()}");
            }

            Log.Information("Maker Engine initialized succesfully");

        }

        public void Shutdown()
        {
            Console.WriteLine("Maker Engine is shutting down");
            SDL.SDL_Quit();
        }
    }
}
