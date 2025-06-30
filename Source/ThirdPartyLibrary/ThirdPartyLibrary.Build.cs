using UnrealBuildTool;
using System.IO;

public class ThirdPartyLibrary : ModuleRules
{
    public ThirdPartyLibrary(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicIncludePaths.AddRange(new string[] {
            Path.Combine(ModuleDirectory, "include")
        });

        PrivateIncludePaths.AddRange(new string[] {
            Path.Combine(ModuleDirectory, "src")
        });

        PublicDependencyModuleNames.AddRange(new string[] {
            "Core", "CoreUObject", "Engine"
        });

        PrivateDependencyModuleNames.AddRange(new string[] {
            "Projects"
        });

        // Optional: Add any platform-specific settings
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            // Example: Link static lib or define macros
            PublicDefinitions.Add("GGML_USE_STD_MUTEX=1");
        }
    }
}
