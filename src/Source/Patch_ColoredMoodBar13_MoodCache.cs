using Verse;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using System;

namespace FlossiesMod {
	[HarmonyPatch( "ColoredMoodBar13.MoodCache", "DoLabelVars" )]
	public static class Patch_ColoredMoodBar13_MoodCache_DoLabelVars {
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

		public static Exception Cleanup( Exception _ex ) {
			return null; // ignore errors
		}
	}
}
