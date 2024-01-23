using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameSet : MonoBehaviour
{
    [SerializeField] private Image characterSprite;
    public InputField playerNameInput;
    [SerializeField]private GameObject System;
    [SerializeField]private GameObject SelectCharacter;

    private CharacterType charaterType;
    public void ClickCharacter()
    {
        System.SetActive(false);
        SelectCharacter.SetActive(true);
    }
    public void ClickSelectCharacter(int index)
    {
        charaterType = (CharacterType)index;
        var character = GameManager.Instance.CharaterList.Find(item => item.CharacterType == charaterType);
        characterSprite.sprite = character.CharacterSprite;
        characterSprite.SetNativeSize();
        SelectCharacter.SetActive(false);
        System.SetActive(true);
    }
    public void StartGame()
    {
        GameManager.Instance.playerName.text = playerNameInput.text;

        if (!string.IsNullOrEmpty(GameManager.Instance.playerName.text))
        {
            
            PlayerPrefs.SetString("PlayerName", GameManager.Instance.playerName.text);

            
        }
        GameManager.Instance.SetCharacter(charaterType, playerNameInput.text);
        Destroy(gameObject);
    }
}
