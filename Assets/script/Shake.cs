using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shake : MonoBehaviour
{   private bool shaking = false;
    [SerializeField]
    private float ShakeAmount;
    private Vector3 originalPos; 
    // Start is called before the first frame update
    void Start()
    {
        Vector3 originalPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {   if(shaking)
    {   
        Vector3 newPos = originalPos + Random.insideUnitSphere *  ShakeAmount;
        //newPos.y = transform.position.y;
        newPos.z = transform.position.z;
        //newPos.x = transform.position.x;
        
        transform.position = newPos;
    }
    }
    public void ShakeMe()
    {
        StartCoroutine("ShakeNow");
    }
    IEnumerator ShakeNow()
    {   
        Vector3 originalPos = transform.position;
        Debug.Log("有搖起來");
        if (shaking == false)
        {
            shaking = true;
        }
        yield return new WaitForSeconds(0.17f);
        shaking = false;
        transform.position = originalPos;
    }
}
