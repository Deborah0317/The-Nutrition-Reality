using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class RicetteManager : MonoBehaviour
{
    private List<Ricetta> ricettario = new List<Ricetta>();

    // Singleton
    public static RicetteManager Instance { get; private set; }

    void Awake()
    {
        // Nel caso c'è un'altra instanza
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Carica tutte le ricette da RicetteData.
        ricettario = RicetteData.GetAllRecipes();
        Debug.Log("RicetteManager: Caricate " + ricettario.Count + " ricette totali dal database.");
    }

    // Aggiorna la lista delle ricette
    public void UpdateDispensaWithAvailableRecipes()
    {
        foreach (Ricetta r in ricettario)
        { // Controllo ogni ricetta del ricettario per vericare se compatibile con gli ingredienti selezionati
            if (r.checkIngredients())
            {
                Dispensa.Instance.addRecipe(r);
            }
        }
        Debug.Log("RicetteManager: Aggiornata la Dispensa con le ricette disponibili.");
        Dispensa.Instance.Output(); // Richiama Output() per aggiornare la GUI della dispensa.
    }

    // output di tutte le ricette
    public List<Ricetta> getRecipes()
    {
        return ricettario;
    }
}


/*using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class RicetteManager : MonoBehaviour
{
    private List<Ricetta> ricettario = new List<Ricetta>(); //raccolta totale delle ricette

    //output delle ricette disponibili
    public List<Ricetta> getRecipes()
    {
        return ricettario;
    }

    //restituisce le ricette che comprendono gli ingredienti selezionati
    private void recipesWithIngredients()
    {
        Dispensa dispensa = GameObject.FindObjectOfType<Dispensa>();
        foreach (Ricetta r in ricettario)
        {
            if (r.checkIngredients() == true) //fa riferimento al metodo della classe Ricetta
            {
                dispensa.addRecipe(r);
            }
        }
    }
}*/