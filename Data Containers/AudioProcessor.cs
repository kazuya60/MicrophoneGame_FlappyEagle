using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioProcessor
{
    private int sampleWindow;
    public AudioProcessor(int sampleWindow = 64)
    {
        this.sampleWindow = sampleWindow;
    }
    
    public float CalculateLoudness(AudioClip audioClip,int position)
    {
        int startingPosition = position - sampleWindow;
        if (startingPosition < 0) return 0;

        float[] waveData = new float[sampleWindow];
        audioClip.GetData(waveData, startingPosition);

        // Calculate total loudness (average of absolute values)
        float totalLoudness = 0f;
        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;  // Average loudness
    }
}
