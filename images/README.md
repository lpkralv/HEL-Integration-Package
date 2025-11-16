# Weapon Image Assets

This directory contains SVG placeholder images for all weapons defined in the HEL Integration Package.

## Overview

All images are created as SVG (Scalable Vector Graphics) files at 200x100 pixels. SVG format was chosen because:
- Scalable to any size without quality loss
- Small file size
- Easy to modify and customize
- Text-based format suitable for version control

## Weapon Image Catalog

### Gun-Type Weapons (Type 2)

| ID | Weapon Name | File | Description |
|----|-------------|------|-------------|
| 500 | STANDARD GUN | `weapon_500_standard_gun.svg` | Standard small size assault rifle gun |
| 501 | SHOTGUN | `weapon_501_shotgun.svg` | Fires group of bullets in a burst with reduced accuracy |
| 502 | SNIPER | `weapon_502_sniper.svg` | High damage, perfect accuracy, slower fire rate with scope |
| 503 | MACHINE GUN | `weapon_503_machine_gun.svg` | High fire rate with ammo belt, includes bipod |
| 504 | GRENADE LAUNCHER | `weapon_504_grenade_launcher.svg` | Fires grenades with explosion radius |
| 505 | AUTO-TURRET | `weapon_505_auto_turret.svg` | Shoulder-mounted auto-turret with twin barrels |
| 506 | SHARD CUBE | `weapon_506_shard_cube.svg` | Floating cube firing random projectiles in all directions |
| 507 | CHARGE LASER | `weapon_507_charge_laser.svg` | Charges a laser that fires until released |
| 508 | ENERGY BUBBLER | `weapon_508_energy_bubbler.svg` | Fires slow-moving energy bubbles |
| 509 | CORRUPTING VIRUS | `weapon_509_corrupting_virus.svg` | Fires virus cloud with spreading infection |
| 510 | HIOX-029 HOME BEACON | `weapon_510_hiox_beacon.svg` | Beacon device that recruits HIOX-029 minions |
| 511 | ETCHING LASER | `weapon_511_etching_laser.svg` | Precision laser with instant hit mechanics |

### Melee Weapons (Type 4)

| ID | Weapon Name | File | Description |
|----|-------------|------|-------------|
| 800 | STANDARD SWORD | `weapon_800_standard_sword.svg` | Standard sword with short range and medium damage |

## Design Specifications

### Standard Dimensions
- Width: 200 pixels
- Height: 100 pixels
- Format: SVG 1.1

### Color Scheme
- Background: `#1a1a1a` (dark gray/black)
- Text (title): `#ffffff` (white)
- Text (ID): `#aaaaaa` (light gray)
- Weapon bodies: Various dark tones (`#2a2a2a` - `#5a5a5a`)
- Energy effects: Blues (`#44aaff`), Greens (`#44ff44`), Reds (`#ff4444`), Cyans (`#44ffff`), Magentas (`#ff44ff`)

### Image Elements
Each weapon image includes:
1. **Weapon illustration** - Stylized representation of the weapon type
2. **Weapon name** - Displayed at top in white text
3. **Mod ID** - Displayed at bottom in gray text

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
- Game UI weapon selection screens
- Inventory displays
- Documentation and guides
- Asset catalogs
- Testing and development

## Customization

To customize these images:
1. Open the SVG file in any text editor or vector graphics editor (Inkscape, Adobe Illustrator, etc.)
2. Modify colors by changing hex values in fill and stroke attributes
3. Adjust shapes by modifying SVG path/shape elements
4. Scale to desired size (SVG maintains quality at any resolution)

## File Naming Convention

Files follow the pattern: `weapon_[MODID]_[name_in_lowercase].svg`

Example: `weapon_502_sniper.svg`

## Future Enhancements

Potential improvements for production use:
- Higher detail artwork
- Animation support (SVG SMIL or CSS animations)
- Multiple views (side, top, isometric)
- Texture and shading improvements
- Sprite sheet generation for game engines
- PNG/WebP exports for web use

## Related Files

- Source data: `/Assets/ModsData.csv`
- Asset definitions: `/Assets/ModsData.asset`
- Documentation: `/CLAUDE.md`

## License

These placeholder images are part of the HEL Integration Package and follow the same license as the repository.
