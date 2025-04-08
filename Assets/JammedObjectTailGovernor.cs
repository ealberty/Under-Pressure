//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine;
//using UnityEngine.XR.Interaction.Toolkit.Interactors;

//public class JammedObjectTailGovernor : MonoBehaviour
//{
//    public InteractionLayerMask Nothing;
//    private XRBaseInteractor interacted;
//    private InteractionLayerMask Broken1;


//    // Start is called before the first frame update
//    void Awake()
//    {
//        interacted = GetComponent<XRBaseInteractor>();
//        Broken1 = interacted.interactionLayers;
//    }

//    public void SetUnJammedLayer()
//    {
//        interacted.interactionLayers = Nothing;
//    }

//    public void SetJammedLayer()
//    {
//        interacted.interactionLayers = Broken1;
//    }


//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
