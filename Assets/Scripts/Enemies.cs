using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float velFactor;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x - (Manager.enviVelocity * velFactor),
            transform.position.y, transform.position.z);

        if (transform.position.x <= -15.0f)
        {
            Destroy(gameObject);
        }
    }
}
