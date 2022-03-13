using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParallax : MonoBehaviour
{  [SerializeField]private float parallaxEffectMultiplier;//2
   private Transform cameraTransform;//1
   private Vector3 lastCameraPosition;//1
   //public GameObject cam;
   private void start(){
       cameraTransform = Camera.main.transform;//1
       lastCameraPosition = cameraTransform.position;//1
       }
   private void Update() {
       Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;//1
       float parallaxEffectMultiplier = .5f;//2
       transform.position += deltaMovement*parallaxEffectMultiplier;//1//2
       lastCameraPosition = cameraTransform.position;//1
       }

    //    void FixedUpdate() {
    //    float temp = (cam.transform.position.x+(1- parallaxEffectMultiplier));
    //    float dist = (cam.transform.position.x*parallaxEffectMultiplier);
    //    }
}
