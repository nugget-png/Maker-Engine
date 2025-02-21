using MakerEngine;
using MakerEngine.Core;
using MakerEngine.Application;
using SDL2;

namespace MakerEngine.Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Engine engine = new Engine();
                engine.Initialize();

                using (var window = new Window("Test Window", 1280, 720))
                {
                    window.ProcessEvents();
                }

                engine.Shutdown();
            }
            catch (Exception ex)
            {
                SDL.SDL_ShowSimpleMessageBox(
                    SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_ERROR, 
                    "Fatal Engine Error", 
                    ex.Message, 
                    IntPtr.Zero
                );
            }
        }
    }
}
