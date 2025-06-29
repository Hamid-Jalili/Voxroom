#include "WhisperFunctionLibrary.h"
#include "Misc/Paths.h"
#include "HAL/PlatformFileManager.h"
#include "Misc/FileHelper.h"
#include "WhisperFunctionLibrary.h"
#include "Misc/Paths.h"
#include "HAL/PlatformFilemanager.h"

// ✅ FIX THIS LINE:
#include "whisper.h"  // Do NOT use 'ThirdParty/Whisper/whisper.h'


// Include the C++ function from your whisper implementation
#include "ThirdParty/Whisper/whisper.h"

FString UWhisperFunctionLibrary::TranscribeFromFile(const FString& FilePath)
{
    std::string NativePath = TCHAR_TO_UTF8(*FilePath);
    std::string Result = transcribe_file(NativePath);
    return FString(Result.c_str());
}
