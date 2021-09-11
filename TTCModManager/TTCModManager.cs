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
	[BepInPlugin("io.github.TeamDoodz.TTCModManager", "TTCModManager", TTCMMVersion)]
	[BepInProcess("To The Core.exe")]
	public class TTCModManagerMain : BaseUnityPlugin {

		/// <summary>
		/// What version of TTCMM are we using?
		/// </summary>
		public const string TTCMMVersion = "0.1.0";

		/// <summary>
		/// There should only be one instance of TTCModManagerMain. Use this field to access it.
		/// </summary>
		public static TTCModManagerMain instance;

		/// <summary>
		/// Directory where all mods should be stored.
		/// </summary>
		public static string ModsDir;

		/// <summary>
		/// All mod classes loaded into To The Core.
		/// </summary>
		public static List<TTCMod> Mods = new List<TTCMod>();

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
			if(instance == null) {
				instance = this;
			} else {
				Logger.LogWarning("Instance != null! This is likely because there are two instances of TTCModManagerMain, which shouldn't happen. (Is a mod causing this?)");
				Destroy(this);
			}
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

			Logger.LogMessage("----PRELOAD PHASE----");

			foreach(var modDir in modFolders) {
				string modID = Regex.Replace(modDir, @"[\d\D]+[/\\]", "");
				Logger.LogInfo($"Loading mod {modID}");

				try {
					Assembly DLL = Assembly.LoadFile(modDir + "\\" + modID + ".dll");

					foreach (Type type in DLL.GetExportedTypes()) {
						if (type.IsSubclassOf(typeof(TTCMod))) {
							ModAssemblies.Add(DLL);

							var c = Activator.CreateInstance(type);
							Mods.Add((TTCMod)c);

							type.GetProperty("Logger").SetValue(c, new TTCLogger(modID), null);

							type.InvokeMember("Preload", BindingFlags.InvokeMethod, null, c, new object[] { });
						}
					}
					Logger.LogInfo($"{modID} successfully loaded");
				} catch (Exception e) {
					Logger.LogWarning(e.ToString());
					Logger.LogWarning($"There was an error loading {modID}. It will be skipped.");
				}
			}

			Logger.LogMessage("----POSTLOAD PHASE----");

			foreach(var mod in Mods) {
				string modID = mod.GetType().Name;
				Logger.LogInfo($"Attempting to post-load {modID}");

				try {
					mod.PostLoad();
				} catch (Exception e) {
					Logger.LogWarning(e.ToString());
					Logger.LogWarning($"There was an error post-loading {modID}.");
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
