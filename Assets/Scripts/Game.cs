using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using State = GameState;

public class Game : MonoBehaviour
{
    public State State { get; private set; }
    private Dictionary<State, Action> stateEnterMethods;
    private Dictionary<State, Action> stateStayMethods;
    private float StateCount;
    public GameObject Table;
    public GameObject FailParticles;

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
            [State.FAIL] = StateEnter_Fail,
        };
        stateStayMethods = new() {
            [State.IDLE] = StateStay_Idle,
            [State.PUZZLE_1] = StateStay_Puzzle_1,
            [State.PUZZLE_2] = StateStay_Puzzle_2,
            [State.PUZZLE_3] = StateStay_Puzzle_3,
            [State.PUZZLE_4_FINISHED] = StateStay_Puzzle_4_Finished,
            [State.FAIL] = StateStay_Fail,
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
    private void StateEnter_Puzzle_1() {
        DoorOneOpen.Instance.OpenDoor();
        Table.GetComponent<TableRisingScript>().enableTable = true;
    }
    private void StateEnter_Puzzle_2() {}
    private void StateEnter_Puzzle_3() {
        DoorTwoOpen.Instance.OpenDoor();
    }
    private void StateEnter_Puzzle_4_Finished() {}
    private void StateEnter_Fail() {
        FailParticles.SetActive(true);
        Invoke("GameOver", 7f);
    }
    #endregion

    #region State Stay Methods
    private void StateStay_Idle() {
        if (StateCount == 0) {}
        else if (StateCount == 1)
            ChangeState(State.PUZZLE_1);
        else if (StateCount == -1)
            ChangeState(State.FAIL);
    }
    private void StateStay_Puzzle_1() {
        if (StateCount == 1) {}
        else if (StateCount == 2)
            ChangeState(State.PUZZLE_2);
        else if (StateCount == -1)
            ChangeState(State.FAIL);
    }
    private void StateStay_Puzzle_2() {
        if (StateCount == 2) {}
        else if (StateCount == 3)
            ChangeState(State.PUZZLE_3);
        else if (StateCount == -1)
            ChangeState(State.FAIL);
    }
    private void StateStay_Puzzle_3() {
        if (StateCount == 4) {}
        else if (StateCount == 3)
            ChangeState(State.PUZZLE_4_FINISHED);
        else if (StateCount == -1)
            ChangeState(State.FAIL);
    }
    private void StateStay_Puzzle_4_Finished() {}
    private void StateStay_Fail() {}
    #endregion
    #endregion

    #region Functions to handle Game
    public void FinishedPuzzle()
    {
        StateCount += 1;
    }
    public void TimeOut()
    {
        StateCount = -1;
    }
    public void GameOver()
    {
        SceneManager.LoadScene("Game Over Scene");
    }
    #endregion
}
