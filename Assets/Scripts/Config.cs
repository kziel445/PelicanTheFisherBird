using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config
{
    // background 
    public const float WATER_MOVING_SPEED = 6;
    public const float WATER_HEIGHT = -1;

    public const float SKY_MOVING_SPEED = 1;
    public const float SKY_HEIGHT = 0;

    // fishes
    public const float FISH_MAX_SPAWN_DELAY = 4;
    public const float FISH_MIN_SPAWN_DELAY = 2;
    public const float FISH_MAX_SPEED = 4;
    public const float FISH_MIN_SPEED = 2;
    public const float FISH_MOVING_RIGHT_PERCENT_CHANCE = .5f;
    public const float FISH_MAX_Y = -2.5f;
    public const float FISH_MIN_Y = -4f;

    // camera
    public const float CAMERA_X_SIZE = 4.62f;

    // pelican
    public const float PELICAN_EAT_HEIGHT = 400;
    public const float PELICAN_DEATH_HEIGHT = -2f;
}
