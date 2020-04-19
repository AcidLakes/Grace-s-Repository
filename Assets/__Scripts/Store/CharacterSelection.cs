using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        // Reading how many objects
        characterList = new GameObject[transform.childCount];

        // Fill the array with our models
        for (int i = 0; i < transform.childCount; i++)  

            // Returnes a transform
            characterList[i] = transform.GetChild(i).gameObject;

        // Toggle off renderer
        foreach (GameObject go in characterList)
            go.SetActive(false);

        // Toggle on first index - first character
        if (characterList[index])
            characterList[index].SetActive(true);

    }

    // Selection to the left
    public void ToggleLeft()
    {
        // Toggle off the current model

        characterList[index].SetActive(false);
        // Index = 0 at first
        index--;
        if (index < 0)
            index = characterList.Length - 1; // Brings back to the end of index

        // Toggle on the current model
        characterList[index].SetActive(true);
    }

    // Selection to the right
    public void ToggleRight()
    {
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
            index = 0;

        characterList[index].SetActive(true);
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Level3");
    }
}

