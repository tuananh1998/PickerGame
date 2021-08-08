using UnityEngine;

public static class SoundManager
{
    public static GameObject Instance;
    public static AudioSource audioSource;
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
        audioSource.PlayOneShot(audio);
    }

}
