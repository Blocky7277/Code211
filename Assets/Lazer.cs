using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lazer : MonoBehaviour
{
    public int interval = 3;

    public int variation = 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }


    IEnumerator Timer() {
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        yield return new WaitForSeconds(Random.Range(interval-variation, interval+variation));
        StartCoroutine(Timer());
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if(GetComponent<Renderer>().enabled) {
            obj.gameObject.GetComponent<Movement>().defeatPlayer();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
