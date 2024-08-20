using System;
using RimWorld;
using UnityEngine;
using Verse;
using HarmonyLib;

namespace FlossiesMod {
	[HarmonyPatch( typeof(MainMenuDrawer), "Init" )]
	public static class Patch_MainMenuDrawer_Init {
		public static void Postfix() {
			try {
				Log.Message( "Patching logo..." );
				var texTitleField = AccessTools.Field( typeof(MainMenuDrawer), "TexTitle" );
				texTitleField.SetValue( null, ContentFinder<Texture2D>.Get( "UI/HeroArt/GameTitle" ) );
				var titleSize = AccessTools.Field( typeof(MainMenuDrawer), "TitleSize" );
				titleSize.SetValue( null, new Vector2( 1032f, 163f ) );
				Log.Message( "Done patching logo" );
			} catch( Exception ex ) {
				Log.Error( ex.ToString() );
			}
		}
	}
}
