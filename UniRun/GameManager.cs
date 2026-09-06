using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour{
    public static GameManager instance;
    public bool isGameover = false;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;

    private int score = 0;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else {
            Debug.LogWarning("씬에 두개 이상의 GameManager 존재");
            Destroy(gameObject);
            }
    }    

    void Update(){
        if(isGameover && Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(SceneManager.GetActivaScene().name);
        }
    }

    public void AddScore(int newScore){
        if(!isGameover){
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    } 

    public void OnPlayerDead(){
        isGameover = true;
        gameOverUI.SetActive(true);
    }
}


/*
 [📌📝MEMO] p.588
*/