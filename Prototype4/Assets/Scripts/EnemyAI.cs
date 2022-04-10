/*
 * (Noah Trillizio)
 * (Assignment 7)
 * (Controls the enemies movment)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody enemyRb;
    public GameObject player;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Add force twords the direction from the player to the enemy

        //vecotor for directive form enemy to player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        //add force towards player
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
