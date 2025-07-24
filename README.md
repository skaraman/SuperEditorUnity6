# SuperEditorUnity6

Unity 6 compatible version of Super Editor - Enhanced Unity Editor functionality.

## Installation

### Via Unity Package Manager

1. Open Unity 6.0.1 or later
2. Go to Window > Package Manager
3. Click the "+" button and select "Add package from git URL"
4. Enter: `https://github.com/skaraman/SuperEditorUnity6.git`

### Manual Installation

1. Download this repository
2. Copy the entire folder to your Unity project's `Packages` directory
3. Unity will automatically detect and import the package

## Compatibility

- **Unity Version**: 6.0.1f1 or later
- **Target Framework**: .NET Standard 2.1
- **Platforms**: Editor only

## Features

Super Editor provides enhanced Unity Editor functionality including:

- Advanced editor window management
- Custom property drawers
- Enhanced hierarchy tools
- Code editing utilities
- Theme system

## Unity 6 Changes

This version has been updated for Unity 6 compatibility:

- Updated to .NET Standard 2.1 target framework
- Modernized project structure with Assembly Definition files
- Unity Package Manager compatible structure
- Conditional assembly references for cross-platform compatibility

## Building

### Unity Package Manager (Recommended)

The primary way to use SuperEditor is through Unity's Package Manager:

1. Open Unity 6.0.1f1 or later
2. Import the package using the Package Manager
3. Unity automatically handles compilation using the `.asmdef` file

### Standalone Build (Development/CI)

The project includes a `.csproj` file for standalone builds:

```bash
dotnet build SuperEditor.sln
```

**Unity Required**: The standalone build requires Unity 6.0.1f1 to be installed:
- **Windows**: `C:\Program Files\Unity\Hub\Editor\6000.1.9f1\`
- **Linux**: `/opt/unity/Editor/6000.1.9f1/`

**Without Unity**: If Unity is not installed, the build succeeds with a stub implementation and helpful warnings about Unity requirements.

### Build Configuration

The build system automatically detects Unity installation and:
- ✅ **With Unity**: Compiles full SuperEditor functionality
- ⚠️ **Without Unity**: Creates stub assembly with usage guidance

Both configurations produce valid .NET assemblies suitable for CI/CD pipelines.

## Support

For issues and support, please use the GitHub issue tracker.