using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public bool isGameOver;
    public float spawnRate = 1f;
    public List<Vector3> targetPositionsInScene;
    public Vector3 randomPos;

    // Texto
    public TextMeshProUGUI scoreText;
    private int score;
    public GameObject gameOverPanel;
    public GameObject startGamePanel;
    
    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;
    

    private void Start()
    {
        isGameOver = false;
        StartCoroutine("SpawnRandomTarget");
       
        score = 0;
        scoreText.text = $"Score: \n{score}";    // La barra n (\n) es un salto de línea

        gameOverPanel.gameObject.SetActive(false);
        startGamePanel.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.gameObject.SetActive(true);
    }

    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minX + Random.Range(0, 4) * distanceBetweenSquares;
        float spawnPosY = minY + Random.Range(0, 4) * distanceBetweenSquares;
        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targetPrefabs.Length);
            
            randomPos = RandomSpawnPosition();
            while (targetPositionsInScene.Contains(randomPos))  // Si la posicion está ocupada, busca otra posición para que aparezca el siguiente objeto
            {
                randomPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomIndex], randomPos, targetPrefabs[randomIndex].transform.rotation);
            targetPositionsInScene.Add(randomPos);
        }
    }

    public void UpdateScore(int newPoints)
    {
        score += newPoints;
        scoreText.text = $"Score: \n{score}";
    }
}
