using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform waterHeight;
    private float waterLevel;
    private bool waterInitialized = false;
    public float WaterLevel
    {
        get { return waterLevel;}
        private set 
        {
            if (!waterInitialized)
            {
                waterLevel = value;
                waterInitialized = true;
            }
        }
    }

    private void Awake()
    {
        WaterLevel = waterHeight.position.y;
        waterHeight.gameObject.SetActive(false);
    }


}
