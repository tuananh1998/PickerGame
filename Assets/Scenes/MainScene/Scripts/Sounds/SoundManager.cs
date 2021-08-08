using UnityEngine;

public static class SoundManager
{
    public static GameObject Instance;
    public static void PlaySound(AudioClip audio)
    {
        if (Instance == null)
        {
            Instance = new GameObject("Sound");
        }
        else
        {
            Instance = GameObject.Find("Sound");
        }
        AudioSource audioSource = Instance.AddComponent<AudioSource>();
        audioSource.PlayOneShot(audio);
    }

}
