using System.Collections.Generic;
using UnityEngine; // Per Debug.Log

public static class RicetteData
{
    public static List<Ricetta> GetAllRecipes()
    {
        Debug.Log("RicetteData: Inizio caricamento di tutte le ricette predefinite.");
        List<Ricetta> recipes = new List<Ricetta>();

        // --- Ricetta 1: Pollo Arrosto con Mela Caramellata ---
        List<string> polloArrostoStepNames = new List<string>
        {
            "Step 1: Prepara il pollo",
            "Step 2: Prepara mele e cipolle",
            "Step 3: Inforna",
            "Step 4: Caramella le mele",
            "Step 5: Servi"
        };
        List<string> polloArrostoSteps = new List<string>
        {
            "Preriscalda il forno a 200°C. Lava il pollo e asciugalo bene con carta da cucina. Massaggia il pollo con olio d'oliva, sale, pepe, rosmarino, timo e aglio tritato.",
            "Taglia le mele a spicchi spessi e le cipolle rosse a fette. In una ciotola, mescola le mele e le cipolle con 1 cucchiaio di olio d'oliva e 1 cucchiaio di zucchero di canna.",
            "Posiziona il pollo in una teglia da forno. Distribuisci le mele e le cipolle intorno al pollo. Inforna per circa 1 ora e 30 minuti, o finché il pollo non è dorato e cotto a fondo (la temperatura interna dovrebbe essere di 74°C). A metà cottura, puoi spennellare il pollo con i succhi della teglia.",
            "Negli ultimi 15 minuti di cottura, se le mele non sono abbastanza caramellate, puoi spolverarle con il rimanente zucchero di canna.",
            "Togli il pollo dal forno e lascialo riposare per 10 minuti prima di affettarlo. Servi con le mele e le cipolle caramellate."
        };
        List<string> polloArrostoStepImages = new List<string>
        {
            "https://picsum.photos/id/200/600/400", // Carne
            "https://picsum.photos/id/201/600/400", // Frutta/Verdura
            "https://picsum.photos/id/202/600/400", // Cottura/Forno
            "https://picsum.photos/id/203/600/400", // Dettaglio cibo
            "https://picsum.photos/id/204/600/400"  // Piatto Servito
        };
        string polloArrostoStartImage = "https://picsum.photos/id/205/600/400"; // Piatto principale
        string polloArrostoEndImage = "https://picsum.photos/id/206/600/400";     // Piatto finale
        List<string> polloArrostoIngredienti = new List<string>
        {
            "Pollo", "Mela", "Cipolla", "Zucchero", "Rosmarino", "Timo", "Aglio", "Olio", "Sale", "Pepe"
        };
        recipes.Add(new Ricetta(
            "Pollo Arrosto con Mela Caramellata",
            polloArrostoStepNames,
            polloArrostoSteps,
            polloArrostoIngredienti,
            "650",
            "Pollo intero succulento, arrostito alla perfezione, accompagnato da mele dolci e cipolle caramellate. Un connubio di sapori agrodolci irresistibile.",
            polloArrostoStepImages,
            polloArrostoStartImage,
            polloArrostoEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");


        // --- Ricetta 2: Torta di Mela Semplice ---
        List<string> tortaMeleStepNames = new List<string>
        {
            "Step 1: Prepara la tortiera e le mele",
            "Step 2: Prepara l'impasto",
            "Step 3: Aggiungi le mele all'impasto",
            "Step 4: Inforna la torta",
            "Step 5: Servi la torta"
        };
        List<string> tortaMeleSteps = new List<string>
        {
            "Preriscalda il forno a 180°C. Imburra e infarina una tortiera da 24 cm di diametro. Sbuccia le mele, togli il torsolo e tagliale a cubetti o a fettine sottili.",
            "In una ciotola capiente, sbatti le uova con lo zucchero fino a ottenere un composto chiaro e spumoso. Aggiungi il latte e l'olio, mescolando bene. Incorpora gradualmente la farina setacciata con il lievito, la scorza di limone grattugiata e la cannella (se la usi). Mescola fino ad ottenere un impasto liscio e omogeneo.",
            "Incorpora delicatamente i pezzi di mela all'impasto.",
            "Versa l'impasto nella tortiera preparata. Inforna per circa 40-45 minuti, o finché la torta non sarà dorata e, inserendo uno stuzzicadenti, questo uscirà pulito.",
            "Sforna la torta e lasciala raffreddare. Prima di servire, spolvera con zucchero a velo."
        };
        List<string> tortaMeleStepImages = new List<string>
        {
            "https://picsum.photos/id/211/600/400", // Frutta
            "https://picsum.photos/id/212/600/400", // Ingredienti
            "https://picsum.photos/id/213/600/400", // Miscelazione
            "https://picsum.photos/id/214/600/400", // Forno
            "https://picsum.photos/id/215/600/400"  // Dolce
        };
        string tortaMeleStartImage = "https://picsum.photos/id/216/600/400"; // Dolce
        string tortaMeleEndImage = "https://picsum.photos/id/217/600/400";     // Dolce
        List<string> tortaMeleIngredienti = new List<string>
        {
            "Mela", "Farina", "Zucchero", "Uovo", "Latte", "Olio", "Lievito", "Limone", "Cannella"
        };
        recipes.Add(new Ricetta(
            "Torta di Mela Semplice",
            tortaMeleStepNames,
            tortaMeleSteps,
            tortaMeleIngredienti,
            "300",
            "Una torta soffice e profumata, con pezzi di mela dolce e un tocco di cannella. Perfetta per la colazione o la merenda.",
            tortaMeleStepImages,
            tortaMeleStartImage,
            tortaMeleEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");


        // --- Ricetta 3: Curry di Pollo e Verdura ---
        List<string> curryPolloStepNames = new List<string>
        {
            "Step 1: Prepara gli ingredienti",
            "Step 2: Soffriggi aromi e curry",
            "Step 3: Aggiungi pollo e verdure",
            "Step 4: Lessa con latte di cocco",
            "Step 5: Completa e servi"
        };
        List<string> curryPolloSteps = new List<string>
        {
            "Taglia il petto di pollo a cubetti. Trita finemente la cipolla e l'aglio. Grattugia lo zenzero. Taglia il peperone e la zucchina a cubetti.",
            "In una pentola capiente o wok, scalda l'olio d'oliva. Aggiungi la cipolla e falla appassire per 5 minuti. Aggiungi l'aglio e lo zenzero, cuocendo per un altro minuto. Aggiungi il curry in polvere e cuoci per 30 secondi, mescolando.",
            "Aggiungi il pollo a cubetti e cuocilo fino a quando non è dorato su tutti i lati. Aggiungi il peperone e la zucchina, cuocendo per altri 5 minuti.",
            "Versa il latte di cocco, il brodo vegetale e la passata di pomodoro. Porta a ebollizione, poi abbassa la fiamma, copri e lascia sobbollire per 15-20 minuti, o finché il pollo non è cotto e le verdure tenere.",
            "Negli ultimi 5 minuti di cottura, aggiungi gli spinaci e mescola finché non appassiscono. Regola di sale e pepe. Servi caldo, guarnito con coriandolo fresco, magari con un contorno di riso basmati."
        };
        List<string> curryPolloStepImages = new List<string>
        {
            "https://themom100.com/wp-content/uploads/2016/01/cubing-chicken-022.jpg",
            "https://thumbs.dreamstime.com/b/fried-onions-pan-cooking-ingredient-210012828.jpg",
            "https://tse1.mm.bing.net/th?id=OIP.hnwWd-jVWeABbhUnwpJ6WgHaHa&r=0&pid=Api",
            "https://img.freepik.com/premium-photo/woman-pours-milk-from-jug-into-pan-making-cream-pie-her-home-kitchen_117406-3507.jpg",
            "https://tse3.mm.bing.net/th?id=OIP.A2gsvW6bFPu0RkfCVKutRwHaE8&pid=Api"
        };
        string curryPolloStartImage = "https://tse3.mm.bing.net/th?id=OIP.fAALY_48gpbg69U6OlDWsAHaE8&pid=Api";
        string curryPolloEndImage = "https://tse2.mm.bing.net/th?id=OIP.rcWMwbnrBt4FF9zVxE25MAAAAA&pid=Api";
        List<string> curryPolloIngredienti = new List<string>
        {
            "Pollo", "Cipolla", "Aglio", "Zenzero", "Curry", "Latte di cocco",
            "Brodo", "Pomodoro", "Peperone", "Zucchina", "Spinaci",
            "Olio", "Sale", "Pepe", "Coriandolo"
        };
        recipes.Add(new Ricetta(
            "Curry di Pollo e Verdura",
            curryPolloStepNames,
            curryPolloSteps,
            curryPolloIngredienti,
            "500",
            "Un curry ricco e cremoso con bocconcini di pollo teneri e verdure miste, perfetto da servire con riso basmati.",
            curryPolloStepImages,
            curryPolloStartImage,
            curryPolloEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");


        // --- Ricetta 4: Pasta al Pomodoro e Basilico ---
        List<string> pastaPomodoroStepNames = new List<string>
        {
            "Step 1: Fai bollire l'acqua",
            "Step 2: Prepara il sugo",
            "Step 3: Cuoci la pasta e uniscila al sugo",
            "Step 4: Servi"
        };
        List<string> pastaPomodoroSteps = new List<string>
        {
            "Fai bollire abbondante acqua salata in una pentola.",
            "Nel frattempo, in una padella, scalda un filo d'olio d'oliva con l'aglio tritato. Aggiungi la passata di pomodoro e un pizzico di sale. Lascia cuocere a fuoco medio-basso per 15-20 minuti.",
            "Cuoci la pasta seguendo le istruzioni sulla confezione. Scolala al dente e versala direttamente nella padella con il sugo.",
            "Aggiungi le foglie di basilico fresco e mescola bene. Servi subito, guarnindo con altro basilico fresco."
        };
        List<string> pastaPomodoroStepImages = new List<string>
        {
            "https://picsum.photos/id/225/600/400", // Pentola
            "https://picsum.photos/id/226/600/400", // Pomodori/Sugo
            "https://picsum.photos/id/227/600/400", // Pasta
            "https://picsum.photos/id/228/600/400"  // Piatto di Pasta
        };
        string pastaPomodoroStartImage = "https://picsum.photos/id/229/600/400";
        string pastaPomodoroEndImage = "https://picsum.photos/id/230/600/400";
        List<string> pastaPomodoroIngredienti = new List<string>
        {
            "Pasta", "Pomodoro", "Basilico", "Aglio", "Olio", "Sale"
        };
        recipes.Add(new Ricetta(
            "Pasta al Pomodoro e Basilico",
            pastaPomodoroStepNames,
            pastaPomodoroSteps,
            pastaPomodoroIngredienti,
            "350",
            "Un classico della cucina italiana: pasta con un sugo di pomodoro fresco e profumato, arricchito dal basilico.",
            pastaPomodoroStepImages,
            pastaPomodoroStartImage,
            pastaPomodoroEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        // --- Ricetta 5: Risotto ai Funghi ---
        List<string> risottoFunghiStepNames = new List<string>
        {
            "Step 1: Tosta il riso",
            "Step 2: Aggiungi il brodo",
            "Step 3: Prepara i funghi e aggiungili",
            "Step 4: Manteca e servi"
        };
        List<string> risottoFunghiSteps = new List<string>
        {
            "In una casseruola, tosta il riso con un filo d'olio. Sfuma con il vino bianco (se usato).",
            "Aggiungi un mestolo di brodo caldo alla volta, mescolando continuamente, finché il brodo non viene assorbito. Continua così per circa 15-18 minuti.",
            "Nel frattempo, salta i funghi affettati con aglio e prezzemolo in un'altra padella. Aggiungili al risotto a metà cottura.",
            "A fine cottura, spegni il fuoco e manteca il risotto con burro e parmigiano. Lascia riposare qualche minuto prima di servire."
        };
        List<string> risottoFunghiStepImages = new List<string>
        {
            "https://picsum.photos/id/231/600/400", // Riso
            "https://picsum.photos/id/232/600/400", // Brodo/Mestolo
            "https://picsum.photos/id/233/600/400", // Funghi
            "https://picsum.photos/id/234/600/400"  // Piatto Cremoso
        };
        string risottoFunghiStartImage = "https://picsum.photos/id/235/600/400";
        string risottoFunghiEndImage = "https://picsum.photos/id/236/600/400";
        List<string> risottoFunghiIngredienti = new List<string>
        {
            "Riso", "Fungo", "Brodo", "Cipolla", "Aglio", "Prezzemolo", "Burro", "Parmigiano", "Olio", "Sale", "Pepe", "Vino"
        };
        recipes.Add(new Ricetta(
            "Risotto ai Funghi",
            risottoFunghiStepNames,
            risottoFunghiSteps,
            risottoFunghiIngredienti,
            "450",
            "Un risotto cremoso e saporito, arricchito dal gusto terroso dei funghi.",
            risottoFunghiStepImages,
            risottoFunghiStartImage,
            risottoFunghiEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        // --- Ricetta 6: Insalata di Tonno e Fagiolo ---
        List<string> insalataTonnoFagioloStepNames = new List<string>
        {
            "Step 1: Prepara tonno e fagioli",
            "Step 2: Aggiungi verdure",
            "Step 3: Condisci e servi"
        };
        List<string> insalataTonnoFagioloSteps = new List<string>
        {
            "Scola il tonno sott'olio e sgranalo in una ciotola. Sciacqua bene i fagioli in scatola sotto acqua corrente.",
            "Aggiungi i fagioli scolati al tonno. Trita finemente la cipolla rossa e il prezzemolo e aggiungili alla ciotola.",
            "Condisci con olio d'oliva, sale e pepe. Mescola bene e servi fredda."
        };
        List<string> insalataTonnoFagioloStepImages = new List<string>
        {
            "https://picsum.photos/id/237/600/400", // Scatolette/Ingredienti
            "https://picsum.photos/id/238/600/400", // Verdure Fresche
            "https://picsum.photos/id/239/600/400"  // Insalata
        };
        string insalataTonnoFagioloStartImage = "https://picsum.photos/id/240/600/400";
        string insalataTonnoFagioloEndImage = "https://picsum.photos/id/241/600/400";
        List<string> insalataTonnoFagioloIngredienti = new List<string>
        {
            "Tonno", "Fagiolo", "Cipolla", "Prezzemolo", "Olio", "Sale", "Pepe"
        };
        recipes.Add(new Ricetta(
            "Insalata di Tonno e Fagiolo",
            insalataTonnoFagioloStepNames,
            insalataTonnoFagioloSteps,
            insalataTonnoFagioloIngredienti,
            "280",
            "Un'insalata leggera e proteica, perfetta per un pranzo veloce o una cena estiva.",
            insalataTonnoFagioloStepImages,
            insalataTonnoFagioloStartImage,
            insalataTonnoFagioloEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        // --- Ricetta 7: Polpette al Sugo ---
        List<string> polpetteSugoStepNames = new List<string>
        {
            "Step 1: Prepara l'impasto e forma le polpette",
            "Step 2: Rosola le polpette",
            "Step 3: Cuoci nel sugo",
            "Step 4: Servi"
        };
        List<string> polpetteSugoSteps = new List<string>
        {
            "In una ciotola, mescola la carne macinata con l'uovo, il pane grattugiato, il prezzemolo tritato, il parmigiano, l'aglio tritato, sale e pepe. Forma delle piccole polpette.",
            "In una padella, scalda un filo d'olio e rosola le polpette su tutti i lati finché non sono dorate.",
            "Aggiungi la passata di pomodoro, un pizzico di zucchero e lascia sobbollire a fuoco basso per circa 20-25 minuti, o finché le polpette non sono cotte.",
            "Servi le polpette calde con il loro sugo, magari accompagnate da purè di patate o pane fresco."
        };
        List<string> polpetteSugoStepImages = new List<string>
        {
            "https://picsum.photos/id/242/600/400", // Carne Macinata
            "https://picsum.photos/id/243/600/400", // Padella
            "https://picsum.photos/id/244/600/400", // Salsa
            "https://picsum.photos/id/245/600/400"  // Piatto con Polpette
        };
        string polpetteSugoStartImage = "https://picsum.photos/id/246/600/400";
        string polpetteSugoEndImage = "https://picsum.photos/id/247/600/400";
        List<string> polpetteSugoIngredienti = new List<string>
        {
            "Carne", "Uovo", "Pane", "Prezzemolo", "Parmigiano", "Aglio", "Pomodoro", "Zucchero", "Olio", "Sale", "Pepe"
        };
        recipes.Add(new Ricetta(
            "Polpette al Sugo",
            polpetteSugoStepNames,
            polpetteSugoSteps,
            polpetteSugoIngredienti,
            "580",
            "Le classiche polpette al sugo, morbide e saporite, un secondo piatto amato da tutti.",
            polpetteSugoStepImages,
            polpetteSugoStartImage,
            polpetteSugoEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        // --- Ricetta 8: Zuppa di Verdura ---
        List<string> zuppaVerduraStepNames = new List<string>
        {
            "Step 1: Taglia le verdure",
            "Step 2: Cuoci la zuppa",
            "Step 3: Servi"
        };
        List<string> zuppaVerduraSteps = new List<string>
        {
            "Lava e taglia a cubetti tutte le verdure (carota, zucchina, patata, sedano, cipolla).",
            "In una pentola capiente, scalda un filo d'olio e fai soffriggere la cipolla. Aggiungi le altre verdure e il brodo vegetale. Porta a ebollizione, poi abbassa la fiamma e lascia cuocere per 25-30 minuti, o finché le verdure non sono tenere.",
            "Regola di sale e pepe. Servi calda, magari con crostini di pane."
        };
        List<string> zuppaVerduraStepImages = new List<string>
        {
            "https://picsum.photos/id/248/600/400", // Verdure Varie
            "https://picsum.photos/id/249/600/400", // Pentola che Bolle
            "https://picsum.photos/id/250/600/400"  // Ciotola di Zuppa
        };
        string zuppaVerduraStartImage = "https://picsum.photos/id/251/600/400";
        string zuppaVerduraEndImage = "https://picsum.photos/id/252/600/400";
        List<string> zuppaVerduraIngredienti = new List<string>
        {
            "Carota", "Zucchina", "Patata", "Sedano", "Cipolla", "Brodo", "Olio", "Sale", "Pepe"
        };
        recipes.Add(new Ricetta(
            "Zuppa di Verdura",
            zuppaVerduraStepNames,
            zuppaVerduraSteps,
            zuppaVerduraIngredienti,
            "200",
            "Una zuppa calda e confortante, ricca di verdure fresche e perfetta per le serate fredde.",
            zuppaVerduraStepImages,
            zuppaVerduraStartImage,
            zuppaVerduraEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        // --- Ricetta 9: Salmone al Forno con Limone ---
        List<string> salmoneFornoStepNames = new List<string>
        {
            "Step 1: Prepara la teglia",
            "Step 2: Condisci il salmone",
            "Step 3: Inforna e servi"
        };
        List<string> salmoneFornoSteps = new List<string>
        {
            "Preriscalda il forno a 180°C. Prepara una teglia con carta forno.",
            "Disponi i filetti di salmone sulla teglia. Condisci con olio d'oliva, sale, pepe e fette di limone.",
            "Inforna per 12-15 minuti, o finché il salmone non è cotto ma ancora tenero. Servi caldo."
        };
        List<string> salmoneFornoStepImages = new List<string>
        {
            "https://picsum.photos/id/253/600/400", // Teglia
            "https://picsum.photos/id/254/600/400", // Limone/Condimenti
            "https://picsum.photos/id/255/600/400"  // Pesce Cotto
        };
        string salmoneFornoStartImage = "https://picsum.photos/id/256/600/400";
        string salmoneFornoEndImage = "https://picsum.photos/id/257/600/400";
        List<string> salmoneFornoIngredienti = new List<string>
        {
            "Salmone", "Limone", "Olio", "Sale", "Pepe"
        };
        recipes.Add(new Ricetta(
            "Salmone al Forno con Limone",
            salmoneFornoStepNames,
            salmoneFornoSteps,
            salmoneFornoIngredienti,
            "400",
            "Un piatto leggero e saporito, il salmone cotto al forno con il profumo del limone.",
            salmoneFornoStepImages,
            salmoneFornoStartImage,
            salmoneFornoEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        // --- Ricetta 10: Omelette con Formaggio ---
        List<string> omeletteFormaggioStepNames = new List<string>
        {
            "Step 1: Sbatti le uova",
            "Step 2: Cuoci e aggiungi formaggio",
            "Step 3: Piega e servi"
        };
        List<string> omeletteFormaggioSteps = new List<string>
        {
            "In una ciotola, sbatti le uova con un pizzico di sale e pepe.",
            "Scalda una padella antiaderente con un po' di burro. Versa le uova sbattute. Appena i bordi iniziano a rapprendersi, aggiungi il formaggio grattugiato su metà dell'omelette.",
            "Quando l'omelette è quasi cotta, piegala a metà e cuocila per un altro minuto. Servi subito."
        };
        List<string> omeletteFormaggioStepImages = new List<string>
        {
            "https://picsum.photos/id/258/600/400", // Uova
            "https://picsum.photos/id/259/600/400", // Padella
            "https://picsum.photos/id/260/600/400"  // Piatto per Colazione
        };
        string omeletteFormaggioStartImage = "https://picsum.photos/id/261/600/400";
        string omeletteFormaggioEndImage = "https://picsum.photos/id/262/600/400";
        List<string> omeletteFormaggioIngredienti = new List<string>
        {
            "Uovo", "Formaggio", "Burro", "Sale", "Pepe"
        };
        recipes.Add(new Ricetta(
            "Omelette con Formaggio",
            omeletteFormaggioStepNames,
            omeletteFormaggioSteps,
            omeletteFormaggioIngredienti,
            "250",
            "Un'omelette soffice e gustosa, perfetta per una colazione ricca o un pranzo veloce.",
            omeletteFormaggioStepImages,
            omeletteFormaggioStartImage,
            omeletteFormaggioEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        // --- Ricetta 11: Purè di Patata ---
        List<string> purePatataStepNames = new List<string>
        {
            "Step 1: Lessa le patate",
            "Step 2: Schiaccia le patate",
            "Step 3: Manteca e servi"
        };
        List<string> purePatataSteps = new List<string>
        {
            "Sbuccia le patate, tagliale a pezzi e lessale in acqua salata finché non sono molto tenere.",
            "Scolale e passale nello schiacciapatate o schiacciale bene con una forchetta.",
            "Aggiungi il burro a pezzetti e il latte caldo, mescolando energicamente finché non ottieni una crema liscia e omogenea. Regola di sale."
        };
        List<string> purePatataStepImages = new List<string>
        {
            "https://picsum.photos/id/263/600/400", // Patate
            "https://picsum.photos/id/264/600/400", // Utensili da Cucina
            "https://picsum.photos/id/265/600/400"  // Piatto Cremoso
        };
        string purePatataStartImage = "https://picsum.photos/id/266/600/400";
        string purePatataEndImage = "https://picsum.photos/id/267/600/400";
        List<string> purePatataIngredienti = new List<string>
        {
            "Patata", "Latte", "Burro", "Sale"
        };
        recipes.Add(new Ricetta(
            "Purè di Patata",
            purePatataStepNames,
            purePatataSteps,
            purePatataIngredienti,
            "180",
            "Un contorno classico e amato, il purè di patate cremoso e vellutato.",
            purePatataStepImages,
            purePatataStartImage,
            purePatataEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        // --- Ricetta 12: Bruschetta al Pomodoro ---
        List<string> bruschettaPomodoroStepNames = new List<string>
        {
            "Step 1: Tosta il pane",
            "Step 2: Prepara il condimento al pomodoro",
            "Step 3: Condisci il pane e servi"
        };
        List<string> bruschettaPomodoroSteps = new List<string>
        {
            "Taglia il pane a fette spesse e tostale in forno o sulla griglia finché non sono dorate e croccanti.",
            "Lava i pomodori e tagliali a cubetti piccoli. In una ciotola, mescola i pomodori con l'aglio tritato, il basilico fresco spezzettato, un filo d'olio d'oliva, sale e pepe.",
            "Strofina l'aglio sulle fette di pane tostate (se ti piace un sapore più intenso). Distribuisci il composto di pomodoro sul pane e servi subito."
        };
        List<string> bruschettaPomodoroStepImages = new List<string>
        {
            "https://picsum.photos/id/268/600/400", // Pane
            "https://picsum.photos/id/269/600/400", // Verdure Fresche/Erbe
            "https://picsum.photos/id/270/600/400"  // Antipasto
        };
        string bruschettaPomodoroStartImage = "https://picsum.photos/id/271/600/400";
        string bruschettaPomodoroEndImage = "https://picsum.photos/id/272/600/400";
        List<string> bruschettaPomodoroIngredienti = new List<string>
        {
            "Pane", "Pomodoro", "Aglio", "Basilico", "Olio", "Sale", "Pepe"
        };
        recipes.Add(new Ricetta(
            "Bruschetta al Pomodoro",
            bruschettaPomodoroStepNames,
            bruschettaPomodoroSteps,
            bruschettaPomodoroIngredienti,
            "150",
            "Un antipasto fresco e gustoso, con pomodori maturi e basilico profumato su pane croccante.",
            bruschettaPomodoroStepImages,
            bruschettaPomodoroStartImage,
            bruschettaPomodoroEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        // --- Ricetta 13: Minestrone ---
        List<string> minestroneStepNames = new List<string>
        {
            "Step 1: Prepara le verdure",
            "Step 2: Cuoci il minestrone",
            "Step 3: Aggiungi pasta/riso e servi"
        };
        List<string> minestroneSteps = new List<string>
        {
            "Lava e taglia a cubetti tutte le verdure (carota, zucchina, patata, sedano, cipolla, pisello, fagiolino).",
            "In una pentola grande, scalda un filo d'olio e fai soffriggere la cipolla. Aggiungi tutte le verdure tagliate e il brodo vegetale. Porta a ebollizione.",
            "Aggiungi un cucchiaio di passata di pomodoro e la pasta (o riso). Lascia cuocere per circa 20-30 minuti, o finché le verdure e la pasta non sono cotte. Regola di sale e pepe. Servi caldo."
        };
        List<string> minestroneStepImages = new List<string>
        {
            "https://picsum.photos/id/273/600/400", // Mix di Verdure
            "https://picsum.photos/id/274/600/400", // Pentola che Bolle
            "https://picsum.photos/id/275/600/400"  // Ciotola di Zuppa
        };
        string minestroneStartImage = "https://picsum.photos/id/276/600/400";
        string minestroneEndImage = "https://picsum.photos/id/277/600/400";
        List<string> minestroneIngredienti = new List<string>
        {
            "Carota", "Zucchina", "Patata", "Sedano", "Cipolla", "Pisello", "Fagiolino", "Brodo", "Pomodoro", "Pasta", "Riso", "Olio", "Sale", "Pepe"
        };
        recipes.Add(new Ricetta(
            "Minestrone",
            minestroneStepNames,
            minestroneSteps,
            minestroneIngredienti,
            "220",
            "Un classico della cucina italiana, una zuppa ricca di verdure miste e legumi, perfetta per un pasto sano e completo.",
            minestroneStepImages,
            minestroneStartImage,
            minestroneEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        // --- Ricetta 14: Pollo al Basilico ---
        List<string> polloBasilicoStepNames = new List<string>
        {
            "Step 1: Taglia il pollo",
            "Step 2: Rosola il pollo",
            "Step 3: Aggiungi brodo e basilico",
            "Step 4: Cuoci e servi"
        };
        List<string> polloBasilicoSteps = new List<string>
        {
            "Taglia i petti di pollo a striscioline o a cubetti.",
            "In una padella antiaderente, scalda un filo d'olio d'oliva. Aggiungi il pollo e fallo rosolare su tutti i lati finché non sarà dorato. Regola di sale e pepe.",
            "Sfuma con un po' di brodo vegetale e aggiungi le foglie di basilico fresco tritate grossolanamente. Lascia cuocere per qualche minuto, finché il pollo non è cotto e il brodo leggermente ridotto.",
            "Servi il pollo al basilico caldo, magari accompagnato da riso basmati o una semplice insalata verde."
        };
        List<string> polloBasilicoStepImages = new List<string>
        {
            "https://picsum.photos/id/278/600/400", // Pollo tagliato
            "https://picsum.photos/id/279/600/400", // Pollo in padella
            "https://picsum.photos/id/280/600/400", // Brodo e erbe aromatiche
            "https://picsum.photos/id/281/600/400"  // Piatto finito con carne e verdure
        };
        string polloBasilicoStartImage = "https://picsum.photos/id/282/600/400";
        string polloBasilicoEndImage = "https://picsum.photos/id/283/600/400";
        List<string> polloBasilicoIngredienti = new List<string>
        {
            "Pollo", "Basilico", "Brodo", "Olio", "Sale", "Pepe"
        };
        recipes.Add(new Ricetta(
            "Pollo al Basilico",
            polloBasilicoStepNames,
            polloBasilicoSteps,
            polloBasilicoIngredienti,
            "400",
            "Un secondo piatto leggero e aromatico, pollo tenero cotto in un delicato sugo al basilico, perfetto per una cena veloce.",
            polloBasilicoStepImages,
            polloBasilicoStartImage,
            polloBasilicoEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        // --- Ricetta 15: Cheesecake al Forno ---
        List<string> cheesecakeStepNames = new List<string>
        {
            "Step 1: Prepara la base di biscotti",
            "Step 2: Prepara il ripieno al formaggio",
            "Step 3: Versa il ripieno sulla base",
            "Step 4: Cuoci la cheesecake in forno",
            "Step 5: Fai raffreddare e guarnisci"
        };
        List<string> cheesecakeSteps = new List<string>
        {
            "Trita finemente i biscotti secchi (es. Digestive) fino a ottenere una polvere. Sciogli il burro e mescolalo con i biscotti tritati. Pressa il composto sul fondo di una tortiera a cerniera (20-22 cm) foderata con carta forno.",
            "In una ciotola capiente, mescola il formaggio cremoso (tipo Philadelphia) a temperatura ambiente con lo zucchero, la vaniglia e la scorza di limone grattugiata fino a ottenere una crema liscia. Aggiungi le uova una alla volta, mescolando delicatamente. Infine, incorpora la panna acida o panna fresca.",
            "Versa il ripieno al formaggio sulla base di biscotti nella tortiera. Livella la superficie con una spatola.",
            "Cuoci in forno preriscaldato a 160°C (modalità statica) per circa 50-60 minuti, o finché i bordi non sono sodi ma il centro è ancora leggermente tremolante. Potrebbe essere utile posizionare una teglia con acqua nel ripiano inferiore del forno per una cottura più uniforme.",
            "Spegni il forno e lascia la cheesecake al suo interno con lo sportello socchiuso per circa un'ora. Poi toglila e lasciala raffreddare completamente a temperatura ambiente. Riponila in frigorifero per almeno 4-6 ore (o idealmente tutta la notte) prima di servirla. Guarnisci a piacere con frutta fresca, coulis di frutti di bosco o cioccolato fuso."
        };
        List<string> cheesecakeStepImages = new List<string>
        {
            "https://picsum.photos/id/284/600/400", // Biscotti e burro
            "https://picsum.photos/id/285/600/400", // Ciotola con formaggio/ingredienti
            "https://picsum.photos/id/286/600/400", // Versamento di impasto
            "https://picsum.photos/id/287/600/400", // Forno con teglia
            "https://picsum.photos/id/288/600/400"  // Dolce guarnito
        };
        string cheesecakeStartImage = "https://picsum.photos/id/289/600/400";
        string cheesecakeEndImage = "https://picsum.photos/id/290/600/400";
        List<string> cheesecakeIngredienti = new List<string>
        {
            "Biscotto", "Burro", "Formaggio", "Zucchero", "Uovo", "Panna", "Vaniglia", "Limone"
        };
        recipes.Add(new Ricetta(
            "Cheesecake al Forno",
            cheesecakeStepNames,
            cheesecakeSteps,
            cheesecakeIngredienti,
            "550",
            "Una cheesecake classica, cremosa e vellutata, con una base croccante di biscotti e un ripieno ricco al formaggio, perfetta per un dessert goloso.",
            cheesecakeStepImages,
            cheesecakeStartImage,
            cheesecakeEndImage
        ));
        Debug.Log($"RicetteData: Aggiunta ricetta '{recipes[recipes.Count - 1].nome}'. Richiede: {string.Join(", ", recipes[recipes.Count - 1].ingredienti)}");

        Debug.Log($"RicetteData: Caricamento ricette completato. Totale ricette caricate: {recipes.Count}.");
        return recipes;

Debug.Log($"RicetteData: Caricamento ricette completato. Totale ricette caricate: {recipes.Count}.");
        return recipes;
    }
}
