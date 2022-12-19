using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Track
{
    public AudioClip clip;
    [HideInInspector]
    public AudioSource audioPlayer;
    public string tag;
    
    [Range(0.00001f, 1f)]
    public float volume;




}
