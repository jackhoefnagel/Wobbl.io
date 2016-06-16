using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Damageable : MonoBehaviour, IDamageable
{

    float curHealth;
    public float maxHealth = 1;

    IEnumerator blinkCoroutine;
    public List<Renderer> gfxToFlash = new List<Renderer>();

    public delegate void DieEvent();
    public event DieEvent Died;

    public delegate void ReceiveDmgEvent();
    public event ReceiveDmgEvent ReceiveDmg;


    void Start()
    {
        curHealth = maxHealth;
    }

    // should be synced on network
    public void UpdateHealth(float amount, bool giveFeedback = true)
    {

        if (amount < 0 && ReceiveDmg != null)
        {
            ReceiveDmg();
        }

        curHealth += amount;

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (curHealth <= 0)
            Die();

        if (giveFeedback)
            Blink();

    }

    void Die()
    {
        if (Died != null)
            Died();

        //Destroy(gameObject);
    }

    void Blink()
    {

        if (blinkCoroutine != null)
            StopCoroutine(blinkCoroutine);

        blinkCoroutine = Flash(gfxToFlash, .1f, Color.red);
        StartCoroutine(blinkCoroutine);

    }

    IEnumerator Flash(List<Renderer> gfx, float time, Color colorToFlash)
    {
        foreach (var item in gfx)
        {
            item.material.color = colorToFlash;
        }
        yield return new WaitForSeconds(time);
        foreach (var item in gfx)
        {
            item.material.color = Color.white;
        }

    }

}
