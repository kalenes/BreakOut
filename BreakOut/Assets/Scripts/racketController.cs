using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racketController : MonoBehaviour
{
    public float limitx = 2.1f;
    public float speed= 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move(){
        var input = Input.GetAxis("Mouse X");
        var position = transform.position;
        if (Input.touchCount > 0)
        {
            position.x = Input.touches[0].deltaPosition.x* Time.deltaTime*0.1f;
            transform.Translate(position.x ,0,0);
        }
        else
        {
            position.x += input * speed *Time.deltaTime;
            position.x = Mathf.Clamp(position.x,-limitx,+limitx);
            transform.position = position;
        }
        

        

        
    }
}
