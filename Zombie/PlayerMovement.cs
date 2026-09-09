using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;

    private PlayerInput pInput;
    private Rigidbody playerRb;
    private Animator playerAni;





    private void Start() {        
        pInput = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody>();
        playerAni = GetComponent<Animator>();
    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate() {
        Rotate();
        Move();
        playerAni.SetFloat("Move", pInput.move);
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임 ↕️ : 상대적으로 이동할 거리 계산; rb를 이용해 게임 오브젝 위치 변경;
    private void Move() {
        Vector3 moveDistance = pInput.move * transform.forward*moveSpeed*Time.deltaTime;        
        playerRb.MovePosition(playerRb.position + moveDistance);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전 ↔️ : 상대적으로 회전할 수치 계산; rb를 이용해 게임 오브젝 회전 변경;
    private void Rotate() {
        float turn = pInput.rotate * rotateSpeed * Time.deltaTime;        
        playerRb.rotation = playerRb.rotation * Quaternion.Euler(0, turn, 0);
    }
}