using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(TimedDestroy());
    }

    IEnumerator TimedDestroy()
    {
        yield return new WaitForSecondsRealtime(3f);
        Destroy(gameObject);
    }
}
