using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System;
using System.Linq;

public class User : Popup{ 


    private int calTot; //consumate dall'utente
    private string username;
    [SerializeField] private TextMeshProUGUI usernameGUI;
    [SerializeField] private TextMeshProUGUI calorieIngrediente;
    [SerializeField] private TextMeshProUGUI calorieRicetta;
    [SerializeField] private TextMeshProUGUI calTotGUI;
    
//funzione per l'inserimento dal'ingredientePopup
    public void addCalIngrediente() {
        string text = calorieIngrediente.text.Trim();
        calTot += Int32.Parse(text.Where(char.IsDigit).ToArray());
        Debug.Log($"User: Sto passando le calorie dell'ingrediente consumato.{calorieIngrediente.text}");
    }

    public void addCalRicetta()
    {
        string text = calorieRicetta.text.Trim();
        calTot += Int32.Parse(new string(text.Where(char.IsDigit).ToArray()));
        Debug.Log($"User: Sto passando le calorie della ricetta consumata.{calorieIngrediente.text}");
    }

    //funzione per l'inserimento da script
    public void addCal(string cal){		
        calTot += Int32.Parse(cal); 
    }

    public void showCalories(){
        calTotGUI.SetText(calTot.ToString());
    }
    
    public void getUsername(TextMeshProUGUI u) {
        username = u.text;
    }

    public void setUsername(){
        usernameGUI.text = username;
    }

}
