using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public Instrument[] instruments;
    public AudioMixer mixer;

    void Awake(){
        // on awake, initialize the output sources for all tracks
        foreach(Instrument i in instruments){
            // counter for group tracks - 0 is parent aka instrument
            int n = 1;
            foreach(Track t in i.tracks){
                // make a new audio player
                t.audioPlayer = gameObject.AddComponent<AudioSource>();
                    
                // assign clip
                t.audioPlayer.clip = t.clip;

                // turn on looping
                t.audioPlayer.loop = true;

                t.audioPlayer.volume = t.volume;

                // assign mixerGroup using inst + track tags
                AudioMixerGroup[] audioMixGroup = mixer.FindMatchingGroups(i.tag);
                t.audioPlayer.outputAudioMixerGroup = audioMixGroup[n];

                // start track
                t.audioPlayer.Play();

                n += 1;
            }
        }
    }

    public void Playback(string instrumentTag, string tag, string cmmd){
        // find instrument group in Instruments - searching by tag
        Instrument i = Array.Find(instruments, instrument => instrument.tag == instrumentTag);
        
        // find track in Instrument tracks array - searchinh by tag
        Track t = Array.Find(i.tracks, track => track.tag == tag);
        
        // set target mixer channels, using inst/track tags
        string mixerGroupParam = i.tag + "_" + t.tag + "_vol";
        
        // set fade params
        float targetVol = 0f;
        float duration = .2f;
        
        // swtich for cmmds
        if(cmmd == "fadeIn"){
            targetVol = 1f;
        }if(cmmd == "fadeOut"){
            targetVol = 0f;
        }
        
        // run()
        StartCoroutine(FadeMixerGroup.StartFade(mixer, mixerGroupParam, duration, targetVol));
    }


    // for volume fade ins/outs
    public class FadeMixerGroup{
        // create an enumerator class
        public static IEnumerator StartFade(AudioMixer mixer, string exposedParam, float duration, float targetVolume)
        {
            // init time
            float currentTime = 0;
            
            // get vol of mixer channel
            float currentVol;
            mixer.GetFloat(exposedParam, out currentVol);
            currentVol = Mathf.Pow(10, currentVol / 20);

            // convert target vol to clamped float num
            float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
                mixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
                yield return null;
            }
            yield break;
        }
    }
    
    // for volume fade ins/outs
    public class FadeFx{
        // create an enumerator class
        public static IEnumerator StartFade(AudioMixer mixer, string exposedParam, float duration, float targetValue)
        {
            // init time
            float currentTime = 0;
            
            // get vol of mixer channel
            float currentVal;
            mixer.GetFloat(exposedParam, out currentVal);

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                float newVal = Mathf.Lerp(currentVal, targetValue, currentTime / duration);
                mixer.SetFloat(exposedParam, newVal);
                yield return null;
            }
            yield break;
        }
    }

    public void FxChange(string FxName, string cmmd){
        // set target mixer channels, fxname
        string mixerGroupParam = FxName;
        float duration = 3f;
        float targetVal = 0f;

        // take cmmd
        // swtich for cmmds
        if(cmmd == "fadeIn"){
            switch(FxName){
                case "reverb":
                    targetVal = -600f;
                    break;
                case "lopass":
                    targetVal = 450f;
                    break;
                case "hipass":
                    targetVal = 1200f;
                    break;
            }
            print(FxName +  " Fading In"  + " target val: " + targetVal);
        }if(cmmd == "fadeOut"){
            switch(FxName){
                case "reverb":
                    targetVal = -10000f;
                    break;
                case "lopass":
                    targetVal = 20000f;
                    break;
                case "hipass":
                    targetVal = 10f;
                    break;
            }
            print(FxName +  " Fading Out" + " target val: " + targetVal);
        }



        // run()
        StartCoroutine(FadeFx.StartFade(mixer, mixerGroupParam, duration, targetVal));        
    }
}


