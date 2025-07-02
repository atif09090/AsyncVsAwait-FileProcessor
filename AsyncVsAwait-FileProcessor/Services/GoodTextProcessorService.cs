using System.Text.RegularExpressions;

namespace AsyncVsAwait_FileProcessor.Services
{
    public class GoodTextProcessorService
    {
        public async Task<string> ProcessFileAsync(IFormFile file)
        {
            var filePath = Path.Combine(Path.GetTempPath(), file.FileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream).ConfigureAwait(false); // Avoid context capture
            }

            string content = await File.ReadAllTextAsync(filePath).ConfigureAwait(false); // Proper async

            // CPU-bound: keep it sync
            var lineCount = CountLines(content);
            var wordCount = CountWords(content);

            return $"Lines: {lineCount}, Words: {wordCount}";
        }

        private int CountLines(string content)
        {
            return content.Split('\n').Length;
        }

        private int CountWords(string content)
        {
            return Regex.Matches(content, @"\b\w+\b").Count;
        }
    }
}
