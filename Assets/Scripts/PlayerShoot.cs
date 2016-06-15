using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public GameObject weapon;
    public Transform bulletExit;
    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.Space)){
            GameObject newBullet = (GameObject)Instantiate(bulletPrefab, bulletExit.position, weapon.transform.rotation);
            Destroy(newBullet, 1.0f);
        }
	}
}
