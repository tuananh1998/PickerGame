using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Scenes.ObjectData;
public class EndScenes : MonoBehaviour
{

    [SerializeField] private Text StampCount;
    [SerializeField] private GameObject StampObj;
    [SerializeField] private ParticleSystem WiningEff;
    [SerializeField] private GameConstants gameConstants;


    void Start()
    {
        int _stampCount = PlayerPrefs.GetInt(gameConstants.StampCountKey);
        StampCount.text = "X" + _stampCount.ToString();
        StampObj.SetActive(_stampCount > 0);
        // WiningEff.Play(true);
    }

    public void OnRetry()
    {
        // WiningEff.Stop();
        Time.timeScale = 1;
        SceneManager.LoadScene(gameConstants.PlayScenes);
    }
}
