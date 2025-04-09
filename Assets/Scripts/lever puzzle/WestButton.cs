using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WestButton : MonoBehaviour{
    public static bool westSwitchHit = false;
    public void OnButtonPressed(){
        westSwitchHit = true;
        print("You hit the west button!");
    }

    public static void clear(){
        westSwitchHit = false;
    }
}
