using System;
using System.Collections.Generic;
using System.Text;

namespace TTCModManager.Lib.Math {
	/// <summary>
	/// Polar coordinate system. <seealso ref="https://en.wikipedia.org/wiki/Polar_coordinate_system"/>
	/// </summary>
	public struct PolarPos {

		/// <summary>
		/// The angle of the position, usually relative to the global Y axis.
		/// </summary>
		public float Angle;

		/// <summary>
		/// The distance to the pole, which is usually the Core.
		/// </summary>
		public float Distance;

		/// <summary>
		/// Polar coordinate system.
		/// </summary>
		/// <param name="Angle">The angle of the position, usually relative to the global Y axis.</param>
		/// <param name="Distance">The distance to the pole, which is usually the Core.</param>
		public PolarPos(float Angle, float Distance) {
			this.Angle = Angle;
			this.Distance = Distance;
		}

	}
}
