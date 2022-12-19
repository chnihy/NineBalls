using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonClick : MonoBehaviour
{   
    public bool isOn = false;
    public bool isToggled = false;
    public bool switcherFlag = false;
    SpriteRenderer sr;

    
    // color changing method
    public void ChangeColor(){        
        // Sprite Renderer is what displays color
        sr = GetComponent<SpriteRenderer>();
        
        if(isOn == true){
            sr.color = Color.red;
        }else{
            sr.color = Color.black;
        }
    }

    void OnMouseUpAsButton(){
        // update on/off status & isToggled status
        isToggled = true;
        if(isOn == false){
            isOn = true;
            switcherFlag = true;
        }else{
            isOn = false;
        }
        
        // update color
        ChangeColor();
    }
}
