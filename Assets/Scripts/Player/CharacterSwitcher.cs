using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    int currentCharacter = 0;
    public GameObject[] characters;

    PlayerInputManager playerInputManager;

    GameManager gameManager;

    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.playerPrefab = characters[currentCharacter];
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SwitchNextCharacter()
    {
        currentCharacter = (currentCharacter + 1) % characters.Length;
        playerInputManager.playerPrefab = characters[currentCharacter];
    }
}
