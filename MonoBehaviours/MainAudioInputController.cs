using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioInputController : MonoBehaviour
{
    private MicrophoneManager microphoneManager;
    private AudioProcessor audioProcessor;
    private AudioClip microphoneClip;
    private string microphoneName;
    public float Loudness;
    public float threshold = 0.1f;
    public event Action OnNewMicrophoneConnected;
    // Start is called before the first frame update
    void Start()
    {
        // Application.targetFrameRate = 30;
        microphoneManager = MicrophoneManager.Instance;
        audioProcessor = new AudioProcessor();
        microphoneManager.InitializeMicrophone();
        microphoneClip = microphoneManager.GetAudioClip();
        microphoneName = microphoneManager.GetMicrophoneName();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int position = Microphone.GetPosition(microphoneName);
        if (microphoneManager.IsRecording())
        {

            Loudness = audioProcessor.CalculateLoudness(microphoneClip, position);
            if (Loudness < threshold)
            {
                Loudness = 0;
            }


        }

        else
        {
            Debug.Log("Microphone was removed or a new one was added");
            audioProcessor = new AudioProcessor();
        microphoneManager.InitializeMicrophone();
        microphoneClip = microphoneManager.GetAudioClip();
        microphoneName = microphoneManager.GetMicrophoneName();
            OnNewMicrophoneConnected?.Invoke();
        return;
        }
    }
}
