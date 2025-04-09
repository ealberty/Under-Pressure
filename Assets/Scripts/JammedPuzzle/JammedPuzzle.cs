using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using State = JammedPuzzleState;

public class JammedPuzzle : MonoBehaviour
{
   public State State {get; private set;}
   public GameObject TailGovernorWheel;
   private Boolean Buffer1Jammed;
   private Boolean Buffer2Jammed;
   private Boolean TailGovernorJammed;
   private Boolean TailGovernorFixed;
   private Dictionary<State, Action> stateEnterMethods;
   private Dictionary<State, Action> stateStayMethods;

   public static JammedPuzzle Instance {get; private set; }

   void Start()
   {
       stateEnterMethods = new() {
            [State.IDLE] = StateEnter_Idle,
            [State.JAMMED] = StateEnter_Jammed,
            [State.UNJAMBUFFJAMTAIL] = StateEnter_UnjamBuffJamTail,
            [State.BROKENJAMMED] = StateEnter_BrokenJammed,
            [State.BROKENUNJAMMED] = StateEnter_BrokenUnjammed,
            [State.FIXEDJAMMED] = StateEnter_FixedJammed,
            [State.FIXED] = StateEnter_Fixed,
            [State.ERROR] = StateEnter_ERROR,
        };
        stateStayMethods = new() {
            [State.IDLE] = StateStay_Idle,
            [State.JAMMED] = StateStay_Jammed,
            [State.UNJAMBUFFJAMTAIL] = StateStay_UnjamBuffJamTail,
            [State.BROKENJAMMED] = StateStay_BrokenJammed,
            [State.FIXEDJAMMED] = StateStay_FixedJammed,
            [State.BROKENUNJAMMED] = StateStay_BrokenUnjammed,
            [State.FIXED] = StateStay_Fixed,
            [State.ERROR] = StateStay_ERROR,
        };

        Buffer1Jammed = true;
        Buffer2Jammed = true;
        TailGovernorJammed = true;
        TailGovernorFixed = false;
        State = State.IDLE;

   }

   void Update()
    {
        stateStayMethods[State]();
    }

    private void ChangeState(State newState) {
        if (State != newState) {
            State = newState;
            stateEnterMethods[newState]();
        }
    }

    private void StateEnter_Idle() {}
    private void StateEnter_Jammed() {}
    private void StateEnter_UnjamBuffJamTail() {}
    private void StateEnter_BrokenJammed() {}
    private void StateEnter_BrokenUnjammed() {}
    private void StateEnter_FixedJammed() {}
    private void StateEnter_Fixed() {}
    private void StateEnter_ERROR() {
        ChangeState(State.IDLE);
    }

    private void StateStay_Idle() {
        if (TailGovernorJammed == true) {
            if (Buffer1Jammed == false && Buffer2Jammed == false) {
                ChangeState(State.UNJAMBUFFJAMTAIL);
            }
            else {
                ChangeState(State.JAMMED);
            }
        }
        else if ((Buffer1Jammed == true && Buffer2Jammed == true)){
            ChangeState(State.BROKENJAMMED);
        }
    }
    private void StateStay_Jammed() {
        if (TailGovernorJammed == true && (Buffer1Jammed == true && Buffer2Jammed == true)) {}
        else if (Buffer1Jammed == false && Buffer2Jammed == false) {
            ChangeState(State.UNJAMBUFFJAMTAIL);
        }
        else if (TailGovernorJammed == false){
            ChangeState(State.BROKENJAMMED);
        }
        else {
            ChangeState(State.ERROR);
        }
    }
    private void StateStay_UnjamBuffJamTail() {
        if (TailGovernorJammed == true) {}
        else if (TailGovernorJammed == false) {
            ChangeState(State.BROKENUNJAMMED);
        }
        else {
            ChangeState(State.ERROR);
        }
    }
    private void StateStay_BrokenJammed() {
        if (TailGovernorJammed == false) {}
        else if (Buffer1Jammed == false && Buffer2Jammed == false) {
            ChangeState(State.BROKENUNJAMMED);
        }
        else if (TailGovernorFixed == true) {
            ChangeState(State.FIXEDJAMMED);    
        }
        else {
            ChangeState(State.ERROR);
        }
    }
    private void StateStay_BrokenUnjammed() {
        if (TailGovernorFixed == false) {}
        else if (TailGovernorFixed == true) {
            ChangeState(State.FIXED);
        }
        else {
            ChangeState(State.ERROR);
        }
    }
    private void StateStay_FixedJammed() {
        if (Buffer1Jammed == true && Buffer2Jammed == true) {}
        else if (Buffer1Jammed == false && Buffer2Jammed == false) {
            ChangeState(State.FIXED);
        }
        else {
            ChangeState(State.ERROR);
        }
    }
    private void StateStay_Fixed(){}
    private void StateStay_ERROR() {}


}
