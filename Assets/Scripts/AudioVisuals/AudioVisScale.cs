using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisScale : MonoBehaviour
{
    public AudioSource audioSource;
    private GameObject objectToVisualizeAudio;
    public float loudnessMultiplier = 1;
    public float currentLoudness;
    public float sampleSum;

    private float[] audioSamples = new float[1024];
    private Vector3 origObjectScale;

    private void Awake()
    {
        objectToVisualizeAudio = this.gameObject;
        origObjectScale = objectToVisualizeAudio.transform.localScale;
    }

    private void FixedUpdate()
    {
        sampleSum = 0;
        currentLoudness = 0;

#if UNITY_WEBGL
        float posCosCalc = 1.0f-Mathf.Abs(Mathf.Cos((Time.timeSinceLevelLoad+0.5f) * 72.0f/60.0f * Mathf.PI));
        ScaleObject(0.07f+ 0.13f* posCosCalc * posCosCalc);
#else
        // Fill array audioSamples with number of samples starting from current playback position of audioSource
        audioSource.clip.GetData(audioSamples, audioSource.timeSamples);

        foreach (float sample in audioSamples)
        {
            sampleSum += Mathf.Abs(sample); // The samples are floats ranging from -1.0f to 1.0f so Abs to ignore the sign(+-) of this value 
        }

        currentLoudness = sampleSum / audioSamples.Length; // Average loudness

        ScaleObject(currentLoudness);
#endif
    }

    private void ScaleObject(float loudness)
    {
        // Scale in all directions
        Vector3 scaleToVector = new Vector3(origObjectScale.x + loudness * loudnessMultiplier, origObjectScale.y + loudness * loudnessMultiplier, origObjectScale.z + loudness * loudnessMultiplier);

        objectToVisualizeAudio.transform.localScale = Vector3.Lerp(objectToVisualizeAudio.transform.localScale, scaleToVector, Time.deltaTime);
    }
}
