using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScenes : MonoBehaviour
{

    [SerializeField] private Text StampCount;
    [SerializeField] private GameObject StampObj;
    [SerializeField] private ParticleSystem WiningEff;

    void Start()
    {
        int _stampCount = PlayerPrefs.GetInt(GameDesignFrontEndConstants.StampCountKey);
        StampCount.text = "X" + _stampCount.ToString();
        StampObj.SetActive(_stampCount > 0);
        // WiningEff.Play(true);
    }

    public void OnRetry()
    {
        // WiningEff.Stop();
        Time.timeScale = 1;
        SceneManager.LoadScene(GameDesignFrontEndConstants.PlayScenes);
    }
}
