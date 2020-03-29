using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    public GameObject destroy;
    public Collider trigger;

    private void OnTriggerEnter(Collider other)
    {
        destroy.SetActive(false);
    }
}
