using System.Reflection;
using Verse;
using HarmonyLib;

namespace FlossiesMod {
	public class FlossiesMod: Mod {
		public static FlossiesMod Instance { get; private set; }

		public string Name => Content.ModMetaData.Name;

		public string Version => Content.ModMetaData.ModVersion;

		public string FullName => $"{Name} v{Version}";

		public FlossiesMod( ModContentPack content ): base( content ) {
			Instance = this;
			var harmony = new Harmony( "Error.FlossiesMod" );
			harmony.PatchAll( Assembly.GetExecutingAssembly() );
			Log.Message( $"{FullName} initialized" );
		}
	}
}
