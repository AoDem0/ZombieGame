using System.Numerics;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    [SerializeField]private Transform player;
    [SerializeField] private float mouseSensitivity = 2f;

    [SerializeField] private float cameraVerticalRotation = 0f;

    
    void Start()
    {

        //wył widoczności kursora i lock kursora
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        //zebranie inputów
        float inputX = Input.GetAxis("Mouse X")*mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y")*mouseSensitivity;

        //rotacja kamery
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);

        transform.localEulerAngles = UnityEngine.Vector3.right * cameraVerticalRotation;
        
        player.Rotate(UnityEngine.Vector3.up * inputX);
    
    }
}
