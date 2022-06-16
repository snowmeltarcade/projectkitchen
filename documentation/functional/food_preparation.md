# Food Preparation

Each type of ingredient can be prepared in various ways. Some preparation techniques change the state of an ingredient and some combine ingredients to create a new ingredient.

Each preparation technique requires one or more kitchen items and a specific amount of time to complete. Some techniques require the player to simply initialize the action, some require multiple invocations from the player.

- [Food Preparation](#food-preparation)
  - [Techniques](#techniques)

## Techniques

| Name | Effect on Ingredient(s) | Required Kitchen Item(s) | Invocation Method | Time Required to Complete (seconds) | Description |
| -- | -- | -- | -- | -- | -- |
| Chop | Changes state | Knife with chopping board | Multiple | N/A | Ingredient states how many invocations are required |
| Mix | Takes two ingredients and outputs a new ingredient | Mixing bowl | Multiple | N/A | Resulting ingredient states how many invocations |
| Fry | Changes state | Frying pan and cooking hob | Single | Ingredient defined | Ingredient will have state set to burnt if time is exceeded |
| Plate | Add ingredient to plate | Plate | Single for each required ingredient | 0 | A plate is assigned a recipe. Only ingredients specified by the recipe can be put on the plate. When all ingredients specified by the recipe are on the plate, the plate can then be sent to the serving area |
