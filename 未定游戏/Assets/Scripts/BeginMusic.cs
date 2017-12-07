using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginMusic : MonoBehaviour {
    //将准备好的MP3格式的声音文件拖入此处  
    public AudioClip Music;
    //用于控制声音的AudioSource组件 
    [HideInInspector] 
    public AudioSource _BeginSource; 

    void Start()  
    {  
       //在添加此脚本的对象中添加AudioSource组件，此处为摄像机  
       _BeginSource = this.gameObject.AddComponent<AudioSource>();  
       //设置循环播放  
       _BeginSource.loop = true;  
       //设置音量为最大，区间在0-1之间  
       _BeginSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1);  
       //设置audioClip  
       _BeginSource.clip = Music;  
       _BeginSource.Play();
    } 
}