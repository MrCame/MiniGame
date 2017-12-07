using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour {
    //将准备好的MP3格式的声音文件拖入此处  
    //public AudioClip BeginMusic;
    public AudioClip BackgroundMusic;
    //public AudioClip WinMusic;
    //public AudioClip LoseMusic;  
    //用于控制声音的AudioSource组件  
    private AudioSource _audioSource; 

    void Awake()  
    {  
       //在添加此脚本的对象中添加AudioSource组件，此处为摄像机  
       _audioSource = this.gameObject.AddComponent<AudioSource>();  
       //设置循环播放  
       _audioSource.loop = true;  
       //设置音量为最大，区间在0-1之间  
       _audioSource.volume = 0.3f;  
       //设置audioClip  
       _audioSource.clip = BackgroundMusic;  
       _audioSource.Play();
    } 
}
/*
using UnityEngine;  
using System.Collections;  
  
public class MusicPlay : MonoBehaviour  
{  
        public static MusicPlay _instance;  
        public AudioClip[] _clips;  
  
        void Awake ()  
        {  
                _instance = this;  
        }  
  
        public void PlayMusic (int i)  
        {  
                //print(i);  
                this.audio.clip = _clips [i];  
                this.audio.Play ();  
        }  
  
} 

MusicPlay._instance.PlayMusic*/