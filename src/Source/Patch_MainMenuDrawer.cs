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
				TexTitleOverlay = ContentFinder<Texture2D>.Get( "UI/HeroArt/GameTitleOverlay" );
			} catch( Exception ex ) {
				Log.Error( ex.ToString() );
			}
		}

		public static Texture2D TexTitleOverlay { get; private set; }
	}

	[HarmonyPatch( typeof(MainMenuDrawer), "MainMenuOnGUI" )]
	public static class Patch_MainMenuDrawer_MainMenuOnGUI {
		public static void Postfix() {
			try {
				var paneSize = new Vector2( 450f, 750f );
				
				Rect rect = new Rect( UI.screenWidth / 2f - paneSize.x / 2f, UI.screenHeight / 2f - paneSize.y / 2f + 50f, paneSize.x, paneSize.y );
				rect.x = UI.screenWidth - rect.width - 30f;
				var rect2 = new Rect( 0f, rect.y - 30f, UI.screenWidth - 85f, 30f );
				var titleSize = new Vector2( 1032f, 146f );
				var titleOverlaySize = new Vector2( 629f, 53f );
				var titleOverlayOffset = new Vector2( -190f, 300f );
				if( titleSize.x > UI.screenWidth ) {
					var scaleFactor = UI.screenWidth / titleSize.x;
					titleOverlaySize *= scaleFactor;
					titleOverlayOffset *= scaleFactor;
					titleSize *= scaleFactor;
				}
				titleOverlaySize *= 0.5f;
				titleSize *= 0.5f;
				titleOverlayOffset *= 0.5f;
				GUI.DrawTexture(
					new Rect(
						UI.screenWidth - titleSize.x - titleOverlayOffset.x,
						rect2.y - titleSize.y + titleOverlayOffset.y,
						titleOverlaySize.x,
						titleOverlaySize.y
					),
					Patch_MainMenuDrawer_Init.TexTitleOverlay,
					ScaleMode.StretchToFill,
					alphaBlend: true
				);
			} catch( Exception ex ) {
				Log.Error( ex.ToString() );
			}
		}
	}
}
