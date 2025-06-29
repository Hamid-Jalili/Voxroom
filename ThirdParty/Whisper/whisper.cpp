#include "whisper.h"
#include <fstream>

std::string transcribe_file(const std::string& path)
{
    // Simple placeholder for real whisper logic
    std::ifstream file(path, std::ios::binary);
    if (!file.is_open())
        return "Error: Failed to open file.";

    return "Mock transcription result from: " + path;
}
