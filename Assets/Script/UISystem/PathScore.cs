
using UnityEngine;
using TMPro;
public class PathScore : MonoBehaviour
{
   static TextMeshProUGUI pathScore;

    private void Awake() {
        pathScore = GetComponent<TextMeshProUGUI>();
    }
   private void Start() {
        ScoreManager.Instance.ResetPathScore();
    }
    public static void UpdateScore(float score){
        //string scoreText=score.ToString("F1");
      //  pathScore.text = scoreText;
         pathScore.text=score.ToString("F1");
    }

}
