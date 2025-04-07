using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = LeverPuzzleState;

public class puzzle_main : MonoBehaviour {
    public State State { get; private set; }
    private Levers lastLever;

    void Start() {
        lastLever = Levers.NONE;
        State = State.IDLE;
    }

    void Update(){
        if (lastLever == Levers.NONE){
            return;
        }
        switch(State){
            case State.IDLE:
                if (lastLever == Levers.SOUTH)
                    ChangeState(State._1_SOUTH);
                else
                    ChangeState(State.ERROR);
                break;
            case State._1_SOUTH:
                if (lastLever == Levers.EAST)
                    ChangeState(State._2_EAST);
                else
                    ChangeState(State.ERROR);
                break;
            case State._2_EAST:
                if (lastLever == Levers.WEST)
                    ChangeState(State._3_WEST);
                else
                    ChangeState(State.ERROR);
                break;
            case State._3_WEST:
                if (lastLever == Levers.NORTH)
                    ChangeState(State._4_NORTH_FINISHED);
                else
                    ChangeState(State.ERROR);
                break;
            case State.ERROR:
                ChangeState(State.IDLE);
                break;
        }
    }
    private void ChangeState(State newState){
        print($"Changing state to {newState}");
        if (State != newState){
            State = newState;
            switch (newState){
                case State.IDLE:
                    break;
                case State._1_SOUTH:
                    LeverSoundManager.Play(SoundType.CORRECT);
                    break;
                case State._2_EAST:
                    LeverSoundManager.Play(SoundType.CORRECT);
                    break;
                case State._3_WEST:
                    LeverSoundManager.Play(SoundType.CORRECT);
                    break;
                case State._4_NORTH_FINISHED:
                    LeverSoundManager.Play(SoundType.FINISHED);
                    break;
                case State.ERROR:
                    LeverSoundManager.Play(SoundType.WRONG);
                    ChangeState(State.IDLE);
                    break;
            }
        }
    }

    public void Press(Levers lever){
        print("PULL THE LEVER KRONK! " + lever);
        print ("WRONG LEVER!");
        lastLever = lever;
    }
}