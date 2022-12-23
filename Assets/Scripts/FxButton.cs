using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FxButton : MonoBehaviour
{
    public bool isOn = false;
    public bool isToggled = false;
    SpriteRenderer sr;

    
    // fx selections
    public SoundFx[] FxSelect;

    void OnMouseUpAsButton(){
        isToggled = true;
        
        
        if(isOn==true){
            isOn=false;
        }else{
            isOn=true;
        }
        
        // if an fx is turned on
        foreach(SoundFx selection in FxSelect){
            if(selection.isEnabled == true){
                if(isOn == true){
                    print(selection.Name + " turned on");
                }else{
                    print(selection.Name + " turned off");
                }
            }
        }
        
        ChangeColor();
    }

    // color changing method
    public void ChangeColor(){        
    // Sprite Renderer is what displays color
        sr = GetComponent<SpriteRenderer>();
        
        if(isOn == true){
            sr.color = Color.green;
        }else{
            sr.color = Color.black;
        }
    }
 
}
