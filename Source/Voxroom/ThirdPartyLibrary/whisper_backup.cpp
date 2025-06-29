#include "whisper.h"
#include <string>
#include <vector>
#include <filesystem>

// This is a simplified version of inference using whisper.cpp
std::string transcribe_file(const std::string& path)
{
    // Load whisper model
    const char* model_path = "Content/Models/ggml-base.en.bin";
    struct whisper_context* ctx = whisper_init_from_file(model_path);
    if (!ctx) return "Failed to load model.";

    // Load audio file
    std::vector<float> pcmf32;
    if (!whisper::wav_to_pcmf32(path.c_str(), pcmf32)) {
        return "Failed to load or decode audio file.";
    }

    // Run the Whisper model
    whisper_full_params params = whisper_full_default_params(WHISPER_SAMPLING_GREEDY);
    if (whisper_full(ctx, params, pcmf32.data(), pcmf32.size()) != 0) {
        return "Failed to run whisper_full.";
    }

    // Collect result
    std::string result;
    const int n_segments = whisper_full_n_segments(ctx);
    for (int i = 0; i < n_segments; ++i) {
        result += whisper_full_get_text(ctx, i);
    }

    // Cleanup
    whisper_free(ctx);
    return result.empty() ? "No speech detected." : result;
}
