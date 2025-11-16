#!/usr/bin/env python3
"""
findlines.py - Find all line numbers containing a target string in a file.

This script can be used both as a module and as a command-line tool.

Usage as module:
    from findlines import findlines
    line_numbers = findlines('myfile.txt', 'search term')

Usage as CLI:
    python findlines.py <filepath> <target_string>
"""

import sys
from typing import List


def findlines(filepath: str, target_string: str) -> List[int]:
    """
    Find all line numbers where target_string appears in the file.

    Args:
        filepath: Path to the file to search
        target_string: String to search for (case-sensitive)

    Returns:
        List of line numbers (1-indexed) where target_string is found

    Raises:
        FileNotFoundError: If the file doesn't exist
        IOError: If there are issues reading the file
    """
    line_numbers = []

    try:
        # Try multiple encodings to handle various text files gracefully
        encodings = ['utf-8', 'utf-16', 'latin-1']

        for encoding in encodings:
            try:
                with open(filepath, 'r', encoding=encoding) as f:
                    for line_num, line in enumerate(f, start=1):
                        if target_string in line:
                            line_numbers.append(line_num)
                break  # Success, exit encoding loop
            except (UnicodeDecodeError, UnicodeError):
                if encoding == encodings[-1]:
                    # Last encoding failed, raise error
                    raise IOError(f"Unable to decode file {filepath} with supported encodings")
                # Try next encoding
                continue

    except FileNotFoundError:
        raise FileNotFoundError(f"File not found: {filepath}")
    except IOError:
        raise
    except Exception as e:
        raise IOError(f"Error reading file {filepath}: {e}")

    return line_numbers


def main():
    """Command-line interface for findlines."""
    if len(sys.argv) != 3:
        print("Usage: python findlines.py <filepath> <target_string>", file=sys.stderr)
        print("", file=sys.stderr)
        print("Example: python findlines.py myfile.txt 'search term'", file=sys.stderr)
        sys.exit(1)

    filepath = sys.argv[1]
    target_string = sys.argv[2]

    try:
        line_numbers = findlines(filepath, target_string)

        if line_numbers:
            print(f"Found '{target_string}' on {len(line_numbers)} line(s):")
            print(line_numbers)
        else:
            print(f"'{target_string}' not found in {filepath}")

    except (FileNotFoundError, IOError) as e:
        print(f"Error: {e}", file=sys.stderr)
        sys.exit(1)


if __name__ == "__main__":
    main()
