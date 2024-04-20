using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Lazer : MonoBehaviour
{

    public int interval = 3;
    public int variation = 2;

    void Start() {
        StartCoroutine(Timer());
    }
    void OnTriggerEnter2D(Collider2D obj) {
        if(obj.gameObject.tag == "Player" && GetComponent<Renderer>().enabled) {
            obj.gameObject.GetComponent<Movement>().defeatPlayer();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator Timer() {
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        float num = Random.Range(interval-2, interval+3);
        yield return new WaitForSeconds(num);
        StartCoroutine(Timer());
    }
}
