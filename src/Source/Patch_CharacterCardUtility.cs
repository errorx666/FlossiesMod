using Verse;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using RimWorld;

namespace FlossiesMod {
	[HarmonyPatch( typeof(CharacterCardUtility), "DrawCharacterCard" )]
	public static class Patch_CharacterCardUtility_DrawCharacterCard {
		public static IEnumerable<CodeInstruction> Transpiler( IEnumerable<CodeInstruction> instructions ) {
			var capitalizeFirst = AccessTools.Method( typeof(GenText), "CapitalizeFirst", [ typeof(string) ] );
			foreach( var instruction in instructions ) {
				if( !instruction.Calls( capitalizeFirst ) ) {
					yield return instruction;
				}
			}
		}
	}
}
