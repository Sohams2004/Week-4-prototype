using UnityEngine;

public class RotatePlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        float yRotation = other.transform.eulerAngles.y;
        
        if (yRotation > 180)
            yRotation -= 360;

        if (yRotation > -120 && yRotation < 120)
        {
            other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x, -180, other.transform.eulerAngles.z);
        }
        else if (yRotation > -170 && yRotation < 170)
        {
            other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x, 0, other.transform.eulerAngles.z);
        }
    }
}