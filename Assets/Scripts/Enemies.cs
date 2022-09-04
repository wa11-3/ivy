using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x - (Manager.enviVelocity), transform.position.y, transform.position.z);
    }
}
