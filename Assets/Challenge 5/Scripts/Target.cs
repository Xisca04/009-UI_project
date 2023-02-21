using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Destrucción del game object al pasar un tiempo - AUTODESTRUCCIÓN

    private float lifeTime = 2f;
    public int points;
    public GameObject explosionParticle;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, lifeTime);
    }

    private void OnMouseDown() // Al hacer click se autodestruye
    {
        if (!gameManager.isGameOver)
        {
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
            else if (gameObject.CompareTag("Good"))
            {
                gameManager.UpdateScore(points);
            }

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.Remove(transform.position);
    }
}
