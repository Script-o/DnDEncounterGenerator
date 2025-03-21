# DnD Encounter Generator

A simple tool for Dungeon Masters to quickly generate encounters and fill them with monsters for their Dungeons & Dragons 5e campaigns. (Alpha state)

## Overview

The DnD Encounter Generator helps Dungeon Masters create combat encounters for their groups. You can add your own monsters and create encounters. As of now it is in a very basic state and is more of a showcase of the overall logic.

## Features

- Allows the user to insert monsters, including their stats, into a living database
- Using RegEx you can import monster stat blocks either from a PDF or another site
- Create custom encounters with a section to write a description of the encounter
- Dynamically add and remove monsters from encounters

## Installation

There shouldn't be anything the user needs to do for this program to run to my knowledge. 
The program uses a Blazor front end and a SQLite backend. 
The program has 6 NuGet packages installed
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.Components.WebAssembly.Server
- Swashbuckle.AspNetCore

### Prerequisites

- .NET 9.0 or higher

### Setup

   Clone the repository:
   ```
   git clone https://github.com/Script-o/DnDEncounterGenerator.git
   cd DnDEncounterGenerator
   ```
   
   Ensure Startup Projects are set correctly:
   ```
   Project 						 | Action 	| Debug Target
   DnDEncounterGenerator 		 | Start 	| IIS Express
   DNDEncounterGenerator.Api 	 | Start 	| IIS Express
   DNDEncounterGenerator.Client  | None 	| 
   DNDEncounterGenerator.Console | None 	| 
   DNDEncounterGenerator.Shared  | None 	| 
   ```

### Basic Operation

1. Add monsters to the database:
   - Click 'Add a New Monster' or click 'Edit' next to whichever entry you want to edit
   - Enter its name as well as all of the basic stats from the Monster Manual
   - Click either 'Submit' or 'Save' to commit your changes to the database

2. Optionally create monsters using RegEx:
   - Copy the text of whatever creature you want to add to the database. The copied text doesn't have to be precise as long as you copy all of the relevant stat fields
   - Click the blue 'Submit' button to go to the 'Add a New Monster' page with the information of the monster filled out from the copied text
   - Enter the monsters name (Still working on automating that part) 
   - Click the blue 'Submit' button to save your changes to the database

3. Add encounters to the database:
   - Click 'Add a New Encounter' or click 'Edit' next to whichever entry you want to edit
   - Enter the name of the encounter as well as a description of what will happen in the encounter.
   - On the quick edit you can click on the red buttons with the monster names to remove them from the encounter or you can click the blue + button to go to the full edit page.
   - On the full edit page you can click the blue buttons with the monster names to add them to the encounter.
   - Click either 'Submit' or 'Save' to commit your changes to the database

## Project Requirements Implementation

This project meets the Code:You capstone requirements in the following ways:

### Web-based Application
- Implemented as a web-based application using a Blazor front end
- DnDEncounterGenerator/DnDEncounterGenerator/Components/Pages

### API Integration
- Created API commands that communicate with the backend database which is launched as a separate application
- Full CRUD accessibility with the backend 
- The program is set to use the localhost:44340 connection for the API calls 
- This would be an example of how to access the data manually https://localhost:44340/api/Encounter
- DnDEncounterGenerator/DnDEncounterGenerator.Api/Controllers

### Database Integration
- Uses SQLite to store monster data and user-created encounters
- The SQLite databases are a one-to-many relationship which is managed on the backend
- The program utilizes two main classes that are in the Shared project (Monster and Encounter)
- DnDEncounterGenerator/DnDEncounterGenerator.Api/Data/Encounters.db
- DnDEncounterGenerator/DnDEncounterGenerator.Api/Data/Monsters.db
- DnDEncounterGenerator/DnDEncounterGenerator.Shared

### Functions/Methods
- Below are the most important locations when it comes to the methods and which lines have the pieces of code which took the most work to figure out.
- DnDEncounterGenerator/DnDEncounterGenerator/Components/Pages/EncounterEditor.razor.cs (lines 143-156)
- DnDEncounterGenerator/DnDEncounterGenerator/Components/Pages/MonsterEditor.razor.cs (lines 64-75)
- DnDEncounterGenerator/DnDEncounterGenerator.Api/Models/EncounterRepository.cs (lines 71-85)
- DnDEncounterGenerator/DnDEncounterGenerator.Api/Models/MonsterRepository.cs (lines 32-57)

### Required Features
1. **Regular Expression (Regex)**:
   - Parses through user inputted text and uses RegEx to find relevant information using common patterns in the Monster Manual. 
   - DnDEncounterGenerator/DnDEncounterGenerator/Components/Pages/MonsterEditorRegEx.razor.cs (lines 36-275)

2. **Dictionary/List Implementation**:
   - I used a handful of lists on my frontend to manage short lived data. I also have a list in each of my classes which was necessary for the two databases to communicate.
   - DnDEncounterGenerator/DnDEncounterGenerator/Components/Pages/EncounterEditor.razor.cs (lines 87-92)
   - DnDEncounterGenerator/DnDEncounterGenerator/Components/Pages/MonsterEditor.razor.cs (lines 45-50)
   - DnDEncounterGenerator/DnDEncounterGenerator.Shared/Encounter.cs (line 17)
   - DnDEncounterGenerator/DnDEncounterGenerator.Shared/Encounter.cs (line 23)

3. **API Application**:
   - I created a backend database with API functionality using controllers which is called by the frontend using services.
   - DnDEncounterGenerator/DnDEncounterGenerator.Api/Controllers
   - DnDEncounterGenerator/DnDEncounterGenerator/Services
   
4. **CRUD API**:
   - The database is fully CRUD accessible and uses API calls to transfer JSON data between the front and backend.
   - DnDEncounterGenerator/DnDEncounterGenerator.Api/Controllers
   - DnDEncounterGenerator/DnDEncounterGenerator/Services

4. **Asynchronous Operations**:
   - Most of the frontend of the application is async and the backend is completely synchronous. 
   - DnDEncounterGenerator/DnDEncounterGenerator/Services/EncounterDataService.cs (lines 18-73)
   - DnDEncounterGenerator/DnDEncounterGenerator/Services/MonsterDataService.cs (lines 17-61)
   - DnDEncounterGenerator/DnDEncounterGenerator/Components/Pages/EncounterEditor.razor.cs (lines 18-163)
   - DnDEncounterGenerator/DnDEncounterGenerator/Components/Pages/MonsterEditor.razor.cs (lines 18-85)

5. **Multiple Related Tables**:
   - The database contains related Monster and Encounter tables which are joined using the EncounterMonster join table
   - If you open the tables in something like DB Browser you can see the join table itself.
   - DnDEncounterGenerator/DnDEncounterGenerator.Api/Data/Encounters.db
   - DnDEncounterGenerator/DnDEncounterGenerator.Api/Data/Monsters.db

## Acknowledgments

- The DnDBeyond website for monster data
- Code:You which gave me the opportunity to learn C# and create this project
