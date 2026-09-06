
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
using UnityEngine;

public class Move : MonoBehaviour {
    public Transform childTransform;

    void Start (){
        transform.position = new Vectro3(0, -1, 0);
        childTransform.localPosition = new Vector3(0, 2, 0);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));
        childTransform.localRotation = Quaternion.Euler(new Vector3(0, 60, 0));
    }

    void Update(){
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(new Vector3(0, -1, 0) * Time.deltaTaim);
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
                transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
                childTransform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime);
                childTransform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime);
            }
        }
    } 
}



/* 
[📌📝MEMO] p.469

공간과 움직임
오일러 각의 Vector3: 물체가 회전해 있는 방향을 3개의 축(X, Y, Z)을 기준으로 각도를 측정하여 표현하는 수학적 방식

*/