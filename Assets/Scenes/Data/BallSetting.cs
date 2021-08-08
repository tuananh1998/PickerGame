using UnityEngine;
namespace Scenes.ObjectData
{
    [CreateAssetMenu(menuName = "Menu/Create Ball Setting")]
    public class BallSetting : ScriptableObject
    {
        [SerializeField]
        public Sprite[] ballItem;

        [SerializeField]
        public Color[] ballColor;
    }

}