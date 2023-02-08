using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

namespace Controllers
{
   public class GameController : MonoBehaviour
    {
        private static GameController instance;
        public static GameController GetInstance()
        {
            return instance;
        }

        public Transform waterHeight;
        public bool controlLineState = false;
        private float waterLevel;
        private bool waterInitialized = false;
        public float WaterLevel
        {
            get { return waterLevel; }
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
            instance = this;
            WaterLevel = waterHeight.position.y;
            waterHeight.gameObject.SetActive(controlLineState);
        }
        public void Test()
        {}

    }

}
