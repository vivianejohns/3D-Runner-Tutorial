using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField]
    AudioSource coinFx;

    void OnTriggerEnter(Collider other)
    {
        coinFx.Play();

        // 'MasterInfo' references other script
        MasterInfo.coinCount += 1;
        // to make sound only play once + hide coin
        gameObject.SetActive(false);
    }
}
