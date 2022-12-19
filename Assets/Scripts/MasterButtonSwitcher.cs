using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterButtonSwitcher : MonoBehaviour
{
    public MasterButton[] masterButtons;
    
    void Update(){
        foreach(MasterButton mb in masterButtons){
            MasterButton mbStatus = mb.GetComponent<MasterButton>();
            bool mb_isOn = mbStatus.m_isOn;
            bool mb_isToggled = mbStatus.m_isToggled;
            
            if(mb_isOn == true && mb_isToggled == true){
                print(mb.tag + "Toggled On");
                string onBtnTag = mb.tag;
                TurnOffOtherButtons(onBtnTag);
                mb_isToggled = false;
            }    
        }

    void TurnOffOtherButtons(string onBtnTag){
        foreach(MasterButton other_mb in masterButtons){
            if(other_mb.tag != onBtnTag && other_mb.m_isOn == true){
                print("Turn off other btns called");
                other_mb.m_isOn = false;
                other_mb.m_isToggled = true;}
            }   
        }
    }
}
