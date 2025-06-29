using UnrealBuildTool;
using System.Collections.Generic;

public class VoxroomTarget : TargetRules
{
    public VoxroomTarget(TargetInfo Target) : base(Target)
    {
        Type = TargetType.Game;
        DefaultBuildSettings = BuildSettingsVersion.V2;
        IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_6;
        ExtraModuleNames.Add("Voxroom");
    }
}
