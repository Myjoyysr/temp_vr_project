using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void EnterScene(string level){
        SceneManager.LoadScene(level);
    }
    public void DeleteInfo0Canvas(){
        //Destroy (transform.gameObject.GetComponentInParent<Canvas>().gameObject);
        Destroy (GameObject.Find ("Info 0"));
    }
    public void QuitApp(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();        
        #endif

    }
}
