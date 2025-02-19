
using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
  static TextMeshProUGUI Count;

private void Awake() {
    Count=GetComponent<TextMeshProUGUI>();
}
private void Start() {
    ScoreManager.Instance.ResetCount();
}
  //  public static void UpdateCount(int count){
   //     Count.text = count.ToString();
   // }

    
}


