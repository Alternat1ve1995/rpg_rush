using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Smoothing = 5f;

    private Vector3 _offset;

    private void Start ()
    {
        _offset = transform.position - Target.position;
    }

    void LateUpdate ()
    {
        Vector3 targetCamPos = Target.position + _offset;

        transform.position = Vector3.Lerp (transform.position, targetCamPos, Smoothing * Time.deltaTime);
    }
}
