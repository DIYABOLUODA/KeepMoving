using UnityEngine;
using UnityEngine.Playables;

public class Skip : MonoBehaviour
{
    public PlayableDirector director;
    public double targetTime = 13.2; 
    private bool hasBeenClicked;

    private void OnEnable()
    {
        hasBeenClicked = false; 
    }

    public void SkipToTargetTime()
    {

      //  Debug.Log("aaaaaaaaaaaaaaa");
        if (hasBeenClicked)
        {
            return;
        }

        if (director != null)
        {
            director.time = targetTime;
            director.Evaluate(); 

            PlayableGraph graph = director.playableGraph;
            graph.Evaluate(); 

            hasBeenClicked = true; 
        }
    }
}
