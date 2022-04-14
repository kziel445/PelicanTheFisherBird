using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruchchorzow : MonoBehaviour
{
    [SerializeField] float jumpModificator = 2;
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
        if (Input.touchCount > 0)
        {
            transform.Translate(0, jumpModificator * Time.deltaTime, 0, Space.World);
        }
        else
        {
            transform.Translate(0, -1 * Time.deltaTime, 0, Space.World);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-1f * Time.deltaTime , 0, 0, Space.World);
        }
    }
}
