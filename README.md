# DattingLab

This repository contains a sample WPF dating simulator built with clean architecture principles.

## Structure

- `src/DattingLab.Domain` – domain entities and repository interfaces
- `src/DattingLab.Application` – application services
- `src/DattingLab.Infrastructure` – EF Core data access implementation
- `src/DattingLab.AI` – interface and dummy implementation for AI chat
- `src/DattingLab.UI` – WPF user interface
- `girl_photos` – folder where profile images are stored (`1.jpg` to `21.jpg`)

## Building

Requires .NET 6 SDK and Windows environment for WPF. Run:

```bash
cd src/DattingLab.UI
dotnet run
```
