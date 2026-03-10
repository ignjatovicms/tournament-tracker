# Tournament Tracker

Tournament Tracker is a desktop application for creating and managing tournaments, teams, and match results.  
The application allows users to organize tournaments, register teams and players, generate tournament brackets, track match results, and automatically determine winners as the tournament progresses.

This project was built while following the 24-hour course by Tim Corey and demonstrates building a full application using C#, SQL Server, WinForms, and Dapper.

---

## Screenshots

### Create Tournament
![Create Tournament](<img width="930" height="639" alt="image" src="https://github.com/user-attachments/assets/e565d248-5319-4e59-b7ef-dd141d89c659" />
)

### Tournament Viewer Form
![Tournament Viewer](<img width="1059" height="722" alt="image" src="https://github.com/user-attachments/assets/45603e13-9823-4b91-b3f2-f9c0dbeb2ea2" />
)

### Create Team
![Create Team](<img width="888" height="721" alt="Screenshot 2026-03-08 210348" src="https://github.com/user-attachments/assets/db70b351-9b27-4b72-b7ef-1e145264b63b" />
)

### Tournament Dashboard
![Tournament Viewer](<img width="720" height="389" alt="Screenshot 2026-03-08 205919" src="https://github.com/user-attachments/assets/73e9f54a-9479-460d-9f28-2c4f1afdf504" />
)

### Create Prize
![Tournament Viewer](<img width="470" height="483" alt="Screenshot 2026-03-08 210258" src="https://github.com/user-attachments/assets/dee5ef5e-ef34-4d8f-bf31-8070d7b68c74" />
)

### Database Diagram
![Database Diagram](<img width="751" height="704" alt="Dijagram Tournament Tracker" src="https://github.com/user-attachments/assets/0010aa1e-a679-40b7-a557-c1752790e5c4" />
)

---

## Features
### Tournament Management
- Create new tournaments
- Set tournament entry fee
- Define tournament name and prizes
- Automatically generate tournament brackets

### Team Management
- Create teams
- Add multiple players to a team
- Store player information (name, email, phone)

### Matchup System
- Automatic bracket generation
- Track rounds and matchups
- Record match scores
- Automatically advance winners to the next round

### Player Management
- Register players
- Store contact information
- Use players in multiple teams

### Prize System
- Create prizes for tournaments
- Assign prizes to winning places
- Support both monetary prizes and percentage prizes

### Email Notifications
- Automatically send email notifications to players when:
  - they advance to the next round
  - they win the tournament
  - tournament results are updated

### Data Storage
The application supports two data storage options:
- SQL Server database using Dapper
- Text file storage

---

## Technologies Used
- C#
- .NET
- Windows Forms
- SQL Server
- Dapper (micro ORM)
- T-SQL Stored Procedures

---

## Application Architecture
The solution is divided into multiple layers:

**TrackerUI**  
WinForms user interface responsible for user interaction.

**TrackerLibrary**  
Core business logic including models, tournament logic, and data access interfaces.

**Data Access Layer**  
Implements data access using:
- SQL Server (Dapper)
- Text file storage

---

## Database Structure
Main tables used in the database:
- Tournaments
- Teams
- TeamMembers
- People
- Matchups
- MatchupEntries
- TournamentEntries
- Prizes
- TournamentPrizes

Stored procedures are used to handle inserting, retrieving, and updating tournament data.

---

## How to Run the Project

1. Open SQL Server.
2. Run the `TournamentTracker.sql` script to create the database.
3. Open the solution in Visual Studio.
4. Update the connection string if necessary.
5. Run the application.

---

## What I Learned
Through this project I practiced:
- Designing relational databases
- Writing SQL stored procedures
- Using Dapper for database access
- Implementing layered architecture
- Building desktop applications with WinForms
- Implementing tournament bracket logic
- Sending automated emails from an application

---

## Credits
This project was built while following the software development course created by [Tim Corey](https://www.youtube.com/@TimCorey).  
The course demonstrates how to design and build a complete application including database design, business logic, and user interface.
