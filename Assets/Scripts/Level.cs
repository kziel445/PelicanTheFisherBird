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
    
    // TODO: 
    // add to camera function or something
    // cameraSize = new Vector2(Camera.main.aspect* Camera.main.orthographicSize* 2f, Camera.main.orthographicSize* 2f);
    //private const float CAMERA_X_SIZE = 4.62f;
    //private const float CAMERA_Y_SIZE = 10f;

    [SerializeField] private float skyMovingSpeed = 1;
    [SerializeField] private float skyHeight = 0;
    Background skyList;
    
    [SerializeField] private float waterMovingSpeed = 6;
    [SerializeField] private float waterHeight = 0;
    Background waterList;


    private void Awake()
    {
        skyList = SpawnInitialBackgrounds(GameAsstes.GetInstance().pfSky, skyMovingSpeed, skyHeight);
        waterList = SpawnInitialBackgrounds(GameAsstes.GetInstance().pfWater, waterMovingSpeed, waterHeight);
        Transform fish = Instantiate(GameAsstes.GetInstance().pfFish, new Vector3(-1, -3.6f, 0), Quaternion.identity);
        Fish fishClass = new Fish(fish.transform, 2, 10, 100);

    }
    private void Update()
    {
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



