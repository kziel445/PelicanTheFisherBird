using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ruchchorzow : MonoBehaviour

{
    public Rigidbody2D rg;
    public float silaskosku = 5f;
    [SerializeField] float jumpModificator = 2;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Skok();
            }
        }
        else
        {

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-1f * Time.deltaTime, 0, 0, Space.World);
        }
    }
    void Skok()
    {
        rg.velocity = Vector2.zero;
        rg.AddForce(new Vector2(0, silaskosku), ForceMode2D.Impulse);
    }
}