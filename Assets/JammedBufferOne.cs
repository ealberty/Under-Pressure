using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class JammedBufferOne : MonoBehaviour
{
    public InteractionLayerMask Nothing;
    private XRBaseInteractor interacted;
    private InteractionLayerMask Broken3;


    // Start is called before the first frame update
    void Awake()
    {
        interacted = GetComponent<XRBaseInteractor>();
        Broken3 = interacted.interactionLayers;
    }

    public void SetUnJammedLayer()
    {
        interacted.interactionLayers = Nothing;
    }

    public void SetJammedLayer()
    {
        interacted.interactionLayers = Broken3;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
