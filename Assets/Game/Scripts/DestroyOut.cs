using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOut : MonoBehaviour
{
    // Start is called before the first frame update

    private float topOfScene = 100.0f;
    private float bottomOfScene = -10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topOfScene)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomOfScene)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > topOfScene)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < bottomOfScene)
        {
            Destroy(gameObject);
        }



    }
}

