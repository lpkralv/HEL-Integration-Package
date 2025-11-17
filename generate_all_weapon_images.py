#!/usr/bin/env python3
"""
Generate PNG images for ALL 156 mods from mod_list.csv
Handles multiple mod types with appropriate visual themes.
"""

from PIL import Image, ImageDraw, ImageFont
import os
import csv
import sys

# Image dimensions
WIDTH = 800
HEIGHT = 400
OUTPUT_DIR = "images"

# Type definitions
TYPE_NANITES = 0
TYPE_WEAPONS = 2
TYPE_MELEE = 4
TYPE_UPGRADES = 10


def draw_gradient_background(draw, width, height, color1, color2):
    """Draw a vertical gradient background."""
    for y in range(height):
        ratio = y / height
        r = int(color1[0] * (1 - ratio) + color2[0] * ratio)
        g = int(color1[1] * (1 - ratio) + color2[1] * ratio)
        b = int(color1[2] * (1 - ratio) + color2[2] * ratio)
        draw.line([(0, y), (width, y)], fill=(r, g, b))


def get_background_colors(mod_type, mod_id):
    """Get background gradient colors based on mod type and ID."""
    if mod_type == TYPE_WEAPONS:
        return ((25, 30, 50), (15, 20, 35))  # Blue-purple (energy weapons)
    elif mod_type == TYPE_MELEE:
        return ((50, 25, 25), (30, 15, 15))  # Red-brown (melee)
    elif mod_type == TYPE_NANITES:
        # Vary nanite backgrounds by ID range
        if 1025 <= mod_id <= 1033:  # Explosive nanites
            return ((50, 35, 20), (30, 20, 10))  # Orange-brown
        elif 2000 <= mod_id <= 2007:  # Structural
            return ((35, 35, 45), (20, 20, 30))  # Gray-blue
        elif 2008 <= mod_id <= 2014:  # Mobility
            return ((30, 45, 30), (15, 30, 15))  # Green
        elif 2015 <= mod_id <= 2020:  # Regeneration
            return ((30, 50, 40), (15, 35, 25))  # Cyan-green
        elif 2021 <= mod_id <= 2028:  # Offensive
            return ((50, 30, 30), (35, 15, 15))  # Red
        elif 2029 <= mod_id <= 2034:  # Resistance
            return ((40, 30, 50), (25, 15, 35))  # Purple
        elif 2035 <= mod_id <= 2042:  # Resource
            return ((30, 40, 50), (15, 25, 35))  # Blue
        elif 2043 <= mod_id <= 2049:  # Tactical
            return ((45, 45, 30), (30, 30, 15))  # Yellow-gray
        else:
            return ((35, 35, 35), (20, 20, 20))  # Default gray
    elif mod_type == TYPE_UPGRADES:
        # Syringes - bright medical colors
        if 3000 <= mod_id <= 3009:  # Combat
            return ((50, 20, 20), (35, 10, 10))  # Dark red
        elif 3010 <= mod_id <= 3019:  # Defensive
            return ((20, 30, 50), (10, 15, 35))  # Blue
        elif 3020 <= mod_id <= 3029:  # Metabolic
            return ((20, 50, 30), (10, 35, 15))  # Green
        elif 3030 <= mod_id <= 3038:  # Elemental
            return ((50, 30, 50), (35, 15, 35))  # Magenta
        elif 3039 <= mod_id <= 3046:  # Tactical
            return ((40, 40, 20), (25, 25, 10))  # Yellow
        elif 3047 <= mod_id <= 3050:  # Exotic
            return ((30, 50, 50), (15, 35, 35))  # Cyan
        else:
            return ((40, 30, 40), (25, 15, 25))  # Purple
    else:
        return ((30, 30, 30), (15, 15, 15))  # Default


def draw_generic_weapon(draw, center_x, center_y, color_scheme='blue'):
    """Draw a generic weapon shape."""
    if color_scheme == 'blue':
        primary = (70, 70, 100)
        secondary = (50, 50, 80)
    elif color_scheme == 'red':
        primary = (100, 50, 50)
        secondary = (80, 30, 30)
    else:
        primary = (70, 70, 70)
        secondary = (50, 50, 50)

    # Weapon body
    draw.rectangle([center_x-100, center_y-20, center_x+40, center_y+20],
                   fill=primary, outline=(primary[0]+30, primary[1]+30, primary[2]+30), width=3)

    # Barrel
    draw.rectangle([center_x+40, center_y-12, center_x+120, center_y+12],
                   fill=secondary, outline=(secondary[0]+30, secondary[1]+30, secondary[2]+30), width=2)

    # Handle
    draw.rectangle([center_x-40, center_y+20, center_x-20, center_y+60],
                   fill=secondary, outline=(secondary[0]+20, secondary[1]+20, secondary[2]+20), width=2)


def draw_generic_melee(draw, center_x, center_y):
    """Draw a generic melee weapon."""
    # Blade
    blade_points = [
        (center_x, center_y-100),
        (center_x+12, center_y),
        (center_x, center_y+50),
        (center_x-12, center_y),
    ]
    draw.polygon(blade_points, fill=(180, 180, 200), outline=(220, 220, 240), width=3)

    # Handle
    draw.rectangle([center_x-15, center_y+45, center_x+15, center_y+95],
                   fill=(60, 40, 20), outline=(90, 70, 50), width=3)


def draw_nanite_swarm(draw, center_x, center_y, color):
    """Draw nanite particles/swarm."""
    import random
    random.seed(hash(color))

    # Central core
    draw.ellipse([center_x-40, center_y-40, center_x+40, center_y+40],
                 fill=color, outline=(min(255, color[0]+50), min(255, color[1]+50), min(255, color[2]+50)), width=3)

    # Orbiting nanites
    for i in range(20):
        angle = (i / 20) * 6.28318
        import math
        radius = 60 + random.randint(-10, 10)
        x = center_x + int(radius * math.cos(angle))
        y = center_y + int(radius * math.sin(angle))
        size = random.randint(3, 8)
        draw.ellipse([x-size, y-size, x+size, y+size],
                    fill=color, outline=(255, 255, 255), width=1)


def draw_syringe(draw, center_x, center_y, liquid_color):
    """Draw a syringe/injection device."""
    # Syringe body (glass)
    draw.rectangle([center_x-30, center_y-80, center_x+30, center_y+20],
                   fill=(200, 220, 230, 180), outline=(150, 170, 180), width=3)

    # Liquid inside
    draw.rectangle([center_x-25, center_y-60, center_x+25, center_y+15],
                   fill=liquid_color)

    # Needle
    draw.polygon([center_x-5, center_y-80, center_x+5, center_y-80,
                 center_x, center_y-120],
                 fill=(180, 180, 190), outline=(150, 150, 160), width=2)

    # Plunger
    draw.rectangle([center_x-25, center_y+15, center_x+25, center_y+25],
                   fill=(100, 100, 110), outline=(130, 130, 140), width=2)
    draw.rectangle([center_x-8, center_y+25, center_x+8, center_y+50],
                   fill=(80, 80, 90), outline=(110, 110, 120), width=2)


def generate_mod_image(mod_id, mod_name, mod_type):
    """Generate a PNG image for a mod."""
    # Create image
    img = Image.new('RGB', (WIDTH, HEIGHT), color=(20, 20, 20))
    draw = ImageDraw.Draw(img, 'RGBA')

    # Draw gradient background
    bg_color1, bg_color2 = get_background_colors(mod_type, mod_id)
    draw_gradient_background(draw, WIDTH, HEIGHT, bg_color1, bg_color2)

    # Draw mod graphic
    center_x = WIDTH // 2
    center_y = HEIGHT // 2

    if mod_type == TYPE_WEAPONS:
        draw_generic_weapon(draw, center_x, center_y, 'blue')
    elif mod_type == TYPE_MELEE:
        draw_generic_melee(draw, center_x, center_y)
    elif mod_type == TYPE_NANITES:
        # Determine nanite color based on ID
        if 1025 <= mod_id <= 1033:
            color = (255, 150, 50)  # Orange (explosive)
        elif 2000 <= mod_id <= 2007:
            color = (100, 100, 150)  # Blue (structural)
        elif 2008 <= mod_id <= 2014:
            color = (100, 200, 100)  # Green (mobility)
        elif 2015 <= mod_id <= 2020:
            color = (100, 255, 200)  # Cyan (regen)
        elif 2021 <= mod_id <= 2028:
            color = (255, 100, 100)  # Red (offensive)
        elif 2029 <= mod_id <= 2034:
            color = (200, 100, 255)  # Purple (resistance)
        elif 2035 <= mod_id <= 2042:
            color = (100, 150, 255)  # Blue (resource)
        else:
            color = (255, 255, 100)  # Yellow (tactical)
        draw_nanite_swarm(draw, center_x, center_y, color)
    elif mod_type == TYPE_UPGRADES:
        # Syringe with type-specific color
        if 3000 <= mod_id <= 3009:
            liquid = (255, 50, 50)  # Red (combat)
        elif 3010 <= mod_id <= 3019:
            liquid = (50, 100, 255)  # Blue (defensive)
        elif 3020 <= mod_id <= 3029:
            liquid = (50, 255, 100)  # Green (metabolic)
        elif 3030 <= mod_id <= 3038:
            liquid = (255, 50, 255)  # Magenta (elemental)
        elif 3039 <= mod_id <= 3046:
            liquid = (255, 255, 50)  # Yellow (tactical)
        else:
            liquid = (50, 255, 255)  # Cyan (exotic)
        draw_syringe(draw, center_x, center_y, liquid)

    # Add text labels
    try:
        title_font = ImageFont.truetype("/usr/share/fonts/truetype/dejavu/DejaVuSans-Bold.ttf", 24)
        id_font = ImageFont.truetype("/usr/share/fonts/truetype/dejavu/DejaVuSans.ttf", 16)
    except:
        title_font = ImageFont.load_default()
        id_font = ImageFont.load_default()

    # Title with shadow (word wrap for long names)
    words = mod_name.split()
    if len(words) > 4:
        line1 = ' '.join(words[:len(words)//2])
        line2 = ' '.join(words[len(words)//2:])
        draw.text((center_x+2, 17), line1, fill=(0, 0, 0), font=title_font, anchor="mm")
        draw.text((center_x, 15), line1, fill=(255, 255, 255), font=title_font, anchor="mm")
        draw.text((center_x+2, 42), line2, fill=(0, 0, 0), font=title_font, anchor="mm")
        draw.text((center_x, 40), line2, fill=(255, 255, 255), font=title_font, anchor="mm")
    else:
        draw.text((center_x+2, 22), mod_name, fill=(0, 0, 0), font=title_font, anchor="mm")
        draw.text((center_x, 20), mod_name, fill=(255, 255, 255), font=title_font, anchor="mm")

    # ID and type label
    type_names = {0: "NANITE", 2: "WEAPON", 4: "MELEE", 10: "SYRINGE"}
    type_label = type_names.get(mod_type, f"TYPE-{mod_type}")
    id_text = f"ID: {mod_id} | {type_label}"
    draw.text((center_x+1, HEIGHT-21), id_text, fill=(0, 0, 0), font=id_font, anchor="mm")
    draw.text((center_x, HEIGHT-20), id_text, fill=(170, 170, 170), font=id_font, anchor="mm")

    return img


def main():
    """Generate all mod images from mod_list.csv."""
    os.makedirs(OUTPUT_DIR, exist_ok=True)

    # Read mod list
    mods = []
    with open('mod_list.csv', 'r') as f:
        reader = csv.DictReader(f)
        for row in reader:
            mods.append({
                'id': int(row['modid']),
                'name': row['name'],
                'type': int(row['type'])
            })

    # Filter by type if specified
    if len(sys.argv) > 1:
        filter_type = int(sys.argv[1])
        mods = [m for m in mods if m['type'] == filter_type]
        print(f"Filtering to type {filter_type}: {len(mods)} mods")

    print(f"Generating {len(mods)} mod images...")

    for mod in mods:
        mod_id = mod['id']
        mod_name = mod['name']
        mod_type = mod['type']

        filename = f"mod_{mod_id}_{mod_name.lower().replace(' ', '_').replace('-', '_')}.png"
        filepath = os.path.join(OUTPUT_DIR, filename)

        print(f"  Generating {filename}...")
        img = generate_mod_image(mod_id, mod_name, mod_type)
        img.save(filepath, 'PNG', optimize=True)

    print(f"\n✓ Successfully generated {len(mods)} mod images in {OUTPUT_DIR}/")


if __name__ == "__main__":
    main()
