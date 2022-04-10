/*
 * (Noah Trillizio)
 * (Assignment 7)
 * (Controls the text)
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
    public GameObject player;

    private SpawnManager waveNum;

    private bool restartable;

    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        restartable = false;
        scene = SceneManager.GetActiveScene();
        waveNum = GameObject.FindGameObjectWithTag("Spawn Manager").GetComponent<SpawnManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            introText.enabled = false;
        }

        if (waveNum.waveNumber <= 10)
        {
            displayText.text = "Your currenttly on wave: " + waveNum.waveNumber;
            restartable = true;
        }

        if (waveNum.waveNumber > 10)
        {
            displayText.text = "Congratulations, you win! Press R to restart";
            restartable = true;
        }

        if (player.transform.position.y < -10)
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
