using UnityEngine;

public static class SoundManager
{
    public static GameObject Instance;
    public static GameObject SoundInstance;
    public static AudioSource audioSource;
    public static AudioSource audioLoopSource;

    public static void PlaySound(AudioClip audio)
    {
        if (Instance == null)
        {
            Instance = new GameObject("Sound");
            audioSource = Instance.AddComponent<AudioSource>();
        }
        else
        {
            Instance = GameObject.Find("Sound");
        }
        audioSource.volume = 1f;
        audioSource.mute = CheckMute();
        audioSource.PlayOneShot(audio);
    }

    public static void PlayLoopSound(AudioClip audio, float volumn)
    {
        if (SoundInstance == null)
        {
            SoundInstance = new GameObject("SoundLoop");
            audioLoopSource = SoundInstance.AddComponent<AudioSource>();
        }
        else
        {
            SoundInstance = GameObject.Find("SoundLoop");
        }
        audioLoopSource.loop = true;
        audioLoopSource.volume = volumn;
        audioLoopSource.clip = audio;
        audioLoopSource.mute = CheckMute();
        audioLoopSource.Play();
    }

    public static bool CheckMute()
    {
        return PlayerPrefs.GetInt(Scenes.ObjectData.GameConstants.MuteSoundKey) == (int)Enums.SoundStatus.Mute;
    }

}
