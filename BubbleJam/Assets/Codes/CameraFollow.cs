using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 direction;  

    // Start is called before the first frame update
    void Start()
    {
      direction = new Vector3(1.6f,1.6f,-10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = direction + player.transform.position;
    }
}
