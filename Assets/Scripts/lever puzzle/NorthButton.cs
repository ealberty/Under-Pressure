using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NorthButton : MonoBehaviour{
    public static bool northSwitchHit = false;
    public void OnButtonPressed(){
        northSwitchHit = true;
        print("You hit the west button!");
    }
    public void OnButtonReleased(){
        northSwitchHit = false;
        print("Released the button!");
    }
}
