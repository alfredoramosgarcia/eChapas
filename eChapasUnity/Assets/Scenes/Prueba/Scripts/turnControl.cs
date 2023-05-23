using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class turnControl : MonoBehaviour
{   
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI turnNumberText;
    public Image turnIndicatorImage;
    public Image turnSquareImage;

    public Color turn1Color;
    public Color turn2Color;

    private int currentTurn;
    private int player1;
    private int player2;

    private float turnDuration = 10f; // Duración de un turno en segundos
    private float turnTimer; // Tiempo restante del turno actual

    private void Start()
    {
        // Inicializar variables y jugadores
        currentTurn = 1;
        player1 = 1;
        player2 = 2;

        // Comenzar el primer turno
        StartTurn();
    }

    private void StartTurn()
    {
        // Reiniciar el temporizador del turno y mostrar el número del turno
        turnTimer = turnDuration;
        turnNumberText.text = "" + currentTurn;

        // Comenzar el temporizador del turno
        InvokeRepeating("UpdateTurnTimer", 0f, 1f);
    }

    private void UpdateTurnTimer()
    {
        // Actualizar el temporizador del turno y mostrarlo en el texto
        turnTimer -= 1f;

        if (turnTimer <= 0f)
        {
            // Finalizar el turno si el tiempo llega a cero
            EndTurn();
        }
        else
        {
            string minutes = Mathf.Floor(turnTimer / 60f).ToString("00");
            string seconds = (turnTimer % 60f).ToString("00");
            timerText.text = "" + minutes + ":" + seconds;
        }
    }

    private void EndTurn()
    {
        // Método para finalizar el turno actual y cambiar al siguiente jugador
        currentTurn = (currentTurn == player1) ? player2 : player1;
        Debug.Log("¡Turno finalizado! Es el turno del Jugador " + currentTurn);

        if (currentTurn == player1)
        {
            turnIndicatorImage.color = turn1Color;
            turnSquareImage.color = turn1Color;
        }
        else if (currentTurn == player2)
        {
            turnIndicatorImage.color = turn2Color;
            turnSquareImage.color = turn2Color;
        }

        // Reiniciar el temporizador para el siguiente turno
        CancelInvoke("UpdateTurnTimer");
        StartTurn();
    }

    public int GetCurrentTurn(){ return currentTurn; }

    private void Update()
    {
        // Lógica del juego y eventos según el turno actual
        if (currentTurn == player1)
        {
            // Es el turno del jugador 1
            // Realizar acciones correspondientes
            // ...
        }
        else if (currentTurn == player2)
        {
            // Es el turno del jugador 2
            // Realizar acciones correspondientes
            // ...
        }
    }
}
