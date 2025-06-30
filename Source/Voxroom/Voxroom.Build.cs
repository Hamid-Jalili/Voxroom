using UnrealBuildTool;
using System.IO;

public class Voxroom : ModuleRules
{
    public Voxroom(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "ThirdPartyLibrary", "src", "ggml-cpu", "include"));

        string GGMLPath = Path.Combine(ModuleDirectory, "ThirdPartyLibrary", "src", "ggml-cpu", "src");
        foreach (string cpp in Directory.EnumerateFiles(GGMLPath, "*.cpp", SearchOption.AllDirectories))
        {
            PublicAdditionalLibraries.Add(cpp);
        }

        // Explicitly exclude duplicate paths:
        PrivateDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore" });
    }
}
