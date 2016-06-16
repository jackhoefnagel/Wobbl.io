using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float damage = 1;
    public float bulletSpeed = 15;
    float aliveTime = 1;

    PhotonView photonView;
    Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        photonView = GetComponent<PhotonView>();
        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = transform.right * bulletSpeed;

        Invoke("DestroyBulletByOwner", aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        // now we know the object can be damaged
        if (other.collider.GetComponent<IDamageable>() != null)
        {
            other.collider.GetComponent<IDamageable>().UpdateHealth(-damage);
            DestroyBulletByOwner();
        }

    }

    void DestroyBulletByOwner()
    {
        if (photonView.isMine)
            PhotonNetwork.Destroy(this.gameObject);
    }

}
