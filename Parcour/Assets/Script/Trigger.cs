using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent onTrigger;

    public void OnTriggerEnter(Collider other)
    {
        if (onTrigger != null)
        {
            onTrigger.Invoke();
        }
    }
}
