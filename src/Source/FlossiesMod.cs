using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace FlossiesMod {
	[StaticConstructorOnStartup]
	public static class FlossiesMod {
		static FlossiesMod() {
			try {
				var texTitleField = typeof(MainMenuDrawer).GetField( "TexTitle", BindingFlags.NonPublic|BindingFlags.Static );
				texTitleField.SetValue( null, ContentFinder<Texture2D>.Get( "UI/HeroArt/GameTitle" ) );
				var titleSize = typeof(MainMenuDrawer).GetField( "TitleSize", BindingFlags.NonPublic|BindingFlags.Static );
				titleSize.SetValue( null, new Vector2( 1032f, 163f ) );
			} catch( Exception ex ) {
				Log.Error( ex.ToString() );
			}

		}
	}
}
