using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxe : MonoBehaviour
{

    private float lenght, startPos;
    public GameObject backGround;
    public float parallaxEffect;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        backGround.transform.position = new Vector3(backGround.transform.position.x + speed, transform.position.y, transform.position.z);

        float temp = backGround.transform.position.x * (1 - parallaxEffect);
        float dist = (backGround.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        /*if (temp > startPos + lenght)
            startPos += lenght;
        else if (temp < startPos - lenght)
            startPos -= lenght;*/
    }
}
