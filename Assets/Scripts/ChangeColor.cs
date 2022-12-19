using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorChanger
{
    // color changing method
    public void ChangeColor(SpriteRenderer sr, 
                            bool isOn){
        
        Color onColor = Color.red;
        Color offColor = Color.black;

        // Sprite Renderer is what displays color
        if(isOn == true){
            sr.color = onColor;
        }else{
            sr.color = offColor;
        }
    }



}
