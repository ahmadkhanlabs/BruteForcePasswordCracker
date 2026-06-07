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