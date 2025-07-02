# 📝 TextFileProcessor

A .NET 8 Web API that demonstrates **good vs. bad asynchronous programming practices** using a real-world scenario: processing large `.txt` files uploaded via HTTP.

This project avoids beginner-level examples and focuses on practical performance and scalability concerns like:
- Avoiding thread blocking (`.Result`, `.Wait()`)
- Not wrapping CPU-bound logic in unnecessary async
- Using `ConfigureAwait(false)` correctly in library code

---

## 🚀 Running the App

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### CLI

```bash
git clone https://github.com/your-org/TextFileProcessor.git
cd TextFileProcessor
dotnet run

