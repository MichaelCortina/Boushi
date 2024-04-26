using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameState : MonoBehaviour
{
    [SerializeField] private PlayerState playerState;
    [SerializeField] private GameObject player;

    private static GameState _instance;

    public static PlayerState PlayerState => _instance.playerState;
    public static GameObject Player => _instance.player;

    public static void InitPlayer(GameObject player)
    {
        if (_instance.player == null)
        {
            _instance.player = player;
        }
        else
        {
            Debug.Log("Please do not run this function multiple times or else the game might explode");
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.Log("There are 2 GameState Singletons in the same scene, this is very bad");
        }
        
    }
}
