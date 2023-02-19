using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    [SerializeField]private float speed = 10f; 
    private Rigidbody2D _rigidbody2D;
    public GameObject gameManager;
    public AudioSource sound;

    void Awake()
    {
       _rigidbody2D = GetComponent<Rigidbody2D>();
       gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        if (gameManager.GetComponent<GameManager>().balls.Length >= 1)
        {
            
            var random = Random.value > .5f ? 1 : -1;   
            var force = new Vector2(random,+1);
            _rigidbody2D.AddForce(force.normalized*speed);
        }
        else
        {
            var random = Random.value > .5f ? 1 : -1;   
            var force = new Vector2(random,-1);
            _rigidbody2D.AddForce(force.normalized*speed);  
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "Star" )
        {
            sound.Play();
        }
    }
}
