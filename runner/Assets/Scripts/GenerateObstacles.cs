using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour
{
    public GameObject[] obstacles;

    //public AudioSource zombieFX_01;
    //public AudioSource zombieFX_02;
    public float zPos = 0;

    public bool createObstacles = false;

    public int obsNum;

    public int laneNum;

    public int twoLaneNum;

    public int containerNum;

    float yAxis;

    float xAxis;

    bool twoLane;

    bool threeLane;

    bool containerContinue;

    // Update is called once per frame
    void Update()
    {
        if (!createObstacles)
        {
            createObstacles = true;
            StartCoroutine(GenerateObs());
        }
    }

    // Coroutine - method that adds time delays
    IEnumerator GenerateObs()
    {
        obsNum = Random.Range(0, 11); // choose between 4 numbers 0-4
        Debug.Log("obsNum:");
        Debug.Log (obsNum);

        twoLane = false;

        // check for containerRamp
        if (obsNum == 0)
        {
            Debug.Log("zombie 1");
            yAxis = 3.10031f;

            //zombieFX_01.Play();
            xAxis = 2;
        }
        else if (obsNum == 1)
        {
            Debug.Log("zombie 2");
            yAxis = 3.10031f;

            // zombieFX_02.Play();
            xAxis = 2;
        }
        else if (obsNum == 2)
        {
            Debug.Log("road block");
            yAxis = 3.60036f;
            xAxis = 2;
        }
        else if (obsNum == 3)
        {
            Debug.Log("ramp");
            yAxis = 3.070364f;
            xAxis = 0.09145093f;
            containerNum = Random.Range(0, 5);
            if (containerNum == 0)
            {
                containerContinue = false;
            }
            else
            {
                containerContinue = true;
            }
        }
        else if (obsNum == 4)
        {
            Debug.Log("palet");
            yAxis = 3.50035f;
            xAxis = 2;
        }
        else if (obsNum == 5)
        {
            Debug.Log("crates");
            twoLaneNum = Random.Range(0, 2);
            yAxis = 2.965919f;
            xAxis = 3.20032f;
            twoLane = true;
        }
        else if (obsNum == 6)
        {
            Debug.Log("box");
            yAxis = 3.70037f;
        }
        else if (obsNum == 7)
        {
            Debug.Log("longRamp");
            yAxis = 3.070364f;
            xAxis = 0.09145093f;
        }
        else if (obsNum == 8)
        {
            Debug.Log("container");
            yAxis = 4.30043f;
            xAxis = 2;
        }
        else if (obsNum == 9)
        {
            Debug.Log("two Ramp");
            threeLane = true;
            yAxis = 3.070364f;
            xAxis = 0;
        }
        else if (obsNum == 10)
        {
            Debug.Log("three ramp");
            threeLane = true;
            yAxis = 3.070364f;
            xAxis = 0;
        }

        /*else
        {
            yAxis = obstacles[obsNum].transform.position.y;
            xAxis = 2;
        }*/
        // 2-lane obstacles
        if (twoLane)
        {
            if (laneNum == 0)
            {
                Instantiate(obstacles[obsNum],
                new Vector3(0.2f, yAxis, zPos),
                obstacles[obsNum].transform.rotation);
            }
            else if (laneNum == 1)
            {
                Instantiate(obstacles[obsNum],
                new Vector3(xAxis, yAxis, zPos),
                obstacles[obsNum].transform.rotation);
            }
            twoLane = false;
        }
        else if (threeLane)
        {
            Instantiate(obstacles[obsNum],
            new Vector3(xAxis, yAxis, zPos),
            obstacles[obsNum].transform.rotation);
        }
        else
        {
            laneNum = Random.Range(0, 3);

            Debug.Log("laneNum:");
            Debug.Log (laneNum);

            // left lane
            if (laneNum == 0)
            {
                Instantiate(obstacles[obsNum],
                new Vector3(-xAxis, yAxis, zPos),
                obstacles[obsNum].transform.rotation);
            }
            else if (laneNum == 1)
            {
                Instantiate(obstacles[obsNum],
                new Vector3(0, yAxis, zPos),
                obstacles[obsNum].transform.rotation);
            }
            else if (laneNum == 2)
            {
                Instantiate(obstacles[obsNum],
                new Vector3(xAxis, yAxis, zPos),
                obstacles[obsNum].transform.rotation);
            }

            /*if (containerContinue)
            {
                Debug.Log("containerContinue");
                Instantiate(obstacles[8],
                new Vector3(xAxis,
                    4.30043f,
                    zPos + 5),
                obstacles[8].transform.rotation);
            }*/
        }

        zPos += 6;
        yield return new WaitForSeconds(0.5f);
        createObstacles = false;
    }
}
