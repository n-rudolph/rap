using UnityEngine;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {

	public Dictionary<SoundEnum, AudioClip> soundEffects;

	public AudioSource audioSource;





	// Use this for initialization
	void Start () {
		soundEffects = new Dictionary<SoundEnum, AudioClip> ();
		AudioClip aux1 = Resources.Load(SoundEnum.BLIZZARD.ToString(), typeof(AudioClip)) as AudioClip;
		soundEffects.Add (SoundEnum.BLIZZARD, aux1);
		aux1 = Resources.Load(SoundEnum.FIREBLAST.ToString(), typeof(AudioClip)) as AudioClip;
		soundEffects.Add (SoundEnum.FIREBLAST, aux1);
		aux1 = Resources.Load(SoundEnum.WATERBLAST.ToString(), typeof(AudioClip)) as AudioClip;
		soundEffects.Add (SoundEnum.WATERBLAST, aux1);

		
	}

	public void Play(SoundEnum key)
	{
		AudioClip temp;
		if (soundEffects.TryGetValue(key, out temp)) {
			audioSource.PlayOneShot(temp, 1.0f);
		}
	}

	public void Stop(){
		
		audioSource.Stop ();

	}

	public enum SoundEnum{
		BLIZZARD, FIREBLAST, WATERBLAST
	}
}
