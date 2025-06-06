using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public makes variables visible in inspector
    public float playerSpeed = 4f;
    public float horizontalSpeed = 3f;
    public float leftBorder = -6.5f;
    public float rightBorder = 6.5f;

    void Update()
    {
        // delta = relative to game and world speed
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > leftBorder)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (gameObject.transform.position.x < rightBorder)
            {
                // multiply by '-1' to invert direction
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            }
        }
    }
}
