using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;   

public class GameTimer : MonoBehaviour
{
    public float timer = 900f;
    public TextMeshPro timerText;
    public bool isRunning = true;
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable button;

    public static GameTimer Instance { get; private set; }

    void Start()
    {
        if (button != null)
        {
            button.selectEntered.AddListener(ReduceTimer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                UpdateTimerDisplay(timer);
            }
            else
            {
                timer = 0;
                isRunning = false;
                UpdateTimerDisplay(timer);
                Game.Instance.TimeOut();
            }
        }
        
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0);

        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void ReduceTimer(SelectEnterEventArgs _)
    {
        timer = 5f;
    }
}
