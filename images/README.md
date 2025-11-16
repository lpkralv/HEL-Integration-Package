# Weapon and Mod Image Assets

This directory contains fully rendered images for **ALL 156 mods** defined in the HEL Integration Package, available in PNG format.

## Overview

**Total Assets**: 156 PNG images (1.8MB)
**Categories**:
- 25 Weapons (Type 2)
- 17 Melee Weapons/Deployables (Type 4)
- 63 Nanites (Type 0)
- 51 Syringes/Upgrades (Type 10)

### Image Format
- **Dimensions**: 800x400 pixels
- **Format**: PNG (Portable Network Graphics)
- **Quality**: Full-color, fully rendered with gradients, particle effects, and professional labels
- **File Size**: 8-14 KB per image (optimized)
- **Features**:
  - Type-specific gradient backgrounds
  - Category-appropriate visual designs (weapons, nanites, syringes)
  - Professional text labels with drop shadows
  - Mod ID and type identification
  - Color-coded by mod function and category

## Complete Mod Catalog

### Weapons (Type 2) - 25 Items
Energy and ballistic weapon systems

| ID Range | Count | Description |
|----------|-------|-------------|
| 515-524 | 10 | Energy Weapons (Lasers, Plasma, Beams) |
| 1000-1014 | 15 | Ballistic Weapons (Kinetic, Precision, Burst) |

**Example Files:**
- `mod_515_coherent_light_projector.png`
- `mod_516_plasma_discharge_rifle.png`
- `mod_1000_kinetic_accelerator_matrix.png`
- `mod_1013_adaptive_ballistic_nexus.png`

### Melee Weapons & Deployables (Type 4) - 17 Items
Close-combat and autonomous construct systems

| ID Range | Count | Description |
|----------|-------|-------------|
| 1034-1043 | 10 | Deployable Constructs (Drones, Platforms, Swarms) |
| 1048-1054 | 7 | Melee Edge Systems (Blades, Kinetic Strikes) |

**Example Files:**
- `mod_1034_basic_combat_drone_assembly.png`
- `mod_1048_kinetic_blade_matrix.png`
- `mod_1054_chromatic_coherence_edge.png`

### Nanites (Type 0) - 63 Items
Nanomachine enhancement systems organized by function

| ID Range | Count | Category | Color Scheme |
|----------|-------|----------|--------------|
| 1025-1033 | 9 | Explosive Ordnance | Orange-Brown |
| 1044-1047 | 4 | Multi-Mode Combat | Gray-Blue |
| 2000-2007 | 8 | Structural/Armor | Gray-Blue |
| 2008-2014 | 7 | Mobility Enhancement | Green |
| 2015-2020 | 6 | Regeneration Systems | Cyan-Green |
| 2021-2028 | 8 | Offensive Amplifiers | Red |
| 2029-2034 | 6 | Elemental Resistance | Purple |
| 2035-2042 | 8 | Resource Management | Blue |
| 2043-2049 | 7 | Tactical Systems | Yellow-Gray |

**Example Files:**
- `mod_1025_fragmentation_launcher.png` (Explosive)
- `mod_2000_reinforced_nanite_shell.png` (Structural)
- `mod_2008_kinetic_accelerator_nanites.png` (Mobility)
- `mod_2015_nanite_reconstruction_matrix.png` (Regeneration)
- `mod_2021_precision_targeting_matrix.png` (Offensive)
- `mod_2029_thermal_insulation_matrix.png` (Resistance)
- `mod_2035_energy_matrix_amplifier.png` (Resource)
- `mod_2044_predictive_evasion_core.png` (Tactical)

### Syringes/Upgrades (Type 10) - 51 Items
Injectable enhancement serums organized by effect type

| ID Range | Count | Category | Liquid Color |
|----------|-------|----------|--------------|
| 3000-3009 | 10 | Combat Enhancement | Red |
| 3010-3019 | 10 | Defensive Protocols | Blue |
| 3020-3029 | 10 | Metabolic Boosters | Green |
| 3030-3038 | 9 | Elemental Infusion | Magenta |
| 3039-3046 | 8 | Tactical Optimization | Yellow |
| 3047-3050 | 4 | Exotic Variants | Cyan |

**Example Files:**
- `mod_3000_damage_enhancement_serum.png` (Combat)
- `mod_3010_structural_fortification_serum.png` (Defensive)
- `mod_3020_regenerative_nanite_injection.png` (Metabolic)
- `mod_3030_thermal_ignition_serum.png` (Elemental)
- `mod_3039_targeting_optimization_serum.png` (Tactical)
- `mod_3047_berserker_rage_protocol.png` (Exotic)

## Design Specifications

### Visual Themes by Type

**Weapons (Type 2)**
- Blue-purple gradient backgrounds
- Weapon silhouettes with barrels, handles, energy emitters
- High-tech industrial aesthetic

**Melee/Deployables (Type 4)**
- Red-brown gradient backgrounds
- Blade shapes for melee, construct shapes for deployables
- Aggressive combat styling

**Nanites (Type 0)**
- Function-specific gradient backgrounds
- Swarm particle effects with central core
- Orbiting nanite particles
- Color-coded by category (explosive, structural, mobility, etc.)

**Syringes (Type 10)**
- Category-specific gradient backgrounds
- Syringe/injector design with glass body
- Colored liquid indicating effect type
- Medical/pharmaceutical aesthetic

### Color Schemes

#### Background Gradients
- **Weapons**: `(25,30,50) → (15,20,35)` - Blue-purple
- **Melee**: `(50,25,25) → (30,15,15)` - Red-brown
- **Nanites**: Varies by category (9 different schemes)
- **Syringes**: Varies by effect type (6 different schemes)

#### Visual Elements
- **Text Labels**: White with black drop shadow for readability
- **Mod ID/Type**: Light gray `(170,170,170)`
- **Nanite Particles**: Category-specific (orange, blue, green, cyan, red, purple, yellow)
- **Syringe Liquids**: Effect-specific (red, blue, green, magenta, yellow, cyan)

## Image Generation

### Automated Generation System

All images are generated using the Python script `generate_all_weapon_images.py` which reads from `mod_list.csv`.

#### Generate All Images (156 total)
```bash
python3 generate_all_weapon_images.py
```

#### Generate by Type (for parallel processing)
```bash
# Weapons only (25 images)
python3 generate_all_weapon_images.py 2

# Melee/Deployables only (17 images)
python3 generate_all_weapon_images.py 4

# Nanites only (63 images)
python3 generate_all_weapon_images.py 0

# Syringes/Upgrades only (51 images)
python3 generate_all_weapon_images.py 10
```

### Requirements
- Python 3.7+
- Pillow library: `pip install Pillow`
- `mod_list.csv` file (generated from DELIVERABLE-ModsData.asset)

### Parallel Generation Workflow

The complete image set was generated using parallel subagents:
1. Extract mod data: `python3 extract_mod_list.py`
2. Generate images in parallel using 4 concurrent processes
3. Each process handles one mod type independently
4. Total generation time: ~30 seconds for all 156 images

## File Naming Convention

Files follow the pattern: `mod_[MODID]_[name_in_lowercase].[ext]`

Examples:
- `mod_515_coherent_light_projector.png`
- `mod_2000_reinforced_nanite_shell.png`
- `mod_3030_thermal_ignition_serum.png`

## Usage

### Production Use Cases
- Game UI mod selection screens
- Inventory and loadout displays
- Mod catalog and documentation
- Marketing materials
- Player guides and wikis
- Testing and development

### Loading Images
```python
# Python example
from PIL import Image

# Load by mod ID
mod_id = 515
img = Image.open(f'images/mod_{mod_id}_coherent_light_projector.png')

# Or iterate through all
import glob
for filepath in glob.glob('images/mod_*.png'):
    print(filepath)
```

## Customization

### Modify Visual Appearance
1. Edit `generate_all_weapon_images.py`
2. Modify drawing functions:
   - `draw_generic_weapon()` for weapon appearance
   - `draw_generic_melee()` for melee weapons
   - `draw_nanite_swarm()` for nanite particle effects
   - `draw_syringe()` for syringe design
3. Adjust `get_background_colors()` for gradient themes
4. Update constants (WIDTH, HEIGHT) for different dimensions
5. Regenerate images using the script

### Add New Mod Types
1. Add entries to `mod_list.csv`
2. Define new type constant in script
3. Add case to `get_background_colors()`
4. Create new drawing function
5. Add type to `generate_mod_image()` conditional

## File Structure

```
images/
├── README.md                                    # This file
├── mod_515_coherent_light_projector.png        # Weapons (515-524)
├── mod_1000_kinetic_accelerator_matrix.png     # Weapons (1000-1014)
├── mod_1034_basic_combat_drone_assembly.png    # Melee/Deployables (1034-1054)
├── mod_1025_fragmentation_launcher.png         # Nanites (1025-2049)
├── mod_3000_damage_enhancement_serum.png       # Syringes (3000-3050)
└── ... (156 PNG files total)
```

## Statistics

- **Total Images**: 156
- **Total Size**: 1.8 MB
- **Average File Size**: ~11.5 KB
- **Image Dimensions**: 800x400 pixels each
- **Color Depth**: 24-bit RGB
- **Format**: PNG with optimization

## Related Files

- **Source Data**: `/DELIVERABLE-ModsData.asset` (156 mod definitions)
- **Extraction Script**: `/extract_mod_list.py` (YAML to CSV converter)
- **Mod List**: `/mod_list.csv` (simplified mod database)
- **Generator**: `/generate_all_weapon_images.py` (image generation engine)
- **Documentation**: `/CLAUDE.md` (project overview)

## Version History

- **v2.0** - Complete 156-mod image set with all categories
  - Added 143 new images (weapons, nanites, syringes, deployables)
  - Parallel generation using subagents
  - Category-specific visual themes
  - Enhanced README with complete catalog

- **v1.0** - Initial 13 weapon images
  - Basic weapons and melee sword
  - SVG prototypes

## License

These images are part of the HEL Integration Package and follow the same license as the repository.

---

**Generated**: 2025-11-16
**Script**: `generate_all_weapon_images.py`
**Format**: PNG 800x400 pixels
**Total Assets**: 156 images
