using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameManager.instance.Score = 0; 
            GameManager.instance.targetscore = 3;
            GameManager.instance.currentLevel = 0;
            GameManager.instance.Deaths++;
            
            SceneManager.LoadScene(0);
        }
    }
}
