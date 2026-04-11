[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/ozVFrFMv)
# CSCI 1260 — Project

## Project Instructions
All project requirements, grading criteria, and submission details are provided on **D2L**.  
Refer to D2L as the *authoritative source* for this assignment.

This repository is intentionally minimal. You are responsible for:
- Creating the solution and projects
- Designing the class structure
- Implementing the required functionality

---

## Getting Started (CLI)

You may use **Visual Studio**, **VS Code**, or the **terminal**.

### Create a solution
```bash
dotnet new sln -n ProjectName
```

### Create a project (example: console app)
```bash
dotnet new console -n ProjectName.App
```

### Add the project to the solution
```bash
dotnet sln add ProjectName.App
```

### Build and run
```bash
dotnet build
dotnet run --project ProjectName.App
```

## Notes
- Commit early and commit often.
- Your repository history is part of your submission.
- Update this README with build/run instructions specific to your project.

# Project Build and Run
- You can build and run the code using this command:
- dotnet build
- dotnet run --project src/Minesweeper.Console

# Game Instructions
- Board Sizes:
- Easy: 8x8 grid
- Medium: 12x12 grid
- Hard: 16x16 grid
- Commands:
- r row col → Reveal a tile ( Example: r 3 4 ))
- f row col → Place or remove a flag ( Example: f 5 6 )
- q, quit, or exit → Quit the game
- Seed Usage:
- The user can enter a seed value at the start
- If left blank, the game uses the current time
- Seeds ensure deterministic mine placement (important for testing)

# Board Symbols
-#	Hidden tile
- F	Flagged tile
- M	Mine
- .	Empty revealed tile
- 1-8	Number of adjacent mines

# Running Unit Tests
- Click Run All Tests
- Test Coverage Includes:
- Board generation
- Mine placement (deterministic with seed)
- Adjacency counts
- Cascade reveal behavior
- Win/loss conditions
- Flagging logic
- Boundary handling