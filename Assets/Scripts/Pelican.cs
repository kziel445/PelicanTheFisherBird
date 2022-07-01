using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pelican : MonoBehaviour

{
    public Rigidbody2D rg;
    public Animator animator;
    public float silaskosku = 5f;
    [SerializeField] float jumpModificator = 2;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
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
        if(Input.GetMouseButtonDown(0)) Skok();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("siem");
            //animator.SetBool("EatTrigger",true);
            animator.Play("pelicanEat");
        }
    }
    void Skok()
    {
        rg.velocity = Vector2.zero;
        rg.AddForce(new Vector2(0, silaskosku), ForceMode2D.Impulse);
    }
}