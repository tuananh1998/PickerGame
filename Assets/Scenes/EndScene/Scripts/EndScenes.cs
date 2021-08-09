using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Scenes.ObjectData;
public class EndScenes : MonoBehaviour
{

    [SerializeField] private Text stampCount;
    [SerializeField] private Text coinCount;
    [SerializeField] private GameObject stampObj;
    [SerializeField] private GameObject cointStampObj;
    [SerializeField] private GameObject winingEff;
    [SerializeField] private GameConstants gameConstants;
    [SerializeField] private AudioData audioData;


    void Start()
    {
        SoundManager.PlaySound(audioData.audioClips[(int)Enums.SoundId.Outro]);
        int _stampCount = PlayerPrefs.GetInt(gameConstants.StampCountKey);
        int _coinCount = PlayerPrefs.GetInt(gameConstants.CoinCountKey);
        stampCount.text = "X" + _stampCount.ToString();
        coinCount.text = "X" + _coinCount.ToString();
        stampObj.SetActive(_stampCount > 0);
        cointStampObj.SetActive(_coinCount > 0);
        OrganizationTransform(_coinCount > 0, _stampCount > 0 && _coinCount > 0);
        // WiningEff.Play(true);
    }

    public void OnRetry()
    {
        SoundManager.PlaySound(audioData.audioClips[(int)Enums.SoundId.CommonClick]);
        // WiningEff.Stop();
        Time.timeScale = 1;
        SceneManager.LoadScene(gameConstants.PlayScenes);
    }

    public void OnHome()
    {
        SoundManager.PlaySound(audioData.audioClips[(int)Enums.SoundId.CommonClick]);
        // WiningEff.Stop();
        Time.timeScale = 1;
        SceneManager.LoadScene(gameConstants.BeginScenes);
    }

    public void OrganizationTransform(bool isHasCoin, bool isHasBoth)
    {
        if (isHasCoin)
        {
            cointStampObj.transform.localPosition = new Vector3(cointStampObj.transform.localPosition.x, 0, cointStampObj.transform.localPosition.z);
        }
        else if (!isHasCoin)
        {
            stampObj.transform.localPosition = new Vector3(stampObj.transform.localPosition.x, 0, stampObj.transform.localPosition.z);
        }
        else if (isHasBoth)
        {
            cointStampObj.transform.localPosition = new Vector3(cointStampObj.transform.localPosition.x, 44f, cointStampObj.transform.localPosition.z);
            stampObj.transform.localPosition = new Vector3(stampObj.transform.localPosition.x, -60f, stampObj.transform.localPosition.z);
        }
    }
}
