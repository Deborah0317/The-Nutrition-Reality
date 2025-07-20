using System;
using UnityEngine;
using TMPro;
using Anaglyph.DisplayCapture;

public class Ingrediente : MonoBehaviour
{
    [SerializeField] private GameObject ingredientePopUp;
    [SerializeField] private GameObject DisplayCaptureManagerObject;
    [SerializeField] private TextMeshProUGUI textToChange;
    [SerializeField] private TextMeshProUGUI calToChange;

    private string nomeIngrediente = " ";
    private string numeroCalorie = " ";
    private Dispensa dispensa;

    void Awake()
    {
        // Il Singleton di Dispensa
        dispensa = Dispensa.Instance;
    }

    // Inserisce il nome e le calorie dell'ingrediente nell'ingredientePopUp
    public void setResult(string result)
    {
        Debug.Log($"Ingrediente: setResult() chiamato con input: '{result}'.");
        // Controlla se il risultato è valido
        if (string.IsNullOrEmpty(result))
        {
            Debug.LogWarning("Ingrediente: Risultato di scansione vuoto o nullo.");
            return;
        }

        // Spezzetto la stringa
        char[] delimiters = { ':', '/' };
        string[] parts = result.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length >= 2)
        {
            nomeIngrediente = parts[0].Trim();
            numeroCalorie = parts[1].Trim();
        }
        else
        {
            Debug.LogError($"Ingrediente: Formato risultato non riconosciuto: '{result}'.");
            return;
        }

        Debug.Log($"Ingrediente: - Nome: '{nomeIngrediente}', Calorie: '{numeroCalorie}'.");

        // Aggiorna la GUI
        textToChange.SetText(nomeIngrediente);
        calToChange.SetText(numeroCalorie + " kcal");
        ShowPopUp();
    }

    private void ShowPopUp()
    {
        Debug.Log("Ingrediente: ShowPopUp() chiamato.");

        // Smette temporaneamente di cercare altri ingredienti
        DisplayCaptureManagerObject.SetActive(false);
        ingredientePopUp.SetActive(true);
    }

    // Aggiunge l'ingrediente alla lista nella Dispensa
    public void keepIngredient()
    {
        // Aggiunge alla lista di ingredienti in dispensa, passando sia il nome che le calorie
        dispensa.AddIngredient(nomeIngrediente, numeroCalorie); // AddIngredient ora normalizza internamente
        Debug.Log($"Ingrediente '{nomeIngrediente}' ({numeroCalorie} cal) passato alla dispensa.");
    }
}