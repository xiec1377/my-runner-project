using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource collectFX;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        collectFX.Play();
        CoinDisplay.coinCount++;
        this.gameObject.SetActive(false);
        
    }
}
