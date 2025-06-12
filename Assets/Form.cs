using System;
using System.Collections;
using TMPro;
using TMPro.Examples;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

public class StartTheGame : MonoBehaviour
{
    string ApplicationName = "Google Sheets API C#";
    string SpreadsheetId = "1Ng16HHB5Z701Gh6Bz6jja2AxWZk7FQ_ceJhgMaRdCWA";
    string SheetName = "Лист1"; // Название вкладки в таблице
    string JsonPath = "hexlet-lead-8c3812279e94.json"; // Файл ключа

    string BOT_TOKEN = "6707889560:AAFBA6d6JrTMzq6JDWjrubUVituAWtRjjtY";
    string user = "5087021054";
    private string url = "https://script.google.com/macros/s/AKfycbzj-UyNxDpOTveW4cjB4EefSNLGJeEzeVxROsSZaHla8VyuLi8PFT62uj-bneyUfjOFLw/exec";
    public TMP_InputField FIO;
    public TMP_InputField Email;
    public TMP_InputField Phone;

    
    public void StartG()
    {
        if (FIO.text != null && Email.text != null && Phone.text != null)
        {
            if (IsValidEmail(Email.text) == true)
            {
                StartCoroutine(StartGame());
            }
        }
    }
    public IEnumerator StartGame()
    {
        StartCoroutine(SendData());
        Debug.Log(url);
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        Debug.Log(request.result);

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator SendData()
    {

        string json = "{\"name\": \"" + FIO.text + "\", \"email\": \"" + Email.text + "\", \"phone\": \"" + Phone.text + "\"}";
        Debug.Log(json);
        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

        UnityWebRequest request = new UnityWebRequest(url, "POST")
        {
            uploadHandler = new UploadHandlerRaw(jsonBytes),
            downloadHandler = new DownloadHandlerBuffer()
        };
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Ответ сервера: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Ошибка! " + request.error);
        }

    }
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            if (Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}