using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxButtonSwitcher : MonoBehaviour
{
    public FxButton[] FxButtons;
    public ColorChanger cc;

    
    void Update(){
        foreach(FxButton fxb in FxButtons){
            if(fxb.isToggled == true){
                
                // singlePlayMode
                if(fxb.isOn == true){
                    TurnOffOtherButtons(fxb.tag);
                }  
                
                fxb.isToggled = false;
            }  
        }

    void TurnOffOtherButtons(string onBtnTag){
        foreach(FxButton other_fxb in FxButtons){
            if(other_fxb.tag != onBtnTag && other_fxb.isOn == true){
                other_fxb.isOn = false;
                other_fxb.ChangeColor();
                other_fxb.isToggled = true;}
            }   
        }
    }
}
