using UnityEngine;
using System.Collections;

public class MicrophonePermissions : MonoBehaviour
{
    public GameObject permissionDeniedMessage;

    void Start()
    {
        CheckMicrophonePermission();
    }

    public void CheckMicrophonePermission()
    {
        if (!Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            StartCoroutine(RequestMicrophonePermission());
        }
        else
        {
            Debug.Log("Microphone permission granted.");
        }
    }

    private IEnumerator RequestMicrophonePermission()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
        
        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            Debug.Log("Microphone permission granted.");
            if (permissionDeniedMessage != null)
                permissionDeniedMessage.SetActive(false);
        }
        else
        {
            Debug.LogError("Microphone permission denied.");
            if (permissionDeniedMessage != null)
                permissionDeniedMessage.SetActive(true);
        }
    }
}
