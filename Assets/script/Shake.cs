using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shake : MonoBehaviour
{   private bool shaking = false;
    public bool Targetshaking = false;
    [SerializeField]
    private float ShakeAmount;
    public float ShakeAmount2;
    private Vector3 originalPos; 
    private Vector3 originalPos2; 
    [SerializeField]
    public GameObject tokei;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        originalPos2 = Target.transform.position;
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
    if(Targetshaking){
     Vector3 newPos2 = originalPos2 + Random.insideUnitSphere *  ShakeAmount2;
     newPos2.z = Target.transform.position.z;
     Target.transform.position = newPos2;
    }
    }
    public void ShakeMe()
    {
        StartCoroutine("ShakeNow");
    }
    public void ShakeIt()
    {
        StartCoroutine("ShakeWithTimer");
    }
    IEnumerator ShakeNow()
    {   
        Vector3 originalPos = transform.position;
        
        if (shaking == false)
        {
            shaking = true;
        }
        yield return new WaitForSeconds(0.15f);
        shaking = false;
        transform.position = originalPos;
    }
    public void ShakeWithTimer()
    {   
        Vector3 originalPos2 = Target.transform.position;
        if (Targetshaking == false)
        {
            Targetshaking = true;
            
        }
        
        if(Targetshaking == false)
        {Target.transform.position = originalPos2;}
            
        
    }
}
