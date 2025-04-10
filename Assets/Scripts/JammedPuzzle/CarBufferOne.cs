using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CarBufferOne : MonoBehaviour
{
    public GameObject CarBufferA;
    public JammedPuzzle Jampuzzle;
    //public InteractionLayerMask JammedWheel;
    //public InteractionLayerMask BrokenWheel;

    // Start is called before the first frame update
    void Start()
    {
        //brokenwheely = GetComponent<Rigidbody>();
        //JammedWheel = TailGovernorWheel.interactionLayers;
    }

    public void Jammed2FixedA(XRBaseInteractor CarBufferA)
    {
        Debug.Log("Jammed2FixedA was called; state is " + Jampuzzle.State);
        if (Jampuzzle.Buffer1Jammed == true)
        {
            Jampuzzle.Buffer1Jammed = false;
            Jampuzzle.Buffer2Jammed = false;
            CarBufferA.interactionLayers = InteractionLayerMask.GetMask("Fixed");
        }
        Debug.Log("state is " + Jampuzzle.State + " TailGovernorFixed = " + Jampuzzle.TailGovernorFixed);
    }

    //public void Broken2Fixed(XRBaseInteractor TailGovernorWheel, XRBaseInteractor InordinateObject)
    //{
    //    puzzleThing.TailGovernorFixed = true;
    //    TailGovernorWheel.interactionLayers = InteractionLayerMask.GetMask("Fixed");
    //    InordinateObject.interactionLayers = InteractionLayerMask.GetMask("Fixed");
    //}

    // Update is called once per frame
}
