using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverPull : MonoBehaviour{
    public Levers lever;
    public puzzle_main puzzle;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
    }

    public void Switch(){
        if (puzzle.State != LeverPuzzleState._4_NORTH_FINISHED){
            print ("KRONK PULLED THIS LEVER: " + lever);
            puzzle.Switch(lever);
        }
    }
}
