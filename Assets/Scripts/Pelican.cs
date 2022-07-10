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
    private Collider2D collider;
    [SerializeField] float jumpModificator = 2;
    private State state;

    public event EventHandler<Transform> EatenFish;
    public event EventHandler OnStartedPlaying;
    public enum State
    {
        WaitingToStart,
        Playing,
        Dead
    }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.bodyType = RigidbodyType2D.Static;

        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;

    }

    void Update()
    {
        switch(state)
        {
            default:
            case State.WaitingToStart:
                WaitingInputs();
                break;
            case State.Playing:
                PlayingInputs();
                break;
            case State.Dead:
                break;
        }
        if (Config.PELICAN_DEATH_HEIGHT > transform.position.y) Die();
    }
    void WaitingInputs()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                state = State.Playing;
                rg.bodyType = RigidbodyType2D.Dynamic;
                Skok();
                if (OnStartedPlaying != null) OnStartedPlaying(this, EventArgs.Empty);
            }
        }
    }
    void PlayingInputs()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began
                && touch.position.y > Config.PELICAN_EAT_HEIGHT)
            {
                Skok();
            }
            else if (touch.phase == TouchPhase.Began
                && touch.position.y <= Config.PELICAN_EAT_HEIGHT)
            {
                Catch();
            }
        }
    }
    void Skok()
    {
        rg.velocity = Vector2.zero;
        rg.AddForce(new Vector2(0, silaskosku), ForceMode2D.Impulse);
    }
    void Catch()
    {
        collider.enabled = true;
        animator.Play("pelicanEat");
    }
    void Die()
    {
        state = State.Dead;
        rg.bodyType = RigidbodyType2D.Static;
    }
    // used with animation event
    void TunrOffCollieder()
    {
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TunrOffCollieder();
        EatenFish?.Invoke(this, other.transform);
    }
}