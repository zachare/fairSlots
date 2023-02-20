# fairSlots

## Current Assessment

The app is now storing both the Game and Player sets in the LocalDB. It is however in a seperate DbContext from the one holding authentication data and thus it requires seperate migrations and updates. The Game History page will now display test data and allow for the user to edit each game (this is to be later restricted to authorized users). Clicking the edit button next to a specific game will then create an edit page for that specific game, populating each of the properties with their current values. This will save any changes made upon clicking the submit button. This will also serve as a create page when the Game object is null and will generate the fields accordingly.

## Roles
- Zach
  - Full Stack Dev
  - GitHub Management
- Jeff and Jay
  - Home/Game Page
  - Game Dev
- Alex M
  - Profile Page
  - Profile Features
- Alex L
  - General UI
