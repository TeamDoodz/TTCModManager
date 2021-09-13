using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace TTCModManager.Lib.Monobehaviours {
	/// <summary>
	/// Base class for making custom collectables; things that do an action and delete themselves when touched by the player. You will still have to write your own code to actually get your object generated on the planet.
	/// </summary>
	public class ModdedCollectable : MonoBehaviour {

		/// <summary>
		/// The tag used to figure out if an object is the player.
		/// </summary>
		protected string PlayerTag = "Player";

		/// <summary>
		/// Wheather or not to destroy this GameObject when collected. This can cause weird issues when turned off!
		/// </summary>
		protected bool DestroyOnCollected = true;

		/// <summary>
		/// Called by Unity when this object collides with another.
		/// </summary>
		/// <param name="other">The other collider in the collision.</param>
		protected void OnTriggerEnter2D(Collider2D other) {
			// Component.CompareTag() is more effecient
			if(other.CompareTag(PlayerTag)) {
				ApplyCollectable();
				if(DestroyOnCollected) Destroy(gameObject);
			}
		}

		/// <summary>
		/// Called when this object is collected, right before it is destroyed. This is where you would usually place your stat buffs and etc.
		/// </summary>
		protected void ApplyCollectable() {
			
		}
	}
}
