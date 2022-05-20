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

    // camera
    private const float CAMERA_X_SIZE = 4.62f;

    // background
    [SerializeField] private float skyMovingSpeed = 1;
    [SerializeField] private float skyHeight = 0;
    Background skyList;
    
    [SerializeField] private float waterMovingSpeed = 6;
    [SerializeField] private float waterHeight = 0;
    Background waterList;

    // fishes
    private const float FISH_MAX_SPAWN_DELAY = 2;
    private const float FISH_MIN_SPAWN_DELAY = 1;
    private const float FISH_MAX_SPEED = 4;
    private const float FISH_MIN_SPEED = 4;
    private const float FISH_MOVING_RIGHT_PERCENT_CHANCE = .5f;
    private const float FISH_MAX_Y = -2.8f;
    private const float FISH_MIN_Y = -4.5f;

    private List<Fish> fishList;
    float fishTimeSpawner;
    float speedModificator;
    int randomFishIndex;
    Vector3 startPosition;
    bool goRight;

    private void Awake()
    {
        skyList = SpawnInitialBackgrounds(GameAsstes.GetInstance().pfSky, skyMovingSpeed, skyHeight);
        waterList = SpawnInitialBackgrounds(GameAsstes.GetInstance().pfWater, waterMovingSpeed, waterHeight);
        fishList = new List<Fish>();       
    }
    private void Update()
    {
        skyList.Move();
        waterList.Move();
        FishMoving();
        FishGenerator();
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

    // all values based random const values min/max,
    // speedModificator changed(speedModificator - waterSpeedModificator) when going right(going upstream),
    // localScale changed when NOT going right
    public void FishGenerator()
    {
        fishTimeSpawner -= Time.deltaTime;
        if(fishTimeSpawner < 0)
        {
            fishTimeSpawner = Random.Range(FISH_MIN_SPAWN_DELAY, FISH_MAX_SPAWN_DELAY);
            speedModificator = Random.Range(FISH_MIN_SPEED, FISH_MAX_SPEED);
            randomFishIndex = Random.Range(0, GameAsstes.GetInstance().pfFish.Count);
            if (Random.Range(0f, 1f) > FISH_MOVING_RIGHT_PERCENT_CHANCE)
            {
                goRight = true;
                speedModificator = speedModificator - waterMovingSpeed  >= 0 ? speedModificator - waterMovingSpeed : 1;
            }
            else goRight = false;
            startPosition = new Vector3(goRight ? -CAMERA_X_SIZE / 2 - 4 : CAMERA_X_SIZE / 2 + 4, Random.Range(FISH_MIN_Y, FISH_MAX_Y), 0);


            Transform fish = Instantiate(GameAsstes.GetInstance().pfFish[randomFishIndex], startPosition, Quaternion.identity);
            if (!goRight) fish.localScale = new Vector3(fish.localScale.x * -1, fish.localScale.y, fish.localScale.z);
            fishList.Add(new Fish(fish, speedModificator, goRight));
        }
    }
    public void FishMoving()
    {
        for (int i = 0; i < fishList.Count; i++)
        {
            if (fishList[i].prefab.position.x > CAMERA_X_SIZE || fishList[i].prefab.position.x < CAMERA_X_SIZE)
            {
                Destroy(fishList[i].prefab.gameObject);
                fishList.Remove(fishList[i]);
                i--;
            }
            else fishList[i].Move();
        }
    }
}



