public class ButtonHover : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerClickHandler  {

    public AudioClip clickSfx;
    protected Vector3 originalSize;
    [SerializeField] protected float buttonScale = 1.1f;    
    [SerializeField] protected float clickDelay = 0.3f;

    

    protected virtual void Start() {
        originalSize = transform.localScale;
    }

    // 마우스가 버튼 가까이 => 버튼 커짐
    public virtual void OnPointerEnter(PointerEventData eventData) {
        transform.localScale = originalSize * buttonScale;
    }

    // 마우스가 멀리 가면 => 버튼 크기 원상복구
    public virtual void OnPointerExit(PointerEventData eventData) {
        transform.localScale = originalSize;
    }

    // 버튼클릭 => 소리재생 => 대기 => Click() 실행
    public virtual void OnPointerClick(PointerEventData eventData) {
        StartCoroutine(ClickRoutine());
    }

    // 
    private IEnumerator ClickRoutine() {
        PlayClickSound();
        yield return new WaitForSecondsRealtime(clickDelay);
        Click();
    }

    protected virtual void Click() {
    }

    protected void PlayClickSound() {
        if (clickSfx != null && Camera.main != null) {
            AudioSource.PlayClipAtPoint(
                clickSfx,
                Camera.main.transform.position
            );
        }
    }
}

/*
protected : 나 자신 + 나를 상속받은 자식만 사용 가능
Coroutine : 시작은 같이 하나 중간에 기다렸다가 나머지 실행
    ㄴasync-await와 비슷

Interface  : 구현해야할 약속
virtual : 자식이 부모메서드 재정의가능


-Polymorphism : 큰틀 => 상속받은 자식이 구현을
*/
