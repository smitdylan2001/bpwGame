using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrap : MonoBehaviour
{
    public GameObject spear;
    public float maxheight;
    public float spearSpeed = 1;
    public float spearDuration = 1;
    private bool isActive = false;
    public float delay = 0.5f;
    public bool isTiming = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveTrap() 
    {
        if (isActive) { return; }
        StartCoroutine(SpearMovement());

    }

    IEnumerator SpearMovement()
    {
        isActive = true;
        yield return new WaitForSeconds(delay);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 1f / spearSpeed;
            yield return null;
            spear.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(spear.transform.localPosition.x, maxheight, spear.transform.localPosition.z), t);
        }
        yield return new WaitForSeconds(delay);
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 1f / spearSpeed;
            yield return null;
            spear.transform.localPosition = Vector3.Lerp(new Vector3(spear.transform.localPosition.x, maxheight, spear.transform.localPosition.z), Vector3.zero, t);
        }
        isActive = false;

        if (isTiming)
        {
            ActiveTrap();
        }
    }
}
