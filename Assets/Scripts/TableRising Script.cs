using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool enableTable = false;

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

        
    }

    void Update()
    {
        if (enableTable){
            // Start checking immediately
            InvokeRepeating(nameof(CheckState), 0f, 1f);
            ChangeState(TableState.STEP1); // Begin with STEP1 immediately
            enableTable = false;
        }
    }

    // This runs once per second so that players dont accidentally get the puzzle right
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

    // Raises the table a foot after completing each step
    private void RaiseTable()
    {
        transform.position += new Vector3(0, 0.3f, 0);
        audioSource.Play();
    }

    // Nothing is happening
    private void StateUpdateWaiting() { }

    // Waiting for the first condition to be met (30 degree angle), when it is the flood starts and we move on
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

    // Waiting for the second condition (-15 degree angle)
    private void StateUpdateStep2()
    {
        float angle = pivot.transform.localRotation.z;
        if (angle <= -0.12f && angle >= -0.16f)
        {
            RaiseTable();
            ChangeState(TableState.STEP3);
        }
    }

    //  Waiting for the third condition (15 degree angle) 
    private void StateUpdateStep3()
    {
        float angle = pivot.transform.localRotation.z;
        if (angle >= 0.12f && angle <= 0.16f)
        {
            RaiseTable();
            ChangeState(TableState.STEP4);
        }
    }

    // Waiting for the fourth condition to be met (0 degree angle) at which point the puzzle is complete
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
        Game.Instance.FinishedPuzzle();
    }

    private IEnumerator Flood()
    {
        // Store the initial position of the object
        UnityEngine.Vector3 startPosition = water.transform.position;
        UnityEngine.Vector3 targetPosition = new UnityEngine.Vector3(startPosition.x, startPosition.y + 8f, startPosition.z);

        
        // Continue to rise the object until it reaches the target height
        while (water.transform.position.y < 0.45f)
        {
            Debug.Log(water.transform.position);
            water.transform.position += new UnityEngine.Vector3(0, 0.003f * Time.deltaTime, 0);
            yield return null;  // Wait for the next frame
        }

        failState();
    }

    public void failState(){
        SceneManager.LoadScene("Game Over Scene");
    }
}
