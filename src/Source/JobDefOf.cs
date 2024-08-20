using RimWorld;

using Verse;

namespace FlossiesMod {
	[DefOf]
	public static class JobDefOf {
		public static JobDef IngestRectal;

		static JobDefOf() {
			DefOfHelper.EnsureInitializedInCtor( typeof(JobDefOf) );
		}
	}
}
