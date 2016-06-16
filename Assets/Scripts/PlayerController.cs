using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    PlayerShoot playerShoot;
    PlayerMove playerMove;
    PhotonView photonView;

    Damageable damagable;

	// Use this for initialization
	void Start () {

        playerShoot = GetComponent<PlayerShoot>();
        playerMove = GetComponent<PlayerMove>();
        photonView = GetComponent<PhotonView>();
        damagable = GetComponent<Damageable>();

        SetupEvents();
        SetupNetworking();
        
    }

    void SetupEvents()
    {
        damagable.Died += SetPlayerDeath;
        damagable.ReceiveDmg += PlayerReceivedDamage;
    }

    void SetupNetworking()
    {
        if (photonView.isMine)
        {
            Camera.main.GetComponent<Cam2DSmoothFollow>().Setup(this.gameObject);

        }
        else
        {
            playerMove.enabled = false;
            playerShoot.enabled = false;
        }
    }

    void SetPlayerDeath()
    {
        damagable.Died -= SetPlayerDeath;

        Destroy(gameObject);
    }

    void PlayerReceivedDamage()
    {
        damagable.ReceiveDmg -= PlayerReceivedDamage;
    }
}
