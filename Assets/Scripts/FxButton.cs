using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FxButton : MonoBehaviour
{
    public bool isOn = false;
    public bool isToggled = false;
    SpriteRenderer sr;
    public AudioManager audioManager;

    
    // fx selections
    public SoundFx[] FxSelect;

    void OnMouseUpAsButton(){
        // change fx button params
        isToggled = true;
        if(isOn==true){
            isOn=false;
        }else{
            isOn=true;
        }
        // build and send am req
        SendAudioManagerReq();
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

    public void SendAudioManagerReq(){
        string cmmd;
        // if an fx is enabled
        foreach(SoundFx selection in FxSelect){
            if(selection.isEnabled == true){
                string FxName = selection.Name;
                
                if(isOn == true){
                    cmmd = "fadeIn";
                }else{
                    cmmd = "fadeOut";
                }
                
                audioManager.FxChange(FxName, cmmd);
            }
        }
    }
}
