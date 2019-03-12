using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject itemObject;

    float delay = 1;
    float counter = 1;

    void Start()
    {
        
    }

    void Update()
    {
        counter += Time.deltaTime;

        if (Input.GetKey(KeyCode.Alpha9) && counter > delay)
        {
            counter = 0;
            Item i= new Item(Random.Range(0, 5), 1, new Vector2((float)((int)Random.Range(0, 40)) +0.5f, (float)((int)Random.Range(0, 40)) + 0.5f));
            if (delay > 0.2f)
            {
                delay -= 0.4f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Alpha9))
        {
            delay = 1;
        }
    }
}
