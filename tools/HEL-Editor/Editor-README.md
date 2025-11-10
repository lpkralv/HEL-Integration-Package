# HEL Editor

A Windows Forms utility for creating, editing, and analyzing HIOX mods using the HEL (HIOX Equation Language) system.

## Purpose

The HEL Editor provides a visual interface for game developers to:
- Create and edit mod definitions
- Test HEL equations and their effects on stats
- Analyze mod combinations and interactions
- Load/save mod data in YAML and CSV formats

## Building and Running

### Prerequisites
- .NET 8.0 SDK or later
- Windows (Windows Forms requirement)

### Build Instructions
```bash
cd HEL-Integration-Package/tools/HEL-Editor
dotnet build
```

### Run the Editor
```bash
dotnet run
```

## Features

- **Mod Management**: Create, edit, and organize mod definitions
- **Equation Testing**: Real-time validation and testing of HEL equations
- **Stats Analysis**: View how mods affect player statistics
- **File I/O**: Load and save mods in YAML or CSV formats
- **UUID Support**: Automatic UUID generation for mod instances

## Usage

1. **Load Mods**: Use File → Load to import existing mod data
2. **Edit Mods**: Select mods from the list to modify their properties
3. **Test Equations**: Enter HEL equations and see their effects immediately
4. **Save Changes**: Use File → Save to export modified mod data

## Integration with HEL System

The editor uses the same HEL core system included in this package (`../../src/`), ensuring consistency between the editor and your game integration.

## File Formats

- **YAML**: Primary format for Unity asset files
- **CSV**: Human-readable format for spreadsheet editing

See the main documentation (`../../docs/HEL-Documentation-Complete.md`) for detailed information about file formats and the HEL system.