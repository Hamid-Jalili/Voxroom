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

        // Whisper third-party path
        string WhisperPath = Path.Combine(ModuleDirectory, "../../ThirdParty/Whisper");

        PublicIncludePaths.AddRange(new string[] {
            WhisperPath
        });

        PrivateIncludePaths.AddRange(new string[] {
            WhisperPath
        });

        // Add the whisper.cpp to be compiled directly (if needed)
        RuntimeDependencies.Add(Path.Combine(WhisperPath, "whisper.cpp"));
    }
}
