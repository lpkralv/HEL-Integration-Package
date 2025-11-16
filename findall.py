#!/usr/bin/env python3
"""
findall.py - Search for files matching a pattern that contain a target string.

Usage:
    As a CLI tool:
        python findall.py <filepath_pattern> <target_string>

    As a module:
        from findall import findall
        results = findall("**/*.py", "import")

Args:
    filepath_pattern: Glob pattern to match files (e.g., "**/*.py", "*.txt")
    target_string: String to search for in file contents (case-sensitive)

Returns:
    List of file paths that match the pattern and contain the target string
"""

import sys
from pathlib import Path
from typing import List


def findall(filepath_pattern: str, target_string: str) -> List[str]:
    """
    Find all files matching filepath_pattern that contain target_string.

    Args:
        filepath_pattern: Glob pattern to match files (e.g., "**/*.py", "*.txt")
        target_string: String to search for in file contents (case-sensitive)

    Returns:
        List of file paths (as strings) that match the pattern and contain the target string
    """
    matching_files = []

    # Use pathlib to find files matching the pattern
    # Start from current directory
    base_path = Path('.')

    try:
        # Get all files matching the pattern
        for file_path in base_path.glob(filepath_pattern):
            # Skip directories
            if not file_path.is_file():
                continue

            try:
                # Try to read the file as text
                with open(file_path, 'r', encoding='utf-8') as f:
                    content = f.read()

                # Check if target string is in the content (case-sensitive)
                if target_string in content:
                    matching_files.append(str(file_path))

            except (UnicodeDecodeError, PermissionError, OSError):
                # Skip binary files, permission errors, or other OS errors
                continue

    except Exception as e:
        print(f"Error processing pattern '{filepath_pattern}': {e}", file=sys.stderr)

    return matching_files


def main():
    """Command-line interface for findall."""
    if len(sys.argv) != 3:
        print("Usage: python findall.py <filepath_pattern> <target_string>", file=sys.stderr)
        print("\nExample: python findall.py '**/*.py' 'import sys'", file=sys.stderr)
        sys.exit(1)

    filepath_pattern = sys.argv[1]
    target_string = sys.argv[2]

    results = findall(filepath_pattern, target_string)

    if results:
        for file_path in results:
            print(file_path)
    else:
        print(f"No files matching '{filepath_pattern}' contain '{target_string}'", file=sys.stderr)


if __name__ == '__main__':
    main()
