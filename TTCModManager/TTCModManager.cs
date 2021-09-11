using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using TMPro;
using TTCModManager.Lib;
using UnityEngine;

namespace TTCModManager.Core {

	/// <summary>
	/// Core TTCMM BepInEx plugin.
	/// </summary>
	[BepInPlugin("io.github.TeamDoodz.TTCModManager", "TTCModManager", "0.0.0")]
	[BepInProcess("To The Core.exe")]
	public class TTCModManagerMain : BaseUnityPlugin {

		/// <summary>
		/// Directory where all mods should be stored.
		/// </summary>
		public static string ModsDir;

		/// <summary>
		/// All mod classes loaded into To The Core.
		/// </summary>
		public static List<Type> Mods = new List<Type>();

		/// <summary>
		/// All mod assemblies` loaded into To The Core.
		/// </summary>
		public static List<Assembly> ModAssemblies = new List<Assembly>();

		/// <summary>
		/// Use this to console log.
		/// </summary>
		public static ManualLogSource CoreLogger;

		private ConfigEntry<bool> replaceDeathText;

		private void Awake() {
			Logger.LogInfo("TTCModManager Loaded");

			CoreLogger = Logger;

			replaceDeathText = Config.Bind("General","ReplaceDeathText",true,"Whether or not to replace the death text with free advertising. <b>Requires a restart to take effect.</b>");

			if(replaceDeathText.Value) new ChangeDeathTextPatch().Patch();

			LoadAllMods();
		}

		private void LoadAllMods() {
			Logger.LogInfo("Loading mods...");

			Logger.LogInfo($"Working Directory: {Directory.GetCurrentDirectory()}");

			ModsDir = Directory.GetCurrentDirectory() + "\\Mods\\TTCModManager";
			Logger.LogInfo($"Mods directory: {ModsDir}");

			string[] modFolders = Directory.GetDirectories(ModsDir);
			Logger.LogInfo($"Mods found: {modFolders.Length}");

			Logger.LogInfo("----PRELOAD PHASE----");

			foreach(var modDir in modFolders) {
				string modID = Regex.Replace(modDir, @"[\d\D]+[/\\]", "");
				Logger.LogInfo($"Loading mod {modID}");

				try {
					Assembly DLL = Assembly.LoadFile(modDir + "\\" + modID + ".dll");

					foreach (Type type in DLL.GetExportedTypes()) {
						if (type.IsSubclassOf(typeof(TTCMod))) {
							Mods.Add(type);
							ModAssemblies.Add(DLL);
							var c = Activator.CreateInstance(type);
							type.InvokeMember("Preload", BindingFlags.InvokeMethod, null, c, new object[] { });
						}
					}
					Logger.LogInfo($"{modID} successfully loaded");
				} catch (Exception e) {
					Logger.LogWarning(e.ToString());
					Logger.LogWarning($"There was an error loading {modID}. It will be skipped.");
				}
			}
			
		}

		/// <summary>
		/// Harmony patch that changes the death text to "TTCModManager by TeamDoodz".
		/// </summary>
		[HarmonyPatch(typeof(DeathSceneManager))]
		[HarmonyPatch("Awake")]
		private class ChangeDeathTextPatch {

			public void Patch() {
				var harmony = new Harmony("io.github.TeamDoodz.TTCModManager.ChangeDeathTextPatch");
				harmony.PatchAll();
			}

#pragma warning disable IDE0051 // Remove unused private members
			static void Postfix(ref TextMeshPro ___deathmessageT) {
#pragma warning restore IDE0051 // Remove unused private members
				___deathmessageT.text = "<color=red>TTCModManager by TeamDoodz</color>";
				___deathmessageT.fontSize = 10;
			}

		}
	}
}
