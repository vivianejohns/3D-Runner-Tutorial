using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField]
    GameObject fadeOut;

    [SerializeField]
    GameObject bounceText;

    [SerializeField]
    GameObject bigButton;

    [SerializeField]
    GameObject animCam;

    [SerializeField]
    GameObject mainCam;

    [SerializeField]
    GameObject menuControls;

    [SerializeField]
    AudioSource buttonSelect;

    public static bool hasClicked;

    [SerializeField]
    GameObject staticCam;

    [SerializeField]
    GameObject fadeIn;

    [SerializeField]
    GameObject highscoreDisplay;

    void Start()
    {
        StartCoroutine(FadeInTurnOff());
        if (highscoreDisplay != null)
        {
            highscoreDisplay.GetComponent<TMPro.TMP_Text>().text =
                "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0);
        }

        if (hasClicked)
        {
            staticCam.SetActive(true);
            animCam.SetActive(false);
            menuControls.SetActive(true);
            bounceText.SetActive(false);
            bigButton.SetActive(false);
            MasterInfo.coinCount = 0;
        }
    }

    public void MenuBeginButton()
    {
        StartCoroutine(AnimCam());
    }

    public void StartGame()
    {
        StartCoroutine(StartButton());
    }

    IEnumerator StartButton()
    {
        buttonSelect.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    IEnumerator AnimCam()
    {
        animCam.GetComponent<Animator>().Play("AnimMenuCam");
        bounceText.SetActive(false);
        bigButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        mainCam.SetActive(true);
        animCam.SetActive(false);
        menuControls.SetActive(true);
        hasClicked = true;
    }

    IEnumerator FadeInTurnOff()
    {
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }
}
