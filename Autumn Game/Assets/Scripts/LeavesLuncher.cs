using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeavesLuncher : MonoBehaviour
{
    [SerializeField] GameObject[] leaves;
    [SerializeField] float seconds = 2;
    [SerializeField] Transform[] lunchPos;


    public float maxTime = 5;
    public float minTime = 2;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    //Timer for making the game harder after time
    Timer timer;



    private void Start()
    {
        SetRandomTime();
        time = minTime;
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            if (SceneManager.GetActiveScene().name == "GameOver") //if its game over scene dont increase amount of leaves
            {
                Instantiate(leaves[Random.Range(0, leaves.Length)], lunchPos[Random.Range(0, lunchPos.Length)].transform.position, Quaternion.identity);
            }
            else
            {
                for (int i = 0; i < timer.currentTime / 10; i++) //istansiatte for 1 time between 0-10 sec, 2 times between 11-20, 3 21-30 and so on
                {
                    Instantiate(leaves[Random.Range(0, leaves.Length)], lunchPos[Random.Range(0, lunchPos.Length)].transform.position, Quaternion.identity);
                }
            }
            time = 0;
            SetRandomTime();
        }

    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
