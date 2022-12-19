using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterButton : MonoBehaviour
{
    public Button[] buttonRow;
    public bool m_isOn = false;
    public bool m_isToggled = false;
    [HideInInspector]
    public ColorChanger cc;

    void OnMouseUpAsButton(){
        foreach(Button b in buttonRow){
            // accessing needed vars in obj
            GameObject btnObj = b.obj;
            buttonClick btnStatus = b.obj.GetComponent<buttonClick>();
            
            // on/off
            if(m_isOn == true){
                btnStatus.isOn = false;
            }
            else if(m_isOn == false){
                btnStatus.isOn = true;
            }
            btnStatus.isToggled = true;
            
            // for multiplay mode - leaving on for default
            btnStatus.switcherFlag = true;
            SpriteRenderer sr = b.obj.GetComponent<SpriteRenderer>();
            cc.ChangeColor(sr, btnStatus.isOn);

            
        }
        if(m_isOn == true){
            m_isOn = false;
        }else{
            m_isOn = true;
        }
        
        m_isToggled = true;
        SpriteRenderer m_sr = GetComponent<SpriteRenderer>();
        cc.ChangeColor(m_sr, m_isOn);

    }

}