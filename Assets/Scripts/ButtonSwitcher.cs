using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitcher : MonoBehaviour
{
    // list of buttons in this group
    public Button[] buttons;

    // toggle singleplaymode
    public bool multiPlayMode = false;

    // empty vars for audioplayback
    public AudioManager audioManager;
    [HideInInspector]
    public string cmmd;


    void Update(){
            
        switchBoardOperate();
    }

    void switchBoardOperate(){
        foreach(Button b in buttons){
            // accessing the actual GameObject
            GameObject btnObj = b.obj;
            // Accessing the click Component of obj where all of our needed vars are stored
            buttonClick btnStatus = btnObj.GetComponent<buttonClick>();

            // if the button has just been changed
            if (btnStatus.isToggled == true)
            {   //log to console
                //print(btnObj.tag + " has been toggled. isOn = " + btnStatus.isOn);
                
                // build audio playback request - send tag and status
                buildPlaybackReq(btnObj.tag, btnStatus);

                // turn off toggled flag
                btnStatus.isToggled = false;

                if(multiPlayMode == false){
                    if(btnStatus.switcherFlag==true){
                        singlePlayMode(btnObj.tag, btnStatus, buttons);
                    }
                }
            }
        }
    }


    void buildPlaybackReq(string btnTag, buttonClick btnStatus){
        // build and send playback cmmd to audioManager.Playback() method
        string tag = btnTag;
        string instrumentTag = gameObject.tag;
        
        if(btnStatus.isOn == true){   
            cmmd = "fadeIn";
        }
        if(btnStatus.isOn == false){   
            cmmd = "fadeOut";
        }
        audioManager.Playback(instrumentTag, tag, cmmd);
    }

    void singlePlayMode(string tag, buttonClick btnStatus, Button[] buttons){
        // first, get id
        string onTag = tag;
        // re-loop through buttons to find any currently on...
        foreach(Button otherButton in buttons)
        {
            // accessing the actual GameObject
            GameObject _obj = otherButton.obj;
            // Accessing the click Component of obj
            buttonClick _btnStatus = _obj.GetComponent<buttonClick>();

            // turn off buttons that are on
            if(_obj.tag != onTag && _btnStatus.isOn == true){
                _btnStatus.isOn = false;
                _btnStatus.ChangeColor();
                _btnStatus.isToggled = true;
            }
        }
        btnStatus.switcherFlag = false;
    }


}