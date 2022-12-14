using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCoin : MonoBehaviour
{
    public GameObject coins;

    //public AudioSource zombieFX_01;
    //public AudioSource zombieFX_02;
    public float zPos = 0;

    public bool createCoins = false;

    public int laneNum;

    float yAxis;

    float xAxis;

    // Update is called once per frame
    void Update()
    {
        if (!createCoins)
        {
            createCoins = true;
            StartCoroutine(GenerateCoins());
        }
    }

    // Coroutine - method that adds time delays
    IEnumerator GenerateCoins()
    {
        laneNum = Random.Range(0, 3);
        Debug.Log("laneNum:");
        Debug.Log (laneNum);

        if (laneNum == 0)
        {
            xAxis = 2;
        }
        else if (laneNum == 1)
        {
            xAxis = 0;
        }
        else
        {
            xAxis = -2;
        }

        Instantiate(coins,
        new Vector3(xAxis, 3.5f, zPos),
        coins.transform.rotation);
        zPos += 3;
        yield return new WaitForSeconds(0.1f);
        createCoins = false;
    }
}
