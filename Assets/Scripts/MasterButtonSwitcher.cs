using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterButtonSwitcher : MonoBehaviour
{
    public MasterButton[] masterButtons;
    public ColorChanger cc;

    
    void Update(){
        foreach(MasterButton mb in masterButtons){
            if(mb.m_isToggled == true){
                // singlePlayMode for master buttons
                if(mb.m_isOn == true){
                    TurnOffOtherButtons(mb.tag);
                }  
                mb.m_isToggled = false;
            }  
        }

    void TurnOffOtherButtons(string onBtnTag){
        foreach(MasterButton other_mb in masterButtons){
            if(other_mb.tag != onBtnTag && other_mb.m_isOn == true){
                //print("Turn off other btns called");
                //print("OnBtnTag: " + onBtnTag);
                //print("Other_mb: " + other_mb);
                other_mb.m_isOn = false;
                other_mb.ChangeColor();
                other_mb.m_isToggled = true;}
            }   
        }
    }
}
