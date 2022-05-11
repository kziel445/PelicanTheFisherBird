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
    [SerializeField] private float skyHeight = 1;
    Background skyList;
    
    [SerializeField] private float waterMovingSpeed = 6;
    [SerializeField] private float waterHight = 1;
    Background waterList;


    private void Awake()
    {
        skyList = SpawnInitialBackgrounds(GameAsstes.GetInstance().pfSky, skyMovingSpeed);
        waterList = SpawnInitialBackgrounds(GameAsstes.GetInstance().pfWater, waterMovingSpeed);

    }
    private void Update()
    {
        skyList.Move();
        waterList.Move();
    }

    // create backgrounds from 2 the same prefabs(only works when one prefab size > screen size)
    public Background SpawnInitialBackgrounds(Transform prefab, float speedModificator)
    {
        List<Transform> listBackgrounds = new List<Transform>();
        float prefabWidth = prefab.GetComponent<SpriteRenderer>().size.x * prefab.transform.localScale.x;

        Transform prefabInit = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        listBackgrounds.Add(prefabInit);        
        prefabInit = Instantiate(prefab, new Vector3(prefabWidth, 0, 0), Quaternion.identity);
        listBackgrounds.Add(prefabInit);

        return new Background(listBackgrounds, speedModificator);
    }
}



