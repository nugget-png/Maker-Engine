using SDL2;
using Serilog;

namespace MakerEngine.Application
{
    public class Window : IDisposable
    {
        public IntPtr Handle { get; private set; }
        public bool IsOpen { get; set; } = true;

        private bool _disposed;

        public Window(string title, int width, int height)
        {
            Handle = SDL.SDL_CreateWindow(
                title,
                SDL.SDL_WINDOWPOS_CENTERED, // X
                SDL.SDL_WINDOWPOS_CENTERED, // Y
                width,
                height,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN // Flags
            );

            if (Handle == IntPtr.Zero)
            {
                Log.Fatal($"Failed to create SDL2 window: {SDL.SDL_GetError()}");
                throw new Exception($"Failed to create SDL2 window: {SDL.SDL_GetError()}");
            }

            Log.Information("Window created succesfully");
        }

        public void ProcessEvents()
        {
            SDL.SDL_Event e;
            while (IsOpen)
            {
                while (SDL.SDL_PollEvent(out e) != 0)
                {
                    if (e.type == SDL.SDL_EventType.SDL_QUIT)
                    {
                        IsOpen = false;
                    }
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (Handle != IntPtr.Zero)
                {
                    SDL.SDL_DestroyWindow(Handle);
                }
            }

            _disposed = true;
        }

        ~Window()
        {
            Dispose(false);
        }
    }
}
