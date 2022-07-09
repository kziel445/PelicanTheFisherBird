using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public sealed class FishController : MonoBehaviour
{
    private static FishController instance;

    public static FishController GetInstance()
    {
        return instance;
    }

    private List<Transform> fishList;
    float fishTimeSpawner;
    float speedModificator;
    int randomFishIndex;
    Vector3 startPosition;
    bool goRight;

    private void Awake()
    {
        instance = this;
        fishList = new List<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Pelican.GetInstance().EatenFish += EatenFish_RemoveFish;
    }
    private void EatenFish_RemoveFish(object sender, Transform e)
    {
        RemoveFish(e);
        Debug.Log($"Die!");
    }
    // Update is called once per frame
    void Update()
    {
        FishMoving();
        FishGenerator();
    }
    // all values based random const values min/max,
    // speedModificator changed(speedModificator - waterSpeedModificator) when going right(going upstream),
    // localScale changed when NOT going right
    public void FishGenerator()
    {
        fishTimeSpawner -= Time.deltaTime;
        if (fishTimeSpawner < 0)
        {
            fishTimeSpawner = Random.Range(Config.FISH_MIN_SPAWN_DELAY, Config.FISH_MAX_SPAWN_DELAY);
            speedModificator = Random.Range(Config.FISH_MIN_SPEED, Config.FISH_MAX_SPEED);
            randomFishIndex = Random.Range(0, GameAsstes.GetInstance().pfFish.Count);

            if (Random.Range(0f, 1f) > Config.FISH_MOVING_RIGHT_PERCENT_CHANCE)
            {
                goRight = true;
                speedModificator = speedModificator - Config.WATER_MOVING_SPEED >= 0 ? speedModificator - Config.WATER_MOVING_SPEED : 1;
            }
            else goRight = false;
            startPosition = new Vector3(goRight ? -Config.CAMERA_X_SIZE : Config.CAMERA_X_SIZE, Random.Range(Config.FISH_MIN_Y, Config.FISH_MAX_Y), 0);


            Transform fish = Instantiate(GameAsstes.GetInstance()
                .pfFish[randomFishIndex], startPosition, Quaternion.identity);

            int fishValue = randomFishIndex;

            Fish fishComponent = fish.GetComponentInChildren<Fish>() ?
                fish.GetComponentInChildren<Fish>() : fish.gameObject.AddComponent<Fish>();
            fishComponent.FishInit(speedModificator, fishValue, goRight);


            if (!goRight) fish.localScale = 
                    new Vector3(
                        fish.localScale.x * -1, fish.localScale.y, fish.localScale.z
                        );
            fishList.Add(fish);
        }
    }
    public void FishMoving()
    {
        for (int i = 0; i < fishList.Count; i++)
        {
            if (fishList[i].transform.position.x > Config.CAMERA_X_SIZE || fishList[i].transform.position.x < -Config.CAMERA_X_SIZE)
            {
                RemoveFish(fishList[i]);
                i--;
            }
            else fishList[i].GetComponentInChildren<Fish>().Move();
        }
    }
    public void RemoveFish(Transform fish)
    {
        Destroy(fish.gameObject);
        fishList.Remove(fish);
    }
}
