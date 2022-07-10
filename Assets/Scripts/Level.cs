using System;
using System.Collections.Generic;
using UnityEngine;


// class contains everything about level
public class Level : MonoBehaviour
{
    private static Level instance;
    public static Level GetInstance()
    {
        return instance;
    }

    Background skyList;

    Background waterList;


    public event EventHandler OnGamePlaying;

    private void Awake()
    {
        skyList = SpawnInitialBackgrounds(GameAsstes.GetInstance().pfSky, Config.SKY_MOVING_SPEED, Config.SKY_HEIGHT);
        waterList = SpawnInitialBackgrounds(GameAsstes.GetInstance().pfWater, Config.WATER_MOVING_SPEED, Config.WATER_HEIGHT);
    }
    private void Update()
    {
        OnGamePlaying?.Invoke(this, EventArgs.Empty);
        skyList.Move();
        waterList.Move();
    }

    // create backgrounds from 2 the same prefabs(only works when one prefab size > screen size)
    public Background SpawnInitialBackgrounds(Transform prefab, float speedModificator, float height)
    {
        List<Transform> listBackgrounds = new List<Transform>();
        float prefabWidth = prefab.GetComponent<SpriteRenderer>().size.x * prefab.transform.localScale.x;

        Transform prefabInit = Instantiate(prefab, new Vector3(0, height, 0), Quaternion.identity);
        listBackgrounds.Add(prefabInit);        
        prefabInit = Instantiate(prefab, new Vector3(prefabWidth, height, 0), Quaternion.identity);
        listBackgrounds.Add(prefabInit);

        return new Background(listBackgrounds, speedModificator);
    }
}



