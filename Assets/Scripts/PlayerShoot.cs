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



        if (Input.GetKeyUp(KeyCode.Space)){
            GameObject newBullet = (GameObject)PhotonNetwork.Instantiate(bulletPrefab.name, bulletExit.position, weapon.transform.rotation,0);
        }
	}
}
