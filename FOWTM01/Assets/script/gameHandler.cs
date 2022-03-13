using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameHandler : MonoBehaviour
{
    public Camfollow camfollow;
    public Transform playerTransform;
    private void Start()
    {
        camfollow.Setup(()=>playerTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
