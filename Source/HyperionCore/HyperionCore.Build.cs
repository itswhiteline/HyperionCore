// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class HyperionCore : ModuleRules
{
	public HyperionCore(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicIncludePaths.Add(GetDiscordPath);
		PublicAdditionalLibraries.Add(GetDiscordLibFiles);
		
		PrivateIncludePaths.AddRange(
			new string[] {
				// ... add other private include paths required here ...
			}
		);
		
		PublicDependencyModuleNames.AddRange(
			new string[] {
				"Core",
				"HyperionUI",
				"KonsolePlugin",
				"UMG"
				// ... add other public dependencies that you statically link with here ...
			}
		);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[] {
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
				// ... add private dependencies that you statically link with here ...	
			}
		);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[] {
				// ... add any modules that your module loads dynamically here ...
			}
		);
	}
	
	private string GetDiscordPath {
		get {
			return Path.GetFullPath(Path.Combine(ModuleDirectory, "Discord"));
		}
	}
	private string GetDiscordLibFiles {
		get {
			return Path.GetFullPath(Path.Combine(ModuleDirectory, "../../Binaries/", GetTargetPlatform,
				GetDiscordLabFileNames));
		}
	}
	private string GetDiscordLabFileNames {
		get {
			if (bIsWin64()) {
				return "discord_game_sdk.dll.lib";
			} else if (bIsMac()) {
				return "discord_game_sdk.dylib";
			}
			return null;
		}
	}
	
	private bool bIsWin64() {
		return Target.Platform == UnrealTargetPlatform.Win64;
	}
	private bool bIsMac() {
		return Target.Platform == UnrealTargetPlatform.Mac;
	}
	private bool bIsLinux() {
		return Target.Platform == UnrealTargetPlatform.Linux;
	}
	
	private string GetTargetPlatform {
		get {
			if (bIsWin64()) {
				return "Win64";
			} else if (bIsMac()) {
				return "Mac";
			} else if (bIsLinux()) {
				return "Linux/x86_64-unknown-linux-gnu";
			}
			return null;
		}
	}
}
