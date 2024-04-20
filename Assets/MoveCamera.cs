using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position;
        GetComponent<Transform>().transform.position = new Vector3(playerTransform.x, playerTransform.y, -10);
    }
}
