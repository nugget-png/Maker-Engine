using Serilog;
using System.Runtime.InteropServices;

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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.Debug()
                .CreateLogger();

            Log.Information("Logger created succesfully");
            Log.Information($"Running in debug mode: {IsDebug.ToString()}");

            Log.Information("Maker Engine initialized succesfully");

        }

        public void Shutdown()
        {
            Console.WriteLine("Maker Engine is shutting down");
        }
    }
}
