using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using UnityEngine.Networking; 

public class StepManager : MonoBehaviour
{
    private Ricetta ricetta;
    private List<string> step;
    private int stepNumber = 0; // Lo step attuale

    // Singleton
    public static StepManager Instance { get; private set; }

    [SerializeField] private GameObject recipePopUp;     // Il popup iniziale che presenta la ricetta
    [SerializeField] private GameObject stepPopUp;       // Il popup per i singoli step di istruzioni
    [SerializeField] private GameObject endPopUp;        // Il popup finale

    [SerializeField] private TextMeshProUGUI titolo; // Titolo ricetta iniziale
    [SerializeField] private TextMeshProUGUI titoloEnd; // Titolo end
    [SerializeField] private TextMeshProUGUI calText; 
    [SerializeField] private TextMeshProUGUI descrizione;
    [SerializeField] private RawImage recipeStartImageDisplay; 
    [SerializeField] private TextMeshProUGUI nomeStep;       
    [SerializeField] private TextMeshProUGUI descrizioneStep; 
    [SerializeField] private TextMeshProUGUI numStep;   
    [SerializeField] private RawImage stepImageDisplay; 
    [SerializeField] private TextMeshProUGUI calTextEnd;     
    [SerializeField] private RawImage recipeEndImageDisplay;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Debug.Log("StepManager: Awake - Singleton inizializzato.");

        // Tutti i popup devono essere disabilitati all'inizio
        if (recipePopUp != null) recipePopUp.SetActive(false);
        if (stepPopUp != null) stepPopUp.SetActive(false);
        if (endPopUp != null) endPopUp.SetActive(false);
    }

    // Questo metodo viene chiamato dalla Dispensa per avviare la visualizzazione di una ricetta
    public void guiRecipe(Ricetta selectedRicetta)
    {
        Debug.Log($"StepManager: Avvio visualizzazione ricetta '{selectedRicetta.nome}'.");

        // Controlla se la ricetta passata è valida
        if (selectedRicetta == null)
        {
            Debug.LogError("StepManager: La ricetta passata è null. Impossibile visualizzare.");
            return;
        }

        ricetta = selectedRicetta;
        step = ricetta.step;
        stepNumber = 0;      

        // Attiva il popup di riepilogo della ricetta e nasconde gli altri
        recipePopUp.SetActive(true);
        Debug.Log("StepManager: Popup riepilogo ricetta attivato.");

        stepPopUp.SetActive(false);
        endPopUp.SetActive(false);

        // Aggiorna la GUI
        titolo.SetText(ricetta.nome);
        descrizione.SetText(ricetta.descrizione);
        calText.SetText(ricetta.calRecipe + " kcal");

        // Carica e mostra l'immagine di inizio ricetta
        Debug.Log($"StepManager: Caricando immagine di inizio ricetta: {ricetta.recipeStartImage}");
        StartCoroutine(LoadImage(ricetta.recipeStartImage, recipeStartImageDisplay));

        Debug.Log("StepManager: Preparato per la ricetta '" + ricetta.nome + "'. Numero di step: " + ricetta.step.Count);
    }

    // Chiamato dal pulsante "Inizia Ricetta" nel recipePopUp.
    public void StartRecipeSteps()
    {
        Debug.Log("StepManager: StartRecipeSteps chiamato. Passando al primo step.");
        if (ricetta == null || ricetta.step == null || ricetta.step.Count == 0)
        {
            Debug.LogWarning("StepManager: Impossibile iniziare gli step. Nessuna ricetta caricata o senza step.");
            hideRecipeOverview();
            return;
        }

        // Nasconde il popup di inizio ricetta
        hideRecipeOverview();
        stepNumber = 0;

        // Mostra il popup del primo step
        stepPopUp.SetActive(true);
        Debug.Log("StepManager: Popup Step attivato (primo step).");

        // Aggiorna la GUI con il primo step
        UpdateCurrentStepUI();
    }

    // Nasconde il popup di inizio ricetta
    public void hideRecipeOverview()
    {
        if (recipePopUp != null)
        {
            recipePopUp.SetActive(false);
            Debug.Log("StepManager: Popup ricetta disattivato.");
            // Pulisce l'immagine di inizio quando il popup viene nascosto
            if (recipeStartImageDisplay != null) recipeStartImageDisplay.texture = null;
        }
    }

    // Nasconde il popup del singolo step
    public void hideStep()
    {
        stepPopUp.SetActive(false);
        Debug.Log("StepManager: Popup Step disattivato.");
        if (stepImageDisplay != null) stepImageDisplay.texture = null;
        
    }

    public void NextStep()
    {
        stepNumber++;

        if (ricetta == null || ricetta.step == null || ricetta.step.Count == 0)
        {
            Debug.LogWarning("StepManager: Nessuna ricetta caricata o step mancanti.");
            return;
        }

        // Se siamo all'ultimo step o oltre
        if (stepNumber >= ricetta.step.Count)
        {
            hideStep(); 
            showEnd();  // Mostra il popup di fine ricetta
            return;
        }

        // Aggiorna la GUI
        UpdateCurrentStepUI();
    }

    public void PreviousStep()
    {
        stepNumber--;

        if (stepNumber < 0) // Se siamo tornati prima del primo step
        {
            stepNumber = 0; // Resetta per sicurezza
            hideStep();
            guiRecipe(ricetta); // Torna al riepilogo della ricetta
            return;
        }

        // Aggiorna la GUI
        UpdateCurrentStepUI();
    }

    // Mando in output la fine della ricetta
    public void showEnd()
    {
        endPopUp.SetActive(true);
        titoloEnd.SetText(ricetta.nome);
        calTextEnd.SetText(ricetta.calRecipe + " kcal");

        // Carica e mostra l'immagine di fine ricetta
        if (!string.IsNullOrEmpty(ricetta.recipeEndImage))
        {
            StartCoroutine(LoadImage(ricetta.recipeEndImage, recipeEndImageDisplay));
        }
        else
        {
            Debug.LogWarning($"StepManager: URL immagine di fine ricetta mancante per '{ricetta.nome}'.");
            recipeEndImageDisplay.texture = null; // Pulisce l'immagine
        }
        }

    // Nasconde il popup finale
    public void hideEnd()
    {
        endPopUp.SetActive(false);
        ricetta = null; // Resetta la ricetta corrente
        stepNumber = 0; 
        // Pulisce l'immagine di fine quando il popup viene nascosto
        recipeEndImageDisplay.texture = null;
        
    }

    // Manda in output il numero dello step corrente
    public void stepCounter()
    {
        if (ricetta != null && ricetta.step != null && ricetta.step.Count > 0)
        {
            numStep.SetText((stepNumber + 1) + "/" + ricetta.step.Count);
        }
        else
        {
            numStep.SetText("N/A"); // Nessuno step da mostrare
            Debug.LogWarning("StepManager: Contatore step non aggiornabile (ricetta o step mancanti).");
        }
    }

    // Coroutine per caricare un'immagine da un URL
    private IEnumerator LoadImage(string url, RawImage targetImage)
    {
        if (targetImage == null)
        {
            Debug.LogError("LoadImage: Target RawImage è null. Impossibile caricare l'immagine.");
            yield break; // Esce dalla coroutine
        }

        Debug.Log($"StepManager: Avvio caricamento immagine da URL: {url}");
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(request);
            targetImage.texture = texture;
            Debug.Log($"StepManager: Immagine caricata con successo da {url}");
        }
        else
        {
            Debug.Log($"StepManager: Non è stato possibile caricare l'immagine {url}");
            targetImage.texture = null;
        }
    }

    // Aggiorna la GUI
    private void UpdateCurrentStepUI()
    {
        if (ricetta == null || ricetta.step == null || stepNumber < 0 || stepNumber >= ricetta.step.Count)
        {
            Debug.LogError($"StepManager: Errore nell'aggiornamento del contenuto dello step.");
            return;
        }

        nomeStep.SetText(ricetta.stepName[stepNumber]);
        descrizioneStep.SetText(ricetta.step[stepNumber]);
        
        // Aggiorna il contatore degli step
        stepCounter();

        // Carica e mostra l'immagine dello step
        if (ricetta.stepImages != null && stepNumber < ricetta.stepImages.Count)
        {
            string imageUrl = ricetta.stepImages[stepNumber];
            if (!string.IsNullOrEmpty(imageUrl))
            {
                StartCoroutine(LoadImage(imageUrl, stepImageDisplay));
            }
            else
            {
                Debug.LogWarning($"StepManager: URL immagine mancante per step {stepNumber} della ricetta '{ricetta.nome}'.");
                stepImageDisplay.texture = null;
            }
        }
        else
        {
            Debug.LogWarning($"StepManager: Lista immagini step mancante o indice ({stepNumber}) fuori limiti per ricetta '{ricetta.nome}'.");
            stepImageDisplay.texture = null;
        }
    }
}