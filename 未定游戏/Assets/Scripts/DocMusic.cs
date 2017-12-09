using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocMusic : MonoBehaviour {
    //将准备好的MP3格式的声音文件拖入此处  
    public AudioClip Music;
    //用于控制声音的AudioSource组件 
    [HideInInspector] 
    public AudioSource _DocSource; 

    void Start()  
    {  
       //在添加此脚本的对象中添加AudioSource组件，此处为摄像机  
       _DocSource = this.gameObject.AddComponent<AudioSource>();  
       //设置循环播放  
       _DocSource.loop = true;  
       //设置音量为最大，区间在0-1之间  
       _DocSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1);  
       //设置audioClip  
       _DocSource.clip = Music;  
       _DocSource.Play();
    } 
}