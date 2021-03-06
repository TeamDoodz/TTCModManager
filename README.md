# <img src= "https://github.com/TeamDoodz/TTCModManager/blob/master/TTCModManager/logo.png?raw=true" width="30" height="30"/> TTCModManager
![GitHub](https://img.shields.io/github/license/TeamDoodz/TTCModManager)
[![PRs Welcome](http://img.shields.io/badge/PRs-welcome-brightgreen)](http://makeapullrequest.com)
![Lines of code](https://img.shields.io/tokei/lines/github/TeamDoodz/TTCModManager)

TTCModManager (or TTCMM, To The Core Mod Manager) is a BepInEx plugin that allows mods to be loaded into Something Extra's [To The Core](https://somethingextra.itch.io/to-the-cores).

## Compiling

To setup compiling, clone the repository into an empty directory. Next, install [BepInEx 5.4.15](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.15) into your TTC directory. In the root directory of the repo create a folder called `Libs` and copy `0Harmony.dll`, `BepInEx.dll`, `BepInEx.Harmony.dll` (from \<BepInEx dir>/core), `Assembly-CSharp.dll`, `Unity.TextMeshPro.dll`, `UnityEngine.CoreModule.dll`, `UnityEngine.ImageConversionModule.dll` `UnityEngine.Physics2DModule.dll` and `UnityEngine.dll` (from \<TTC dir>/To The Core_Data/Managed).

To actually compile it, open `TTCModManager.sln` in Visual Studio 2019 (Other versions may work, but don't count on it), right-click the solution in the Solution Explorer window, and click "Build Solution".

## Installation

<b>An automated method of doing this is planned.</b>

First make sure BepInEx is installed in your TTC directory. Run TTC once to make sure BepInEx configured correctly. Download the [BepInEx Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager) and follow its installation instructions. Copy-paste `TTCModManager.dll` and `TTCModManager.xml` into \<TTC dir>/BepInEx/plugins/TTCModManager.

Finally, create a folder in your TTC directory called "Mods", and in that "TTCModManager". That directory is where all mods will be installed.

To confirm TTCMM was succesfully installed you can view the BepInEx console window, it should say "TTCModManager Loaded". Press F1 in-game to view config settings.
