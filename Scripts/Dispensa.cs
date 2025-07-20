using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO; 
using TMPro;
using System.Linq;

public class Dispensa : Popup
{
    // Struttura per un ingrediente
    [System.Serializable]
    public struct Ingredient
    {
        public string name;
        public string cal; // Calorie dell'ingrediente

        // Costruttore per facilitare la creazione di nuovi ingredienti
        public Ingredient(string name, string cal)
        {
            this.name = name;
            this.cal = cal;
        }
    }

    // Classe contenitore per serializzare la lista di ingredienti
    // JsonUtility non può serializzare direttamente liste, quindi serve un wrapper.
    [System.Serializable]
    private class IngredientDataWrapper
    {
        public List<Ingredient> ingredients;
    }

    private List<Ingredient> ingredients = new List<Ingredient>(); // Ingredienti trovati dalla scansione
    private List<string> recipeIngredients = new List<string>(); // Ingredienti che vengono controllati per le ricette
    private int page; // Pagina delle ricette che sto mandando in output al momento
    private List<Ricetta> recipesWithIngredients = new List<Ricetta>(); // Ricette che possono essere create con gli ingredienti attuali
    private int recipeTot = 0; // Contatore delle ricette che hanno gli ingredienti disponibili
    private int selected; // Variabile per capire quale ingrediente sto selezionando [0,5]

    // GUI
    [SerializeField] private List<TextMeshProUGUI> nomeRicetta = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> calRicetta = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> nomeIngrediente = new List<TextMeshProUGUI>(); // NomiIngredienti
    [SerializeField] private List<TextMeshProUGUI> calIngrediente = new List<TextMeshProUGUI>(); // CalIngredienti
    [SerializeField] private List<Toggle> bottoneIngrediente = new List<Toggle>(); // BottoniIngredienti
    [SerializeField] private List<GameObject> ingredientGUI = new List<GameObject>(); // Sezione complessiva dell'ingrediente
    [SerializeField] private List<GameObject> recipeGUI = new List<GameObject>(); // Sezione complessiva della ricetta
    [SerializeField] private GameObject overloadPopup; // Popup per quando ci sono troppi ingredienti
    [SerializeField] private GameObject DisplayCaptureManagerObject; // Per fermare la cattura dello schermo

    // Singleton
    public static Dispensa Instance { get; private set; }
    private readonly string saveFileName = "dispensa_data.json"; // File di salvataggio

    private void Awake()
    {
        Debug.Log("Dispensa: Awake - Inizializzazione Singleton.");
        // Se un'altra istanza esiste già e non è questa, distruggi questa istanza per mantenere un unico singleton.
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Dispensa: Trovata un'altra istanza. Distruggo questa.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Debug.Log("Dispensa: Singleton istanza impostata.");

        LoadData(); // Carica gli ingredienti già in memoria
    }

    public void Start()
    {
        // Disattiva gli elementi grafici non assegnati
        for (int c = 0; c < 5; c++)
        {
            if (c < ingredientGUI.Count) ingredientGUI[c].SetActive(false);
            if (c < recipeGUI.Count) recipeGUI[c].SetActive(false);
        }
        Output(); // Aggiorna la GUI con i dati caricati
    }

    public void showOverload()
    {
        // Smette temporaneamente di cercare altri ingredienti
        DisplayCaptureManagerObject.SetActive(false);
        overloadPopup.SetActive(true);
    }

    // Aggiunge un ingrediente alla lista
    public void AddIngredient(string nomeIngrediente, string calorieIngrediente)
    {
        Debug.Log($"Dispensa: Tentativo di aggiungere ingrediente: '{nomeIngrediente}'.");

        // Pulizia stringa risultato ingrediente
        string normalizedName = nomeIngrediente.Trim().ToLowerInvariant();  // Trim() rimuove gli spazi

        // Verifica se l'ingrediente è già presente nella dispensa
        if (ingredients.Exists(i => i.name == normalizedName))
        {
            Debug.Log($"Dispensa: Ingrediente '{normalizedName}' è già presente in dispensa. Non aggiunto nuovamente.");
            Output();
            return; // Esci se l'ingrediente è un duplicato
        }

        if (ingredients.Count < 6) // Controllo se ci sono troppi ingredienti (limite 6 per la GUI)
        {
            Ingredient i = new Ingredient(normalizedName, calorieIngrediente);
            ingredients.Add(i); // Aggiunge l'ingrediente scansionato alla lista
            SaveData(); // Salva i dati dopo aver aggiunto un ingrediente

            Debug.Log($"Dispensa: Ingrediente '{normalizedName}' aggiunto alla lista 'ingredients'. Numero ingredienti in dispensa: {ingredients.Count}.");

            // Pulisce la lista recipesWithIngredients della dispensa per prepararla al ricalcolo
            recipesWithIngredients.Clear();
            recipeTot = 0;
            RicetteManager.Instance.UpdateDispensaWithAvailableRecipes();
        }
        else
        {
            Debug.Log("Dispensa: Troppi ingredienti, impossibile aggiungere " + nomeIngrediente);
            showOverload(); // Mostra il popup di sovraccarico
        }
    }

    // L'utente rimuove un ingrediente dalla GUI
    public void RemoveIngredient(int guiIndex)
    {
        Debug.Log($"Dispensa: Tentativo di rimuovere ingrediente all'indice GUI: {guiIndex}");
        string removedIngredientName = ingredients[guiIndex].name;
        ingredients.RemoveAt(guiIndex);
        for (int i = 0; i < 6; i++) bottoneIngrediente[i].isOn = false; //Deseleziona tutto anche nella GUI
        recipeIngredients.Clear(); // Deseleziona tutti gli ingredienti quando ne elimina uno
        SaveData();

        // Pulisco il ricetteManager
        Debug.Log($"Dispensa: Ingrediente '{removedIngredientName}' rimosso da 'ingredients'. Numero ingredienti in dispensa: {ingredients.Count}.");
        recipesWithIngredients.Clear(); 
        recipeTot = 0;
        Debug.Log("Dispensa: Lista recipesWithIngredients pulita.");
        RicetteManager.Instance.UpdateDispensaWithAvailableRecipes();
    }

    // Aggiorna tutti i valori grafici della Dispensa
    public void Output()
    {
        Debug.Log("Dispensa: Eseguo Output() per aggiornare GUI.");
        printIngredient();
        printRecipes();
    }

    // Stampa gli ingredienti nella GUI
    public void printIngredient()
    {
        Debug.Log($"Dispensa: printIngredient() - Tentativo di stampare {ingredients.Count} ingredienti.");
        // Disattiva tutti gli elementi GUI degli ingredienti prima di ripopolarli
        for (int c = 0; c < ingredientGUI.Count; c++)
        {
             ingredientGUI[c].SetActive(false);
        }

        // Popola gli elementi GUI con gli ingredienti attuali
        for (int c = 0; c < ingredients.Count && c < ingredientGUI.Count; c++)
        {
                ingredientGUI[c].SetActive(true);
                nomeIngrediente[c].SetText(ingredients[c].name); // Qui usiamo il nome normalizzato che abbiamo salvato
                calIngrediente[c].SetText(ingredients[c].cal + " kcal");
        }
        Debug.Log($"Dispensa: printIngredient() - Stampati {ingredients.Count} ingredienti sulla GUI.");
    }

    // Stampa le ricette nella GUI
    public void printRecipes()
    {
        // Disattiva tutti gli elementi GUI delle ricette prima di ripopolarli
        for (int r = 0; r < recipeGUI.Count; r++)
        {
            recipeGUI[r].SetActive(false);
        }

        PageManager pageM = PageManager.Instance; // Singleton di PageManager

        pageM.pageManager(recipeTot, 5); // Assumo che '5' sia il numero di ricette per pagina
        page = pageM.getPage(); // Il pageManager si occupa di dirmi in quale pagina sono
        Debug.Log($"Dispensa: PageManager calcola pagina {page}, ricette totali per paginazione: {recipeTot}.");

        int displayedRecipeCount = 0; // Contatore per quante ricette stiamo mostrando in questa pagina
        // Itera attraverso le ricette da visualizzare nella pagina corrente
        for (int rt = page * 5; rt < recipesWithIngredients.Count && displayedRecipeCount < 5; rt++)
        {
            // Controllo che l'indice rt sia valido per recipesWithIngredients e displayedRecipeCount per recipeGUI
            if (rt >= 0 && displayedRecipeCount < recipeGUI.Count)
            {
                recipeGUI[displayedRecipeCount].SetActive(true);
                nomeRicetta[displayedRecipeCount].SetText(recipesWithIngredients[rt].nome);
                calRicetta[displayedRecipeCount].SetText(recipesWithIngredients[rt].calRecipe + " kcal");
                displayedRecipeCount++;
                Debug.Log($"Dispensa: Stampato ricetta '{recipesWithIngredients[rt].nome}' all'indice GUI {displayedRecipeCount - 1}.");
            }
            else
            {
                Debug.LogWarning($"Dispensa: Indicizzazione fuori limiti in printRecipes. rt: {rt}, displayedRecipeCount: {displayedRecipeCount}.recipesWithIngredients.Count: {recipesWithIngredients.Count}, recipeGUI.Count: {recipeGUI.Count}");
                break; 
            }
        }
        Debug.Log($"Dispensa: printRecipes() - Fine. Stampate {displayedRecipeCount} ricette sulla GUI per la pagina {page}.");
    }

    // Aggiunge una ricetta alla lista delle ricette disponibili
    public void addRecipe(Ricetta R)
    {
        // Controlliamo se la ricetta è già presente per evitare duplicati.
        if (!recipesWithIngredients.Exists(rec => rec.nome == R.nome))
        {
            recipesWithIngredients.Add(R); // Usa Add() per aggiungere elementi a una lista
            recipeTot = recipesWithIngredients.Count; // Aggiorna il contatore totale
            Debug.Log($"Dispensa: Aggiunta ricetta '{R.nome}' alla lista recipesWithIngredients. Totale: {recipesWithIngredients.Count}");
        }
        else
        {
            Debug.Log($"Dispensa: Ricetta '{R.nome}' già presente nella lista di ricette disponibili. Non aggiunta nuovamente.");
        }
    }

    // La funzione che restituisce gli ingredienti da controllare per le ricette
    public List<string> ingredientsToBeChecked()
    {
        return recipeIngredients;
    }

    // La funzione che controlla se un ingrediente è selezionato/deselezionato
    public void ingredientsSelection(int s)
    {
        string selectedIngredientNameGUI = nomeIngrediente[s].text;
        Debug.Log($"Dispensa: Nome ingrediente originale dalla GUI: '{selectedIngredientNameGUI}'. Indice: {s}");

        // Pulizia stringa del nome ingrediente selezionato
        string normalizedSelectedIngredientName = selectedIngredientNameGUI.Trim().ToLowerInvariant();

        // Controlla se l'ingrediente è già stato selezionato
        if (recipeIngredients.Contains(normalizedSelectedIngredientName))
        {
            // Se già presente lo deseleziona
            recipeIngredients.Remove(normalizedSelectedIngredientName);
            Debug.Log($"Dispensa: Deselezionato ingrediente: '{normalizedSelectedIngredientName}'.");
        }
        else
        {
            // Se non presente, lo seleziona
            recipeIngredients.Add(normalizedSelectedIngredientName);
            Debug.Log($"Dispensa: Selezionato ingrediente: '{normalizedSelectedIngredientName}'.");
        }

        // Il RicetteManager aggiorna le ricette disponibili in base alla selezione
        Debug.Log("Dispensa: Chiamo RicetteManager per ricalcolare ricette dopo selezione/deselezione.");
        recipesWithIngredients.Clear();
        recipeTot = 0;
        Debug.Log("Dispensa: Lista recipesWithIngredients pulita.");
        RicetteManager.Instance.UpdateDispensaWithAvailableRecipes(); // Chiede al RicetteManager di ripopolarla
    }

    // Fa partire la ricetta selezionata
    public void startRecipe(int s)
    {
        Debug.Log($"Dispensa: startRecipe() - Indice ricetta selezionata: {s}.");

        // Recupera l'oggetto Ricetta dalla lista
        Ricetta selectedRicetta = recipesWithIngredients[s];
        Debug.Log($"Dispensa: Avvio ricetta '{selectedRicetta.nome}'.");

        StepManager stepManager = GameObject.FindObjectOfType<StepManager>(); // Che si occupa di gestire gli step della ricetta
        stepManager.guiRecipe(selectedRicetta);
    }

    // Questo metodo sarà chiamato dai pulsanti freccia nella GUI
    public void ChangeRecipePage(int move)
    {
        PageManager.Instance.changePage(move); // Chiede al PageManager di cambiare pagina
        Output(); // Output della nuova pagina
        Debug.Log("Dispensa: Pagina ricette cambiata e GUI aggiornata.");
    }


    // --- Metodi di salvataggio e caricamento dei dati ---
    private void SaveData()
    {
        // Crea un wrapper per la lista di ingredienti
        IngredientDataWrapper dataWrapper = new IngredientDataWrapper { ingredients = this.ingredients };
        string json = JsonUtility.ToJson(dataWrapper, true); // true per un output JSON leggibile

        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            File.WriteAllText(filePath, json);
            Debug.Log("Dispensa: Dati della Dispensa salvati su: " + filePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Dispensa: Errore durante il salvataggio dei dati della Dispensa: " + e.Message);
        }
    }

    private void LoadData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);
        Debug.Log($"Dispensa: Tentativo di caricare dati da: {filePath}");

        if (File.Exists(filePath))
        {
            try
            {
                string json = File.ReadAllText(filePath);
                IngredientDataWrapper dataWrapper = JsonUtility.FromJson<IngredientDataWrapper>(json);
                if (dataWrapper != null && dataWrapper.ingredients != null)
                {
                    this.ingredients = dataWrapper.ingredients;
                    Debug.Log("Dispensa: Dati della Dispensa caricati con successo. Numero ingredienti: " + this.ingredients.Count);
                }
                else
                {
                    Debug.LogWarning("Dispensa: File di salvataggio della Dispensa vuoto o corrotto. Inizializzazione nuova lista.");
                    this.ingredients = new List<Ingredient>();
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Dispensa: Errore durante il caricamento dei dati della Dispensa: " + e.Message);
                this.ingredients = new List<Ingredient>(); // Inizializza una lista vuota in caso di errore
            }
        }
        else
        {
            Debug.Log("Dispensa: File di salvataggio della Dispensa non trovato. Inizializzazione nuova lista.");
            this.ingredients = new List<Ingredient>();
        }
    }
}