using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class UploadFile : MonoBehaviour
{
    private string uploadURL = "https://192.168.1.6:5000/upload";  // Questo è corretto

    void Update()
    {
        UploadString("Ciao, sono il client!");
    }
    public void UploadString(string text)
    {
        StartCoroutine(UploadStringCoroutine(text));
    }

    private IEnumerator UploadStringCoroutine(string text)
    {
        UnityWebRequest request = new UnityWebRequest(uploadURL, "POST");

        // Converti la stringa in un array di byte
        byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text);

        // Aggiungi i dati come body della richiesta
        UploadHandlerRaw uploadHandler = new UploadHandlerRaw(textBytes);
        request.uploadHandler = uploadHandler;
        request.downloadHandler = new DownloadHandlerBuffer();

        // Setta il tipo di contenuto come testo
        request.SetRequestHeader("Content-Type", "text/plain");

        // Invia la richiesta
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("String uploaded successfully!");
        }
        else
        {
            Debug.Log("String upload failed: " + request.error);
        }
    }
}