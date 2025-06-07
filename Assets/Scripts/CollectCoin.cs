using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField]
    AudioSource coinFx;

    // cache highscore instead of calling PlayerPrefs on every coin collection for better performance
    private int cachedHighscore = -1;

    void OnTriggerEnter(Collider other)
    {
        coinFx.Play();

        // 'MasterInfo' references other script
        MasterInfo.coinCount += 1;
        // to make sound only play once + hide coin
        gameObject.SetActive(false);
        CheckHighscore();
    }

    void CheckHighscore()
    {
        if (cachedHighscore == -1)
        {
            cachedHighscore = PlayerPrefs.GetInt("HighScore", 0);
        }

        if (MasterInfo.coinCount > cachedHighscore)
        {
            // highscore saved only on local computer!
            PlayerPrefs.SetInt("HighScore", MasterInfo.coinCount);
            cachedHighscore = MasterInfo.coinCount;
        }
    }
}
