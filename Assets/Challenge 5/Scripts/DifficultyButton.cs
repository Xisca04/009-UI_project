using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;  // Dificultad ( 1 = fácil, 2 = medio, 3 = difícil)
    private Button _button;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Esta relación con el Game Manager se ha de hacer en el Start y no en el Awake, para evitar posibles errores
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        gameManager.SatrtGame(difficulty);
    }
}
