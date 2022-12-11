 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public GameObject target;
    bool hit;

    void Start(){
        target.GetComponent<MeshRenderer> ().material = material1;
        hit = false;
     }

    void OnTriggerEnter(Collider other)
    {

        if (hit == false){
            target.GetComponent<MeshRenderer> ().material = material1;
            hit = true;
        }
        else{
            target.GetComponent<MeshRenderer> ().material = material1;
            hit = false;
        }

    }
}
