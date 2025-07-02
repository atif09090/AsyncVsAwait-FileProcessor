namespace AsyncVsAwait_FileProcessor.Services
{
    public class BadTextProcessorService
    {
        public async Task<string> ProcessFile(IFormFile file)
        {
            var filePath = Path.Combine(Path.GetTempPath(), file.FileName);

            // Awaiting a completed Task for a sync operation (unnecessary overhead)
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // .Result on async method = potential deadlock
            var content = File.ReadAllTextAsync(filePath).Result;

            var lineCount = await Task.FromResult(content.Split('\n').Length); // Useless async wrapper

            return $"Lines: {lineCount}";
        }
    }
}
