﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    public GameObject mob;
    Quaternion rotation = Quaternion.identity;
    bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activated == true)
        {
            Instantiate(mob, transform.position, rotation);
            Destroy(this.gameObject);
        }

        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.01f, transform.position.y, transform.position.z);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        activated = true;
    }

}
