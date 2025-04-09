using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TableState {
    WAITING,
    STEP1,
    STEP2,
    STEP3,
    STEP4,
    DONE
}

public class TableRisingScript : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject pivot;
    public GameObject water;

    private TableState curState = TableState.WAITING;
    private Dictionary<TableState, System.Action> stateUpdateMethods;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        stateUpdateMethods = new()
        {
            [TableState.WAITING] = StateUpdateWaiting,
            [TableState.STEP1] = StateUpdateStep1,
            [TableState.STEP2] = StateUpdateStep2,
            [TableState.STEP3] = StateUpdateStep3,
            [TableState.STEP4] = StateUpdateStep4,
            [TableState.DONE] = StateUpdateDone
        };

        // Start checking immediately
        InvokeRepeating(nameof(CheckState), 0f, 1f);
        ChangeState(TableState.STEP1); // Begin with STEP1 immediately
    }

    void CheckState()
    {
        if (stateUpdateMethods.ContainsKey(curState))
        {
            stateUpdateMethods[curState]?.Invoke();
        }
    }

    void ChangeState(TableState newState)
    {
        if (curState != newState)
        {
            curState = newState;
        }
    }

    private void RaiseTable()
    {
        transform.position += new Vector3(0, 0.3f, 0);
        audioSource.Play();
    }

    private void StateUpdateWaiting() { }

    private void StateUpdateStep1()
    {
        float angle = pivot.transform.localRotation.z;
        if (angle > 0.25f)
        {
            RaiseTable();
            StartCoroutine(Flood());
            ChangeState(TableState.STEP2);
        }
    }

    private void StateUpdateStep2()
    {
        float angle = pivot.transform.localRotation.z;
        if (angle <= -0.12f && angle >= -0.16f)
        {
            RaiseTable();
            ChangeState(TableState.STEP3);
        }
    }

    private void StateUpdateStep3()
    {
        float angle = pivot.transform.localRotation.z;
        if (angle >= 0.12f && angle <= 0.16f)
        {
            RaiseTable();
            ChangeState(TableState.STEP4);
        }
    }

    private void StateUpdateStep4()
    {
        float angle = pivot.transform.localRotation.z;
        if (angle >= -0.02f && angle <= 0.02f)
        {
            RaiseTable();
            ChangeState(TableState.DONE);
        }
    }

    private void StateUpdateDone()
    {
        //triggers next thing
    }

    private IEnumerator Flood()
    {
        // Store the initial position of the object
        UnityEngine.Vector3 startPosition = water.transform.position;
        UnityEngine.Vector3 targetPosition = new UnityEngine.Vector3(startPosition.x, startPosition.y + 8f, startPosition.z);

        // Continue to rise the object until it reaches the target height
        while (water.transform.position.y < targetPosition.y)
        {
            water.transform.position += new UnityEngine.Vector3(0, 0.001f * Time.deltaTime, 0);
            yield return null;  // Wait for the next frame
        }

        // Ensure the object stops exactly at the target position
        water.transform.position = targetPosition;
    }
}
