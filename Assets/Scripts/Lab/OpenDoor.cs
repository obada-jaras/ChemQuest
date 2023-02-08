using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public float openAngle = 4.0f;
    public float openSpeed = 2.0f;

    private Quaternion targetRotation;
    private bool open;

    private void Start()
    {
        targetRotation = Quaternion.Euler(0, openAngle, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            open = true;
        }
    }

    private void Update()
    {
        if (open)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
        }
    }
}
