using UnityEngine;
namespace Scenes.ObjectData
{
    [CreateAssetMenu(menuName = "Menu/Create Audio Data")]
    public class AudioData : ScriptableObject
    {
        [SerializeField]
        public AudioClip[] audioClips;
    }
}