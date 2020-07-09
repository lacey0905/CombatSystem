using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacterController : MonoBehaviour
{
    //[SerializeField]
    //private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;

    public Transform Cam;

    private void Awake()
    {
        
    }

    private void Update()
    {
        LookAround();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;
        if(x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y, camAngle.z);
        Cam.rotation = Quaternion.Euler(0f, camAngle.y + mouseDelta.x, 0f);
    }


}
