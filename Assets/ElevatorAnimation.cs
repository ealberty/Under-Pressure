using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAnimation : MonoBehaviour
{
    private Animator animator;
    
    public static ElevatorAnimation Instance {get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        animator.Play("Base Layer.Elevator idle");
    }

    public void elevatorenter() {
        animator.Play("Base Layer.Elevator Puzzle Finished");
    }

    public void OnButtonPressed() {
        animator.Play("Base Layer.Player in elevator game win");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
