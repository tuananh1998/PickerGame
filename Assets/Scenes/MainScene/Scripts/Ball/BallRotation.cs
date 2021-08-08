using UnityEngine;

public class BallRotation : MonoBehaviour
{
    float speedRotate = 50f;
    void Update()
    {
        transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }
}
