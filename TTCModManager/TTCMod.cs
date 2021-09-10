using System;
using System.Collections.Generic;
using System.Text;
using TTCModManager.Core;

namespace TTCModManager.Lib {
	/// <summary>
	/// A mod that can be loaded by TTCModManager.
	/// </summary>
	public abstract class TTCMod {

		/// <summary>
		/// Place any Harmony patches here.
		/// </summary>
		public abstract void Preload();

		/// <summary>
		/// Prints info message to the BepInEx console.
		/// </summary>
		/// <param name="msg">The message to print.</param>
		public void LogInfo(object msg) {
			TTCModManagerMain.CoreLogger.LogInfo($"[{this.GetType().Name}] {msg}");
		}

	}
}
