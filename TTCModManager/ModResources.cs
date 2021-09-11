using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TTCModManager.Core;
using UnityEngine;

namespace TTCModManager.Lib.IO {
	/// <summary>
	/// Static class for loading a mod's assets.
	/// </summary>
	public static class ModResources {

		//TODO: Fix this (use WWW instead of Resources)
		/*
		/// <summary>
		/// Loads resource &lt;Game path&gt;/Mods/TTCModManager/&lt;Mod Name&gt;/Assets/&lt;path&gt;. If you are just loading plaintext files try using 
		/// <para>File extensions must be omitted - this is just how Unity works.</para>
		/// </summary>
		/// <typeparam name="TMod">The mod to load assets from.</typeparam>
		/// <param name="path">The path to the resource, relative to the Asset folder of the mod. File extensions must be omitted.</param>
		/// <returns>The resource found. If none is found returns null.</returns>
		public static Object LoadAsset<TMod>(string path) where TMod : TTCMod {
			string data = TTCModManagerMain.ModsDir + "\\" + typeof(TMod).Name + "\\Assets\\" + Regex.Replace(path,"/","\\");
			TTCModManagerMain.CoreLogger.LogInfo(data);
			return Resources.Load(data);
		}
		*/

		/// <summary>
		/// Loads a file using System.IO.
		/// </summary>
		/// <typeparam name="TMod">The mod to load assets from.</typeparam>
		/// <param name="path">The path to the file, relative to the Asset folder of the mod. Include extensions.</param>
		/// <param name="encoding">What encoding does the file use? If this method returns random garbage data try adjusting this value.</param>
		/// <returns>The contents of the found file, or null if no such file exists.</returns>
		public static string LoadTextFile<TMod>(string path, Encoding encoding) {
			string data = TTCModManagerMain.ModsDir + "\\" + typeof(TMod).Name + "\\Assets\\" + Regex.Replace(path, "/", "\\");
			return File.ReadAllText(data, encoding);
		}

		/// <summary>
		/// If file is null, returns fallback. Otherwise returns file.text.
		/// <para>If the file is null this is either because it cannot be casted to <see cref="TextAsset"/> or does not exist.</para>
		/// </summary>
		/// <param name="file">The file to read.</param>
		/// <param name="fallback">The string to return if file is null. Defaults to an empty string.</param>
		/// <returns>The safely read string.</returns>
		public static string SafeReadPlaintext(this TextAsset file, string fallback = "") {
			if (file == null) return fallback;
			return file.text;
		}

	}
}
