using UnrealBuildTool;
using System.IO;

public class Voxroom : ModuleRules
{
    public Voxroom(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicDependencyModuleNames.AddRange(new string[]
        {
            "Core", "CoreUObject", "Engine", "InputCore", "AudioMixer", "DeveloperSettings"
        });

        PrivateDependencyModuleNames.AddRange(new string[] { });

        // ✅ Add Whisper folder to include path
        string WhisperIncludePath = Path.Combine(ModuleDirectory, "../../ThirdParty/Whisper/");
        PublicIncludePaths.Add(WhisperIncludePath);
    }
}
