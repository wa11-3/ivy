using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float velFactor;
    public float amplitude;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x - (Manager.enviVelocity * velFactor),
            transform.position.y + (Mathf.Sin(transform.position.x) * amplitude), transform.position.z);
        if (transform.position.x <= -15.0f)
        {
            Destroy(gameObject);
        }
    }
}
