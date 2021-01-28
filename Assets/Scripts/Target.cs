using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 100;
    public Material material;
    public GameObject destroyGameObject;
    public AudioSource hitSound;
    public GameObject fx;
    public float lifetime = 5;
    public bool useLifetime = false;

    private void Start()
    {
        GetComponent<Renderer>().material = material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject, 1);

            GameObject gameObject = Instantiate(fx, transform);
            if (useLifetime)
            {
                Destroy(gameObject, lifetime);
            }

            // add score to game
            Game.Instance.AddPoints(points);
            if(destroyGameObject != null)
            {
                hitSound.Play();
                Destroy(destroyGameObject, 0.5f);
            }
        }
    }
}
