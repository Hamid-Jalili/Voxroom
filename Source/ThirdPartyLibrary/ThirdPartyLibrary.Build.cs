using UnrealBuildTool;
using System.IO;

public class ThirdPartyLibrary : ModuleRules
{
    public ThirdPartyLibrary(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "include"));

        // Add necessary source files
        string SourcePath = Path.Combine(ModuleDirectory, "src");
        string[] SourceFiles = new string[]
        {
            "ggml.c",
            "whisper.cpp",
            "ggml-cpu/ggml_cpu.cpp",
            "ggml-cpu/arch/x86/repack.cpp",
            "ggml-cpu/arch/x86/cpu-feats.cpp",
            "ggml-cpu/arch/x86/quants.c"
        };

        foreach (var file in SourceFiles)
        {
            string fullPath = Path.Combine(SourcePath, file);
            if (File.Exists(fullPath))
            {
                PrivateAdditionalSourceFiles.Add(fullPath);
            }
        }

        PrivateDependencyModuleNames.Add("Core");
    }
}
