using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{
    private MainAudioInputController mainAudioInputController;
    private Slider slider;
    public int volumeIntensity = 100;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        mainAudioInputController = GameObject.FindObjectOfType<MainAudioInputController>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = mainAudioInputController.Loudness * volumeIntensity;
    }

    public void MoveOnTheBeat()
    {
    }
}
