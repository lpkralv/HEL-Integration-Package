#!/usr/bin/env python3
"""
Generate fully rendered PNG images for all weapons.
Creates high-quality, full-color weapon images using PIL/Pillow.
"""

from PIL import Image, ImageDraw, ImageFont
import os

# Image dimensions
WIDTH = 800
HEIGHT = 400

# Output directory
OUTPUT_DIR = "images"

# Weapon definitions from ModsData.csv
WEAPONS = [
    {"id": 500, "name": "STANDARD GUN", "type": "gun"},
    {"id": 501, "name": "SHOTGUN", "type": "gun"},
    {"id": 502, "name": "SNIPER", "type": "gun"},
    {"id": 503, "name": "MACHINE GUN", "type": "gun"},
    {"id": 504, "name": "GRENADE LAUNCHER", "type": "gun"},
    {"id": 505, "name": "AUTO-TURRET", "type": "turret"},
    {"id": 506, "name": "SHARD CUBE", "type": "energy"},
    {"id": 507, "name": "CHARGE LASER", "type": "energy"},
    {"id": 508, "name": "ENERGY BUBBLER", "type": "energy"},
    {"id": 509, "name": "CORRUPTING VIRUS", "type": "bio"},
    {"id": 510, "name": "HIOX-029 HOME BEACON", "type": "summon"},
    {"id": 511, "name": "ETCHING LASER", "type": "energy"},
    {"id": 800, "name": "STANDARD SWORD", "type": "melee"},
]


def draw_gradient_background(draw, width, height, color1, color2):
    """Draw a vertical gradient background."""
    for y in range(height):
        ratio = y / height
        r = int(color1[0] * (1 - ratio) + color2[0] * ratio)
        g = int(color1[1] * (1 - ratio) + color2[1] * ratio)
        b = int(color1[2] * (1 - ratio) + color2[2] * ratio)
        draw.line([(0, y), (width, y)], fill=(r, g, b))


def draw_standard_gun(draw, center_x, center_y):
    """Draw a standard assault rifle."""
    # Gun body
    draw.rectangle([center_x-120, center_y-25, center_x+20, center_y+25],
                   fill=(70, 70, 80), outline=(100, 100, 110), width=3)

    # Barrel
    draw.rectangle([center_x+20, center_y-15, center_x+100, center_y+15],
                   fill=(80, 80, 90), outline=(110, 110, 120), width=3)

    # Barrel tip
    draw.ellipse([center_x+95, center_y-18, center_x+105, center_y+18],
                 fill=(50, 50, 60), outline=(80, 80, 90), width=2)

    # Magazine
    draw.rectangle([center_x-40, center_y+25, center_x-10, center_y+70],
                   fill=(50, 50, 60), outline=(70, 70, 80), width=2)

    # Stock
    draw.polygon([center_x-120, center_y-20, center_x-160, center_y-15,
                  center_x-160, center_y+15, center_x-120, center_y+20],
                 fill=(60, 60, 70), outline=(90, 90, 100), width=2)

    # Handle
    draw.rectangle([center_x-50, center_y+25, center_x-30, center_y+65],
                   fill=(40, 40, 50), outline=(60, 60, 70), width=2)

    # Trigger
    draw.ellipse([center_x-25, center_y+15, center_x-15, center_y+30],
                 fill=(30, 30, 40), outline=(50, 50, 60), width=1)

    # Scope rail
    draw.rectangle([center_x-40, center_y-30, center_x+10, center_y-25],
                   fill=(40, 40, 50), outline=(60, 60, 70), width=1)


def draw_shotgun(draw, center_x, center_y):
    """Draw a shotgun with double barrel."""
    # Gun body
    draw.rectangle([center_x-110, center_y-30, center_x+20, center_y+30],
                   fill=(70, 50, 30), outline=(100, 80, 60), width=3)

    # Double barrels
    draw.rectangle([center_x+20, center_y-25, center_x+110, center_y-5],
                   fill=(80, 60, 40), outline=(110, 90, 70), width=3)
    draw.rectangle([center_x+20, center_y+5, center_x+110, center_y+25],
                   fill=(80, 60, 40), outline=(110, 90, 70), width=3)

    # Barrel tips
    draw.ellipse([center_x+105, center_y-28, center_x+115, center_y-2],
                 fill=(40, 30, 20), outline=(70, 50, 30), width=2)
    draw.ellipse([center_x+105, center_y+2, center_x+115, center_y+28],
                 fill=(40, 30, 20), outline=(70, 50, 30), width=2)

    # Pump action
    draw.rectangle([center_x-20, center_y-35, center_x+10, center_y-25],
                   fill=(50, 40, 25), outline=(80, 60, 40), width=2)

    # Stock
    draw.polygon([center_x-110, center_y-25, center_x-150, center_y-20,
                  center_x-150, center_y+20, center_x-110, center_y+25],
                 fill=(60, 45, 30), outline=(90, 70, 50), width=2)

    # Handle
    draw.rectangle([center_x-40, center_y+30, center_x-20, center_y+70],
                   fill=(50, 35, 20), outline=(70, 55, 35), width=2)


def draw_sniper(draw, center_x, center_y):
    """Draw a sniper rifle with scope."""
    # Gun body
    draw.rectangle([center_x-130, center_y-20, center_x+30, center_y+25],
                   fill=(40, 70, 40), outline=(70, 100, 70), width=3)

    # Long barrel
    draw.rectangle([center_x+30, center_y-12, center_x+150, center_y+12],
                   fill=(50, 80, 50), outline=(80, 110, 80), width=3)

    # Barrel tip with suppressor
    draw.rectangle([center_x+140, center_y-15, center_x+160, center_y+15],
                   fill=(30, 50, 30), outline=(60, 80, 60), width=2)

    # Scope
    draw.ellipse([center_x-50, center_y-60, center_x+50, center_y-30],
                 fill=(20, 40, 40), outline=(50, 70, 70), width=3)

    # Scope lens
    draw.ellipse([center_x+30, center_y-55, center_x+45, center_y-35],
                 fill=(100, 150, 200), outline=(150, 180, 220), width=2)

    # Crosshair reflection
    draw.line([center_x+35, center_y-50, center_x+40, center_y-40],
              fill=(200, 220, 255), width=1)

    # Bipod
    draw.line([center_x+80, center_y+12, center_x+70, center_y+50],
              fill=(60, 60, 70), width=4)
    draw.line([center_x+100, center_y+12, center_x+110, center_y+50],
              fill=(60, 60, 70), width=4)

    # Stock
    draw.polygon([center_x-130, center_y-15, center_x-170, center_y-10,
                  center_x-170, center_y+20, center_x-130, center_y+20],
                 fill=(30, 60, 30), outline=(60, 90, 60), width=2)

    # Handle
    draw.rectangle([center_x-60, center_y+25, center_x-40, center_y+65],
                   fill=(30, 50, 30), outline=(50, 80, 50), width=2)


def draw_machine_gun(draw, center_x, center_y):
    """Draw a heavy machine gun."""
    # Large gun body
    draw.rectangle([center_x-120, center_y-35, center_x+30, center_y+35],
                   fill=(70, 70, 40), outline=(100, 100, 70), width=4)

    # Thick barrel
    draw.rectangle([center_x+30, center_y-25, center_x+130, center_y+25],
                   fill=(80, 80, 50), outline=(110, 110, 80), width=4)

    # Barrel heat shield
    for i in range(5):
        x = center_x + 40 + i * 18
        draw.line([x, center_y-30, x, center_y-25], fill=(60, 60, 40), width=2)
        draw.line([x, center_y+25, x, center_y+30], fill=(60, 60, 40), width=2)

    # Ammo belt
    draw.rectangle([center_x-60, center_y-50, center_x+20, center_y-35],
                   fill=(60, 60, 30), outline=(90, 90, 60), width=2)

    # Ammo belt feed
    for i in range(6):
        x = center_x - 55 + i * 13
        draw.rectangle([x, center_y-48, x+5, center_y-37],
                      fill=(180, 150, 50), outline=(200, 170, 70), width=1)

    # Bipod legs
    draw.line([center_x+60, center_y+35, center_x+50, center_y+80],
              fill=(70, 70, 70), width=5)
    draw.line([center_x+80, center_y+35, center_x+90, center_y+80],
              fill=(70, 70, 70), width=5)

    # Handle
    draw.rectangle([center_x-50, center_y+35, center_x-30, center_y+75],
                   fill=(50, 50, 30), outline=(70, 70, 50), width=2)


def draw_grenade_launcher(draw, center_x, center_y):
    """Draw a grenade launcher."""
    # Gun body
    draw.rectangle([center_x-100, center_y-30, center_x+20, center_y+30],
                   fill=(70, 40, 40), outline=(100, 70, 70), width=3)

    # Wide barrel/cylinder
    draw.ellipse([center_x+10, center_y-40, center_x+110, center_y+40],
                 fill=(80, 50, 50), outline=(110, 80, 80), width=4)

    # Cylinder chambers
    angles = [0, 60, 120, 180, 240, 300]
    for angle in angles:
        import math
        rad = math.radians(angle)
        x = center_x + 60 + int(15 * math.cos(rad))
        y = center_y + int(15 * math.sin(rad))
        draw.ellipse([x-8, y-8, x+8, y+8],
                    fill=(50, 70, 50), outline=(80, 100, 80), width=2)

    # Barrel opening
    draw.ellipse([center_x+100, center_y-25, center_x+120, center_y+25],
                 fill=(40, 30, 30), outline=(80, 60, 60), width=3)

    # Stock
    draw.polygon([center_x-100, center_y-25, center_x-130, center_y-20,
                  center_x-130, center_y+20, center_x-100, center_y+25],
                 fill=(60, 35, 35), outline=(90, 65, 65), width=2)

    # Handle
    draw.rectangle([center_x-40, center_y+30, center_x-20, center_y+70],
                   fill=(50, 30, 30), outline=(70, 50, 50), width=2)


def draw_auto_turret(draw, center_x, center_y):
    """Draw an auto-turret."""
    # Base platform
    draw.polygon([center_x-60, center_y+40, center_x+60, center_y+40,
                  center_x+50, center_y+60, center_x-50, center_y+60],
                 fill=(60, 60, 80), outline=(90, 90, 110), width=3)

    # Turret body
    draw.ellipse([center_x-50, center_y-30, center_x+50, center_y+40],
                 fill=(70, 70, 90), outline=(100, 100, 120), width=4)

    # Twin barrels
    draw.rectangle([center_x+40, center_y-20, center_x+120, center_y-5],
                   fill=(80, 80, 100), outline=(110, 110, 130), width=3)
    draw.rectangle([center_x+40, center_y+5, center_x+120, center_y+20],
                   fill=(80, 80, 100), outline=(110, 110, 130), width=3)

    # Sensor/camera
    draw.ellipse([center_x-20, center_y-10, center_x+20, center_y+10],
                 fill=(40, 40, 60), outline=(70, 70, 90), width=2)

    # Camera lens (glowing red)
    draw.ellipse([center_x-10, center_y-5, center_x+10, center_y+5],
                 fill=(255, 50, 50), outline=(255, 100, 100), width=2)

    # Mounting arm
    draw.rectangle([center_x-15, center_y-60, center_x+15, center_y-30],
                   fill=(60, 60, 80), outline=(90, 90, 110), width=2)

    # Status lights
    draw.ellipse([center_x-35, center_y+25, center_x-25, center_y+35],
                 fill=(50, 255, 50))
    draw.ellipse([center_x+25, center_y+25, center_x+35, center_y+35],
                 fill=(50, 255, 50))


def draw_shard_cube(draw, center_x, center_y):
    """Draw a floating shard cube."""
    # Floating cube (isometric)
    # Top face
    draw.polygon([center_x, center_y-50, center_x+60, center_y-30,
                  center_x, center_y-10, center_x-60, center_y-30],
                 fill=(70, 70, 110), outline=(100, 100, 140), width=3)

    # Right face
    draw.polygon([center_x, center_y-50, center_x+60, center_y-30,
                  center_x+60, center_y+30, center_x, center_y+50],
                 fill=(60, 60, 90), outline=(90, 90, 120), width=3)

    # Left face
    draw.polygon([center_x, center_y-50, center_x-60, center_y-30,
                  center_x-60, center_y+30, center_x, center_y+50],
                 fill=(50, 50, 80), outline=(80, 80, 110), width=3)

    # Energy core
    draw.ellipse([center_x-25, center_y-15, center_x+25, center_y+15],
                 fill=(255, 100, 255), outline=(255, 150, 255), width=3)
    draw.ellipse([center_x-15, center_y-10, center_x+15, center_y+10],
                 fill=(255, 200, 255))

    # Projectile trails radiating out
    projectiles = [
        (140, -50, (255, 100, 255)),
        (150, 20, (100, 255, 100)),
        (120, 80, (100, 100, 255)),
        (-140, -40, (255, 255, 100)),
        (-110, 70, (255, 100, 100)),
        (0, -100, (100, 255, 255)),
    ]

    for px, py, color in projectiles:
        draw.line([center_x, center_y, center_x+px, center_y+py],
                 fill=color, width=3)
        draw.ellipse([center_x+px-8, center_y+py-8, center_x+px+8, center_y+py+8],
                    fill=color, outline=(255, 255, 255), width=2)


def draw_charge_laser(draw, center_x, center_y):
    """Draw a charge laser weapon."""
    # Gun body
    draw.rectangle([center_x-100, center_y-25, center_x+30, center_y+25],
                   fill=(40, 40, 70), outline=(70, 70, 100), width=3)

    # Energy chamber
    draw.rectangle([center_x-30, center_y-35, center_x+20, center_y+35],
                   fill=(50, 50, 80), outline=(80, 80, 110), width=3)

    # Charging coils
    for i in range(3):
        y_offset = -20 + i * 20
        draw.ellipse([center_x-20, center_y+y_offset-8,
                     center_x+10, center_y+y_offset+8],
                    fill=(100, 150, 255), outline=(150, 200, 255), width=2)

    # Laser emitter
    draw.rectangle([center_x+20, center_y-15, center_x+40, center_y+15],
                   fill=(30, 30, 60), outline=(60, 60, 90), width=2)

    # Laser beam
    beam_width = 10
    for i in range(5):
        alpha_factor = 1 - (i * 0.15)
        beam_color = (int(100 * alpha_factor), int(150 * alpha_factor), 255)
        y1 = center_y - beam_width + i * 4
        y2 = center_y + beam_width - i * 4
        if y1 < y2:
            draw.rectangle([center_x+40, y1, center_x+150, y2],
                          fill=beam_color)

    # Laser impact point
    draw.ellipse([center_x+140, center_y-15, center_x+160, center_y+15],
                 fill=(150, 200, 255), outline=(200, 230, 255), width=3)
    draw.ellipse([center_x+145, center_y-10, center_x+155, center_y+10],
                 fill=(255, 255, 255))

    # Handle
    draw.rectangle([center_x-50, center_y+25, center_x-30, center_y+65],
                   fill=(30, 30, 60), outline=(60, 60, 90), width=2)

    # Power indicator
    draw.rectangle([center_x-95, center_y-20, center_x-85, center_y+20],
                   fill=(100, 255, 100))


def draw_energy_bubbler(draw, center_x, center_y):
    """Draw an energy bubbler weapon."""
    # Gun body
    draw.rectangle([center_x-100, center_y-25, center_x+30, center_y+30],
                   fill=(40, 70, 70), outline=(70, 100, 100), width=3)

    # Bubble chamber
    draw.ellipse([center_x-20, center_y-50, center_x+40, center_y+20],
                 fill=(30, 60, 60), outline=(60, 90, 90), width=3)

    # Chamber liquid
    draw.ellipse([center_x-15, center_y-40, center_x+35, center_y+10],
                 fill=(100, 200, 200, 128))

    # Emitter nozzle
    draw.ellipse([center_x+20, center_y-15, center_x+50, center_y+15],
                 fill=(30, 50, 50), outline=(60, 80, 80), width=3)

    # Energy bubbles floating out
    bubbles = [
        (80, -10, 25),
        (120, 0, 18),
        (150, -5, 12),
        (90, 20, 15),
        (130, 25, 10),
    ]

    for bx, by, size in bubbles:
        # Bubble outer
        draw.ellipse([center_x+bx-size, center_y+by-size,
                     center_x+bx+size, center_y+by+size],
                    fill=(100, 255, 255, 100),
                    outline=(150, 255, 255), width=2)
        # Bubble highlight
        hl_size = int(size * 0.4)
        draw.ellipse([center_x+bx-hl_size, center_y+by-size+5,
                     center_x+bx, center_y+by-size+5+hl_size],
                    fill=(200, 255, 255))

    # Handle
    draw.rectangle([center_x-50, center_y+30, center_x-30, center_y+70],
                   fill=(30, 50, 50), outline=(60, 80, 80), width=2)


def draw_corrupting_virus(draw, center_x, center_y):
    """Draw a corrupting virus weapon."""
    # Gun body (organic looking)
    draw.ellipse([center_x-120, center_y-30, center_x+30, center_y+30],
                 fill=(40, 70, 40), outline=(70, 100, 70), width=3)

    # Virus chamber
    draw.ellipse([center_x-50, center_y-40, center_x+20, center_y+20],
                 fill=(30, 60, 30), outline=(60, 90, 60), width=3)

    # Glowing virus core
    draw.ellipse([center_x-35, center_y-25, center_x+5, center_y+5],
                 fill=(100, 255, 100), outline=(150, 255, 150), width=2)

    # Emitter
    draw.ellipse([center_x+15, center_y-20, center_x+45, center_y+10],
                 fill=(40, 60, 40), outline=(70, 90, 70), width=2)

    # Virus cloud
    cloud_particles = [
        (70, -15, 30, 20),
        (110, -5, 25, 18),
        (140, 0, 20, 15),
        (80, 15, 18, 14),
        (120, 20, 15, 12),
    ]

    for cx, cy, w, h in cloud_particles:
        draw.ellipse([center_x+cx-w, center_y+cy-h,
                     center_x+cx+w, center_y+cy+h],
                    fill=(100, 255, 100, 80),
                    outline=(120, 255, 120), width=2)

    # Virus particles
    for i in range(15):
        import random
        random.seed(500 + i)
        px = random.randint(70, 160)
        py = random.randint(-20, 30)
        ps = random.randint(2, 5)
        draw.ellipse([center_x+px-ps, center_y+py-ps,
                     center_x+px+ps, center_y+py+ps],
                    fill=(150, 255, 150))

    # Organic tendrils
    draw.arc([center_x-80, center_y+20, center_x-40, center_y+60],
            start=0, end=180, fill=(60, 90, 60), width=3)
    draw.arc([center_x-60, center_y+25, center_x-30, center_y+55],
            start=0, end=180, fill=(60, 90, 60), width=3)

    # Handle
    draw.rectangle([center_x-70, center_y+30, center_x-50, center_y+70],
                   fill=(30, 50, 30), outline=(60, 80, 60), width=2)


def draw_hiox_beacon(draw, center_x, center_y):
    """Draw HIOX-029 home beacon."""
    # Beacon device
    draw.rectangle([center_x-80, center_y-25, center_x, center_y+25],
                   fill=(60, 60, 90), outline=(90, 90, 120), width=3)

    # Antenna
    draw.rectangle([center_x-50, center_y-50, center_x-45, center_y-25],
                   fill=(70, 70, 100))

    # Beacon light (glowing red)
    draw.ellipse([center_x-60, center_y-65, center_x-35, center_y-50],
                 fill=(255, 100, 100), outline=(255, 150, 150), width=3)
    draw.ellipse([center_x-55, center_y-62, center_x-40, center_y-53],
                 fill=(255, 50, 50))

    # Signal waves
    for radius in [20, 30, 40, 50]:
        draw.arc([center_x-48-radius, center_y-58-radius,
                 center_x-48+radius, center_y-58+radius],
                start=0, end=360, fill=(255, 100, 100, 180-radius*2), width=2)

    # Display screen
    draw.rectangle([center_x-70, center_y-10, center_x-10, center_y+10],
                   fill=(20, 20, 40), outline=(60, 60, 80), width=2)

    # Screen text
    try:
        font = ImageFont.truetype("/usr/share/fonts/truetype/dejavu/DejaVuSansMono.ttf", 12)
    except:
        font = ImageFont.load_default()
    draw.text((center_x-65, center_y-5), "HIOX-029", fill=(100, 255, 100), font=font)

    # Minions (small robots)
    minion_positions = [(60, -10), (100, 0), (130, -5)]
    for mx, my in minion_positions:
        # Body
        draw.rounded_rectangle([center_x+mx-15, center_y+my-20,
                               center_x+mx+15, center_y+my+20],
                              radius=3, fill=(70, 70, 100),
                              outline=(100, 100, 130), width=2)
        # Eye (glowing cyan)
        draw.ellipse([center_x+mx-8, center_y+my-12,
                     center_x+mx+8, center_y+my-4],
                    fill=(100, 255, 255), outline=(150, 255, 255), width=2)
        # Legs
        draw.rectangle([center_x+mx-10, center_y+my+20,
                       center_x+mx-5, center_y+my+35],
                      fill=(60, 60, 90))
        draw.rectangle([center_x+mx+5, center_y+my+20,
                       center_x+mx+10, center_y+my+35],
                      fill=(60, 60, 90))

    # Handle
    draw.rectangle([center_x-55, center_y+25, center_x-35, center_y+65],
                   fill=(50, 50, 80), outline=(80, 80, 110), width=2)


def draw_etching_laser(draw, center_x, center_y):
    """Draw an etching laser weapon."""
    # Gun body (precise, technical)
    draw.rectangle([center_x-110, center_y-22, center_x+20, center_y+22],
                   fill=(60, 60, 80), outline=(90, 90, 110), width=3)

    # Precision barrel
    draw.rectangle([center_x+20, center_y-15, center_x+100, center_y+15],
                   fill=(70, 70, 90), outline=(100, 100, 120), width=2)

    # Cooling vents
    for i in range(8):
        x = center_x - 70 + i * 12
        draw.line([x, center_y-22, x, center_y-30],
                 fill=(90, 90, 120), width=2)
        draw.line([x, center_y+22, x, center_y+30],
                 fill=(90, 90, 120), width=2)

    # Focusing lens
    draw.ellipse([center_x+95, center_y-20, center_x+115, center_y+20],
                 fill=(30, 30, 60), outline=(60, 60, 90), width=3)
    draw.ellipse([center_x+100, center_y-15, center_x+110, center_y+15],
                 fill=(100, 100, 200), outline=(150, 150, 255), width=2)

    # Precision laser beam (thin and focused)
    draw.line([center_x+110, center_y, center_x+170, center_y],
             fill=(255, 100, 100), width=4)
    draw.line([center_x+110, center_y, center_x+170, center_y],
             fill=(255, 200, 200), width=2)

    # Laser hit point
    draw.ellipse([center_x+165, center_y-8, center_x+175, center_y+8],
                 fill=(255, 150, 150), outline=(255, 200, 200), width=3)
    draw.ellipse([center_x+168, center_y-5, center_x+172, center_y+5],
                 fill=(255, 255, 255))

    # Power cell
    draw.rectangle([center_x-70, center_y-30, center_x-40, center_y-22],
                   fill=(40, 40, 60), outline=(70, 70, 90), width=2)

    # Power indicators (green bars)
    for i in range(5):
        draw.rectangle([center_x-68+i*5, center_y-28,
                       center_x-65+i*5, center_y-24],
                      fill=(100, 255, 100))

    # Handle
    draw.rectangle([center_x-55, center_y+22, center_x-35, center_y+62],
                   fill=(50, 50, 70), outline=(80, 80, 100), width=2)

    # Trigger
    draw.rectangle([center_x-25, center_y+22, center_x-15, center_y+40],
                   fill=(30, 30, 50), outline=(60, 60, 80), width=1)


def draw_standard_sword(draw, center_x, center_y):
    """Draw a standard medieval sword."""
    # Blade
    blade_points = [
        (center_x, center_y-120),  # tip
        (center_x+15, center_y-100),
        (center_x+18, center_y+10),
        (center_x+8, center_y+20),
        (center_x-8, center_y+20),
        (center_x-18, center_y+10),
        (center_x-15, center_y-100),
    ]
    draw.polygon(blade_points, fill=(180, 180, 200), outline=(200, 200, 220), width=3)

    # Blade edge highlight
    draw.line([center_x-5, center_y-110, center_x-5, center_y+10],
             fill=(220, 220, 240), width=2)

    # Fuller (groove in blade)
    draw.line([center_x+8, center_y-100, center_x+8, center_y+5],
             fill=(140, 140, 160), width=2)

    # Crossguard
    draw.rectangle([center_x-70, center_y+15, center_x+70, center_y+30],
                   fill=(70, 60, 40), outline=(100, 90, 70), width=3)

    # Crossguard ends (decorative)
    draw.ellipse([center_x-75, center_y+15, center_x-65, center_y+30],
                 fill=(60, 50, 30), outline=(90, 80, 60), width=2)
    draw.ellipse([center_x+65, center_y+15, center_x+75, center_y+30],
                 fill=(60, 50, 30), outline=(90, 80, 60), width=2)

    # Grip (handle)
    draw.rectangle([center_x-20, center_y+30, center_x+20, center_y+90],
                   fill=(60, 40, 20), outline=(90, 70, 50), width=3)

    # Grip wrapping
    for i in range(6):
        y = center_y + 35 + i * 10
        draw.line([center_x-20, y, center_x+20, y],
                 fill=(40, 25, 10), width=2)

    # Pommel
    draw.ellipse([center_x-25, center_y+85, center_x+25, center_y+105],
                 fill=(70, 60, 40), outline=(100, 90, 70), width=3)
    draw.ellipse([center_x-15, center_y+90, center_x+15, center_y+100],
                 fill=(60, 50, 30))

    # Decorative gem in pommel
    draw.ellipse([center_x-8, center_y+92, center_x+8, center_y+98],
                 fill=(150, 50, 50), outline=(200, 100, 100), width=2)


# Weapon drawing function mapping
WEAPON_DRAW_FUNCTIONS = {
    500: draw_standard_gun,
    501: draw_shotgun,
    502: draw_sniper,
    503: draw_machine_gun,
    504: draw_grenade_launcher,
    505: draw_auto_turret,
    506: draw_shard_cube,
    507: draw_charge_laser,
    508: draw_energy_bubbler,
    509: draw_corrupting_virus,
    510: draw_hiox_beacon,
    511: draw_etching_laser,
    800: draw_standard_sword,
}


def get_background_colors(weapon_type):
    """Get background gradient colors based on weapon type."""
    backgrounds = {
        "gun": ((30, 35, 40), (15, 20, 25)),
        "turret": ((35, 35, 50), (20, 20, 35)),
        "energy": ((25, 30, 50), (15, 20, 35)),
        "bio": ((25, 40, 25), (15, 25, 15)),
        "summon": ((30, 30, 45), (20, 20, 30)),
        "melee": ((35, 30, 25), (20, 15, 10)),
    }
    return backgrounds.get(weapon_type, ((30, 30, 30), (15, 15, 15)))


def generate_weapon_image(weapon_id, weapon_name, weapon_type):
    """Generate a full-color PNG image for a weapon."""
    # Create image
    img = Image.new('RGB', (WIDTH, HEIGHT), color=(20, 20, 20))
    draw = ImageDraw.Draw(img, 'RGBA')

    # Draw gradient background
    bg_color1, bg_color2 = get_background_colors(weapon_type)
    draw_gradient_background(draw, WIDTH, HEIGHT, bg_color1, bg_color2)

    # Draw weapon
    center_x = WIDTH // 2
    center_y = HEIGHT // 2

    if weapon_id in WEAPON_DRAW_FUNCTIONS:
        WEAPON_DRAW_FUNCTIONS[weapon_id](draw, center_x, center_y)

    # Add title and ID labels
    try:
        title_font = ImageFont.truetype("/usr/share/fonts/truetype/dejavu/DejaVuSans-Bold.ttf", 28)
        id_font = ImageFont.truetype("/usr/share/fonts/truetype/dejavu/DejaVuSans.ttf", 18)
    except:
        title_font = ImageFont.load_default()
        id_font = ImageFont.load_default()

    # Title with shadow
    draw.text((center_x+2, 22), weapon_name, fill=(0, 0, 0),
             font=title_font, anchor="mm")
    draw.text((center_x, 20), weapon_name, fill=(255, 255, 255),
             font=title_font, anchor="mm")

    # ID label
    id_text = f"ID: {weapon_id}"
    draw.text((center_x+1, HEIGHT-21), id_text, fill=(0, 0, 0),
             font=id_font, anchor="mm")
    draw.text((center_x, HEIGHT-20), id_text, fill=(170, 170, 170),
             font=id_font, anchor="mm")

    return img


def main():
    """Generate all weapon images."""
    os.makedirs(OUTPUT_DIR, exist_ok=True)

    print(f"Generating {len(WEAPONS)} weapon images...")

    for weapon in WEAPONS:
        weapon_id = weapon["id"]
        weapon_name = weapon["name"]
        weapon_type = weapon["type"]

        filename = f"weapon_{weapon_id}_{weapon_name.lower().replace(' ', '_').replace('-', '_')}.png"
        filepath = os.path.join(OUTPUT_DIR, filename)

        print(f"  Generating {filename}...")
        img = generate_weapon_image(weapon_id, weapon_name, weapon_type)
        img.save(filepath, 'PNG', optimize=True)

    print(f"\n✓ Successfully generated {len(WEAPONS)} weapon images in {OUTPUT_DIR}/")


if __name__ == "__main__":
    main()
