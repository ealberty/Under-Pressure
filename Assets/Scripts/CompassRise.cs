using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CompassRise : MonoBehaviour{
    public  void raiseTheCompass(){
        transform.position += new Vector3(0, 0.09f, 0);
    }
 
}
