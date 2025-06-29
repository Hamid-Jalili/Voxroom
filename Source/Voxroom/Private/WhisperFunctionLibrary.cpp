#include "WhisperFunctionLibrary.h"
#include "Misc/Paths.h"
#include "Misc/FileHelper.h"
#include "HAL/PlatformFilemanager.h"

#include "whisper.h" // Make sure this resolves via include paths from Build.cs

#define WHISPER_SAMPLE_RATE 16000

void UWhisperFunctionLibrary::TranscribeFromFile(const FString& FilePath)
{
    FString AbsolutePath = FPaths::ConvertRelativePathToFull(FilePath);
    UE_LOG(LogTemp, Log, TEXT("Reading audio from: %s"), *AbsolutePath);

    // Load whisper model file from inside Content/Whisper/Models/
    FString ModelPath = FPaths::Combine(FPaths::ProjectContentDir(), TEXT("Whisper/Models/ggml-base.en"));
    std::string ModelPathStr = TCHAR_TO_UTF8(*ModelPath);

    whisper_context* ctx = whisper_init_from_file(ModelPathStr.c_str());
    if (!ctx)
    {
        UE_LOG(LogTemp, Error, TEXT("Failed to load whisper model: %s"), *ModelPath);
        return;
    }

    // Load WAV file into buffer
    TArray<uint8> FileBytes;
    if (!FFileHelper::LoadFileToArray(FileBytes, *AbsolutePath))
    {
        UE_LOG(LogTemp, Error, TEXT("Failed to read audio file: %s"), *AbsolutePath);
        whisper_free(ctx);
        return;
    }

    // Skip WAV header (44 bytes) and convert to float samples
    const int16* AudioData = reinterpret_cast<const int16*>(FileBytes.GetData() + 44);
    int NumSamples = (FileBytes.Num() - 44) / sizeof(int16);

    std::vector<float> Samples;
    Samples.reserve(NumSamples);
    for (int i = 0; i < NumSamples; ++i)
    {
        Samples.push_back(static_cast<float>(AudioData[i]) / 32768.0f); // Normalize
    }

    // Set Whisper inference parameters
    whisper_full_params params = whisper_full_default_params(WHISPER_SAMPLING_GREEDY);
    params.print_progress = false;

    if (whisper_full(ctx, params, Samples.data(), Samples.size()) != 0)
    {
        UE_LOG(LogTemp, Error, TEXT("Whisper inference failed."));
        whisper_free(ctx);
        return;
    }

    // Extract transcription
    FString Transcription;
    int NumSegments = whisper_full_n_segments(ctx);
    for (int i = 0; i < NumSegments; ++i)
    {
        const char* SegmentText = whisper_full_get_segment_text(ctx, i);
        Transcription += UTF8_TO_TCHAR(SegmentText);
        Transcription += TEXT(" ");
    }

    UE_LOG(LogTemp, Display, TEXT("Transcribed Text:\n%s"), *Transcription);

    whisper_free(ctx);
}
