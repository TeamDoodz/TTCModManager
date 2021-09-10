using System;
using System.Collections.Generic;
using System.Text;

namespace TTCModManager.Lib.Patching {

	/// <summary>
	/// It is recomended to make your patcher a class inheriting from this.
	/// </summary>
	public interface IModPatch {

		/// <summary>
		/// Place your harmony patching code here.
		/// </summary>
		void Patch();

	}
}
