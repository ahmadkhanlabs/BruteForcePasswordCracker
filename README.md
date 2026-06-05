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
