using UnityEngine;

public class PlatformObstacle : MonoBehaviour {
    public GameObject[] obstacles; // 장애물
    private bool stepped = false; // 플레이어 캐릭터가 밟았는가

    private void OnEnable() {
        stepped = false;

        for(int i=1; i < obstacles.Length; i++){
            if(Random.Range(0, 3) == 0){
                obstacles[i].SetActive(true);
            }
            else{
                obstacles[i].SetActive(false);
            }
        }
    }

    // 밟힘 상태여부 확인 후 점수추가
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collier.tag == "Player" && !stepped){
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}

/*
[📌📝MEMO] p.605
*/