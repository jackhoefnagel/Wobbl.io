using UnityEngine;
using System.Collections;

public class DebugUIScript : MonoBehaviour {

    public PlayerMove playerMoveScript;
    public Cam2DSmoothFollow camMoveScript;

    public void UpdateCamDistance(float camDistance)
    {
        camMoveScript.cameraDistance = camDistance;
    }

    public void UpdateMovementSpeed(float movSpeed)
    {
        playerMoveScript.speed = movSpeed;
    }
}
