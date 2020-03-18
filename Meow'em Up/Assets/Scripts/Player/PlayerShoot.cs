using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 1f;
    float nextFire;

    public GameObject ammo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(ammo, this.transform);

        }
    }
}
