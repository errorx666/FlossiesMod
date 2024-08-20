using RimWorld;

using System.Collections.Generic;

using Verse;
using Verse.AI;

namespace FlossiesMod {
	public class JobDriver_IngestRectal: JobDriver_Ingest {
		public override string GetReport() => "Shoving {0} up {PAWN_possessive} butt.".Formatted( job.targetA.Thing.LabelShort, pawn.Named( "PAWN" ) );
	}
}
