using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = TiltPuzzleState;

public class TiltPuzzle : MonoBehaviour
{
    public State State { get; private set; }
    public GameObject Battery;
    public Transform BatterySpawn;
    private GameObject SpawnedBattery;
    private float BatteryCount;
    private Boolean BoxOneUsed;
    private Boolean BoxTwoUsed;
    private Boolean BoxThreeUsed;
    private Dictionary<State, Action> stateEnterMethods;
    private Dictionary<State, Action> stateStayMethods;

    public static TiltPuzzle Instance {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SpawnedBattery = Instantiate(Battery, BatterySpawn.position, Quaternion.Euler(0, 0, 90));
        stateEnterMethods = new() {
            [State.IDLE] = StateEnter_Idle,
            [State.ONE]  = StateEnter_One,
            [State.TWO] = StateEnter_Two,
            [State.THREE_FINISHED] = StateEnter_Three_Finished,
            [State.ERROR] = StateEnter_ERROR,
        };
        stateStayMethods = new() {
            [State.IDLE] = StateStay_Idle,
            [State.ONE] = StateStay_One,
            [State.TWO] = StateStay_Two,
            [State.THREE_FINISHED] = StateStay_Three_Finished,
            [State.ERROR] = StateStay_ERROR,
        };
        BatteryCount = 0;
        BoxOneUsed = false;
        BoxTwoUsed = false;
        BoxThreeUsed = false;
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

    private void StateEnter_Idle() {}
    private void StateEnter_One() {
        SoundManager.Play(SoundType.CORRECT, pitch:0.7f);
    }
    private void StateEnter_Two() {
        SoundManager.Play(SoundType.CORRECT, pitch:0.85f);
    }
    private void StateEnter_Three_Finished() {
        SoundManager.Play(SoundType.FINISHED, pitch:1.0f);
    }
    private void StateEnter_ERROR() {
        SoundManager.Play(SoundType.WRONG);
        ChangeState(State.IDLE);
    }

    private void StateStay_Idle() {
        if (BatteryCount == 0) {}
        else if (BatteryCount == 1)
            ChangeState(State.ONE);
    }
    private void StateStay_One() {
        if (BatteryCount == 1) {}
        else if (BatteryCount == 2)
            ChangeState(State.TWO);
        else
            ChangeState(State.ERROR);
    }
    private void StateStay_Two() {
        if (BatteryCount == 2) {}
        else if (BatteryCount == 3)
            ChangeState(State.THREE_FINISHED);
        else
            ChangeState(State.ERROR);
    }
    private void StateStay_Three_Finished() {
        if (SpawnedBattery != null)
            Destroy(SpawnedBattery);
    }
    private void StateStay_ERROR() {
    }

    public void BatteryBoxOne() {
        if (BatteryCount < 3)
        {
            if (BoxOneUsed == false)
            {
                BatteryCount += 1;
                BoxOneUsed = true;
            }
            else
            {
                BatteryCount = 0;
                BoxOneUsed = false;
                BoxTwoUsed = false;
                BoxThreeUsed = false;
            }
            if (SpawnedBattery != null)
            {
                Destroy(SpawnedBattery);
                SpawnedBattery = Instantiate(Battery, BatterySpawn.position, Quaternion.Euler(0, 0, 90));
            }
        }
        else
        {
            Destroy(SpawnedBattery);
        }
    }
    public void BatteryBoxTwo() {
        if (BatteryCount < 3)
        {
            if (BoxTwoUsed == false)
            {
                BatteryCount += 1;
                BoxTwoUsed = true;
            }
            else
            {
                BatteryCount = 0;
                BoxOneUsed = false;
                BoxTwoUsed = false;
                BoxThreeUsed = false;
            }
            if (SpawnedBattery != null)
            {
                Destroy(SpawnedBattery);
                SpawnedBattery = Instantiate(Battery, BatterySpawn.position, Quaternion.Euler(0, 0, 90));
            }
        }
        else
        {
            Destroy(SpawnedBattery);
        }
    }
    public void BatteryBoxThree() {
        if (BatteryCount < 3)
        {
            if (BoxThreeUsed == false)
            {
                BatteryCount += 1;
                BoxThreeUsed = true;
            }
            else
            {
                BatteryCount = 0;
                BoxOneUsed = false;
                BoxTwoUsed = false;
                BoxThreeUsed = false;
            }
            if (SpawnedBattery != null)
            {
                Destroy(SpawnedBattery);
                SpawnedBattery = Instantiate(Battery, BatterySpawn.position, Quaternion.Euler(0, 0, 90));
            }
        }
        else
        {
            Destroy(SpawnedBattery);
        }
    }
    public void SpawnBattery() 
    {
        if (BatteryCount < 3)
        {
            if (SpawnedBattery != null)
            {
                Destroy(SpawnedBattery);
                SpawnedBattery = Instantiate(Battery, BatterySpawn.position, Quaternion.Euler(0, 0, 90));
            }
        }
    }
}
