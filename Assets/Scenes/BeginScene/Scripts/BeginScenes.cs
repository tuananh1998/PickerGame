using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Scenes.ObjectData;

namespace Scenes.BeginScenes
{
    public class BeginScenes : MonoBehaviour
    {
        [SerializeField]
        private Text Coints;

        [SerializeField]
        private AudioData audioData;

        [SerializeField]
        private GameConstants gameConstants;

        bool isFirst = true;
        public void OnPlay()
        {
            SoundManager.PlaySound(audioData.audioClips[(int)Enums.SoundId.CommonClick]);
            SceneManager.LoadScene(gameConstants.PlayScenes);
        }

        public void OnShop()
        {
            SoundManager.PlaySound(audioData.audioClips[(int)Enums.SoundId.CommonClick]);
            SceneManager.LoadScene(gameConstants.ShopScenes);
        }

        void Start()
        {
            if (isFirst && PlayerPrefs.GetInt(gameConstants.FirstRewardKey) == 0)
            {
                PlayerPrefs.SetInt(gameConstants.FirstRewardKey, 1);
                PlayerPrefs.SetInt(GameConstants.CointKey, gameConstants.Coint);
                isFirst = false;
            }
            Coints.text = PlayerPrefs.GetInt(GameConstants.CointKey) > gameConstants.MaxCoint ? gameConstants.FormatCoint : PlayerPrefs.GetInt(GameConstants.CointKey).ToString();
        }
    }
}