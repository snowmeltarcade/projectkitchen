# Food Preparation

Each type of [ingredient](ingredients.md) can be prepared in various ways. Some preparation techniques change the state of an ingredient and some combine ingredients to create a new ingredient.

Each preparation technique requires a [kitchen item](kitchen_items.md) and a specific set of actions to complete.

- [Food Preparation](#food-preparation)
  - [Actions](#actions)
    - [Moving Ingredients and Items](#moving-ingredients-and-items)
    - [Kitchen Item Actions](#kitchen-item-actions)

## Actions

All actions must be simple to perform for players using a small touch screen device and must be actionable by players using a game controller or keyboard/mouse combination.

On non-touch screen devices, a game cursor will be visible and can be controlled with the mouse or game controller's d-pad/stick.

### Moving Ingredients and Items

Ingredients and kitchen items must be drag and drop-able on the player's kitchen worktop. Ingredients must be able to be dropped onto a kitchen item and removed from the item.

Once an ingredient has been placed on a kitchen item, it can only be removed when the item's actions have been fully performed.

A kitchen item can only be moved when an ingredient has not been placed on it. If an ingredient is on the kitchen item, that action is counted as a process action.

| Input Device | Description of Input |
| -- | -- |
| Touch Screen | Tap and drag |
| Keyboard & Mouse | Click and drag with mouse |
| Game Controller | Drag with d-pad/stick whilst pressing action button |

### Kitchen Item Actions

Ingredients can be processed when placed onto a kitchen item. The process actions must be performed on/over the kitchen item (tapping it, swiping it etc...) If no ingredients are on the kitchen item, no process actions are processed by the kitchen item.

The following actions are supported:

| Action | Touch Screen | Keyboard & Mouse | Game Controller | Description |
| -- | -- | -- | -- | -- |
| Tap | Tap screen | Click with mouse | Press action button | The output ingredient specifies how many times to tap |
| Swipe | Swipe screen | Click and move cursor | Press action button then auxiliary button in rapid sequence | The output ingredient specifies how many times to swipe |
| Circle | Touch circle gesture | Click and circle with mouse | Press action and auxillary buttons at the same time in rapid sequence | The output ingredient specifies how many times to circle |
