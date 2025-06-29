#pragma once

#include "Kismet/BlueprintFunctionLibrary.h"
#include "WhisperFunctionLibrary.generated.h"

UCLASS()
class VOXROOM_API UWhisperFunctionLibrary : public UBlueprintFunctionLibrary
{
    GENERATED_BODY()

public:
    UFUNCTION(BlueprintCallable, Category = "Whisper")
    static FString TranscribeFromFile(const FString& FilePath);
};
