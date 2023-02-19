using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectibleItem : MonoBehaviour
{
    private GameObject gameManager;
    public float speed = 1f;
    
    private void Awake()
    { 
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    private void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.gameObject.tag == "Ball")
        {
            Destroy(this.gameObject);
            gameManager.GetComponent<GameManager>().instantBall(this.transform.position);
        }
        
    }

    

    private void Update()
    {
      transform.position -= transform.up * Time.deltaTime * speed;

    }
}
