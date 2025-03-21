# DnD Encounter Generator

A simple, easy-to-use tool for Dungeon Masters to quickly generate balanced encounters for their Dungeons & Dragons 5e campaigns.

## Overview

DnD Encounter Generator helps Dungeon Masters create appropriate combat encounters based on party level, size, and desired difficulty. It provides a selection of monsters that match the encounter parameters and calculates challenge ratings according to the D&D 5e guidelines.

## Features

- Generate balanced encounters based on party level and size
- Choose from multiple difficulty settings (Easy, Medium, Hard, Deadly)
- Access a database of D&D 5e monsters with complete stat blocks
- Filter monsters by environment, type, alignment, and other criteria
- Save encounters for future reference
- Export encounter details to various formats

## Installation

### Prerequisites

- Python 3.8 or higher
- pip (Python package installer)

### Steps

1. Clone the repository:
   ```
   git clone https://github.com/Script-o/DnDEncounterGenerator.git
   cd DnDEncounterGenerator
   ```

2. Install required dependencies:
   ```
   pip install -r requirements.txt
   ```

3. Run the application:
   ```
   python main.py
   ```

## Usage

### Basic Operation

1. Input your party's information:
   - Number of players
   - Character levels (individual or average)
   - Desired difficulty (Easy, Medium, Hard, Deadly)

2. Optionally filter monsters by:
   - Environment (Forest, Dungeon, Arctic, etc.)
   - Monster type (Humanoid, Beast, Undead, etc.)
   - Challenge Rating range
   - Source book

3. Generate the encounter with the "Create Encounter" button

4. View suggested monsters and encounter statistics

5. Optionally save the encounter for future reference

### Example

```python
# Code example for programmatic usage
from encounter_generator import EncounterGenerator

generator = EncounterGenerator()
encounter = generator.create_encounter(
    party_size=4,
    party_level=5,
    difficulty="Medium",
    environment="Forest"
)

print(encounter.get_monsters())
print(encounter.get_xp_total())
```

## Project Requirements Implementation

This project meets the Code:You capstone requirements in the following ways:

### Web-based Application
- Implemented as a web-based application using MVC architecture (src/controllers/encounter_controller.py, lines 10-45)
- Features a responsive web interface accessible across devices (src/views/templates/index.html)

### API Integration
- Created a custom API that serves monster data and generates encounters (src/api/monster_api.py, lines 25-60)
- Implements RESTful endpoints for CRUD operations on encounters (src/api/routes.py, lines 15-78)

### Database Integration
- Uses SQLite to store monster data and user-created encounters (src/models/database.py, lines 8-40)
- Implements Entity Framework patterns with custom Monster and Encounter classes (src/models/monster.py, lines 5-35)

### Required Features
1. **Dictionary/List Implementation**:
   - Created and populated a dictionary of monsters by environment type (src/services/monster_service.py, lines 45-70)
   - Implements collections to manage encounter composition (src/models/encounter.py, lines 22-38)

2. **Regular Expression (Regex)**:
   - Validates monster CR inputs to ensure proper format (src/utils/validators.py, lines 15-30)
   - Sanitizes user inputs for database operations (src/controllers/input_controller.py, lines 40-55)

3. **Writing to Text Files**:
   - Exports encounter data to CSV files (src/utils/export_utils.py, lines 10-35)
   - Implements logging to track application behavior (src/utils/logger.py, lines 5-25)

4. **Asynchronous Operations**:
   - Implements async loading of monster data (src/services/data_service.py, lines 30-55)
   - Uses async methods for API calls (src/api/api_client.py, lines 15-40)

5. **Multiple Related Tables**:
   - Database contains related Monster and Encounter tables (src/models/schema.py, lines 10-45)
   - Implements join operations to retrieve complete encounter data (src/repositories/encounter_repository.py, lines 50-75)

### Testing
- Includes unit tests for core functionality (tests/test_encounter_generator.py)
- Implements integration tests for API endpoints (tests/test_api.py)

## Configuration

The application can be configured by editing the `config.json` file:

- `monster_data_source`: Path to the monster database file
- `custom_monsters_file`: Path to user-added custom monsters
- `default_settings`: Default party size, level, and difficulty
- `ui_theme`: Choose between "light", "dark", or "system"

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- The D&D 5e SRD for monster data
- [Open5e API](https://open5e.com/) for additional monster information
- All the Dungeon Masters who provided feedback and suggestions
