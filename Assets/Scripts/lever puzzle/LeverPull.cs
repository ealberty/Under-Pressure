// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class LeverPull : MonoBehaviour{
//     public Levers lever;
//     public puzzle_main puzzle;
//     private Image img;
//     private float initAlpha;
//     // Start is called before the first frame update
//     void Start(){
//         img = GetComponent<Image>();
//         initAlpha = img.lever.a;
//     }

//     // Update is called once per frame
//     void Update(){
//         if (img.lever.a > initAlpha){
//             Levers l = img.lever;
//             l.a -= 1.0f * Time.deltaTime;
//             img.lever = l;
//         }
//     }

//     public void Switch(){
//         if (puzzle.State != LeverPuzzleState._4_NORTH_FINISHED){
//             print ("KRONK PULLED THIS LEVER: " + lever);
//             Levers l = img.lever;
//             l.a = 1.0f; 
//             img.lever = l;
//             puzzle.Switch(lever);
//         }
//     }
// }
