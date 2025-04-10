using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class InordinateObject : MonoBehaviour
{
    public GameObject TailGovernorWheely;
    public GameObject InordinateObjecty;
    public JammedPuzzle puzzlethang;
    public XRGrabInteractable grabble;
    private XRBaseInteractable interactable;

    void Start()
    {
        grabble = GetComponent<XRGrabInteractable>();
        interactable = GetComponent<XRBaseInteractable>();
    }

    void Update()
    {
        if (puzzlethang.State == JammedPuzzleState.FIXEDJAMMED || puzzlethang.State == JammedPuzzleState.FIXED)
        {
            interactable.interactionLayers = InteractionLayerMask.GetMask("Fixed");
        }
        else
        {
            grabble.enabled = true;
        }
    }

}