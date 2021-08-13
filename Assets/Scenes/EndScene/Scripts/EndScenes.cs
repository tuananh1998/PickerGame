using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Scenes.ObjectData;
public class EndScenes : MonoBehaviour
{
    #region SerializeField
    [SerializeField]
    private Text stampCount;

    [SerializeField]
    private Text coinCount;

    [SerializeField]
    private GameObject stampObj;

    [SerializeField]
    private GameObject cointStampObj;

    [SerializeField]
    private GameObject winingEff;

    [SerializeField]
    private GameConstants gameConstants;

    [SerializeField]
    private AudioData audioData;

    #endregion

    #region Function
    void Start()
    {
        Time.timeScale = 1;
        SoundManager.PlaySound(audioData.audioClips[(int)Enums.SoundId.Outro]);
        int _stampCount = PlayerPrefs.GetInt(gameConstants.StampCountKey);
        int _coinCount = PlayerPrefs.GetInt(gameConstants.CoinCountKey);
        stampCount.text = "X" + _stampCount.ToString();
        coinCount.text = "X" + _coinCount.ToString();
        stampObj.SetActive(_stampCount > 0);
        cointStampObj.SetActive(_coinCount > 0);
        OrganizationTransform(_coinCount > 0);
        PlayWinningEffect(winingEff, true);
    }

    public void OnRetry()
    {
        SoundManager.PlaySound(audioData.audioClips[(int)Enums.SoundId.CommonClick]);
        PlayWinningEffect(winingEff, false);
        Time.timeScale = 1;
        SceneManager.LoadScene(gameConstants.PlayScenes);
    }

    public void OnHome()
    {
        SoundManager.PlaySound(audioData.audioClips[(int)Enums.SoundId.CommonClick]);
        PlayWinningEffect(winingEff, false);
        Time.timeScale = 1;
        SceneManager.LoadScene(gameConstants.BeginScenes);
    }

    public void OrganizationTransform(bool isHasCoin)
    {
        if (isHasCoin)
        {
            cointStampObj.transform.localPosition = new Vector3(cointStampObj.transform.localPosition.x, 44f, cointStampObj.transform.localPosition.z);
            stampObj.transform.localPosition = new Vector3(stampObj.transform.localPosition.x, -60f, stampObj.transform.localPosition.z);
        }
        else if (!isHasCoin)
        {
            stampObj.transform.localPosition = new Vector3(stampObj.transform.localPosition.x, 0, stampObj.transform.localPosition.z);
        }
    }

    public void PlayWinningEffect(GameObject winEff, bool isActive)
    {
        var winParticles = winEff.GetComponentsInChildren<ParticleSystem>();
        foreach (var winParticle in winParticles)
        {
            if (isActive)
                winParticle.Play();
            else winParticle.Stop();
        }
    }


    #endregion
}
