# Workstations

A workstation is a section in a [kitchen](kitchens.md) that performs a function. The locations of workstations in a kitchen is player defined. Players move between workstations to perform the functions offered by the workstation.

Workstations must be purchased and leveled up by using stars awarded when completing levels.

- [Workstations](#workstations)
  - [Size](#size)
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

## Size

All workstations take up one cell in the kitchen grid and have the same size.

Items (ingredients, plates etc...) all have different sizes and cannot overlap. This means that the number of items a player stores on a workstation is limited.

If a player passes an item to a workstation that has no space, this item is spoiled by falling on the floor. Players are made aware that a workstation has no space before they commit to passing to it, although there is no game mechanic to stop them from passing the item if they choose to do so. If they choose to still pass an ingredient, it falls to the floor and is spoiled. If a plate falls to the floor, it smashes and cannot be restocked during that level.

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

**Purchase Cost**: Free - given to the player by default

**Level 1**

_Cost of Upgrade_: N/A

_Stocked Ingredients_: Bread; Beef;

**Level 2**

_Cost of Upgrade_: ??

_Stocked Ingredients_: ??

**Level 3**

_Cost of Upgrade_: ??

_Stocked Ingredients_: ??

**Level 4**

_Cost of Upgrade_: ??

_Stocked Ingredients_: ??

**Level 5**

_Cost of Upgrade_: ??

_Stocked Ingredients_: ??

#### Plate Cupboard

Plates are taken from here to plate ingredients. Will include a sink to wash dishes when level upgraded to level 2.

**Purchase Cost**: Free - given to the player by default

**Level 1**

_Cost of Upgrade_: N/A

_Stocked Plates_: Paper;

**Level 2**

_Cost of Upgrade_: ??

_Stocked Plates_: Ceramic;

**Level 3**

_Cost of Upgrade_: ??

_Stocked Plates_: Slate;

**Level 4**

_Cost of Upgrade_: ??

_Stocked Plates_: Player;

**Level 5**

_Cost of Upgrade_: ??

_Stocked Plates_: Jewel Encrusted;

### Mutation

Allows items to be changed from one type to another. This is a process that requires user action and/or a period of time. The specific number of actions and/or time required depends on the item being processed.

As these workstations level up, their ability to produce different forms of an ingredient becomes available. The player must perform the required action a certain number of times or for a certain period of time to product an available ingredient form.

If the player performs too many of these actions or takes too long (for instance, slices an ingredient too many times), the actions cannot be reversed. Either the player uses the resulting ingredient form or tries again with a new ingredient.

A help label on these workstations will remind the player of what actions are required. This label can be tapped/clicked to be viewed by the player.

Different workstations require different player actions.

#### Chopping Board

Ingredients can be chopped here.

**Required action**: `swipe`.

**Purchase Cost**: Free - given to the player by default

**Level 1**

_Cost of Upgrade_: N/A

_Produced Ingredient Types_: Peeled;

_Number of Actions Required_: 4

**Level 2**

_Cost of Upgrade_: ??

_Produced Ingredient Types_: Rough Slice;

_Number of Actions Required_: 6

**Level 3**

_Cost of Upgrade_: ??

_Produced Ingredient Types_: Fine Slice;

_Number of Actions Required_: 8

**Level 4**

_Cost of Upgrade_: ??

_Produced Ingredient Types_: Rough Dice;

_Number of Actions Required_: 10

**Level 5**

_Cost of Upgrade_: ??

_Produced Ingredient Types_: Find Dice;

_Number of Actions Required_: 12

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

Completed plates of food are taken here and are then delivered to customers. All order slips can be seen on this station. The player must place the completed plate of food on an order slip. As soon as the plate is placed on a slip, it is delivered. If the plate of food does not match the slip, the customer will give a 0-star rating.

Once a plate of food is delivered and that plate is reusable, that plate is automatically placed in the plate cupboard's sink after a short period of time. This period of time is defined by type of restaurant. If there is more than one plating cupboard workstation, the workstation is randomly chosen.
