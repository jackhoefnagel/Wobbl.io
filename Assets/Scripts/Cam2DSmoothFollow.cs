using UnityEngine;
using System.Collections;

public class Cam2DSmoothFollow : MonoBehaviour {

    public Camera cam;

    public Transform target;
    public float lerpSmoothness = 1.0f;

    private Vector3 camTargetPosition;

    public float cameraDistance = 5;
    private float distanceToPlayer;
	
	// Update is called once per frame
	void FixedUpdate () {
        UpdatePosition();

        UpdateDistance();
	}

    void UpdatePosition(){
        camTargetPosition.x = target.position.x;
        camTargetPosition.y = target.position.y;
        camTargetPosition.z = transform.position.z;

        distanceToPlayer = Vector3.Distance(transform.position, target.position) / 5;

        transform.position = Vector3.Lerp(transform.position, camTargetPosition, Time.deltaTime * lerpSmoothness * distanceToPlayer);
    }

    void UpdateDistance(){
        cam.orthographicSize = cameraDistance;
    }
}
