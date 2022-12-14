using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceScore : MonoBehaviour
{
    public GameObject distanceDisplay;
    public int distance;
    public bool addDistance;
    
    // Update is called once per frame
    void Update()
    {
        if (!addDistance) {
            addDistance = true;
            StartCoroutine(AddingDistance());
        }
    }

    IEnumerator AddingDistance() {
        distance++; 
        Debug.Log("distance:");
        Debug.Log(distance);
        distanceDisplay.GetComponent<Text>().text = "" + distance;
        yield return new WaitForSeconds(0.25f);
        addDistance = false;
    }
}
