# Weapon Image Assets

This directory contains fully rendered weapon images for all weapons defined in the HEL Integration Package, available in both PNG and SVG formats.

## Overview

Weapon images are available in two formats:

### PNG Format (Recommended for Production)
- **Dimensions**: 800x400 pixels
- **Format**: PNG (Portable Network Graphics)
- **Quality**: Full-color, fully rendered with gradients, shadows, and effects
- **Features**:
  - Detailed weapon illustrations
  - Type-specific gradient backgrounds
  - Professional text labels with shadows
  - Optimized file size (6-14 KB per image)
  - Ready for game UI, documentation, and marketing materials

### SVG Format (Editable Vector Graphics)
- **Dimensions**: 200x100 pixels
- **Format**: SVG 1.1 (Scalable Vector Graphics)
- **Purpose**: Placeholder/prototype images
- **Features**:
  - Scalable to any size without quality loss
  - Small file size
  - Easy to modify and customize
  - Text-based format suitable for version control

## Weapon Image Catalog

### Gun-Type Weapons (Type 2)

| ID | Weapon Name | PNG File | SVG File | Description |
|----|-------------|----------|----------|-------------|
| 500 | STANDARD GUN | `weapon_500_standard_gun.png` | `weapon_500_standard_gun.svg` | Standard small size assault rifle gun |
| 501 | SHOTGUN | `weapon_501_shotgun.png` | `weapon_501_shotgun.svg` | Fires group of bullets in a burst with reduced accuracy |
| 502 | SNIPER | `weapon_502_sniper.png` | `weapon_502_sniper.svg` | High damage, perfect accuracy, slower fire rate with scope |
| 503 | MACHINE GUN | `weapon_503_machine_gun.png` | `weapon_503_machine_gun.svg` | High fire rate with ammo belt, includes bipod |
| 504 | GRENADE LAUNCHER | `weapon_504_grenade_launcher.png` | `weapon_504_grenade_launcher.svg` | Fires grenades with explosion radius |
| 505 | AUTO-TURRET | `weapon_505_auto_turret.png` | `weapon_505_auto_turret.svg` | Shoulder-mounted auto-turret with twin barrels |
| 506 | SHARD CUBE | `weapon_506_shard_cube.png` | `weapon_506_shard_cube.svg` | Floating cube firing random projectiles in all directions |
| 507 | CHARGE LASER | `weapon_507_charge_laser.png` | `weapon_507_charge_laser.svg` | Charges a laser that fires until released |
| 508 | ENERGY BUBBLER | `weapon_508_energy_bubbler.png` | `weapon_508_energy_bubbler.svg` | Fires slow-moving energy bubbles |
| 509 | CORRUPTING VIRUS | `weapon_509_corrupting_virus.png` | `weapon_509_corrupting_virus.svg` | Fires virus cloud with spreading infection |
| 510 | HIOX-029 HOME BEACON | `weapon_510_hiox_029_home_beacon.png` | `weapon_510_hiox_beacon.svg` | Beacon device that recruits HIOX-029 minions |
| 511 | ETCHING LASER | `weapon_511_etching_laser.png` | `weapon_511_etching_laser.svg` | Precision laser with instant hit mechanics |

### Melee Weapons (Type 4)

| ID | Weapon Name | PNG File | SVG File | Description |
|----|-------------|----------|----------|-------------|
| 800 | STANDARD SWORD | `weapon_800_standard_sword.png` | `weapon_800_standard_sword.svg` | Standard sword with short range and medium damage |

## Design Specifications

### PNG Images (Full-Color Rendered)
- **Dimensions**: 800x400 pixels
- **Format**: PNG with alpha channel support
- **Color depth**: 24-bit RGB
- **Features**:
  - Type-specific gradient backgrounds
  - Detailed weapon geometry with outlines and fills
  - Visual effects (glows, particles, beams, shadows)
  - Anti-aliased text rendering
  - Professional drop shadows on labels

### SVG Images (Vector Graphics)
- **Dimensions**: 200x100 pixels
- **Format**: SVG 1.1

### Color Schemes

#### PNG Gradient Backgrounds (by weapon type)
- **Gun weapons**: Dark blue-gray gradient `(30,35,40) → (15,20,25)`
- **Turret**: Blue-tinted gradient `(35,35,50) → (20,20,35)`
- **Energy weapons**: Purple-tinted gradient `(25,30,50) → (15,20,35)`
- **Bio weapons**: Green-tinted gradient `(25,40,25) → (15,25,15)`
- **Summon weapons**: Dark blue gradient `(30,30,45) → (20,20,30)`
- **Melee weapons**: Brown-tinted gradient `(35,30,25) → (20,15,10)`

#### Common Color Elements
- **Text (title)**: White `#FFFFFF` with black shadow for contrast
- **Text (ID)**: Light gray `#AAAAAA` with black shadow
- **Energy effects**:
  - Cyan: `(100,255,255)`
  - Green: `(100,255,100)`
  - Red: `(255,100,100)`
  - Blue: `(100,150,255)`
  - Magenta: `(255,100,255)`

### Image Elements
Each weapon image includes:
1. **Weapon illustration** - Detailed representation of the weapon type with appropriate visual style
2. **Weapon name** - Displayed at top center with shadow effect
3. **Mod ID** - Displayed at bottom center in gray text

### Visual Design Themes

#### Conventional Weapons (500-504)
- Military/industrial color palette (grays, browns, greens)
- Realistic proportions and components
- Traditional gun shapes (barrel, body, handle, trigger)

#### Advanced Tech Weapons (505-511)
- Energy-based visual effects (glows, particles, beams)
- Futuristic color schemes (blues, cyans, magentas)
- Sci-fi elements (floating cubes, energy chambers, laser beams)

#### Melee Weapons (800)
- Medieval/fantasy styling
- Metallic finishes and highlights
- Traditional sword components (blade, guard, grip, pommel)

## Usage

These images can be used for:
- **PNG images** (recommended):
  - Production game UI weapon selection screens
  - High-quality inventory displays
  - Marketing materials and promotional content
  - Documentation and player guides
  - Web displays and social media
- **SVG images**:
  - Quick prototyping and mockups
  - Developer documentation
  - Editable templates for custom artwork
  - Version control friendly asset management

## Image Generation

PNG images are automatically generated using the Python script `generate_weapon_images.py` at the repository root.

### Regenerating Images

To regenerate all weapon images:

```bash
python3 generate_weapon_images.py
```

Requirements:
- Python 3.7+
- Pillow library (`pip install Pillow`)

The script generates 800x400 pixel PNG images with:
- Type-specific gradient backgrounds
- Detailed weapon illustrations
- Professional text rendering
- Optimized file sizes

### Customizing the Generator

To modify the generated images:
1. Edit `generate_weapon_images.py`
2. Modify the weapon drawing functions (e.g., `draw_sniper()`)
3. Adjust colors in `get_background_colors()`
4. Change dimensions by updating `WIDTH` and `HEIGHT` constants
5. Run the script to regenerate all images

## Customization

### PNG Customization
- Edit `generate_weapon_images.py` to modify weapon illustrations
- Adjust gradients, colors, and effects in the drawing functions
- Regenerate images using the Python script

### SVG Customization
1. Open the SVG file in any text editor or vector graphics editor (Inkscape, Adobe Illustrator, etc.)
2. Modify colors by changing hex values in fill and stroke attributes
3. Adjust shapes by modifying SVG path/shape elements
4. Scale to desired size (SVG maintains quality at any resolution)

## File Naming Convention

Files follow the pattern: `weapon_[MODID]_[name_in_lowercase].[ext]`

Examples:
- PNG: `weapon_502_sniper.png`
- SVG: `weapon_502_sniper.svg`

## Future Enhancements

Potential improvements for production use:
- **Animation support**: Animated PNGs (APNG) or sprite sheets
- **Multiple views**: Side, top, isometric perspectives
- **Texture improvements**: More detailed shading and highlights
- **3D renders**: Integration with 3D modeling tools
- **Sprite sheet generation**: Automated sprite atlas creation for game engines
- **Additional formats**: WebP for web optimization, JPEG for photos
- **Variant generation**: Automatic color scheme variations

## Related Files

- Source data: `/Assets/ModsData.csv`
- Asset definitions: `/Assets/ModsData.asset`
- Documentation: `/CLAUDE.md`

## License

These placeholder images are part of the HEL Integration Package and follow the same license as the repository.
