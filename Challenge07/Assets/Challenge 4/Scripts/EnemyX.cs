/*
 * (Noah Trillizio)
 * (Assignment 7)
 * (Controls enemies movement)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    private TextDisplay text;

    private SpawnManagerX waveNum;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectWithTag("PlayerGoal");
        text = GameObject.FindGameObjectWithTag("TextDisplay").GetComponent<TextDisplay>();
        waveNum = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (waveNum.enemyCount == 0)
        {
            speed = speed + (waveNum.waveCount);
        }
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            text.hasLost = true;
            Destroy(gameObject);
        }

    }

}
