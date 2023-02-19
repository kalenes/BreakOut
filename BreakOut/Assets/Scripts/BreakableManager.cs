using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] states;
    public int health { get; private set; }
    public bool unbreakable;
    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (!this.unbreakable)
        {
            this.health = this.states.Length;
            this.spriteRenderer.sprite = this.states[this.health-1];
        }
    }
    private void Hit()
    {
        if (this.unbreakable)
        {
            return;
        }
        
        this.health--;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }else { 
            this.spriteRenderer.sprite = this.states[this.health-1];
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Hit();
        }
    }
}
