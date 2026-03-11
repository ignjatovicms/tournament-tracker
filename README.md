# Tournament Tracker

Tournament Tracker is a desktop application for creating and managing tournaments, teams, and match results.  
The application allows users to organize tournaments, register teams and players, generate tournament brackets, track match results, and automatically determine winners as the tournament progresses.

This project was built while following the 24-hour course by Tim Corey and demonstrates building a full application using C#, SQL Server, WinForms, and Dapper.

---

## Screenshots

### Create Tournament
Create Tournament images/<img width="930" height="639" alt="CreateTournament" src="https://github.com/user-attachments/assets/950ff79f-38d5-43da-9c95-01d770d8fead" />

### Tournament Viewer Form
Tournament Viewer images/<img width="1059" height="722" alt="TournamentViewer" src="https://github.com/user-attachments/assets/ca0dc9b9-dda5-4e56-b838-28f64ef2b6ef" />

### Create Team
![Create Team](images/<img width="888" height="721" alt="CreateTeam" src="https://github.com/user-attachments/assets/5458273c-f7a4-4dab-83e5-c91d566ced7b" />

### Tournament Dashboard
Tournament Viewer images/<img width="720" height="389" alt="TournamentDashboard" src="https://github.com/user-attachments/assets/a968c819-640e-406d-b8ee-11dd1d2d8612" />

### Create Prize
Tournament Viewer images/<img width="470" height="483" alt="CreatePrize" src="https://github.com/user-attachments/assets/bc285e63-a262-4292-8659-10ab4776960f" />

### Database Diagram
Database Diagram images/<img width="751" height="704" alt="TournamentTrackerDiagram" src="https://github.com/user-attachments/assets/a965b35d-8287-4f99-a3f6-3b53882b07f1" />

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
This project was built while following the software development course created by Tim Corey - https://www.youtube.com/@TimCorey](https://www.youtube.com/@IAmTimCorey .
The course demonstrates how to design and build a complete application including database design, business logic, and user interface.
