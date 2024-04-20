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
            Physics2D.gravity = new Vector2(0, 20);
        }
    }
}
