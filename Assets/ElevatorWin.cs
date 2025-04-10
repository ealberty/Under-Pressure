using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorWin : MonoBehaviour
{
    public void OnButtonPressed() {
        ElevatorAnimation.Instance.OnButtonPressed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
