# HEL Stats/Mods Bundle - Maintenance Guide

**Purpose:** This document explains the bundling process, strategy, and update procedures for maintaining the HEL Stats/Mods Bundle across future development sessions.

**Version:** 1.0
**Date:** 2025-11-16
**Current Bundle Version:** v1.0

---

## Table of Contents

1. [Bundle Overview](#bundle-overview)
2. [Bundling Strategy](#bundling-strategy)
3. [Directory Structure](#directory-structure)
4. [Update Procedures](#update-procedures)
5. [Version Control](#version-control)
6. [Quality Checklist](#quality-checklist)
7. [Common Scenarios](#common-scenarios)

---

## Bundle Overview

### What is the Bundle?

The HEL Stats/Mods Bundle is a self-contained distribution package containing all design documents, asset files, and integration guides necessary for game designers and developers to implement the Stats/Mods system.

### Bundle Location

- **Source Repository:** `/home/user/HEL-Integration-Package/`
- **Bundle Directory:** `/home/user/HEL-Integration-Package/HEL-Stats-Mods-Bundle-v1.0/`
- **Source Documents:** `/home/user/HEL-Integration-Package/docs/` and root `.asset` files

### Bundle Contents (v1.0)

- **31 files** total
- **604 KB** size
- **4 categories:** Entry docs, Deliverables, Reference materials, Technical specs

---

## Bundling Strategy

### Design Principles

1. **Self-Contained:** Bundle must be usable without external dependencies
2. **Organized:** Clear hierarchy (entry → deliverables → reference → technical)
3. **Non-Duplicative:** README guides to content, doesn't duplicate it
4. **Version-Tracked:** Each bundle iteration has a version number
5. **Audience-Focused:** Different entry points for designers vs developers

### Three-Tier Documentation

**Tier 1: Essential (Must Read)**
- Entry documents (README, Quick Start, Checklist)
- Core deliverables (System Philosophy, Stats/Mods descriptions, Validation Report)
- Asset files (StatsData.asset, ModsData.asset)

**Tier 2: Detailed Reference (As Needed)**
- 19 class design documents for specific mod details

**Tier 3: Technical Specifications (Implementation)**
- HEL equation syntax guides
- YAML format specifications

### Target Audiences

- **Game Designers:** System Philosophy → Mods Description → Class References
- **Developers:** Quick Start → Integration Checklist → Technical Guides → Assets
- **Technical Artists:** Mods Description → Class References (for UI/drop rates)

---

## Directory Structure

### Bundle Root Structure

```
HEL-Stats-Mods-Bundle-v{VERSION}/
├── README-BUNDLE.md                   # Primary navigation guide
├── 00-QUICK-START.md                  # 5-minute orientation
├── INTEGRATION-CHECKLIST.md           # Developer tracking
├── BUNDLE-MANIFEST.txt                # Contents listing
│
├── deliverables/                      # Core design docs + assets
│   ├── DELIVERABLE-System-Philosophy.md
│   ├── DELIVERABLE-Stats-Description.md
│   ├── DELIVERABLE-Mods-Description.md
│   ├── Integration-Validation-Report.md
│   ├── StatsData.asset
│   └── ModsData.asset
│
├── reference/                         # Detailed class designs
│   ├── weapons/
│   │   ├── Weapons-Ballistic.md
│   │   ├── Weapons-Energy.md
│   │   ├── Weapons-Explosive.md
│   │   ├── Weapons-Deployables.md
│   │   ├── Weapons-Hybrid.md
│   │   └── Weapons-Melee.md
│   ├── items/
│   │   ├── Items-Structural.md
│   │   ├── Items-Mobility.md
│   │   ├── Items-Regeneration.md
│   │   ├── Items-Offensive.md
│   │   ├── Items-Resistance.md
│   │   ├── Items-Resource.md
│   │   └── Items-Tactical.md
│   └── syringes/
│       ├── Syringes-Combat.md
│       ├── Syringes-Defensive.md
│       ├── Syringes-Metabolic.md
│       ├── Syringes-Elemental.md
│       ├── Syringes-Tactical.md
│       └── Syringes-Exotic.md
│
└── technical/                         # Integration specs
    ├── Foundation-HEL-Guide.md
    └── Foundation-Format-Guide.md
```

### Source-to-Bundle Mapping

**Entry Documents (Created in Bundle):**
- `HEL-Stats-Mods-Bundle-v{VERSION}/README-BUNDLE.md` - Generated fresh each version
- `HEL-Stats-Mods-Bundle-v{VERSION}/00-QUICK-START.md` - Generated fresh each version
- `HEL-Stats-Mods-Bundle-v{VERSION}/INTEGRATION-CHECKLIST.md` - Generated fresh each version
- `HEL-Stats-Mods-Bundle-v{VERSION}/BUNDLE-MANIFEST.txt` - Generated fresh each version

**Deliverables (Copied from Source):**
```bash
docs/DELIVERABLE-System-Philosophy.md     → deliverables/DELIVERABLE-System-Philosophy.md
docs/DELIVERABLE-Stats-Description.md     → deliverables/DELIVERABLE-Stats-Description.md
docs/DELIVERABLE-Mods-Description.md      → deliverables/DELIVERABLE-Mods-Description.md
docs/Integration-Validation-Report.md     → deliverables/Integration-Validation-Report.md
DELIVERABLE-StatsData.asset               → deliverables/StatsData.asset
DELIVERABLE-ModsData.asset                → deliverables/ModsData.asset
```

**Reference Materials (Copied from Source):**
```bash
docs/Weapons-*.md    → reference/weapons/
docs/Items-*.md      → reference/items/
docs/Syringes-*.md   → reference/syringes/
```

**Technical Specs (Copied from Source):**
```bash
docs/Foundation-HEL-Guide.md      → technical/Foundation-HEL-Guide.md
docs/Foundation-Format-Guide.md   → technical/Foundation-Format-Guide.md
```

---

## Update Procedures

### Scenario 1: Minor Updates to Existing Documents

**When:** Typo fixes, clarifications, minor balance tweaks to existing mods

**Process:**

1. **Update source documents** in their original locations
   ```bash
   # Example: Fix typo in System Philosophy
   # Edit: docs/DELIVERABLE-System-Philosophy.md
   ```

2. **Determine if bundle update is needed**
   - Minor typos: Optional, can batch multiple fixes
   - Balance changes: Recommended
   - Content additions: Required

3. **If updating bundle:**
   ```bash
   # Copy updated file to existing bundle
   cp docs/DELIVERABLE-System-Philosophy.md \
      HEL-Stats-Mods-Bundle-v1.0/deliverables/

   # Update version in BUNDLE-MANIFEST.txt
   # Change: v1.0 (2025-11-16) → v1.1 (2025-11-XX)
   # Add changelog entry
   ```

4. **Commit changes**
   ```bash
   git add HEL-Stats-Mods-Bundle-v1.0/
   git commit -m "Update bundle v1.1: Fix typos in System Philosophy"
   git push
   ```

### Scenario 2: Major Content Updates

**When:** New mods added, stats modified, system changes, rebalancing

**Process:**

1. **Update all affected source documents**
   ```bash
   # Example: Add 10 new mods to Weapons-Ballistic
   # Edit: docs/Weapons-Ballistic.md
   # Edit: docs/DELIVERABLE-Mods-Description.md (add to overview)
   # Edit: DELIVERABLE-ModsData.asset (add YAML entries)
   # Edit: docs/Integration-Validation-Report.md (update validation)
   ```

2. **Increment bundle version** (minor → major)
   ```bash
   # Rename bundle directory for new major version
   cp -r HEL-Stats-Mods-Bundle-v1.0 HEL-Stats-Mods-Bundle-v2.0
   ```

3. **Update all copied files**
   ```bash
   # Re-copy all deliverables
   cp docs/DELIVERABLE-*.md HEL-Stats-Mods-Bundle-v2.0/deliverables/
   cp DELIVERABLE-*.asset HEL-Stats-Mods-Bundle-v2.0/deliverables/

   # Re-copy affected reference files
   cp docs/Weapons-Ballistic.md HEL-Stats-Mods-Bundle-v2.0/reference/weapons/
   ```

4. **Regenerate entry documents**
   ```bash
   # Update README-BUNDLE.md with new mod counts
   # Update BUNDLE-MANIFEST.txt with new file counts/sizes
   # Update 00-QUICK-START.md if process changed
   # Update INTEGRATION-CHECKLIST.md with new tasks
   ```

5. **Update version references**
   - Change all v1.0 → v2.0 in bundle files
   - Update dates
   - Add changelog to BUNDLE-MANIFEST.txt

6. **Commit new bundle version**
   ```bash
   git add HEL-Stats-Mods-Bundle-v2.0/
   git commit -m "Release bundle v2.0: Add 10 new Ballistic weapons, rebalancing"
   git push
   ```

### Scenario 3: Adding New Documents to Bundle

**When:** New class added, new technical guide created, new deliverable needed

**Process:**

1. **Create new document** in source location
   ```bash
   # Example: New weapon class "Weapons-Exotic.md"
   # Create: docs/Weapons-Exotic.md
   ```

2. **Update bundle structure** if needed
   ```bash
   # If new category needed:
   mkdir -p HEL-Stats-Mods-Bundle-v2.0/reference/new_category/
   ```

3. **Copy new document to bundle**
   ```bash
   cp docs/Weapons-Exotic.md \
      HEL-Stats-Mods-Bundle-v2.0/reference/weapons/
   ```

4. **Update bundle navigation documents**
   - **README-BUNDLE.md:** Add new file to contents listing
   - **BUNDLE-MANIFEST.txt:** Add to appropriate section, update counts
   - **00-QUICK-START.md:** Add if entry-level document
   - **INTEGRATION-CHECKLIST.md:** Add tasks if implementation required

5. **Update deliverable overviews**
   - Update `DELIVERABLE-Mods-Description.md` to reference new class
   - Update `Integration-Validation-Report.md` with validation of new content

6. **Increment version and commit**
   ```bash
   # Minor version bump for new content
   # v2.0 → v2.1
   git add HEL-Stats-Mods-Bundle-v2.1/
   git commit -m "Bundle v2.1: Add Exotic weapons class (8 new mods)"
   git push
   ```

### Scenario 4: Removing Documents from Bundle

**When:** Document deprecated, content consolidated, no longer needed

**Process:**

1. **Verify document is truly obsolete**
   - Check if referenced by other bundle documents
   - Confirm content moved elsewhere or no longer relevant

2. **Remove from bundle**
   ```bash
   rm HEL-Stats-Mods-Bundle-v2.1/reference/items/Items-Deprecated.md
   ```

3. **Update all references**
   - Remove from README-BUNDLE.md contents
   - Remove from BUNDLE-MANIFEST.txt
   - Remove from any cross-references in other docs
   - Update file counts

4. **Increment version and commit**
   ```bash
   git add HEL-Stats-Mods-Bundle-v2.1/
   git commit -m "Bundle v2.1: Remove deprecated Items-Deprecated.md"
   git push
   ```

---

## Version Control

### Version Numbering Scheme

**Format:** `vMAJOR.MINOR`

**MAJOR version increment when:**
- Complete system redesign
- 20+ new mods added
- Breaking changes to asset format
- New build archetypes added
- Incompatible with previous version

**MINOR version increment when:**
- 1-19 new mods added
- Balance adjustments to existing mods
- New documents added to bundle
- Typo fixes and clarifications
- Documentation improvements

### Version Tracking

**BUNDLE-MANIFEST.txt maintains version history:**

```
VERSION HISTORY
================
v2.1 (2025-11-20) - Minor Update
  - Added Exotic weapons class (8 mods)
  - Fixed typos in System Philosophy
  - Updated Integration Checklist with new tasks

v2.0 (2025-11-18) - Major Update
  - Added 10 new Ballistic weapons
  - Rebalanced Glass Cannon archetype
  - Updated ModsData.asset with new entries

v1.0 (2025-11-16) - Initial Release
  - Complete stats/mods design (65 stats, 155 mods)
  - Full documentation bundle (31 files)
  - Ready for implementation
```

### Git Workflow

**Each bundle version is a directory:**
- `HEL-Stats-Mods-Bundle-v1.0/` (committed)
- `HEL-Stats-Mods-Bundle-v2.0/` (committed)
- `HEL-Stats-Mods-Bundle-v2.1/` (committed)

**Keep old versions** for reference and rollback capability.

**Commit messages format:**
```
Bundle v{VERSION}: {Brief description}

- Detailed change 1
- Detailed change 2
- Detailed change 3
```

---

## Quality Checklist

### Before Releasing New Bundle Version

**Content Verification:**
- [ ] All source documents up-to-date
- [ ] All files copied to bundle correctly
- [ ] No missing files (check file counts)
- [ ] Asset files valid YAML syntax
- [ ] No broken cross-references between documents

**Entry Documents:**
- [ ] README-BUNDLE.md updated with new content
- [ ] 00-QUICK-START.md accurate for current system
- [ ] INTEGRATION-CHECKLIST.md has tasks for new features
- [ ] BUNDLE-MANIFEST.txt reflects actual contents

**Version Information:**
- [ ] Version number incremented appropriately
- [ ] All version references updated (v1.0 → v2.0 everywhere)
- [ ] Dates updated to current
- [ ] Changelog added to BUNDLE-MANIFEST.txt

**File Counts and Sizes:**
- [ ] Total file count verified
- [ ] Bundle size calculated (`du -sh`)
- [ ] BUNDLE-MANIFEST.txt counts match reality
- [ ] README-BUNDLE.md counts match reality

**Navigation:**
- [ ] README links to all major documents
- [ ] Directory structure logical and consistent
- [ ] Quick Start still takes ~5 minutes
- [ ] Audience-specific paths clear

**Technical:**
- [ ] All markdown renders correctly
- [ ] No corrupted files
- [ ] Asset files importable to Unity
- [ ] File permissions appropriate

---

## Common Scenarios

### Quick Reference Commands

**Copy all deliverables to bundle:**
```bash
BUNDLE_DIR="HEL-Stats-Mods-Bundle-v2.0"

cp docs/DELIVERABLE-*.md ${BUNDLE_DIR}/deliverables/
cp docs/Integration-Validation-Report.md ${BUNDLE_DIR}/deliverables/
cp DELIVERABLE-*.asset ${BUNDLE_DIR}/deliverables/
```

**Copy all reference materials:**
```bash
BUNDLE_DIR="HEL-Stats-Mods-Bundle-v2.0"

cp docs/Weapons-*.md ${BUNDLE_DIR}/reference/weapons/
cp docs/Items-*.md ${BUNDLE_DIR}/reference/items/
cp docs/Syringes-*.md ${BUNDLE_DIR}/reference/syringes/
```

**Copy technical docs:**
```bash
BUNDLE_DIR="HEL-Stats-Mods-Bundle-v2.0"

cp docs/Foundation-HEL-Guide.md ${BUNDLE_DIR}/technical/
cp docs/Foundation-Format-Guide.md ${BUNDLE_DIR}/technical/
```

**Count bundle files:**
```bash
find HEL-Stats-Mods-Bundle-v2.0 -type f | wc -l
```

**Check bundle size:**
```bash
du -sh HEL-Stats-Mods-Bundle-v2.0
```

**Verify asset YAML syntax:**
```bash
# If yamllint installed
yamllint HEL-Stats-Mods-Bundle-v2.0/deliverables/*.asset

# Or basic check
cat HEL-Stats-Mods-Bundle-v2.0/deliverables/StatsData.asset
```

### Emergency Rollback

If a bundle version has critical errors:

```bash
# Don't commit broken bundle
git reset HEAD HEL-Stats-Mods-Bundle-v2.1/

# Remove broken bundle directory
rm -rf HEL-Stats-Mods-Bundle-v2.1/

# Start over from last good version
cp -r HEL-Stats-Mods-Bundle-v2.0 HEL-Stats-Mods-Bundle-v2.1
# Fix issues and try again
```

### Creating Bundle from Scratch

If starting a new bundle line (e.g., v3.0 with major changes):

```bash
# Step 1: Create directory structure
NEW_VERSION="v3.0"
BUNDLE_DIR="HEL-Stats-Mods-Bundle-${NEW_VERSION}"

mkdir -p ${BUNDLE_DIR}/{deliverables,reference/{weapons,items,syringes},technical}

# Step 2: Generate entry documents (manually or with script)
# Create: README-BUNDLE.md
# Create: 00-QUICK-START.md
# Create: INTEGRATION-CHECKLIST.md
# Create: BUNDLE-MANIFEST.txt

# Step 3: Copy all source files
cp docs/DELIVERABLE-*.md ${BUNDLE_DIR}/deliverables/
cp docs/Integration-Validation-Report.md ${BUNDLE_DIR}/deliverables/
cp DELIVERABLE-*.asset ${BUNDLE_DIR}/deliverables/
cp docs/Weapons-*.md ${BUNDLE_DIR}/reference/weapons/
cp docs/Items-*.md ${BUNDLE_DIR}/reference/items/
cp docs/Syringes-*.md ${BUNDLE_DIR}/reference/syringes/
cp docs/Foundation-*.md ${BUNDLE_DIR}/technical/

# Step 4: Verify and commit
find ${BUNDLE_DIR} -type f | wc -l
du -sh ${BUNDLE_DIR}
git add ${BUNDLE_DIR}/
git commit -m "Release bundle ${NEW_VERSION}: [description]"
git push
```

---

## Best Practices

### 1. Always Update Source First
Never edit files directly in the bundle. Always edit source documents, then copy to bundle.

### 2. Keep Bundle Versions Separate
Don't overwrite `v1.0` to make `v2.0`. Create new directory so old versions remain accessible.

### 3. Batch Minor Updates
If fixing multiple typos, batch them into one version bump rather than creating v1.1, v1.2, v1.3 for each typo.

### 4. Test Asset Files
Before releasing bundle, verify `.asset` files parse correctly (test import in Unity if possible).

### 5. Update All Entry Docs
If contents change, update README, Quick Start, Checklist, AND Manifest. Keep them in sync.

### 6. Changelog Everything
BUNDLE-MANIFEST.txt version history should explain what changed in each version.

### 7. Verify File Counts
Always verify actual file counts match BUNDLE-MANIFEST.txt and README-BUNDLE.md claims.

### 8. Commit Atomically
Commit the entire bundle version as one atomic commit, not piecemeal.

---

## Troubleshooting

### Bundle Size Growing Too Large

**Problem:** Bundle exceeds 5 MB or contains too many files

**Solutions:**
- Remove outdated reference materials
- Consolidate similar documents
- Create "archive" directory for deprecated content
- Consider compression (tar.gz) for distribution

### Inconsistent Information Across Documents

**Problem:** README says 155 mods but Manifest says 165

**Solution:**
- Run verification script:
  ```bash
  # Count actual mod entries in ModsData.asset
  grep "^  - modid:" deliverables/ModsData.asset | wc -l

  # Update all references to match reality
  ```

### File Missing from Bundle

**Problem:** Developer reports missing file mentioned in README

**Solution:**
- Check source file still exists
- Verify file was copied in update procedure
- Update bundle with missing file
- Release patch version (v2.1 → v2.1.1)

### Bundle Structure Changed

**Problem:** Need to reorganize bundle directories

**Solution:**
- Create new major version (v3.0)
- Document structure change in BUNDLE-MANIFEST changelog
- Update README navigation to reflect new structure
- Update all path references in documents

---

## Summary Workflow

**For Minor Updates (typos, small fixes):**
1. Edit source document
2. Copy to existing bundle directory
3. Update version in BUNDLE-MANIFEST.txt (v1.0 → v1.1)
4. Commit and push

**For Major Updates (new content, system changes):**
1. Edit all affected source documents
2. Create new bundle directory (v2.0)
3. Copy all files to new bundle
4. Regenerate entry documents (README, Quick Start, Checklist, Manifest)
5. Update version references throughout
6. Verify with quality checklist
7. Commit and push

**For New Documents:**
1. Create in source location
2. Copy to bundle
3. Update README, Manifest, and relevant references
4. Increment minor version
5. Commit and push

---

**This guide should be reviewed and updated whenever the bundling process changes significantly.**

**Last Updated:** 2025-11-16
**Bundle Maintenance Guide Version:** 1.0
