using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace TTCModManager.Lib.GOUtil {
	/// <summary>
	/// API for performing procedural shaking animations on objects.
	/// </summary>
	public static class ShakeFactory {

		/// <summary>
		/// Shakes an object using the <seealso cref="shake"/> component.
		/// </summary>
		/// <param name="obj">The GameObject to shake.</param>
		/// <param name="settings">Settings used for shaking the object.</param>
		/// <returns></returns>
		public static shake ShakeObject(GameObject obj, ShakeSettings settings) {
			shake Shaker = obj.AddComponent<shake>();
			Shaker.infinite = settings.Time == -1f;
			Shaker.time = Shaker.infinite ? 0 : settings.Time;
			Shaker.frequency = settings.Frequency;
			Shaker.amplutude = settings.Amplitude;
			Shaker.smoothTime = settings.SmoothTime;
			return Shaker;
		}

		/// <summary>
		/// Settings used to shake something.
		/// </summary>
		public struct ShakeSettings {
			/// <summary>
			/// Same as <seealso cref="shake.time"/>.
			/// <para>The duration of the shake, in seconds. Set to -1 to make it infinite.</para>
			/// </summary>
			public float Time;
			/// <summary>
			/// Same as <seealso cref="shake.frequency"/>.
			/// <para>The time between changes in position; A lower value makes the object shake quicker.</para>
			/// </summary>
			public float Frequency;
			/// <summary>
			/// Same as <seealso cref="shake.amplutude"/>.
			/// <para>Further experimentation is required to figure out what this does.</para>
			/// </summary>
			public float Amplitude;
			/// <summary>
			/// Same as <seealso cref="shake.smoothTime"/>. Default is <c>0.3f</c>.
			/// <para>Further experimentation is required to figure out what this does.</para>
			/// </summary>
			public float SmoothTime;
			/// <summary>
			/// 
			/// </summary>
			/// <param name="Time"><seealso cref="ShakeSettings.Time"/></param>
			/// <param name="Frequency"><seealso cref="ShakeSettings.Frequency"/></param>
			/// <param name="Amplitude"><seealso cref="ShakeSettings.Amplitude"/></param>
			/// <param name="SmoothTime"><seealso cref="ShakeSettings.SmoothTime"/></param>
			public ShakeSettings(float Time = 0f, float Frequency = 0f, float Amplitude = 0f, float SmoothTime = 0.3f) {
				this.Time = Time;
				this.Frequency = Frequency;
				this.Amplitude = Amplitude;
				this.SmoothTime = SmoothTime;
			}
		}

	}
}
