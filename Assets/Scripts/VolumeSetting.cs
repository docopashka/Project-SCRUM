using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Добавлено для Text и Slider

public class VolumeSetting : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource audio;
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;

    [Header("Keys")]
    [SerializeField] private string saveVolumeKey;

    [Header("Tags")]
    [SerializeField] private string sliderTag;     // Исправлено на sliderTag
    [SerializeField] private string textVolumeTag; // Исправлено на textVolumeTag

    [Header("Parameters")]
    [SerializeField] private float volume;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(this.saveVolumeKey))
        {    
            this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
            this.audio.volume = this.volume;

            GameObject sliderObj = GameObject.FindGameObjectWithTag(this.sliderTag); // Исправлено на GameObject.FindGameObjectWithTag
            if (sliderObj != null)
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.slider.value = this.volume;
            }
        }
        
        else
        {
            this.volume = 0.5f;
            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            this.audio.volume = this.volume;
        }
    }

    private void LateUpdate()
    {
        GameObject sliderObj = GameObject.FindGameObjectWithTag(this.sliderTag); // Исправлено на GameObject.FindGameObjectWithTag
        if (sliderObj != null)
        {
            this.slider = sliderObj.GetComponent<Slider>();
            this.volume = slider.value;

            if (this.audio.volume != this.volume)
            {
                PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            }

            GameObject textObj = GameObject.FindGameObjectWithTag(this.textVolumeTag); // Исправлено на GameObject.FindGameObjectWithTag
            if (textObj != null)
            {
                this.text = textObj.GetComponent<Text>(); // Исправлено на textObj.GetComponent<Text>();

                this.text.text = Mathf.Round(this.volume * 100) + "%"; // Исправлено на Mathf.Round
            }
        }

        this.audio.volume = this.volume;

    }
}