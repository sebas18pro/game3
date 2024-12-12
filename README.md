# Dungeon3
Console-Based Dungeon Crawler Game
## Overview
This is a simple console-based dungeon crawler game where the player must navigate a maze-like environment, collect gems, and avoid enemies.

## How to Play

    Movement: Use the arrow keys to move the character (represented by the letter 'A') around the map.
    Objective: Collect all the gems (represented by the letter 'O') while avoiding the enemies (represented by the letter 'X').
    Scoring: Each gem collected is worth 10 points.
    Game Over: The game ends when either all gems are collected or the character collides with an enemy.

## Features

    Maze-like map for the player to navigate.
    Multiple enemies that move horizontally.
    Score tracking.
    Clear instructions and game over condition.



## The game is written in C# and utilizes the following key components:

    element struct: Represents game elements like the character, enemies, and items, storing their position, speed, symbol, color, and visibility.
    map array: Stores the string representation of the game map.
    start() method: Initializes game variables, character, enemies, and items.
    Draw() method: Renders the game map, character, enemies, and items on the console.
    movement() method: Handles character movement based on user input.
    parameters() method: Controls enemy movement.
    comfirmgamestate() method: Checks for collisions between the character and enemies or items, and updates the game state accordingly.
    pause() method: Introduces a pause to control the game speed.
    movement(int x, int y) method: Checks if a given position is valid for movement based on the map layout.

