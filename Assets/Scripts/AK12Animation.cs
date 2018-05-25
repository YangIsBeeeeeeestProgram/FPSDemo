using UnityEngine;
using System.Collections.Generic;

public class AK12Animation: MonoBehaviour {

    Animation ani;
    Dictionary<string, AnimationClip> clips = new Dictionary<string, AnimationClip>(); 
    string path = "Animations/";

    private void Awake()
    {
        ani = this.GetComponent<Animation>();
    }


 

    /// <summary>
    /// 播放发射动画
    /// </summary>
    public void Shoot()
    {
        if (ani.isPlaying)
        {
            ani.Stop();
        }
        ani.clip = GetClip("shootonce");
        ani.Play();
    }

    /// <summary>
    /// 播放换弹夹动画
    /// </summary>
    public void Reload()
    {
        if(ani.isPlaying)
        {
            ani.Stop();
        }
        ani.clip = GetClip("reload");
        ani.Play();
    }





    AnimationClip GetClip(string clipName)
    {
        if (!clips.ContainsKey(clipName))
        {
            AnimationClip clip = Resources.Load(path + clipName) as AnimationClip;
            clips.Add(clipName, clip);
        }
        return clips[clipName];
    }



}