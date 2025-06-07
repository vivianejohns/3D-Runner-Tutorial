using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    // static to make interactable with other script files
    public static int coinCount = 0;

    [SerializeField]
    GameObject coinDisplay;

    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinCount;
    }
}
