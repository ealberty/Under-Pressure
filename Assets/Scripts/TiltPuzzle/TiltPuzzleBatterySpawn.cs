using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TiltPuzzleBatterySpawn : MonoBehaviour
{ 
    public void OnButtonPressed()
    {
        TiltPuzzle.Instance.SpawnBattery();
    }
}
