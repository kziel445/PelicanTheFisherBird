# PelicanTheFisherBird

Simple mobile game, where your task is to catch fishes :fish: :fish:

## Unity Version

2021.3.0f1

<br>

# GameHandler classes

## Level

### SpawnInitialBackgrounds

Create 2 gameObjects which are passed as a list to background class <br>
Return Background class;

### FishGenerator<br>

Create fish in const time delay<br>
all values based random const values beetwen min and max,<br>
speedModificator changed(speedModificator - waterSpeedModificator) when going right(going upstream),<br>
localScale changed when NOT going right

### FishMoving<br>

Handle fish moving, when out of screen(screen size x) destroy object

## Fish

Parameters: prefab, speedModificator, moveDirection<br>
Methods: Move

### Moving

Fish class and place for asset has been added

## Background

Parameters: speedModificator, backgroundList, leftBorder, rightBorder<br>
Methods: Move

### Moving water and sky

Two prefab with spriteRenderer going left until reach left border, then change position.x to rightBorder. <br>
-leftBorder position.x = 0 - width of prefab sprite <br>
-rightBorder position.x = 0 + width of prefab sprite
