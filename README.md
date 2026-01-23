# Scripture Memorizer Program

## Overview
This program helps users memorize scriptures by displaying the full text and then progressively hiding random words until the entire scripture is hidden.

## Features
- **Encapsulation**: Uses `Scripture`, `Reference`, and `Word` classes to handle specific responsibilities.
- **Multiple Reference Types**: Supports single verses (e.g., "John 3:16") and verse ranges (e.g., "Proverbs 3:5-6").
- **Interactive Memorization**: Press Enter to hide words randomly; type 'quit' to exit.
- **Clean Interface**: Clears the console between steps for a seamless experience.

## Exceeding Requirements
To exceed the core requirements, I have implemented a **Scripture Library**.
- Instead of a single hardcoded scripture, the program contains a collection of scriptures.
- When the program starts, it randomly selects one scripture from the library to present to the user.
- This provides a better memorization tool as the user can practice different verses.

## Project Structure
- `Program.cs`: The entry point. Handles the main loop and the scripture library.
- `Scripture.cs`: Manages the scripture text and the logic for hiding words.
- `Reference.cs`: Represents the scripture reference (Book, Chapter, Verse).
- `Word.cs`: Represents individual words and tracks their visibility state.

## How to Run
1. Navigate to the project directory:
   ```bash
   cd week03/ScriptureMemorizer
   ```
2. Run the application:
   ```bash
   dotnet run
   ```
