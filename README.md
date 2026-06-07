# Brute Force Password Cracker

A C# application that creates a random SHA256-hashed password and then
recovers it using a brute force attack. It compares single-threaded and
multi-threaded performance. The GUI is built with Avalonia (cross-platform C#).

## Planned Features
- Password generation
- SHA256 hashing with a static salt
- Single-threaded brute force
- Multi-threaded brute force
- Progress display
- Elapsed time display
- Found password display
- Performance comparison (single vs multi)

## Classes
- PasswordHasher
- PasswordGenerator
- BruteForceGenerator
- PasswordValidator
- BruteForceEngine
- PerformanceLogger
- MainWindow (GUI)

## Development History
### Version 1
- Created the project
- Added .gitignore
- Created the class structure
- Created the UML diagram
- Wrote the README

### Version 2
- Implemented PasswordHasher class
- Added SHA256 hashing with a static salt
- Updated UML to show HashPassword method

### Version 3
- Implemented PasswordGenerator class
- Generates a random 4-5 character lowercase password
- Hashes the generated password using PasswordHasher
- Updated the UML diagram

### Version 4
- Implemented the BruteForceGenerator class
- Generates all possible character combinations of a given length
- Uses the same lowercase charset as the password generator
- Updated the UML diagram

### Version 5
- Implemented the PasswordValidator class
- Hashes a guess and compares it to the target hash
- Returns true if the guess matches, false otherwise
- Updated the UML diagram

### Version 6
- Implemented the single-threaded BruteForceEngine
- Searches from length 1 up to a maximum of 6
- Uses BruteForceGenerator for guesses and PasswordValidator to check them
- Stops as soon as the password is found
- Updated the UML diagram

### Version 7
- Added multi-threaded brute force using (CPU cores - 1) threads
- Splits each length's guesses across threads by first letter
- Uses a CancellationToken so all threads stop immediately when one finds the password
- Multi-threaded search is significantly faster for longer passwords
- Updated the UML diagram

### Version 8
- Implemented the PerformanceLogger class
- Records single-threaded and multi-threaded crack times
- Calculates and reports the speedup factor
- Updated the UML diagram

### Version 9
- Built the Avalonia GUI (MainWindow)
- Create Password, Start, Stop, and Clear buttons
- Displays status, elapsed time, and the result with performance comparison
- Brute force runs on a background task so the UI stays responsive
- Completed the UML diagram with all classes

## About the Project

This application is a password reset brute force simulator built in C# using the Avalonia UI framework. It generates a random password, hashes it with SHA256 and a constant salt, and then attempts to crack the hash using a brute force attack — first single-threaded, then multi-threaded — and compares the performance of the two approaches.

## How It Works

1. A random password of 4–5 lowercase characters is generated and hashed.
2. The brute force engine tries every possible combination starting from length 1 up to a maximum of 6, without knowing the real password length.
3. Each guess is hashed and compared against the target hash.
4. The single-threaded version checks guesses one at a time.
5. The multi-threaded version splits the work across (CPU cores − 1) threads running in parallel, and stops all threads immediately once the password is found.
6. The performance of both methods is measured and compared.

## How To Use The App

1. Run the application.
2. Click **Create Password** to generate a new random hashed password.
3. Click **Start Brute Force** to begin cracking. The single-threaded and multi-threaded attacks run on a background thread so the interface stays responsive.
4. The result box shows the found password and a performance comparison (single vs multi-threaded time and the speedup factor).
5. Click **Clear** to reset the app and try again.

## Classes Overview

- **PasswordHasher** — hashes a string using SHA256 with a constant salt.
- **PasswordGenerator** — creates a random 4–5 character password and hashes it.
- **BruteForceGenerator** — produces all possible character combinations of a given length.
- **PasswordValidator** — hashes a guess and compares it to the target hash.
- **BruteForceEngine** — coordinates the attack, both single-threaded and multi-threaded.
- **PerformanceLogger** — records and reports the single vs multi-threaded timing.
- **MainWindow** — the graphical user interface.

## Technologies Used

- C# (.NET)
- Avalonia UI (cross-platform GUI framework)
- SHA256 hashing
- Multi-threading with Tasks and CancellationToken

## Author

Ahmad Khan
Vilnius University — Object Oriented Programming
