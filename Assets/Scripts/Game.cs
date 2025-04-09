using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = GameState;

public class Game : MonoBehaviour
{
    public State State { get; private set; }
    private Dictionary<State, Action> stateEnterMethods;
    private Dictionary<State, Action> stateStayMethods;
    private float StateCount;

    public static Game Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        stateEnterMethods = new() {
            [State.IDLE] = StateEnter_Idle,
            [State.PUZZLE_1] = StateEnter_Puzzle_1,
            [State.PUZZLE_2] = StateEnter_Puzzle_2,
            [State.PUZZLE_3] = StateEnter_Puzzle_3,
            [State.PUZZLE_4_FINISHED] = StateEnter_Puzzle_4_Finished,
        };
        stateStayMethods = new() {
            [State.IDLE] = StateStay_Idle,
            [State.PUZZLE_1] = StateStay_Puzzle_1,
            [State.PUZZLE_2] = StateStay_Puzzle_2,
            [State.PUZZLE_3] = StateStay_Puzzle_3,
            [State.PUZZLE_4_FINISHED] = StateStay_Puzzle_4_Finished,
        };
        StateCount = 0;
        State = State.IDLE;
    }

    // Update is called once per frame
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

    #region State Methods
    #region State Enter Methods
    private void StateEnter_Idle() {}
    private void StateEnter_Puzzle_1() {}
    private void StateEnter_Puzzle_2() {}
    private void StateEnter_Puzzle_3() {}
    private void StateEnter_Puzzle_4_Finished() {}
    #endregion

    #region State Stay Methods
    private void StateStay_Idle() {
        if (StateCount == 0) {}
        else if (StateCount == 1)
            ChangeState(State.PUZZLE_1);
    }
    private void StateStay_Puzzle_1() {
        if (StateCount == 1) {}
        else if (StateCount == 2)
            ChangeState(State.PUZZLE_2);
    }
    private void StateStay_Puzzle_2() {
        if (StateCount == 2) {}
        else if (StateCount == 3)
            ChangeState(State.PUZZLE_3);
    }
    private void StateStay_Puzzle_3() {
        if (StateCount == 4) {}
        else if (StateCount == 3)
            ChangeState(State.PUZZLE_4);
    }
    private void StateStay_Puzzle_4_Finished() {}
    #endregion
    #endregion

    #region Functions to handle Game
    public void FinishedPuzzle()
    {
        StateCount += 1;
    }
    #endregion
}
