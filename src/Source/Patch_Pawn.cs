using Verse;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using RimWorld;

namespace FlossiesMod {
	[HarmonyPatch( typeof(Pawn), "GetTooltip" )]
	public static class Patch_Pawn_GetTooltip {
		public static IEnumerable<CodeInstruction> Transpiler( IEnumerable<CodeInstruction> instructions ) {
			var getLabelCap = AccessTools.PropertyGetter( typeof(Entity), "LabelCap" );
			var getLabel = AccessTools.PropertyGetter( typeof(Entity), "Label" );
			foreach( var instruction in instructions ) {
				if( instruction.Calls( getLabelCap ) ) {
					yield return new CodeInstruction( OpCodes.Callvirt, getLabel );
				} else {
					yield return instruction;
				}
			}
		}
	}
}
