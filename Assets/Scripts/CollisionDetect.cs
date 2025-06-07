using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject playerAnimation;
    [SerializeField]
    AudioSource collisionFX;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    GameObject fadeOutScreen;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CollisionEnd());
    }

    IEnumerator CollisionEnd()
    {
        collisionFX.Play();
        // stop moving when colliding with object
        player.GetComponent<PlayerMovement>().enabled = false;
        playerAnimation.GetComponent<Animator>().Play("Stumble Backwards");
        cam.GetComponent<Animator>().Play("CollisionCam");
        yield return new WaitForSeconds(1.5f);
        fadeOutScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
