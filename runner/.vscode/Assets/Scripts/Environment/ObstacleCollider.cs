using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    public GameObject player;
    void OnTriggerEnter(Collider other) {
        Debug.Log("Collided");
        player.GetComponent<Move>().enabled = false;
        player.GetComponent<Animator>().SetBool("isStumble", true);
    }
}
