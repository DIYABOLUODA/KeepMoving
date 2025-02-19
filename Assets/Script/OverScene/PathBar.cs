
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PathBar : MonoBehaviour
{
  [SerializeField] Image pathFill;
    [SerializeField] GameObject Player;
    PathMove pathMove;
    float currentFillAmount;
    float CurrentFillAmount{
        get=>currentFillAmount;
        set=>currentFillAmount= Mathf.Clamp01(value);
        
    }
    float targetFillAmount;

    float TargetFillAmount{
        get => targetFillAmount;
        set=>targetFillAmount= Mathf.Clamp01(value);
    }
    [SerializeField] float maxFillValue;
    Coroutine pathFillCoroutine;
    float t;
   [SerializeField] float fillSpeed;
    private void Awake() {
        Initialize(0,maxFillValue);
        pathMove=Player.GetComponent<PathMove>();
    }

    private void Start() {
        //Debug.Log(ScoreManager.Instance.GetPathScore()+"啊？出啥问题捏");
        UpdateStar(ScoreManager.Instance.GetPathScore(),maxFillValue);
    }
  public void Initialize(float currentFillValue,float maxFillValue){
        CurrentFillAmount=currentFillValue/maxFillValue;
        TargetFillAmount=CurrentFillAmount;
        pathFill.fillAmount=CurrentFillAmount;
  }

  public void UpdateStar(float currentFillValue,float maxFillValue){
    TargetFillAmount=currentFillValue/maxFillValue;
   // Debug.Log(targetFillAmount+"啊？咋辉石捏");
    if(pathFillCoroutine!=null){
            StopCoroutine(pathFillCoroutine);
    }
    if(CurrentFillAmount<TargetFillAmount){
        pathFillCoroutine=StartCoroutine(PathFillCoroutine(pathFill));
    }
  }

 IEnumerator PathFillCoroutine(Image pathFill)
{
    float t = 0f;
    float initialFillAmount = CurrentFillAmount;  // 记录初始填充量
    Vector3 initialPosition = Player.transform.position;  // 记录初始位置

    while (t < 1f)
    {
        t += Time.fixedDeltaTime * fillSpeed;

     
        CurrentFillAmount = Mathf.Lerp(initialFillAmount, TargetFillAmount, Mathf.Clamp01(t));
        pathFill.fillAmount = CurrentFillAmount;

       
        float targetPositionX = initialPosition.x + pathMove.TargetPos(TargetFillAmount);
        float moveDistance = Mathf.Lerp(initialPosition.x, targetPositionX, Mathf.Clamp01(t));
        Player.transform.position = new Vector3(moveDistance, Player.transform.position.y, Player.transform.position.z);

        yield return null;
    }

    CurrentFillAmount = TargetFillAmount;
    pathFill.fillAmount = TargetFillAmount;
    Player.transform.position = new Vector3(initialPosition.x + pathMove.TargetPos(TargetFillAmount), Player.transform.position.y, Player.transform.position.z);
    Animator animator= Player.GetComponent<Animator>();
    if (animator != null){
        animator.Play("SoldierIdle");
    }
}

}
