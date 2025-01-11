using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MicrophoneManager : MonoBehaviour
{
    public static MicrophoneManager Instance{get;private set;}
    [SerializeField]private AudioClip microphoneClip;
    private string selectedDevice;

    void Awake()

    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void InitializeMicrophone()
    {
        if (Microphone.devices.Length <= 0)
        {
            Debug.LogError("No Microphones Detected!");
            return;
        }
        string[] availableDevices = Microphone.devices;
        Debug.Log($"Available Devices: {string.Join(", ", availableDevices)}");

        selectedDevice = Microphone.devices[0];
        Debug.Log("Started using: " + selectedDevice);

        int sampleRate = AudioSettings.outputSampleRate;
        int duration = 5; // seconds
        Debug.Log("Output sample raate is : " + sampleRate);

        microphoneClip = Microphone.Start(selectedDevice,true,duration,sampleRate);

        if(microphoneClip == null)
        {
            Debug.LogError("Failed to start microphone");
        }

        else
        {
            Debug.Log("Microphone started successfully");
        }

    }

    public AudioClip GetAudioClip()
    {
        return microphoneClip;
    }

    public string GetMicrophoneName()
    {
        return selectedDevice;
    }

    public bool IsRecording()
    {
        return Microphone.IsRecording(selectedDevice);
    }
}
