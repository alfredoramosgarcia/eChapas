using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccerPlayer : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Balon")){
            GetComponent<Animator>().SetTrigger("shoot");
        }
    }

}
