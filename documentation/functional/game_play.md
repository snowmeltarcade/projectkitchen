# Game Play

Having fun is the main game play objective. Game rules and logic should be simple and easy to learn and remember. Cooperative play is encouraged over competitive play.

- [Game Play](#game-play)
  - [Goals](#goals)
  - [Style](#style)
  - [Target Audience](#target-audience)
  - [Flow](#flow)
  - [Cooking Levels](#cooking-levels)

## Goals

Working as a group; gather ingredients and process and plate them according to set recipes within a set time limit.

## Style

Game sessions are easy to setup and simple to play. Game sessions should not be overly long in length or require much cognitive load. Fun is based on cooperation and group play. Challenge is based on inter-group communication, specific recipes to create and time limits.

## Target Audience

* A group with a minimum of 2 players and a maximum of 16 players
* Groups of people between 5 and 40 years of age
* Low technical skill required
* No real life cooking experience required
* Basic computer game experience beneficial
* Willing to communicate and cooperate with others

## Flow

The basic game flow is as follows:

```mermaid
flowchart TB;
    start_game([Start Game])-->select_game_mode{Start Server/<br/>Connect to Server};
    select_game_mode--Server-->start_server[Start Server];
    select_game_mode--Client-->connect_to_server[Connect to Server];
    start_server-->configure_players[Configure and Connect Networked Players];
    configure_players-->configure_level[Configure Level];
    configure_level-->load_level[Load Level];
    connect_to_server-->load_level;
    load_level-->play_level[Play Level];
    play_level-->select_game_mode;
```

## Cooking Levels

A typical game level has the following flow:

![Cooking Level Flow](images/cooking_level_flow.drawio.png)
