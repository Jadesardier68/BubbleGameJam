using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBaseRotationController : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed * Time.deltaTime);
    }
}
