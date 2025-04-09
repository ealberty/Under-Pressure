using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = LeverPuzzleState;

public class puzzle_main : MonoBehaviour {
    public State State { get; private set; }
    private Levers northLever;
    private Levers southLever;
    private Levers eastLever;
    private Levers westLever;
    bool north = false;
    bool south = false;
    bool east = false;
    bool west = false;

    void Start() {
        northLever = Levers.NONE;
        southLever = Levers.NONE;
        eastLever = Levers.NONE;
        westLever = Levers.NONE;
        State = State.IDLE;
    }

    void Update(){
        north = NorthButton.northSwitchHit;
        south = SouthButton.southSwitchHit;
        east = EastButton.eastSwitchHit;
        west = WestButton.westSwitchHit;
        if (north){
            northLever = Levers.NORTH;
            north = false;
        }
        else if (south){
            southLever = Levers.SOUTH;
        }
        else if (west){
            westLever = Levers.WEST;
        }
        else if (east){
            eastLever = Levers.EAST;
        }
        else{
            return;
        }

        switch(State){
            case State.IDLE:
                if (southLever == Levers.SOUTH){
                    ChangeState(State._1_SOUTH);
                    break;
                }
                else{
                    ChangeState(State.ERROR);
                    break;
                }
            case State._1_SOUTH:
                if (eastLever == Levers.EAST && southLever == Levers.SOUTH){
                    ChangeState(State._2_EAST);
                    break;
                }
                else{
                    ChangeState(State.ERROR);
                    break;
                }
            case State._2_EAST:
                if (westLever == Levers.WEST){
                    ChangeState(State._3_WEST);
                    break;
                }
                else{
                    ChangeState(State.ERROR);
                    break;
                }
            case State._3_WEST:
                if (northLever == Levers.NORTH){
                    ChangeState(State._4_NORTH_FINISHED);
                    break;
                }
                else {
                    ChangeState(State.ERROR);
                    break;
                }
            case State.ERROR:
                northLever = Levers.NONE;
                southLever = Levers.NONE;
                eastLever = Levers.NONE;
                westLever = Levers.NONE;
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
                    SoundManager.Play(SoundType.CORRECT);
                    break;
                case State._2_EAST:
                    SoundManager.Play(SoundType.CORRECT);
                    break;
                case State._3_WEST:
                    SoundManager.Play(SoundType.CORRECT);
                    break;
                case State._4_NORTH_FINISHED:
                    SoundManager.Play(SoundType.FINISHED);
                    break;
                case State.ERROR:
                    SoundManager.Play(SoundType.WRONG);
                    ChangeState(State.IDLE);
                    break;
            }
        }
    }
}