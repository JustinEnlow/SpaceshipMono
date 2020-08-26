/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatingOrigin : MonoBehaviour{
    public float distanceToRecenter = 10f;
    Scene scene;

    void FixedUpdate(){
        scene = SceneManager.GetActiveScene();
        if(transform.position.magnitude > distanceToRecenter){
            foreach(GameObject go in scene.GetRootGameObjects()){
                go.transform.position -= transform.position;
            }
            transform.position -= transform.position;
        }
    }
}