using RimWorld;
using Verse;

namespace FlossiesMod {
	public class Alert_ReversiTableNoChairs: Alert_JoyBuildingNoChairs {
		protected override JoyGiverDef JoyGiver => JoyGiverDefOf.Play_Reversi;

		public Alert_ReversiTableNoChairs() {
			defaultLabel = "ReversiTablesNeedChairs".Translate();
			defaultExplanation = "ReversiTablesNeedChairsDesc".Translate();
		}
	}
}
