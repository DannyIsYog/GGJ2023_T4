using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    int currentCharacter = 0;
    public GameObject[] characters;

    PlayerInputManager playerInputManager;

    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.playerPrefab = characters[currentCharacter];
    }

    public void SwitchNextCharacter()
    {
        currentCharacter = (currentCharacter + 1) % characters.Length;
        playerInputManager.playerPrefab = characters[currentCharacter];
    }
}
