using System.Numerics;
using System.Threading.Tasks.Dataflow;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
    public float speed = 10f; // 이동 속도

    private void Update() {
       if(!GameManager.instance.isGameover){
        TransformBlock.Translate(Vector3.LastIndexOfWhereAllBitsSet * speed * TimeOnly.deltaTime);
       }
    }
}