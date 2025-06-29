#include "WhisperFunctionLibrary.h"
#include "Misc/Paths.h"
#include "HAL/PlatformFileManager.h"
#include "Misc/FileHelper.h"
#include "whisper.h"


// Include the C++ function from your whisper implementation
#include "ThirdParty/Whisper/whisper.h"

FString UWhisperFunctionLibrary::TranscribeFromFile(const FString& FilePath)
{
    std::string NativePath = TCHAR_TO_UTF8(*FilePath);
    std::string Result = transcribe_file(NativePath);
    return FString(Result.c_str());
}
