using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterButton : MonoBehaviour
{
    public Button[] buttonRow;
    public bool m_isOn = false;
    public bool m_isToggled = false;
    SpriteRenderer sr;

    void OnMouseUpAsButton(){
        m_isToggled = true;
        

        // master button controls
        if(m_isOn == true){
            m_isOn = false;
        }else{
            m_isOn = true;}
        
        ChangeColor();
        
        // Button row controls
        MasterButtonAction();
        
    }


    // color changing method
    public void ChangeColor(){        
        // Sprite Renderer is what displays color
        sr = GetComponent<SpriteRenderer>();
        
        if(m_isOn == true){
            sr.color = Color.red;
        }else{
            sr.color = Color.black;
        }
    }


    public void MasterButtonAction(){
        // button row controls
        foreach(Button b in buttonRow){
            // accessing needed vars in obj
            GameObject btnObj = b.obj;
            buttonClick btnStatus = b.obj.GetComponent<buttonClick>();
            
            // on/off
            if(m_isOn == false){
                btnStatus.isOn = false;
                }
            else if(m_isOn == true){
                btnStatus.isOn = true;
                }
            
            btnStatus.isToggled = true;
            
            // for singlePlayMode - leaving on for default
            btnStatus.switcherFlag = true;
            btnStatus.ChangeColor();
            }
    }
}