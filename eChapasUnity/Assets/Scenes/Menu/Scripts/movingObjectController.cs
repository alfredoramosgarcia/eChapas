using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObjectController : MonoBehaviour
{   
    private void Awake(){
        var dontDestroy = FindObjectsOfType<movingObjectController>();
        if(dontDestroy.Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
