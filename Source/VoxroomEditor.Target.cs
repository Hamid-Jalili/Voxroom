using UnrealBuildTool;
using System.Collections.Generic;

public class VoxroomEditorTarget : TargetRules
{
    public VoxroomEditorTarget(TargetInfo Target) : base(Target)
    {
        Type = TargetType.Editor;
        DefaultBuildSettings = BuildSettingsVersion.V5;
        IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_6;

        // ❌ REMOVE this line below for installed engines
        // BuildEnvironment = TargetBuildEnvironment.Unique;

        ExtraModuleNames.AddRange(new string[] { "Voxroom" });
    }
}
