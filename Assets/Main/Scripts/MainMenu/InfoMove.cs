using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMove : MonoBehaviour
{
    private bool isIn = false;
    public Transform[] setPoints;
    private int currentPoint;
    public float moveSpeed;

    void Start(){
        currentPoint = 0;
        isIn = false;
        transform.position = setPoints[currentPoint].position;
    }

    void Update()
    {
        if (isIn == true){
            currentPoint = 1;
            transform.position = Vector3.MoveTowards(transform.position, setPoints[currentPoint].position, moveSpeed * Time.deltaTime);
        }
        else{
            if (currentPoint == 2){
                transform.position = Vector3.MoveTowards(transform.position, setPoints[currentPoint].position, moveSpeed * Time.deltaTime);
            }
            if (transform.position == setPoints[2].position){
                currentPoint = 0;
                transform.position = setPoints[currentPoint].position;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            isIn = true;
            //#Debug.Log("Player ENter");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player"){
            isIn = false;
            //Debug.Log("Player EXIT");
            currentPoint = 2;
        }
    }/*
    void OnTriggerStay(Collider other){

        if (other.tag == "Player"){
            isIn = true;
            Debug.Log("Player STAY");
        }
    }
*/
}
