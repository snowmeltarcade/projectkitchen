# Game Play

Having fun is the main game play objective. Game rules and logic should be simple and easy to learn and remember. Cooperative play is encouraged over competitive play.

- [Game Play](#game-play)
  - [Goals](#goals)
  - [Style](#style)
  - [Target Audience](#target-audience)
  - [Game Flow](#game-flow)
  - [Configuring Levels](#configuring-levels)
  - [Cooking Levels](#cooking-levels)
    - [Passing and Failing](#passing-and-failing)
    - [Order Ratings](#order-ratings)
    - [Moving Between Workstations](#moving-between-workstations)
    - [Player Disconnections](#player-disconnections)
  - [Ingredients](#ingredients)
    - [Passing Ingredients](#passing-ingredients)
    - [Preparing Ingredients](#preparing-ingredients)
  - [Plates](#plates)
  - [Achievements](#achievements)
    - [Stars](#stars)
  - [World Map](#world-map)

## Goals

Working as a group; gather ingredients and process and plate them according to set recipes within a set time limit.

## Style

Game sessions are easy to setup and simple to play. Game sessions should not be overly long in length or require much cognitive load. Fun is based on cooperation and group play. Challenge is based on inter-group communication, specific recipes to create and time limits.

## Target Audience

* A group with a minimum of 1 player and a maximum of 16 players
* Groups of people over 5 years of age
* Low technical skill required
* No real life cooking experience required
* Basic computer game experience beneficial
* Willing to communicate and cooperate with others

## Game Flow

The basic game flow is as follows:

```mermaid
flowchart TB;
    start_game([Start Game])-->select_game_mode{Single Player<br/>Start Server<br/>Connect to Server};
    select_game_mode--Server-->start_server[Start Server];
    select_game_mode--Client-->connect_to_server[Connect to Server];
    start_server-->configure_players[Configure and Connect Networked Players];
    configure_players-->configure_level[Configure Level];
    select_game_mode--Single Player-->configure_level;
    configure_level-->load_level[Load Level];
    connect_to_server-->load_level;
    load_level-->play_level[Play Level];
    play_level-->select_game_mode;
```

## Configuring Levels

Each [kitchen](kitchens.md) has a set layout with a slots for workstations to be placed. Before a level can be played, the lead player (the server) must fill these slots with the workstations they have access to. Every kitchen has a set of required workstations.

After the kitchen has been layed out, each player must then select the workstation they will start at. This will be done using the kitchen lobby screen.

## Cooking Levels

A typical game level has the following flow:

```mermaid
flowchart TB;
    kitchen_lobby(["Players select their workstations"])-->game_play_tips[Game play tips are displayed during level load];
    game_play_tips-->level_goals[Players informed of what recipes are expected];
    level_goals-->countdown[Countdown timer in seconds - 3, 2, 1];
    countdown-->level_timer_begins[Level timer begins];
    level_timer_begins-->orders_placed[Orders continually placed by restaurant customers];
    orders_placed-->communication[Players communicate what ingredients they need];
    communication-->pantry_ingredients[Player at pantry workstation to get ingredients and pass to other players];
    pantry_ingredients-->passing_ingredients[Players pass ingredients either up, down, left or right until the ingredients end up at the correct workstation];
    passing_ingredients-->prepare_ingredients["Player at workstation prepares the ingredients at the workstation.<br/>(If no player is at the workstation, a player needs to move to that workstation.)"];
    prepare_ingredients-->passing_prepared_ingredients["Players pass the prepared ingredients up, down left or right until the ingredients end up at the plating workstation"];
    passing_prepared_ingredients-->plating_up[Player at plating up workstation puts prepared ingredients on a plate];
    plating_up-->pass_plate_to_serving_area[When the plate has all the needed ingredients for an order,<br/>the player passes the plate to their up, down, left or right until the plate ends up at the serving area workstation];
    pass_plate_to_serving_area-->serving_plate[Player places plate onto a menu order on the serving area workstation];
    serving_plate-->rating_assigned["Rating given by customer based on how long their had to wait for their order<br/>and how accurately prepared the ingredients were."];
    rating_assigned-->game_time_expired{Game Time Expired?};
    game_time_expired--No-->orders_placed;
    game_time_expired--Yes-->game_play_stopped[Game play stopped];
    game_play_stopped-->results_screen[Results screen displayed];
    results_screen-->exit_level([Exit level]);
```

### Passing and Failing

To pass a level, at last 1 star must have been awarded, else the level has been failed.

### Order Ratings

Each time a plate of food is served to a customer, that customer gives the restaurant a 0 to 5 rating.

1. 0 stars means that the order was unfulfilled
2. 1 star means the ingredients and/or plate did not match what was ordered
3. 2 stars means that the ingredients and plate were correct, but no ingredients were prepared correctly
4. 3 stars means that the ingredients and plate were correct, but less than 100% of the ingredients were prepared correctly
5. 4 stars means that the ingredients and plate were correct, and all of the ingredients were prepared correctly or the order was served in less time than the customer expected
6. 5 stars means that the ingredients and plate were correct, and all of the ingredients were prepared correctly and the order was served in less time than the customer expected

### Moving Between Workstations

Players can move between workstations during game play. They will do this by using the kitchen lobby screen. Players can only move to a workstation that has no player already there.

### Player Disconnections

If a player gets disconnected from game play (or the app stops running, due to being minimized/put into the background on a mobile device etc...), that player automatically gets removed from active game play. When that player reconnects (or the app starts running again), they will start out at the kitchen lobby screen.

## Ingredients

Ingredients need to be passed and prepared so they can be plated according to customer orders

### Passing Ingredients

The player has to pass ingredients either up, down, left or right to a different workstations. As workstations are positioned in a grid, the player must keep in mind where a workstation is in relation to their current workstation. Workstations are positioned directly next to each other, so there are no gaps between workstations.

Not all sides of a workstation will have an adjacent workstation. If there is no workstation on the side an ingredient is passed, that ingredient falls to the floor and is lost.

This is an example of how workstations may be positioned:

![Workstation Selection](images/workstation_selection.drawio.png)

### Preparing Ingredients

[Ingredients](ingredients.md) can be prepared up to 5 different ways. A workstation is required to prepare an ingredient. When a customer makes an order, they will also specify how they would like an ingredient to be prepared.

## Plates

Prepared ingredients should be put on a [plate](plates.md) so they can be given to a customer. A customer will specify what type of plate they expect their food to be put on.

The number of certain types of plates is limited. When this type of plate is given to a customer, it will be returned to a wash area after a set period of time. Some plates can also be dropped and smashed, thus rendering them unusable.

Food can only be put on plates in the plating area.

## Achievements

For every level that is passed, the lead player is awarded stars. These can be used to purchase new workstations or upgrade existing [workstations](workstations.md).

### Stars

Each level has a maximum of 5 stars that can be awarded. The number of stars awarded is determined by the average star rating given for all orders in the level.

Stars can only be awarded once. The player may retry a level in order to get the full number of stars, but stars already awarded cannot be awarded again.

Stars that have been awarded can be used to level up and purchase workstations.

## World Map

The game world is organized into different areas. Each area contains a set of levels. Some levels are mandatory to move onto the next level. Other levels are optional.

The player moves around the dragging the map and selecting a level to play.
