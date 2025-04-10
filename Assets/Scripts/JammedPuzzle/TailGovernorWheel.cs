using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GovernorWheel : MonoBehaviour
{
    public GameObject TailGovernorWheel;
    public GameObject InordinateObject;
    public JammedPuzzle puzzleThing;
    public Rigidbody brokenwheely;
    //public InteractionLayerMask JammedWheel;
    //public InteractionLayerMask BrokenWheel;

    // Start is called before the first frame update
    void Start()
    {
        //brokenwheely = GetComponent<Rigidbody>();
        //JammedWheel = TailGovernorWheel.interactionLayers;
    }

    public void Jammed2Broken(XRBaseInteractor TailGovernorWheel)
    {
        Debug.Log("This was called; state is " + puzzleThing.State);
        if (puzzleThing.TailGovernorJammed == true)
        {
            puzzleThing.TailGovernorJammed = false;
            TailGovernorWheel.interactionLayers = InteractionLayerMask.GetMask("BrokenWheel");
        }
        if (puzzleThing.State == JammedPuzzleState.BROKENJAMMED || puzzleThing.State == JammedPuzzleState.BROKENUNJAMMED)
        {
            puzzleThing.TailGovernorFixed = true;
            TailGovernorWheel.interactionLayers = InteractionLayerMask.GetMask("Fixed");

        }
        Debug.Log("state is " + puzzleThing.State + " TailGovernorFixed = " + puzzleThing.TailGovernorFixed);
    }

    void Update()
    {
        if (puzzleThing.State == JammedPuzzleState.BROKENJAMMED || puzzleThing.State == JammedPuzzleState.BROKENUNJAMMED)
        {
            brokenwheely.constraints = ~RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            brokenwheely.constraints = RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
