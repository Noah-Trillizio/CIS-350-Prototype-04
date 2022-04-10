/*
 * (Noah Trillizio)
 * (Assignment 7)
 * (Controls the text display)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public Text displayText;
    public Text introText;

    public bool hasLost;

    private SpawnManagerX waveNum;

    private bool restartable;

    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        hasLost = false;
        restartable = false;
        scene = SceneManager.GetActiveScene();
        waveNum = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            introText.enabled = false;
        }

        if (waveNum.waveCount - 1 <= 10)
        {
            displayText.text = "Your currenttly on wave: " + (waveNum.waveCount - 1);
            restartable = true;
        }

        if (waveNum.waveCount - 1 > 10)
        {
            displayText.text = "Congratulations, you win! Press R to restart";
            restartable = true;
        }

        if (hasLost == true)
        {
            displayText.text = "You loss, press R to restart";
            restartable = true;
        }

        if (restartable == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
