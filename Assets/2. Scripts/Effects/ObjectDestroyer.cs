using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    // Start is called before the first frame update

    public float secondsToDestroy;
    void Start()
    {
        Destroy(gameObject, secondsToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
