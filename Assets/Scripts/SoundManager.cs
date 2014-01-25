using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioClip[] clips;
	public static SoundManager instance;

	void Awake () {
		instance = this;
	}

	AudioClip GetAudio (string clipName) {
		foreach(AudioClip clip in clips)
		{
			if(clip.name == clipName)
			{
				return clip;
			}
		}
		return null;
	}

	public void PlayAudioWithName (string clipName) {
		audio.PlayOneShot(GetAudio(clipName));
	}
}
