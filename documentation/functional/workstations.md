# Workstations

A workstation is a section in a [kitchen](kitchens.md) that performs a function. The locations of workstations in a kitchen is player defined. Players move between workstations to perform the functions offered by the workstation.

All workstations take up one cell in the kitchen grid.

- [Workstations](#workstations)
  - [Types](#types)
    - [Ingredient Store](#ingredient-store)
      - [Food Box](#food-box)
      - [Pantry](#pantry)
    - [Serving Area](#serving-area)
    - [Plate Cupboard](#plate-cupboard)
    - [Chopping Board](#chopping-board)
    - [Mixing Bowel](#mixing-bowel)
    - [Frying Pan](#frying-pan)

## Types

There are various types of workstation, each with a specific function. Types can have subtypes. Each type requires a specific [action](food_preparation.md).

### Ingredient Store

Provides ingredients for players to use. Specific ingredient choices are provided based upon the menus to be created. Ingredients can be removed from the store at a set rate per n-unit of time. For instance, 1 potato every 5 seconds.

Food preparation action: `tap`.

#### Food Box

This is the basic level ingredient store. Its capacity is limited and refill rate slow.

#### Pantry

This is the higher level ingredient store. Its capacity is high and refill rate fast.

### Serving Area

Food and plates are passed here to be served to a customer.

Food preparation action: `tap`.

### Plate Cupboard

Plates are taken from here to prepare for food. Plates can only be taken at a set rate per n-unit of time.

Food preparation action: `tap`.

### Chopping Board

Food can be chopped here.

Food preparation action: `swipe`.

### Mixing Bowel

Food can be mixed here.

Food preparation action: `circle`.

### Frying Pan

Food can be fried here.

Food preparation action: `circle`.
