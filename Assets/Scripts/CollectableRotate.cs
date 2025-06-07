using UnityEngine;

public class CollectableRotate : MonoBehaviour
{
    [SerializeField]
    int rotateSpeed = 3;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
