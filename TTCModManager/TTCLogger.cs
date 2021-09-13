using System;
using System.Collections.Generic;
using System.Text;
using TTCModManager.Core;

namespace TTCModManager.Lib {
	/// <summary>
	/// Interfaces with <seealso cref="TTCModManagerMain.CoreLogger"/>.
	/// </summary>
	public class TTCLogger {

		/// <summary>
		/// Creates a TTCLogger with prefix Prefix.
		/// </summary>
		/// <param name="Prefix">The prefix to use.</param>
		public TTCLogger(string Prefix) {
			this.Prefix = Prefix;
		}

		/// <summary>
		/// Prefix used by the logger.
		/// </summary>
		public string Prefix = "Unnamed Logger";

		/// <summary>
		/// Logs info to the console.
		/// </summary>
		/// <param name="msg">The message to log.</param>
		public void LogInfo(object msg) {
			TTCModManagerMain.CoreLogger.LogInfo($"[{Prefix}] {msg}");
		}

		/// <summary>
		/// Logs debug to the console.
		/// </summary>
		/// <param name="msg">The message to log.</param>
		public void LogDebug(object msg) {
			TTCModManagerMain.CoreLogger.LogDebug($"[{Prefix}] {msg}");
		}

		/// <summary>
		/// Logs warning to the console.
		/// </summary>
		/// <param name="msg">The message to log.</param>
		public void LogWarning(object msg) {
			TTCModManagerMain.CoreLogger.LogWarning($"[{Prefix}] {msg}");
		}

		/// <summary>
		/// Logs error to the console.
		/// </summary>
		/// <param name="msg">The message to log.</param>
		public void LogError(object msg) {
			TTCModManagerMain.CoreLogger.LogError($"[{Prefix}] {msg}");
		}

		/// <summary>
		/// Logs fatal to the console.
		/// </summary>
		/// <param name="msg">The message to log.</param>
		public void LogFatal(object msg) {
			TTCModManagerMain.CoreLogger.LogFatal($"[{Prefix}] {msg}");
		}

		/// <summary>
		/// Logs message to the console.
		/// </summary>
		/// <param name="msg">The message to log.</param>
		public void LogMessage(object msg) {
			TTCModManagerMain.CoreLogger.LogMessage($"[{Prefix}] {msg}");
		}

	}
}
