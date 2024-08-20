using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace FlossiesMod {
	public class CompIngestRectal: ThingComp {
		public override IEnumerable<FloatMenuOption> CompFloatMenuOptions( Pawn selPawn ) {
			var drug = parent;
			if( drug == null ) yield break;
			if( selPawn == null ) yield break;
			var ingestibleProperties = drug.def.ingestible;
			if( ingestibleProperties == null ) yield break;
			
			yield return new FloatMenuOption( 
				"Ingest {0} (rectally)".Formatted( drug.Label ),
				() => {
					var job = new Job( JobDefOf.IngestRectal, drug );
					selPawn.jobs.TryTakeOrderedJob( job, JobTag.SatisfyingNeeds );
				}
			) {
				Disabled = !selPawn.CanTakeDrug( drug.def ) || !selPawn.CanReserveAndReach( drug, PathEndMode.Touch, Danger.Deadly )
			};
		}
	}
}
