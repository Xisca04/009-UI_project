using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Destrucci�n del game object al pasar un tiempo - AUTODESTRUCCI�N

    public int points;   // Puntuaci�n de los objetos (positiva para GOOD y 0 para BAD)
    public GameObject explosionParticle;
    
    private float lifeTime = 2f;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, lifeTime);  // Autodestrucci�n
    }

    private void OnMouseDown() // Al hacer click se autodestruye
    {
        if (!gameManager.isGameOver)
        {
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.MinusLife();
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
