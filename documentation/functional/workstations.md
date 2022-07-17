# Workstations

A workstation is a section in a [kitchen](kitchens.md) that performs a function. The locations of workstations in a kitchen is player defined. Players move between workstations to perform the functions offered by the workstation.

All workstations take up one cell in the kitchen grid.

- [Workstations](#workstations)
  - [Types](#types)
    - [Supply](#supply)
      - [Pantry](#pantry)
      - [Plate Cupboard](#plate-cupboard)
    - [Mutation](#mutation)
      - [Chopping Board](#chopping-board)
      - [Mixing Bowel](#mixing-bowel)
      - [Frying Pan](#frying-pan)
    - [Finalization](#finalization)
      - [Plating Station](#plating-station)
      - [Serving Stations](#serving-stations)

## Types

There are three types of workstation:

1. Supply
2. Mutation
3. Finalization

Types can have subtypes. Each subtype requires a specific player [action](food_preparation.md).

### Supply

Supplies a variety of items. These items could be ingredients, plates or something else.

Getting items from a supply workstation is not rate limited by time, but item types are limited by capacity. Once items run out, a period of time is required for those items to be restocked. The restocking occurs automatically during a level, and instantly after a level is finished.

As supply workstations are leveled up, their capacity increases and the restocking time decreases. Different items have different capacities and restocking times.

When an item is taken out of a supply workstation, it is placed on the workstation itself for the player to handle.

Required action: `tap`.

#### Pantry

Provides ingredients for players to use. Specific ingredient choices are provided based upon the menus to be created.

#### Plate Cupboard

Plates are taken from here to plate ingredients.

### Mutation

Allows items to be changed from one type to another. This is a process that requires user action and/or a period of time. The specific number of actions and/or time required depends on the item being processed.

As these workstations level up, their time to process certain ingredients decreases. Also, the number of items that can be processed at one time increases.

Different workstations require different player actions.

#### Chopping Board

Ingredients can be chopped here.

Required action: `swipe`.

#### Mixing Bowel

Ingredients can be mixed here.

Required action: `circle`.

#### Frying Pan

Ingredients can be fried here.

Required action: `circle`.

### Finalization

Items are placed here to be finalized - that is to be plated and served.

Required action: `tap`.

#### Plating Station

Ingredients are placed on a plate. What ingredients are allowed to be plated depends on what menu orders are active.

A completed plate of food must be passed to a serving station.

#### Serving Stations

Completed plates of food are taken here and are then delivered to customers. The player simply needs to place a completed plate of food here. The actual delivery to customers is automatic.

Once a plate of food is delivered, that plate is automatically restocked in the plate cupboard.
