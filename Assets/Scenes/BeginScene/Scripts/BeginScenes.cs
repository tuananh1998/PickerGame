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
        private Image SoundObject;

        [SerializeField]
        private AudioData audioData;

        [SerializeField]
        private GameConstants gameConstant;

        [SerializeField]
        private float BgmVolumn = 0.1f;

        [SerializeField]
        private DialogueTrigger dialogue;

        [SerializeField]
        private Image blockImg;

        bool _isFirst = true, _isMute = false;
        public void OnPlay()
        {
            OnPlayCommonUISound();
            SceneManager.LoadScene(gameConstant.PlayScenes);
        }

        public void OnShop()
        {
            OnPlayCommonUISound();
            SceneManager.LoadScene(gameConstant.ShopScenes);
        }

        void Start()
        {
            OnSetUp();
            OnSetUpColorButtonSound(SoundManager.CheckMute());
        }

        void OnSetUp()
        {
            ReLoadSound();
            if (_isFirst && PlayerPrefs.GetInt(gameConstant.FirstRewardKey) == 0)
            {
                PlayerPrefs.SetInt(gameConstant.FirstRewardKey, 1);
                PlayerPrefs.SetInt(GameConstants.CointKey, gameConstant.Coint);
                blockImg.gameObject.SetActive(_isFirst && PlayerPrefs.GetInt(gameConstant.FirstRewardKey) == 0);
                dialogue.gameObject.SetActive(_isFirst && PlayerPrefs.GetInt(gameConstant.FirstRewardKey) == 0);
                dialogue.TriggerDialogue();
                _isFirst = false;
            }
            Coints.text = PlayerPrefs.GetInt(GameConstants.CointKey) > gameConstant.MaxCoint ? gameConstant.FormatCoint : PlayerPrefs.GetInt(GameConstants.CointKey).ToString();
        }

        public void ReLoadSound()
        {
            SoundManager.PlayLoopSound(audioData.audioClips[(int)Enums.SoundId.Bgm], BgmVolumn);
        }

        public void OnMuteSound()
        {
            // SoundManager.PlaySound(audioData.audioClips[(int)Enums.SoundId.CommonClick]);
            _isMute = !SoundManager.CheckMute();
            PlayerPrefs.SetInt(Scenes.ObjectData.GameConstants.MuteSoundKey, (_isMute) ? (int)Enums.SoundStatus.Mute : (int)Enums.SoundStatus.Normal);
            ReLoadSound();
            OnSetUpColorButtonSound(_isMute);
        }

        public void OnSetUpColorButtonSound(bool isMute)
        {
            SoundObject.color = (isMute) ? gameConstant.MuteSoundColor : gameConstant.NormalSoundColor;
        }

        public void OnClose()
        {
            Application.Quit();
        }

        public void OnPlayCommonUISound()
        {
            SoundManager.PlaySound(audioData.audioClips[(int)Enums.SoundId.CommonClick]);
        }

    }
}