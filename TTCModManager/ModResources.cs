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

		/// <summary>
		/// Converts a path relative to a mod's assets forlder to an abesolute path.
		/// </summary>
		/// <typeparam name="TMod">The mod to convert.</typeparam>
		/// <param name="inputPath">The path specified.</param>
		/// <returns></returns>
		public static string ModAssetPath<TMod>(string inputPath) {
			return TTCModManagerMain.ModsDir + "\\" + typeof(TMod).Name + "\\Assets\\" + Regex.Replace(inputPath, "/", "\\");
		}

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
			return File.ReadAllText(ModAssetPath<TMod>(path), encoding);
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

		/// <summary>
		/// Loads a PNG/JPG file from the mod's Assets folder.
		/// </summary>
		/// <param name="path">The path to the texture, relative to the mod's Assets folder.</param>
		/// <returns>A <see cref="Texture2D"/> representing the texture data.</returns>
		// from https://forum.unity.com/threads/generating-sprites-dynamically-from-png-or-jpeg-files-in-c.343735/
		public static Texture2D LoadTexture<TMod>(string path) {

			// Load a PNG or JPG file from disk to a Texture2D
			// Returns null if load fails

			Texture2D Tex2D;
			byte[] FileData;

			if (File.Exists(ModAssetPath<TMod>(path))) {
				FileData = File.ReadAllBytes(ModAssetPath<TMod>(path));
				Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
				if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
					return Tex2D;                 // If data = readable -> return texture
			}
			return null;                     // Return null if load failed
		}

		/// <summary>
		/// Loads a PNG/JPG file from the mod's Assets folder, as a <see cref="Sprite"/>.
		/// </summary>
		/// <param name="path">The path to the texture, relative to the mod's Assets folder.</param>
		/// <param name="PixelsPerUnit">The pixels per unit of the sprite. In TTC this <i>should</i> be 16f.</param>
		/// <returns>A <see cref="Sprite"/> representing the texture data.</returns>
		// from https://forum.unity.com/threads/generating-sprites-dynamically-from-png-or-jpeg-files-in-c.343735/
		public static Sprite LoadNewSprite<TMod>(string path, float PixelsPerUnit = 16f) {

			// Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference

			Sprite NewSprite;
			//TTCModManagerMain.CoreLogger.LogInfo(ModAssetPath<TMod>(path));
			Texture2D SpriteTexture = LoadTexture<TMod>(path);
			NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);

			return NewSprite;
		}

	}
}
