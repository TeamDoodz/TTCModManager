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
		/// Allows mods to interface with the BepInEx console.
		/// </summary>
		public TTCLogger Logger { get; set; }

		/// <summary>
		/// Called as the mod is loaded.
		/// </summary>
		public virtual void Preload() { }

		/// <summary>
		/// Called after all mods have been loaded.
		/// </summary>
		public virtual void PostLoad() { }

	}
}
