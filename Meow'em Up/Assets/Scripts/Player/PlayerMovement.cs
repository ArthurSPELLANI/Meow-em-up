using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    

    public class PlayerMovement : MonoBehaviour
    {
        [Range(0, 10)]
        public int speed;

        Rigidbody2D rb;
        
            
    
    	void Awake()
	    {
            rb = GetComponentInParent<Rigidbody2D>();
	    }
    
        void Start()
        {
            
        }
    
        void Update()
        {
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                rb.AddForce(new Vector2(0.0f, 2.0f) * speed);
            }

            if (Input.GetAxisRaw("Vertical") == -1)
            {
                rb.AddForce(new Vector2(0.0f, -2.0f) * speed);
            }

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                rb.AddForce(new Vector2(-2.0f, 0.0f) * speed);
            }

            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                rb.AddForce(new Vector2(2.0f, 0.0f) * speed);
            }
        }
    
    
    
    }
}