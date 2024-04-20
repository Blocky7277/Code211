using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlipper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if (Input.GetKeyDown(KeyCode.Q)){
            GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
        if (Input.GetKeyDown(KeyCode.E)){
            GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
    }
}
