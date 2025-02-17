# Maker Engine
  Maker Engine is an early-stage 2D game engine written in C#. Originally, I was developing this engine in C++, but since I started to get into C# recently, I decided that I would completely rewrite the engine to be in that language.
  At the moment, the engine is in its initial stages, with basic project structure and some code setup in place. The focus is on laying down the foundation for future features.

  The engine is aimed at beginners while allowing for more advanced features in the future.

## Current Status
   - The foundation of the engine is being developed, with core features such as window creation still in progress. 
   - The engine will use Vulkan for rendering, however no functionality has been implemented yet.
   - The project just started, so there is not much code.

## Planned Features
  - Scripting with Lua
  - An editor implemented with ImGui
  - 3D support 
  - An entity component system
  - Scene management

## Building
  - The IDE I recommend using for building the engine is [Visual Studio](https://visualstudio.microsoft.com/downloads/), since the project is mainly designed for it, but you can still use a different IDE if you would prefer.
  ### Steps to build in Visual Studio:
  1. Clone the repository:
  ```shell
  git clone https://github.com/nugget-png/MakerEngine.git
  ```
 2. Once it is fully downloaded, open the project in Visual Studio.
 3. Ensure all necessary dependencies are set up correctly, then press **F5** to launch the build process. If everything went as expected, you should see a window open and/or build files generated in the project directories.

## License
  This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).
