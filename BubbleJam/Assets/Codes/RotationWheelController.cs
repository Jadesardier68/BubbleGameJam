using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWheelController : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform baseObject;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.RotateAround(baseObject.position, Vector3.back, rotationSpeed * Time.deltaTime);
    }
}
