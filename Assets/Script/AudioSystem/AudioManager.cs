using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonManager<AudioManager>
{
    [SerializeField] AudioSource sFXPlayer;
    [SerializeField] AudioSource musicPlayer;

    const float MIN_PITCH=0.9f;
    const float MAX_PITCH=1.1f;
    public void PlaySFX(AudioData audioData){
        if(audioData!=null){
        sFXPlayer.PlayOneShot(audioData.audioClip,audioData.volume);//playOneShot让声音听起来更连贯
        }
    }

    public void PlayerMusic(AudioData audioData){
        musicPlayer.clip=audioData.audioClip;
        musicPlayer.Play();
    }

    public void StopMusic(){
        if(musicPlayer!=null&&musicPlayer.isPlaying){
            musicPlayer.Stop();
        }

        
    }
    public void PlayRandomSFX(AudioData audioDate){//正常出去用这个，有节奏一点
        sFXPlayer.pitch=Random.Range(MIN_PITCH,MAX_PITCH);
        PlaySFX(audioDate);
    }

    public void PlayRandomSFX(AudioData[] audioData){
        PlayRandomSFX(audioData[Random.Range(0,audioData.Length)]);
    }
}
