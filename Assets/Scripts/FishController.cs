using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
   
    private List<Fish> fishList;
    float fishTimeSpawner;
    float speedModificator;
    int randomFishIndex;
    Vector3 startPosition;
    bool goRight;

    private void Awake()
    {
        fishList = new List<Fish>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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


            Transform fish = Instantiate(GameAsstes.GetInstance().pfFish[randomFishIndex], startPosition, Quaternion.identity);
            if (!goRight) fish.localScale = new Vector3(fish.localScale.x * -1, fish.localScale.y, fish.localScale.z);
            fishList.Add(new Fish(fish, speedModificator, goRight));
        }
    }
    public void FishMoving()
    {
        for (int i = 0; i < fishList.Count; i++)
        {
            if (fishList[i].prefab.position.x > Config.CAMERA_X_SIZE || fishList[i].prefab.position.x < -Config.CAMERA_X_SIZE)
            {
                Destroy(fishList[i].prefab.gameObject);
                fishList.Remove(fishList[i]);
                i--;
            }
            else fishList[i].Move();
        }
    }
}
