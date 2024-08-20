using System.Reflection;
using Verse;
using HarmonyLib;
using System;

namespace FlossiesMod {
	public class FlossiesMod: Mod {
		public static FlossiesMod Instance { get; private set; }

		public string Name => Content.ModMetaData.Name;
		public string Version => Content.ModMetaData.ModVersion;

		public FlossiesMod( ModContentPack content ): base( content ) {
			Instance = this;
			var harmony = new Harmony( "Error.FlossiesMod" );
			harmony.PatchAll( Assembly.GetExecutingAssembly() );
			Log.Message( $"{Name} v{Version} initialized" );
		}
	}
}
