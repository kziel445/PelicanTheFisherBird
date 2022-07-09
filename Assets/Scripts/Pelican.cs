using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pelican : MonoBehaviour
{
    private static Pelican instance;

    public static Pelican GetInstance()
    {
        return instance;
    }

    public Rigidbody2D rg;
    public Animator animator;
    public float silaskosku = 5f;
    [SerializeField] float jumpModificator = 2;

    public event EventHandler<Transform> EatenFish;

    private void Awake()
    {
        instance = this;
    }
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
            if (touch.phase == TouchPhase.Began
                && touch.position.y > Config.PELICAN_EAT_HEIGHT)
            {
                Skok();
            }
            else if(touch.phase == TouchPhase.Began
                && touch.position.y <= Config.PELICAN_EAT_HEIGHT)
            {

                Debug.Log(touch.position.y);
                Eat();
            }
        }
    }
    void Skok()
    {
        rg.velocity = Vector2.zero;
        rg.AddForce(new Vector2(0, silaskosku), ForceMode2D.Impulse);
    }
    void Eat()
    {
        animator.Play("pelicanEat");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EatenFish?.Invoke(this, other.transform);
    }
}