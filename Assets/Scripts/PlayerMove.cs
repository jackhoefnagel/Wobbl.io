using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed = 0.1F;

    private Rigidbody rb;
    private Vector3 pushDirection;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            pushDirection.x = -touchDeltaPosition.x * speed;
            pushDirection.y = -touchDeltaPosition.y * speed;

            // Move object across XY plane
            //transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
            rb.AddRelativeForce(pushDirection, ForceMode.Force);
        }

        pushDirection.x = Input.GetAxis("Horizontal") * speed;
        pushDirection.y = Input.GetAxis("Vertical") * speed;

        //rb.AddRelativeForce(pushDirection, ForceMode.Force); 
        rb.AddForce(pushDirection, ForceMode.Force); 
    }
}
