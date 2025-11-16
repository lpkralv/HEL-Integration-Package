#!/usr/bin/env python3
"""
sniptext.py - Extract text snippets from files by line range
"""

import sys
import argparse


def sniptext(filepath, start_line, end_line):
    """
    Extract a snippet of text from a file.

    Args:
        filepath: Path to the file to read
        start_line: Starting line number (1-indexed, inclusive)
        end_line: Ending line number (1-indexed, inclusive)

    Returns:
        String containing the requested lines

    Raises:
        FileNotFoundError: If the file doesn't exist
        ValueError: If line numbers are invalid
    """
    if start_line < 1:
        raise ValueError("start_line must be >= 1")
    if end_line < start_line:
        raise ValueError("end_line must be >= start_line")

    try:
        # Try UTF-8 first
        with open(filepath, 'r', encoding='utf-8') as f:
            lines = f.readlines()
    except UnicodeDecodeError:
        # Fall back to latin-1 which accepts all byte values
        try:
            with open(filepath, 'r', encoding='latin-1') as f:
                lines = f.readlines()
        except Exception as e:
            raise Exception(f"Error reading file with encoding fallback: {e}")

    # Extract the requested range (convert to 0-indexed)
    snippet_lines = lines[start_line - 1:end_line]

    # Join and return (preserve original line endings)
    return ''.join(snippet_lines)


def main():
    """Command-line interface for sniptext."""
    parser = argparse.ArgumentParser(
        description='Extract text snippets from files by line range'
    )
    parser.add_argument('filepath', help='Path to the file to read')
    parser.add_argument('start_line', type=int, help='Starting line number (1-indexed)')
    parser.add_argument('end_line', type=int, help='Ending line number (1-indexed)')

    args = parser.parse_args()

    try:
        snippet = sniptext(args.filepath, args.start_line, args.end_line)
        print(snippet, end='')
    except Exception as e:
        print(f"Error: {e}", file=sys.stderr)
        sys.exit(1)


if __name__ == '__main__':
    main()
