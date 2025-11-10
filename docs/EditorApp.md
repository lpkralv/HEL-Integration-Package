# HIOX Mod Editor Documentation

## Click Behavior in Display Area

### Left-Click Behavior

- **Single Left-Click**: 
  - For unequipped mods: Increments the selection count by 1
  - For equipped mods (blue): Adds to selection leaving count unchanged

- **Shift + Left-Click**:
  - Selects a range of mods from the last clicked position to current position
  - For unequipped mods in range: Increments their selection count by 1
  - For equipped mods in range: Adds them to selection leaving count unchanged

### Right-Click Behavior

- **Single Right-Click**:
  - For unequipped mods: Decrements the selection count by 1 (minimum 0)
  - For equipped mods (blue): Removes from selection if present

- **Shift + Right-Click**:
  - Applies right-click behavior to a range of mods from the last clicked position to current position
  - For unequipped mods in range: Decrements their count by 1 (removes if count reaches 0)
  - For equipped mods in range: Removes them from selection

### Color Indicators
- **Black**: Default unselected mod
- **Green**: Selected mod (marked)
- **Blue**: Equipped mod
- **Red**: Both selected and equipped

## Command Button Functions

### Selection Commands
- **SELECT ALL**: Selects all mods with count 1
- **UNSELECT**: Clears all selections
- **EQUIP**: Equips player with selected mods (copies selection counts to player inventory)
- **UNEQUIP**: Removes selected mods from player inventory (sets count to 0)

### Sorting Commands
- **SORT ID**: Sorts all mods by their ID number
- **SORT NAME**: Sorts all mods alphabetically by name
- **SORT EQUIP**: Moves equipped mods to the top while preserving relative order

### Editing Commands
- **COPY**: Copies first selected mod's data to input fields
- **UPDATE**: Updates the selected mod with edited values from input fields
- **ADD NEW**: Adds a new mod using values from input fields
- **DELETE**: Deletes all selected mods from the list

### Analysis Commands
- **CHECK**: Validates syntax of all mod equations
- **EVALUATE**: Evaluates stat changes from selected mods given equipped mods
- **ANALYZE**: Simulates and analyzes mod effects on player stats

### File Operations
- **CSV SAVE**: Saves all mods to ModsData.csv
- **CSV LOAD**: Loads mods from ModsData.csv
- **YAML SAVE**: Saves all mods to ModsData.asset
- **YAML LOAD**: Loads mods from ModsData.asset

### Utility Commands
- **CLEAR INPUT**: Clears all input/edit fields
- **RESET STATS**: Resets player stats to default values
- **CLEAR MSGS**: Clears the message area
- **HELP ON/OFF**: Toggles button hover help messages