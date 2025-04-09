using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EastButton : MonoBehaviour{
    public static bool eastSwitchHit = false;
    public void OnButtonPressed(){
        eastSwitchHit = true;
        print("You hit the north button!");
    }
}
