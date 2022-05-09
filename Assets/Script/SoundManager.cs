using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip popSound;

    public AudioClip triggerSound;

    private AudioSource src;
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
       
    }

    public void PlaySound()
    {
        src.PlayOneShot(shootSound);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (popSound != null)
        {
            src.PlayOneShot(popSound, 0.7f);
            src.PlayOneShot(triggerSound, 0.7f);
            Destroy(other.gameObject);
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
