# PelicanTheFisherBird
Simple mobile game, where your task is to catch fishes :fish: :fish:
## Unity Version
2021.3.0f1

<br>

# GameHandler
## Fish
### Existing
Fish class and place for asset has been added

## Background
### Moving water and sky
Two prefab with spriteRenderer going left until reach left border, then change position.x to rightBorder. <br>
-leftBorder position.x = 0 - width of prefab sprite <br>
-rightBorder position.x = 0 + width of prefab sprite

### Implementation
Prefab wider than screen<br>
Add prefab to GameAsset<br>
Set starting position.y<br>
Set move speed<br>
### Feature
Add possibility to add sprites smaller than wide of screen <br>
Add possibility to add diffrent sprites