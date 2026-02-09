using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] float paralaxMultiplayer;

    Transform cameraTransform;
    Vector3 previusCameraPosition;

    private void OnEnable()
    {
        cameraTransform = Camera.main.transform;
        previusCameraPosition = cameraTransform.position;
    }
    
    private void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - previusCameraPosition.x) * paralaxMultiplayer;
        transform.Translate(new Vector3(deltaX, 0, 0));
        previusCameraPosition = cameraTransform.position;
    }
}
