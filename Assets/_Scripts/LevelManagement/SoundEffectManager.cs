using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager Instance;
	
	private static AudioSource audioSource;
	private static AudioSource randomPitchAudioSource;
	private static SoundEffectLibrary soundEffectLibrary;
	[SerializeField] private Slider sfxSlider;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
			AudioSource[] audioSources = GetComponents<AudioSource>();
			audioSource = audioSources[0];
			randomPitchAudioSource = audioSources[1];
			soundEffectLibrary = GetComponent<SoundEffectLibrary>();
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}

	private void Start()
	{
		sfxSlider.onValueChanged.AddListener(delegate { OnValueChange(); });
	}
	public static void Play(string soundName, bool randomPitch = false)
	{
		AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
		if(audioClip != null )
		{
			if (randomPitch)
			{
				randomPitchAudioSource.pitch = Random.Range(1f, 1.5f);
				randomPitchAudioSource.PlayOneShot(audioClip);
			}
			else
				audioSource.PlayOneShot(audioClip);
		}
	}

	public static void SetGeneralVolume(float volume)
	{
		audioSource.volume = volume;
		randomPitchAudioSource.volume = volume;
	}
	public static void SetMusicVolume(float volume)
	{
		audioSource.volume = volume;
	}
	public static void SetSFXVolume(float volume)
	{
		randomPitchAudioSource.volume = volume;
	}

	public void OnValueChange()
	{
		//SetVolume(sfxSlider.value);
	}
}
