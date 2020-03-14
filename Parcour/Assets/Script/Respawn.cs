using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    
    public GameObject player;
    public Transform SpawnPoint;

    void OnCollisionEnter()
    {
        player.transform.position = SpawnPoint.transform.position;
    }
}
