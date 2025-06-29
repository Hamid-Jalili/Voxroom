// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class Voxroom : ModuleRules
{
    public Voxroom(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicDependencyModuleNames.AddRange(new string[] {
            "Core", "CoreUObject", "Engine", "InputCore"
        });

        PrivateDependencyModuleNames.AddRange(new string[] {
            // Add any private dependencies here
        });

        // Path to the ThirdPartyLibrary
        string ThirdPartyPath = Path.Combine(ModuleDirectory, "ThirdPartyLibrary");

        // Add include path
        PrivateIncludePaths.Add(ThirdPartyPath);

        // Optional: If ggml requires C math defines or optimization flags
        PublicDefinitions.Add("GGML_USE_STDIO=1"); // define GGML_USE_STDIO if needed
        PublicDefinitions.Add("GGML_USE_ACCELERATE=0"); // or other GGML config flags

        // Add the ThirdParty source files explicitly if needed
        // (if Unreal is not detecting them automatically)
        // E.g., Runtime compilation helpers can go here
    }
}
