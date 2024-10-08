using Verse;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FlossiesMod {
	[HarmonyPatch( typeof(GenMapUI), "GetPawnLabel" )]
	public static class Patch_GenMapUI_GetPawnLabel {
		public static IEnumerable<CodeInstruction> Transpiler( IEnumerable<CodeInstruction> instructions ) {
			var getLabelShortCap = AccessTools.PropertyGetter( typeof(Entity), "LabelShortCap" );
			var getLabelShort = AccessTools.PropertyGetter( typeof(Entity), "LabelShort" );
			foreach( var instruction in instructions ) {
				if( instruction.Calls( getLabelShortCap ) ) {
					yield return new CodeInstruction( OpCodes.Callvirt, getLabelShort );
				} else {
					yield return instruction;
				}
			}
		}
	}
}
