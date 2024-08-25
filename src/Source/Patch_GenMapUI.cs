using System;
using Verse;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;

namespace FlossiesMod {
	[HarmonyPatch( typeof(GenMapUI), "GetPawnLabel" )]
	public static class Patch_GenMapUI_GetPawnLabel {
		public static IEnumerable<CodeInstruction> Transpiler( IEnumerable<CodeInstruction> instructions ) {
			var getLabelShortCap = typeof(Entity).GetProperty( "LabelShortCap" ).GetAccessors().Where( a => a.GetParameters().Length == 0 ).Single();
			var getLabelShort = typeof(Entity).GetProperty( "LabelShort" ).GetAccessors().Where( a => a.GetParameters().Length == 0 ).Single();
			foreach( var instruction in instructions ) {
				if( instruction.Calls( getLabelShortCap ) ) {
					instruction.operand = getLabelShort;
				}
				yield return instruction;
			}
		}
	}
}
