using System.Reflection;
using Verse;
using HarmonyLib;

namespace FlossiesMod {
	public class FlossiesMod: Mod {
		public FlossiesMod( ModContentPack content ): base( content ) {
			var harmony = new Harmony( "Error.FlossiesMod" );
			harmony.PatchAll( Assembly.GetExecutingAssembly() );
		}
	}
}
