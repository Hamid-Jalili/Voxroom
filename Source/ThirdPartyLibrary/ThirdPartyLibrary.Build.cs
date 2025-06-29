using System.IO;
using UnrealBuildTool;

public class ThirdPartyLibrary : ModuleRules
{
    public ThirdPartyLibrary(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
        Type = ModuleType.External;

        string ThirdPartyPath = Path.Combine(ModuleDirectory, "../../ThirdParty/Whisper/");
        PublicIncludePaths.Add(ThirdPartyPath);
        PrivateIncludePaths.Add(ThirdPartyPath);

        string WhisperSrcCpp = Path.Combine(ThirdPartyPath, "whisper.cpp");
        if (File.Exists(WhisperSrcCpp))
        {
            PrivateDefinitions.Add("WITH_WHISPER_CPP=1");
            PublicDefinitions.Add("WITH_WHISPER_CPP=1");

            // ✅ Remove AdditionalSourceFiles — Unreal will include whisper.cpp automatically
            PublicDependencyModuleNames.Add("Core"); // just in case it's needed
        }
    }
}
