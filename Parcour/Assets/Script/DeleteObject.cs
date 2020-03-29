using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    public GameObject destroy;
    public Collider trigger;
    void Start()
    {
        
    }

    // Update is called once per frame
  

    private void OnTriggerEnter(Collider other)
    {
        destroy.SetActive(false);
    }
}
