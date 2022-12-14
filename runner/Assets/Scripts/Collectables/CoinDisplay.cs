using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public GameObject coin;

    public static int coinCount;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hi");
        coin.GetComponent<Text>().text = "" + coinCount;
    }
}
