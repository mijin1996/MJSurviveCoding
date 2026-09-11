using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ImageTracker : MonoBehaviour{
    ARTrackedImageManager manager;
    [SerializeField] List<string> listName;
    [SerializeField] List<GameObject> listAnimal;

    Dictionary<string, GameObject> dictPrefab = new();
    Dictionary<string, GameObject> dictSpawn = new();

  
    void Awake(){
        manager = FindFirstObjectByType<ARTrackedImageManager>();

        for(int i=0; i<listName.Count; i++){ 
            dictPrefab[listName[i]] = listAnimal[i];
        }
    }

    //스캔한 이미지의 0, 0, 0위치 에서 스폰해라
    //ㄴ> Instantiate때문에 부모 위치를 기준으로 캐릭터 생성하라는 의미
    void SpawnCharacter(ARTrackedImage img){
        string name = img.referenceImage.name;
        if (!dictPrefab.ContainsKey(name)) return;

        var go = Instantiate(dictPrefab[name], img.transform);
        go.transform.localPosition = Vector3.zero;

        dictSpawn[name] = go;
    }

    // 프로그램이 작동할때 설정한 이름을 찾아서 불러오도록 
    void UpdateCharacter(ARTrackedImage img){
        string name = img.referenceImage.name;

        // 이미지 이름과 연결된 프리팹이 없으면 메서드 종료
        if (!dictSpawn.ContainsKey(name)) return;

        bool active = img.trackingState == TrackingState.Tracking;
        dictSpawn[name].SetActive(active);
    }

    void HideCharacter(ARTrackedImage img){
        string name = img.referenceImage.name;
        if (dictSpawn.ContainsKey(name))
        {
            dictSpawn[name].SetActive(false);
        }
    }

    void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> args){
        foreach (var img in args.added)
            SpawnCharacter(img);

        foreach (var img in args.updated)
            UpdateCharacter(img);

        foreach (var img in args.removed)
            HideCharacter(img.Value);

    }


    void OnEnable(){
        manager.trackablesChanged.AddListener(OnChanged);
    }

    void OnDisable(){
        manager.trackablesChanged.RemoveListener(OnChanged);
    }
}



/*
foreach : 리스트 안에 있는걸 모두 다 넣어서, 하나씩 실행, 다시 전부 꺼내라
AddListener : 
RemoveListener :



*/
