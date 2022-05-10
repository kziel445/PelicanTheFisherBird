using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plywanie : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-0.5f *Time.deltaTime, 0, 0, Space.World);
    }
}