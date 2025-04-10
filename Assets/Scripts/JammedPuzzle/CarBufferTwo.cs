using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CarBufferTwo : MonoBehaviour
{
    public GameObject CarBufferB;
    public JammedPuzzle Jampuzzle;
    //public InteractionLayerMask JammedWheel;
    //public InteractionLayerMask BrokenWheel;

    // Start is called before the first frame update
    void Start()
    {
        //brokenwheely = GetComponent<Rigidbody>();
        //JammedWheel = TailGovernorWheel.interactionLayers;
    }

    public void Jammed2FixedB(XRBaseInteractor CarBufferB)
    {
        Debug.Log("Jammed2FixedB was called; state is " + Jampuzzle.State);
        if (Jampuzzle.Buffer2Jammed == true)
        {
            Jampuzzle.Buffer2Jammed = false;
            CarBufferB.interactionLayers = InteractionLayerMask.GetMask("Fixed");
        }
        Debug.Log("state is " + Jampuzzle.State + " TailGovernorFixed = " + Jampuzzle.Buffer2Jammed);
    }

    //public void Broken2Fixed(XRBaseInteractor TailGovernorWheel, XRBaseInteractor InordinateObject)
    //{
    //    puzzleThing.TailGovernorFixed = true;
    //    TailGovernorWheel.interactionLayers = InteractionLayerMask.GetMask("Fixed");
    //    InordinateObject.interactionLayers = InteractionLayerMask.GetMask("Fixed");
    //}

    // Update is called once per frame
}
