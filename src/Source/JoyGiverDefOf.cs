using RimWorld;

namespace FlossiesMod {
	[DefOf]
	public static class JoyGiverDefOf {
		public static JoyGiverDef Play_Reversi;

		static JoyGiverDefOf() 	{
			DefOfHelper.EnsureInitializedInCtor(typeof(JoyGiverDefOf));
		}
	}
}
