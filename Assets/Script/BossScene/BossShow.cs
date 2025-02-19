
using UnityEngine;
using UnityEngine.Playables;
public class BossShow : MonoBehaviour
{
   [SerializeField] PlayableDirector bossShow;
    public GameObject Boss;
    Soldier soldier;
    int Play=0;
    private void Awake() {
        if(AudioManager.Instance != null) {
            Debug.Log("停止音乐");
            AudioManager.Instance.StopMusic();
        }
        Play=1;
    }
    public AudioData bossMusic;
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("PlayerTrigger")){
        soldier=other.GetComponentInParent<Soldier>();
       soldier.setIsIdle();
      bossShow.Play();
      Boss.SetActive(true);
      if(Play==1){
      AudioManager.Instance.PlayerMusic(bossMusic);
      Play=0;
      }
       }
   }
}
