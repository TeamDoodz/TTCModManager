# TTCModManager

TTCModManager (or TTCMM, To The Core Mod Manager) is a BepInEx plugin that allows mods to be loaded into Something Extra's [To The Core](https://somethingextra.itch.io/to-the-cores).

## Compiling

To setup compiling, clone the repository into an empty directory. Next, install [BepInEx 5.4.15](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.15) into your TTC directory. In the root directory of the repo create a folder called `Libs` and copy `0Harmony.dll`, `BepInEx.dll`, `BepInEx.Harmony.dll` (from \<BepInEx dir>/core), `Assembly-CSharp.dll`, `Unity.TextMeshPro.dll`, `UnityEngine.CoreModule.dll`, and `UnityEngine.dll` (from \<TTC dir>/To The Core_Data/Managed).

To actually compile it, open `TTCModManager.sln` in Visual Studio 2019 (Other versions may work, but don't count on it), right-click the solution in the Solution Explorer window, and click "Build Solution".

## Installation

<b>An automated method of doing this is planned.</b>

First make sure BepInEx is installed in your TTC directory. Run TTC once to make sure BepInEx configured correctly. Download the [BepInEx Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager) and follow its installation instructions. Copy-paste `TCCModManager.dll` and `TCCModManager.xml` into \<TTC dir>/BepInEx/plugins/TTCModManager. To confirm TTCMM was succesfully installed you can view the BepInEx console window, it should say "TTCModManager Loaded".
