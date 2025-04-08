using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPuzzleBatteryInSlot : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("TiltPuzzleWinBox1"))
        {
            TiltPuzzle.Instance.BatteryBoxOne();
        }
        if (collision.CompareTag("TiltPuzzleWinBox2"))
        {
            TiltPuzzle.Instance.BatteryBoxTwo();
        }
        if (collision.CompareTag("TiltPuzzleWinBox3"))
        {
            TiltPuzzle.Instance.BatteryBoxThree();
        }
    }
}
