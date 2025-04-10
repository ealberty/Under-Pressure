using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOneOpen : MonoBehaviour
{
    private Animator animator;

    public static DoorOneOpen Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        animator.Play("Base Layer.Door Idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor() {
        animator.Play("Base Layer.Door Close");
    }
}
