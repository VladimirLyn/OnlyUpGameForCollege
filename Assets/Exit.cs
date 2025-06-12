using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class Exit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ExitTheGame());
    }

    public IEnumerator ExitTheGame()
    {
        Debug.Log("Quit");
        yield return new WaitForSeconds(2f);
        Debug.Log("Quit");
        Application.Quit();
        Debug.Log("Quit");
    }

}
