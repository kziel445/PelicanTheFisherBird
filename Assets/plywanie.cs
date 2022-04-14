using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plywanie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
        Debug.Log(transform.rotation.eulerAngles);
        Debug.Log(transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1f *Time.deltaTime , 0, 0, Space.World);
    }
}
