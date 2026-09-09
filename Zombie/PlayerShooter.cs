using UnityEngine;

// 주어진 Gun 오브젝트를 쏘거나 재장전
// 알맞은 애니메이션을 재생하고 IK를 사용해 캐릭터 양손이 총에 위치하도록 조정
public class PlayerShooter : MonoBehaviour {
    public Gun gun;
    public Transform gunPivot; 
    public Transform leftHandMount;
    public Transform rightHandMount;
    private PlayerInput playerInput;
    private Animator playerAni;





    private void Start(){
        playerInput = GetComponent<PlayerInput>();
        playerAni = GetComponent<Animator>();
    }

    private void OnEnable(){
        // 슈터가 활성화될 때 총도 함께 활성화
        gun.gameObject.SetActive(true);
    }
    
    private void OnDisable(){
        gun.gameObject.SetActive(false);
    }

    private void Update(){
        // 입력을 감지하고 총 발사하거나 재장전
        if (playerInput.fire){
            gun.Fire();
        }
        else if (playerInput.reload){
            if (gun.Reload()){
                playerAni.SetTrigger("Reload");
            }
        }
        UpdataUI();
    }

    // 탄약 UI 갱신
    private void UpdataUI(){
        if (gun != null && UIManager.instance != null){
            // UI 매니저의 탄약 텍스트에 탄창의 탄약과 남은 전체 탄약을 표시
            UIManager.instance.UpdateAmmoText(gun.magAmmo, gun.ammoRemain);
        }
    }

    // 애니메이터의 IK 갱신
    private void OnAnimatorIK(int layerIndex) {
        gunPivot.position = playerAni.GetIKHintPosition(AvatarIKHint.RightElbow);

        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);

        playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandMount.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandMount.rotation);

        playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        
        playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount.rotation);
    }
}


/*
 [📌📝MEMO] p.784
Mount: 장착이라는 의미


*/