using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SouthButton : MonoBehaviour{
    public static bool southSwitchHit = false;
    public void OnButtonPressed(){
        southSwitchHit = true;
        print("You hit the north button!");
    }
}
