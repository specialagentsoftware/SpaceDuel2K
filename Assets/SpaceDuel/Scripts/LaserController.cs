using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed = 400f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 5);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
