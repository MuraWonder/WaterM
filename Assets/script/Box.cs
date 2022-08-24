using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{   private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if(isBeingHeld == true)
        {
             Vector3 mousePos;
             mousePos = Input.mousePosition;
             mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
            this.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY,0);
        }
    }
    private void OnMouseDown() 
    {
        if(Input.GetMouseButtonDown(0))
        {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
       

        startPosX = mousePos.x - this.transform.localPosition.x;
        startPosY = mousePos.y - this.transform.localPosition.y;

         isBeingHeld = true;
        }
    }
    private void OnMouseUp() 
    {
        isBeingHeld = false;
    }
}
