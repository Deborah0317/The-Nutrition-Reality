using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Ricetta
{
    public string nome;
    public List<string> stepName;
    public List<string> step;
    public List<string> stepImages; // Lista di URL delle immagini per ogni step
    public string recipeStartImage;
    public string recipeEndImage;
    public List<string> ingredienti; // Richiesti per questa ricetta
    public string calRecipe;
    public string descrizione;

    public Ricetta(string n, List<string> sn, List<string> s, List<string> i, string cal, string des, List<string> si = null, string startImg = "", string endImg = "")
    {
        nome = n;
        stepName = sn != null ? new List<string>(sn) : new List<string>();
        step = s != null ? new List<string>(s) : new List<string>();
        ingredienti = i != null ? new List<string>(i) : new List<string>();
        calRecipe = cal;
        descrizione = des;
        stepImages = si != null ? new List<string>(si) : new List<string>();
        recipeStartImage = startImg;
        recipeEndImage = endImg;
    }

    // Funzione che controlla se questa ricetta è compatibile con gli ingredienti selezionati dall'utente
    public bool checkIngredients()
    {

        // Ottiene gli ingredienti selezionati dalla dispensa
        List<string> selectedIngredientsFromDispensa = Dispensa.Instance.ingredientsToBeChecked();
        
        if (selectedIngredientsFromDispensa.Count == 0)
        {
            return false;
        }
        
        // Pulisco le stringhe degli ingredienti
        List<string> normalizedRecipeIngredients = new List<string>();
        foreach (string ing in this.ingredienti)
        {
            normalizedRecipeIngredients.Add(ing.Trim().ToLowerInvariant());
        }

        // Il controllo effettivo
        foreach (string selectedIng in selectedIngredientsFromDispensa)
        {
            if (!normalizedRecipeIngredients.Contains(selectedIng))
            {
                // Trovato un ingrediente selezionato dall'utente che QUESTA ricetta NON richiede.
                return false;
            }
        }

        // Se non è uscito dal metodo finora, allora la ricetta contiene gli ingredienti selezionati
        return true; 
    }
}




/*using UnityEngine;
using System.Collections.Generic;

public class Ricetta : MonoBehaviour
{ 
    public string nome;
    public List<string> stepName;
    public List<string> step;
    public List<string> ingredienti;
    public string calRecipe;
    public string descrizione;

//classico costruttore
     public Ricetta(string n, List<string> sn, List<string> s, List<string> i, string cal, string des)
    {
        nome = n;
        stepName = new List<string>(sn);
        step = new List<string>(s);
        ingredienti = new List<string>(i);
        calRecipe = cal;
        descrizione = des;
    }

//funzione che controlla che gli ingredienti siano tutti presenti nella ricetta
    public bool checkIngredients()
    {
        Dispensa dispensa = GameObject.FindObjectOfType<Dispensa>();
        int flag = 0; //flag = 1 -> ingrediente presente nella ricetta. flag = -1 -> ingrediente non presente nella ricetta
        foreach (string i in dispensa.ingredientsToBeChecked())
        {    //per ogni ingrediente in dispensa
            if (flag == -1) { return false; }     //qualche ingrediente in dispensa non fa parte della ricetta in questione
            flag = 0;
            while (flag == 0)
            {
                foreach (string ig in ingredienti)
                {  //per ogni ingrediente nella ricetta
                    if (i == ig) { flag = 1; break; }      //se l'ingrediente è stato trovato tra quelli della ricetta passo all'ingrediente successivo della dispensa
                }
                flag = -1;
            }
        }
        return true;   //tutti gli ingredienti selezionati fanno parte della ricetta
    }
}*/