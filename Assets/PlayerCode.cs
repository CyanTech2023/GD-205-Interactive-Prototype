using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Reusing this code as the Final Game
public class PlayerCode : MonoBehaviour
{
    bool letMove = true;
    public GameObject[] enemies;

    public float speed;

    public GameManager myManager;
    //Program the player model to collect an object with the right tag and makes it stop if it hits an enemy
    void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect")
        {
            myManager.allCollectables.Remove(other.gameObject);
            Destroy(other.gameObject);
        }

        for (int i = 0; i < myManager.enemyNum; i++)
        {
            if (other.gameObject == myManager.enemies[i])
            {
                letMove = false;
                Debug.Log("Hit!");
            }
        }

    }
    //Move keys and each much have the function that makes the function of movement to a halt
    void Update()
        {
            Vector3 newPos = transform.position;

            if (Input.GetKey(KeyCode.W))
            if (letMove)
            {
                newPos.z = newPos.z + 10 * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
                if (letMove)
                {
                    newPos.z = newPos.z - 10 * Time.deltaTime;
                }

            if (Input.GetKey(KeyCode.A))
            if (letMove)
            {
                newPos.x = newPos.x - 10 * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            if (letMove)
            {
                newPos.x = newPos.x + 10 * Time.deltaTime;
            }

            transform.position = newPos;

        }
 }