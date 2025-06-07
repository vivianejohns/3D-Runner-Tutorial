using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFx;

    void OnTriggerEnter(Collider other)
    {
        coinFx.Play();

        // 'MasterInfo' referenziert das andere Skript 
        MasterInfo.coinCount += 1;
        // to make sound only play once + hide coin
        gameObject.SetActive(false);
        CheckHighscore();
    }

    void CheckHighscore()
    {
        if (MasterInfo.coinCount > PlayerPrefs.GetInt("HighScore", 0))
        {
            // highscore saved only on local computer!
            PlayerPrefs.SetInt("HighScore", MasterInfo.coinCount);
        }
    }
}
