# Large File Protocol - Detailed Reference

**Purpose**: Efficient handling of large Stats/Mods files to conserve token budget

---

## File Size Thresholds

| Lines | Strategy | Tools Required |
|-------|----------|----------------|
| < 200 | Direct read | `Read` tool |
| 200-500 | Targeted extraction | `findlines.py` + `sniptext.py` |
| 500+ | **NEVER full read** | `findlines.py` + `sniptext.py` ONLY |

**Always check file size first:**
```bash
wc -l <filepath>
```

---

## Critical Large Files in This Repository

### DELIVERABLE Asset Files (YAML)
- `DELIVERABLE-ModsData.asset` (2,947 lines) - 156 mods
- `DELIVERABLE-StatsData.asset` (191 lines) - 27 stats

### Source Asset Files (YAML)
- `src/ModsData.asset` (1,023 lines)
- `Assets/ModsData.asset` (1,023 lines)
- `src/StatsData.asset` (213 lines)
- `Assets/StatsData.asset` (213 lines)

### Documentation Files (Markdown)
- `docs/DELIVERABLE-Mods-Description.md` (616 lines) - 15 mod categories
- `docs/DELIVERABLE-Stats-Description.md` (662 lines) - 27 new stats
- `docs/DELIVERABLE-System-Philosophy.md` (617 lines)

---

## Required Workflow

### Step 1: Identify What You Need
Determine the specific mod ID, stat name, or category you're searching for.

### Step 2: Locate Target Content
```bash
# Find specific mod by ID
python3 findlines.py DELIVERABLE-ModsData.asset "id: 1015"

# Find specific stat by name
python3 findlines.py DELIVERABLE-StatsData.asset "CRIT_CHANCE"

# Find category in documentation
python3 findlines.py docs/DELIVERABLE-Mods-Description.md "ENERGY EMITTERS"
```

### Step 3: Extract Relevant Section
```bash
# Extract lines around the target
python3 sniptext.py DELIVERABLE-ModsData.asset <start_line> <end_line>
```

### Step 4: Expand Only If Necessary
Extract additional sections as needed - but NEVER read the entire file.

---

## Practical Examples

### Example 1: Finding a Specific Mod's Equation

**Task**: Find the equation for "Plasma Rifle" (ID 1015)
**File**: DELIVERABLE-ModsData.asset (2,947 lines)

```bash
# Step 1: Find the mod
python3 findlines.py DELIVERABLE-ModsData.asset "id: 1015"
# Output: [450]

# Step 2: Extract mod definition (typically 15-25 lines per mod)
python3 sniptext.py DELIVERABLE-ModsData.asset 450 475
```

**Result**: ~500 tokens instead of 80,000 tokens (160x savings!)

---

### Example 2: Understanding a Specific Stat

**Task**: Understand how "CRIT_MULTIPLIER" works
**File**: docs/DELIVERABLE-Stats-Description.md (662 lines)

```bash
# Step 1: Find the stat section
python3 findlines.py docs/DELIVERABLE-Stats-Description.md "CRIT_MULTIPLIER"
# Output: [245, 412]

# Step 2: Extract the stat description (add context lines)
python3 sniptext.py docs/DELIVERABLE-Stats-Description.md 410 430
```

---

### Example 3: Finding All Mods in a Category

**Task**: Analyze all ENERGY EMITTERS mods
**File**: docs/DELIVERABLE-Mods-Description.md (616 lines)

```bash
# Step 1: Find category section
python3 findlines.py docs/DELIVERABLE-Mods-Description.md "### ENERGY EMITTERS"
# Output: [133]

# Step 2: Find next category to determine bounds
python3 findlines.py docs/DELIVERABLE-Mods-Description.md "### EXPLOSIVE LAUNCHERS"
# Output: [196]

# Step 3: Extract just the ENERGY EMITTERS section
python3 sniptext.py docs/DELIVERABLE-Mods-Description.md 133 195
```

---

### Example 4: Multi-File Search

**Task**: Find all files referencing "CRIT_CHANCE"

```bash
# Search across all markdown files
python3 findall.py "**/*.md" "CRIT_CHANCE"

# Search across all asset files
python3 findall.py "**/*.asset" "CRIT_CHANCE"

# Then use findlines.py on each result to locate specific lines
```

---

## Token Cost Comparison

| Approach | File | Lines Read | Est. Tokens | Efficiency |
|----------|------|------------|-------------|------------|
| ❌ Read tool | DELIVERABLE-ModsData.asset | 2,947 | ~80,000 | Wasteful |
| ✅ findlines + sniptext | DELIVERABLE-ModsData.asset | 25 | ~600 | **133x better** |
| ❌ Read tool | docs/DELIVERABLE-Mods-Description.md | 616 | ~18,000 | Wasteful |
| ✅ findlines + sniptext | docs/DELIVERABLE-Mods-Description.md | 50 | ~1,200 | **15x better** |

---

## Violation vs. Correct Usage

### ❌ VIOLATION (Wastes Tokens)
```
"I'll read DELIVERABLE-ModsData.asset to see the mod structure..."
[Uses Read tool on 2,947-line file → 80,000 tokens wasted]
```

### ✅ CORRECT (Efficient)
```
"DELIVERABLE-ModsData.asset is 2,947 lines. Using large file protocol.
Searching for mod ID 1015 with findlines.py..."
[Uses findlines.py + sniptext.py → 600 tokens used]
```

---

## Tool Reference

### findall.py - Find Files Containing Text
Searches for files matching a glob pattern that contain a target string.

```bash
# CLI usage
python3 findall.py "**/*.asset" "CRIT_CHANCE"
python3 findall.py "docs/*.md" "ENERGY EMITTERS"

# Module usage
from findall import findall
files = findall("**/*.cs", "HEL")
```

---

### findlines.py - Find Line Numbers
Returns 1-indexed line numbers where a target string appears.

```bash
# CLI usage
python3 findlines.py DELIVERABLE-ModsData.asset "id: 1015"
python3 findlines.py docs/DELIVERABLE-Stats-Description.md "## CRIT"

# Module usage
from findlines import findlines
lines = findlines("src/HELInterpreter.cs", "CoefDict")
```

---

### sniptext.py - Extract Text Snippets
Extracts a snippet from a file by line range (1-indexed, inclusive).

```bash
# CLI usage
python3 sniptext.py DELIVERABLE-ModsData.asset 450 475
python3 sniptext.py docs/DELIVERABLE-Mods-Description.md 133 195

# Module usage
from sniptext import sniptext
snippet = sniptext("src/HEL.cs", 15, 25)
```

---

## Asset File Structure Knowledge

### ModsData.asset Structure
- **Format**: YAML for Unity integration
- **Per-mod size**: ~15-25 lines (id, name, description, HEL equation, tier, values)
- **Organization**: By category (Weapons, Items, Syringes)
- **Total content**: 156 mods across 15 categories
- **Header**: Contains metadata, version info, and mod ID range documentation

### StatsData.asset Structure
- **Format**: YAML for Unity integration
- **Per-stat size**: ~5-10 lines (name, display, description, min, max, base, class)
- **Total content**: 27 new stats (65 total in system including 38 existing)
- **Categories**: Combat, Defense, Elemental, Resource, etc.

### Documentation Structure
- **Format**: Markdown with hierarchical headers
- **Hierarchy**: Category → Subcategory → Individual Mod/Stat
- **Use case**: Grep for `^#` to identify section boundaries
- **Tip**: Use section headers to determine extraction ranges

---

## Pre-Task Checklist

Before starting ANY task involving Stats or Mods:

- [ ] Identify target files (which asset/doc files needed?)
- [ ] Check file sizes with `wc -l <filepath>`
- [ ] Determine what you're searching for (mod ID, stat name, category)
- [ ] Apply findlines.py + sniptext.py for files >200 lines
- [ ] Document what you searched and what lines you examined

---

## Why This Protocol Matters

1. **Token Budget**: ModsData.asset alone consumes 80,000 tokens if read completely
2. **Context Efficiency**: Preserves context window for actual work, not data parsing
3. **Speed**: Targeted 25-line extractions are instant; full file parsing is slow
4. **Accuracy**: Focus on exactly what you need, avoiding information overload
5. **Cost**: Token usage directly impacts API costs and rate limits
