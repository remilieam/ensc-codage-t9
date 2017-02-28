using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Projet_S1 // Roger_Tartas
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            string phrase;
            string[] dico = lectureDico("..\\..\\..\\dicoFR.txt");                                  // Récupération du dictionnaire dans un tableau

            ConsoleKeyInfo numChoisi = Accueil();                                                   // Choix de la fonction, par l’utilisateur

            while (numChoisi.Key == ConsoleKey.NumPad1 || numChoisi.Key == ConsoleKey.NumPad2 ||
                   numChoisi.Key == ConsoleKey.NumPad3 || numChoisi.Key == ConsoleKey.NumPad4 ||
                   numChoisi.Key == ConsoleKey.D1 || numChoisi.Key == ConsoleKey.D2 ||
                   numChoisi.Key == ConsoleKey.D3 || numChoisi.Key == ConsoleKey.D4)                // Tant que l’utilisateur veut tester les différentes fonctions
            {
                #region Cas où l’utilisateur choisit la fonction codageMultiTap
                if (numChoisi.Key == ConsoleKey.NumPad1 || numChoisi.Key == ConsoleKey.D1)
                {
                    Console.Clear();                                                                // Effaçage de l’écran d’accueil
                    Console.WriteLine(@"
========== CODAGE MULTITAP ==========

/!\  VEUILLEZ LIRE ATTENTIVEMENT  /!\
        LE MESSAGE CI-DESSOUS

    UNE FOIS LA LECTURE TERMINÉE,
  APPUYEZ SUR UNE TOUCHE DU CLAVIER

============== NOTICE ===============

SAISISSEZ VOTRE PHRASE EN MAJUSCULES

  IL EST ÉGALEMENT POSSIBLE D’ENTRER
DES CARACTÈRES ACCENTUÉS, DES CHIFFRES
    ET DES SIGNES DE PONCTUATION

UNE FOIS LA SAISIE MULTITAP TERMINÉE
   APPUYEZ SUR LA TOUCHE “ENTRÉE”");                                                                 // Affichage de la “notice”

                    Console.ReadKey();                                                              // “Pause” = Il faut appuyer sur une touche pour continuer

                    Console.Clear();
                    Console.Write("Entrer la phrase à encoder en MultiTap : ");
                    phrase = Console.ReadLine();

                    Console.WriteLine("\nLa phrase \"{0}\" se code, en MultiTap :\n\n{1}", phrase, codageMultiTap(phrase));

                    Console.WriteLine("\nAppuyez sur une touche pour continuer");
                    Console.ReadKey();

                    numChoisi = Accueil();                                                          // Retour à l’accueil
                }
                #endregion

                #region Cas où l’utilisateur choisit la fonction codageT9
                if (numChoisi.Key == ConsoleKey.NumPad2 || numChoisi.Key == ConsoleKey.D2)
                {
                    Console.Clear();                                                                // Effaçage de l’écran d’accueil
                    Console.WriteLine(@"
============= CODAGE T9 =============

/!\  VEUILLEZ LIRE ATTENTIVEMENT  /!\
        LE MESSAGE CI-DESSOUS

    UNE FOIS LA LECTURE TERMINÉE,
  APPUYEZ SUR UNE TOUCHE DU CLAVIER

============== NOTICE ===============

SAISISSEZ VOTRE PHRASE EN MAJUSCULES

  IL EST ÉGALEMENT POSSIBLE D’ENTRER
DES CARACTÈRES ACCENTUÉS, DES CHIFFRES
    ET DES SIGNES DE PONCTUATION

   UNE FOIS LA SAISIE T9 TERMINÉE
   APPUYEZ SUR LA TOUCHE “ENTRÉE” ");                                                                 // Affichage de la “notice”

                    Console.ReadKey();                                                              // “Pause”

                    Console.Clear();
                    Console.Write("Entrer la phrase à encoder en T9 : ");

                    phrase = Console.ReadLine();

                    Console.WriteLine("\nLa phrase \"{0}\" se code, en T9 :\n\n{1}", phrase, codageT9(phrase));

                    Console.WriteLine("\nAppuyez sur une touche pour continuer");
                    Console.ReadKey();

                    numChoisi = Accueil();                                                          // Retour à l’accueil
                }
                #endregion

                #region Cas où l’utilisateur choisit la fonction decodageMultiTap
                if (numChoisi.Key == ConsoleKey.NumPad3 || numChoisi.Key == ConsoleKey.D3)
                {
                    Console.Clear();                                                                // Effaçage de l’écran d’accueil
                    decodageMultiTap();
                    numChoisi = Accueil();                                                          // Retour à l’accueil
                }
                #endregion

                #region Cas où l’utilisateur choisit la procédure decodageT9
                if (numChoisi.Key == ConsoleKey.NumPad4 || numChoisi.Key == ConsoleKey.D4)
                {
                    Console.Clear();                                                                // Effaçage de l’écran d’accueil
                    decodageT9(dico);
                    numChoisi = Accueil();                                                          // Retour à l’accueil
                }
                #endregion
            }

            Console.Clear();                                                                        // Effaçage de l’écran d’accueil
            Console.WriteLine("\n============ AU REVOIR ! ============\n");                         // Message d’adieu

        }
        #endregion

        #region Fonction lectureDico
        public static string[] lectureDico(string fichier_source)
        {
            try
            {
                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");     // Création de deux instances de StreamReader pour parcourir 2 fois le fichier source
                StreamReader myStreamReader = new StreamReader(fichier_source, encoding);
                StreamReader monStreamReader = new StreamReader(fichier_source, encoding);

                int nbMots = 0;
                string mot = myStreamReader.ReadLine();

                while (mot != null)                                                                 // Calcul du nombre de lignes (ici, mots) dans le fichier source
                {
                    nbMots++;
                    mot = myStreamReader.ReadLine();
                }

                string[] dico = new string[nbMots];

                for (int i = 0; i < nbMots; i++)                                                    // Ajout de tous les lignes (ici, mots) dans les cases d’un tableau
                {
                    mot = monStreamReader.ReadLine();
                    dico[i] = mot;
                }

                monStreamReader.Close();                                                            // Fermeture des instances de StreamReader
                myStreamReader.Close();

                return dico;                                                                        // Renvoi du tableau
            }

            catch (Exception ex)
            {
                Console.Write("Une erreur est survenue au cours de l'opération : ");                // Code exécuté en cas d’exception
                Console.WriteLine(ex.Message);
            }

            return new string[1];
        }
        #endregion

        #region Fonction Accueil
        public static ConsoleKeyInfo Accueil()
        {
            Console.Clear();
            Console.WriteLine(@"
============ BIENVENUE ! ============

SI VOUS SOUHAITEZ TRADUIRE UNE PHRASE
        EN UN CODE MULTITAP :

               TAPEZ 1

-------------------------------------

SI VOUS SOUHAITEZ TRADUIRE UNE PHRASE
           EN UN CODE T9 :

               TAPEZ 2

-------------------------------------

  SI VOUS SOUHAITEZ TRADUIRE UN CODE
      AVEC UNE SAISIE MULTITAP :

               TAPEZ 3

-------------------------------------

  SI VOUS SOUHAITEZ TRADUIRE UN CODE
         AVEC UNE SAISIE T9 :

               TAPEZ 4

-------------------------------------

             POUR QUITTER :
     TAPEZ SUR UNE AUTRE TOUCHE");

            ConsoleKeyInfo numChoisi = Console.ReadKey();
            return numChoisi;
        }
        #endregion

        #region Fonction codageMultiTap
        public static string codageMultiTap(string phrase)
        {
            string[,] alphabet = { { " 0", "0" },
                                 { ".,-?!:;'()1", "1" }, { "ABCÇÀÂ2", "2" }, { "DEFÉÈÊË3", "3" },
                                 { "GHIÎÏ4", "4" }, { "JKL5", "5" }, { "MNOÔŒ6", "6" },
                                 { "PQRS7", "7" }, { "TUVÙÛÜ8", "8" }, { "WXYZ9", "9" } };
            bool trouveLettre;
            int i = 0;
            int a = 0;
            int b = 0;
            string numPrec = "";
            string code = "";

            while (i < phrase.Length)                                                               // Parcours de toute la phrase, caractère par caractère
            {
                a = 0;                                                                              // a parcourt les touches du clavier du téléphone
                b = 0;                                                                              // b parcourt les caractères de la touche a
                trouveLettre = false;

                while ((a < alphabet.GetLength(0) && alphabet[a, 0][b] != phrase[i])
                    && trouveLettre == false)                                                       // Recherche du caractère dans le tableau “alphabet” => Parcours des touches du clavier du téléphone, une par une
                {
                    b = 1;

                    while (b < alphabet[a, 0].Length && alphabet[a, 0][b] != phrase[i]) { b++; }    // Et, sur chaque touche, parcours de tous ses caractères, un par un

                    if (b == alphabet[a, 0].Length)
                    {
                        a++;
                        b = 0;
                    }

                    else { trouveLettre = true; }
                }

                if (a == alphabet.GetLength(0))                                                     // Cas où le caractère n’est pas dans le tableau “alphabet”
                {
                    return "Erreur ! Vous avez saisi un caractère indisponible dans votre phrase…";
                }

                else                                                                                // Cas où on a trouvé le caractère dans le tableau “alphabet”
                {
                    if (i != 0 && numPrec == alphabet[a, 1]) { code += "*"; }                       // Cas où deux caractères successifs sont sur la même touche => Ajout d’une astérisque au code

                    for (int k = 1; k <= b + 1; k++) { code += alphabet[a, 1]; }                    // Composition du code associé au caractère, sachant que la position b de la lettre dans l’alphabet correspond à son nombre d’occurence, i.e. b + 1 occurences

                    numPrec = alphabet[a, 1];
                }

                i += 1;
            }

            return code;
        }
        #endregion

        #region Fonction codageT9
        public static string codageT9(string phrase)
        {
            string[,] alphabet = { { " 0", "0" },
                                 { ".,-?!:;'()1", "1" }, { "ABCÇÀÂ2", "2" }, { "DEFÉÈÊË3", "3" },
                                 { "GHIÎÏ4", "4" }, { "JKL5", "5" }, { "MNOÔŒ6", "6" }, { "PQRS7", "7" },
                                 { "TUVÙÛÜ8", "8" }, { "WXYZ9", "9" } };
            bool trouveLettre;
            int i = 0;
            int a = 0;
            int b = 0;
            string code = "";

            while (i < phrase.Length)                                                               // Parcours de toute la phrase, caractère par caractère
            {
                a = 0;                                                                              // a parcourt les touches du clavier du téléphone
                b = 0;                                                                              // b parcourt les caractères de la touche a
                trouveLettre = false;

                while ((a < alphabet.GetLength(0) && alphabet[a, 0][b] != phrase[i])
                    && trouveLettre == false)                                                       // Recherche du caractère dans le tableau “alphabet” => Parcours des touches du clavier du téléphone, une par une
                {

                    b = 1;

                    while (b < alphabet[a, 0].Length && alphabet[a, 0][b] != phrase[i]) { b++; }    // Et, sur chaque touche, parcours de tous ses caractères, un par un

                    if (b == alphabet[a, 0].Length)
                    {
                        a++;
                        b = 0;
                    }

                    else { trouveLettre = true; }
                }

                if (a == alphabet.GetLength(0))                                                     // Cas où le caractère n’est pas dans le tableau “alphabet”
                {
                    return "Erreur ! Vous avez saisi un caractère indisponible dans votre phrase…";
                }

                else { code += alphabet[a, 1]; }                                                    // Cas où on a trouvé le caractère dans le tableau “alphabet”

                i += 1;
            }

            return code;                                                                            // Renvoi du code T9
        }
        #endregion

        #region Fonction decodageMultiTap
        public static string decodageMultiTap()
        {
            string[,] alphabet = { { " 0", "0" },
                                 { ".,-?!:;'()1", "1" }, { "ABCÇÀÂ2", "2" }, { "DEFÉÈÊË3", "3" },
                                 { "GHIÎÏ4", "4" }, { "JKL5", "5" }, { "MNOÔŒ6", "6" },
                                 { "PQRS7", "7" }, { "TUVÙÛÜ8", "8" }, { "WXYZ9", "9" } };
            string code = "";
            string phrase = "";
            string lettre = "";
            int rangAlphabet = 0;
            int i = 0;

            Console.Clear();
            Console.WriteLine(@"
========= DÉCODAGE MULTITAP =========

/!\  VEUILLEZ LIRE ATTENTIVEMENT  /!\
        LE MESSAGE CI-DESSOUS

    UNE FOIS LA LECTURE TERMINÉE,
  APPUYEZ SUR UNE TOUCHE DU CLAVIER

============== NOTICE ===============

SAISISSEZ VOTRE CODE AVEC LES TOUCHES
        DU CLAVIER NUMÉRIQUE

     POUR MODIFIER VOTRE CHOIX :
    APPUYEZ SUR LA FLÈCHE DU BAS

UNE FOIS LA SAISIE MULTITAP TERMINÉE
   APPUYEZ SUR LA TOUCHE “ENTRÉE”");

            Console.ReadKey();

            Console.Clear();
            Console.Write("Entrer le code MultiTap à décoder : {0}\nLe code MultiTap précédent se décode : {1}\nActuel choix de lettre : {2}", code, phrase, "");

            ConsoleKeyInfo numero = Console.ReadKey();
            ConsoleKeyInfo numeroPrec = numero;

            do                                                                                      // Tant que qu’on n’appuie pas sur la touche “Entrée”
            {
                i = 0;

                while (numeroPrec == numero)                                                        // Écriture de chaque lettre, une par une => Vérification qu’on appuie toujours sur la même touche
                {
                    #region Écriture d’une lettre
                    if (numero.Key == ConsoleKey.NumPad0 || numero.Key == ConsoleKey.NumPad1 ||
                        numero.Key == ConsoleKey.NumPad2 || numero.Key == ConsoleKey.NumPad3 ||
                        numero.Key == ConsoleKey.NumPad4 || numero.Key == ConsoleKey.NumPad5 ||
                        numero.Key == ConsoleKey.NumPad6 || numero.Key == ConsoleKey.NumPad7 ||
                        numero.Key == ConsoleKey.NumPad8 || numero.Key == ConsoleKey.NumPad9 ||
                        numero.Key == ConsoleKey.D0 || numero.Key == ConsoleKey.D1 ||
                        numero.Key == ConsoleKey.D2 || numero.Key == ConsoleKey.D3 ||
                        numero.Key == ConsoleKey.D4 || numero.Key == ConsoleKey.D5 ||
                        numero.Key == ConsoleKey.D6 || numero.Key == ConsoleKey.D7 ||
                        numero.Key == ConsoleKey.D8 || numero.Key == ConsoleKey.D9)
                    {
                        if (numero.Key == ConsoleKey.NumPad1 || numero.Key == ConsoleKey.D1) { code += "1"; rangAlphabet = 1; }

                        else if (numero.Key == ConsoleKey.NumPad2 || numero.Key == ConsoleKey.D2) { code += "2"; rangAlphabet = 2; }

                        else if (numero.Key == ConsoleKey.NumPad3 || numero.Key == ConsoleKey.D3) { code += "3"; rangAlphabet = 3; }

                        else if (numero.Key == ConsoleKey.NumPad4 || numero.Key == ConsoleKey.D4) { code += "4"; rangAlphabet = 4; }

                        else if (numero.Key == ConsoleKey.NumPad5 || numero.Key == ConsoleKey.D5) { code += "5"; rangAlphabet = 5; }

                        else if (numero.Key == ConsoleKey.NumPad6 || numero.Key == ConsoleKey.D6) { code += "6"; rangAlphabet = 6; }

                        else if (numero.Key == ConsoleKey.NumPad7 || numero.Key == ConsoleKey.D7) { code += "7"; rangAlphabet = 7; }

                        else if (numero.Key == ConsoleKey.NumPad8 || numero.Key == ConsoleKey.D8) { code += "8"; rangAlphabet = 8; }

                        else if (numero.Key == ConsoleKey.NumPad9 || numero.Key == ConsoleKey.D9) { code += "9"; rangAlphabet = 9; }

                        else { code += "0"; rangAlphabet = 0; }

                        lettre = alphabet[rangAlphabet, 0][i % (alphabet[rangAlphabet, 0].Length)].ToString();

                        Console.Clear();
                        Console.Write("Entrer le code MultiTap à décoder : {0}\nLe code MultiTap précédent se décode : {1}\nActuel choix de lettre : {2}", code, phrase, lettre);

                        i += 1;
                    }
                    #endregion

                    #region Séparation avec une étoile
                    else if (numero.Key == ConsoleKey.Multiply || numero.Key == ConsoleKey.Oem5)    // Cas où on veut écrire des lettres successives qui appartiennent à la même touche
                    {
                        code += "*";                                                                // Ajout d’une astérisque
                        lettre = "";

                        Console.Clear();
                        Console.Write("Entrer le code MultiTap à décoder : {0}\nLe code MultiTap précédent se décode : {1}\nActuel choix de lettre : {2}", code, phrase, lettre);
                    }
                    #endregion

                    #region Erreurs
                    else                                                                            // Cas où on n’appuie ni sur un chiffre, ni sur l’astérisque
                    {
                        lettre = "";

                        Console.Clear();                                                            // Affichage d’un message d’erreur
                        Console.WriteLine("=============ERREUR DE SAISIE=============");
                        Console.WriteLine("\n        IL FAUT SAISIR DES CHIFFRES");
                        Console.WriteLine("\n    OU APPUYER SUR ENTRÉE POUR QUITTER");
                        Console.WriteLine("\n------------------------------------------");
                        Console.WriteLine("\nAppuyez sur une touche pour continuer");
                        Console.ReadKey();

                        Console.Clear();
                        Console.Write("Entrer le code MultiTap à décoder : {0}\nLe code MultiTap précédent se décode : {1}\nActuel choix de lettre : {2}", code, phrase, lettre);
                    }
                    #endregion

                    numeroPrec = numero;
                    numero = Console.ReadKey();
                }

                numeroPrec = numero;
                phrase += lettre;                                                                   // Ajout de la lettre à la phrase
            }
            while (numero.Key != ConsoleKey.Enter);

            Console.Clear();
            Console.WriteLine("Entrer le code MultiTap à décoder : {0}\nLe code MultiTap précédent se décode : {1}", code, phrase);
            Console.WriteLine("\nAppuyez sur une touche pour continuer");
            Console.ReadKey();

            return phrase;
        }
        #endregion

        #region Fonction corresDico
        public static string[] corresDico(string[] dico, string code)
        {
            string[,] alphabet = { { "ABCÇÀÂ2", "2" }, { "DEFÉÈÊË3", "3" },
                                 { "GHIÎÏ4", "4" }, { "JKL5", "5" }, { "MNOÔŒ6", "6" },
                                 { "PQRS7", "7" }, { "TUVÙÛÜ8", "8" }, { "WXYZ9", "9" } };

            try
            {
                int i, j, k, nbMotsCompatibles = 0;
                bool motCompatible;
                string chaineMotsCompatibles = "";
                string[] touchesLettres = new string[code.Length], tableauMotsComptables;

                #region 1ère étape
                for (i = 0; i < code.Length; i++)                                                   // Recherche et insertion dans un tableau, des paquets de lettres correspondant au code
                {
                    j = 0;

                    while (alphabet[j, 1] != code[i].ToString()) { j += 1; }

                    touchesLettres[i] = alphabet[j, 0];
                }
                #endregion

                #region 2ème étape
                for (k = 0; k < dico.Length; k++)                                                   // Parcours de tout le dictionnaire, mot par mot
                {
                    if (dico[k].Length == code.Length)                                              // Vérification que le mot à la même longueur que le code
                    {
                        i = 0;
                        motCompatible = true;

                        while (motCompatible && i < code.Length)                                    // Vérification, lettre par lettre, que le mot correspond au code
                        {
                            j = 0;

                            while (j < touchesLettres[i].Length && dico[k][i] != touchesLettres[i][j]) { j += 1; }

                            if (j == touchesLettres[i].Length) { motCompatible = false; }           // Cas où la lettre du mot ne correspond pas au chiffre du code

                            i += 1;
                        }

                        if (motCompatible)                                                          // Cas où toutes les lettres correspondent
                        {
                            chaineMotsCompatibles += dico[k] + " ";
                            nbMotsCompatibles += 1;
                        }
                    }
                }
                #endregion

                #region 3ème étape
                if (nbMotsCompatibles > 0)                                                          // Rangement des mots compatibles dans un tableau
                {
                    tableauMotsComptables = new string[nbMotsCompatibles];
                    i = 0;
                    j = 0;

                    while (j < chaineMotsCompatibles.Length)
                    {
                        while (chaineMotsCompatibles[j] != ' ')                                     // Tant qu’on ne rencontre pas d’espace, ajout lettre par lettre du mot, dans la i-ème case du tableau
                        {
                            tableauMotsComptables[i] += chaineMotsCompatibles[j];
                            j++;
                        }

                        i++;                                                                        // Changement de case
                        j++;
                    }

                    return tableauMotsComptables;
                }
                #endregion
            }

            catch (Exception ex)
            {
                Console.Write("Une erreur est survenue au cours de l'opération : ");                // Code exécuté en cas d’exception
                Console.WriteLine(ex.Message);
            }

            return new string[] { " " };
        }
        #endregion

        #region Procédure decodageT9
        public static void decodageT9(string[] dico)
        {
            string ponctuation = ".,-?!:;'()";
            string codeMot = "";
            string codePhrase = "";
            string phrase = "";
            string lettreDefaut = "";
            string mot_choisi = "";
            string[] mots;
            int i = 0;

            Console.Clear();
            Console.WriteLine(@"
============ DÉCODAGE T9 ============

/!\  VEUILLEZ LIRE ATTENTIVEMENT  /!\
        LE MESSAGE CI-DESSOUS

    UNE FOIS LA LECTURE TERMINÉE,
  APPUYEZ SUR UNE TOUCHE DU CLAVIER

============== NOTICE ===============

SAISISSEZ VOTRE CODE AVEC LES TOUCHES
        DU CLAVIER NUMÉRIQUE

     POUR MODIFIER VOTRE CHOIX :
    APPUYEZ SUR LA FLÈCHE DU BAS

LORSQU’UN MOT N’EST PAS DANS LE DICO
   APPUYEZ SUR LA TOUCHE “INSÉRER”

UNE FOIS LA SAISIE MULTITAP TERMINÉE
   APPUYEZ SUR LA TOUCHE “ENTRÉE”

QUAND VOUS AVEZ TERMINÉ LE DÉCODAGE,
   APPUYEZ SUR LA TOUCHE “ENTRÉE");

            Console.ReadKey();

            Console.Clear();
            Console.Write("Votre code : {0}\nVotre phrase : {1}\nVotre choix : {2}", codePhrase, phrase, "");

            ConsoleKeyInfo caractere = Console.ReadKey();

            do                                                                                      // Tant que qu’on n’appuie pas sur la touche “Entrée”
            {
                #region Écriture d’un mot
                while (caractere.Key == ConsoleKey.NumPad2 || caractere.Key == ConsoleKey.NumPad3 ||
                       caractere.Key == ConsoleKey.NumPad4 || caractere.Key == ConsoleKey.NumPad5 ||
                       caractere.Key == ConsoleKey.NumPad6 || caractere.Key == ConsoleKey.NumPad7 ||
                       caractere.Key == ConsoleKey.NumPad8 || caractere.Key == ConsoleKey.NumPad9 ||
                       caractere.Key == ConsoleKey.D2 || caractere.Key == ConsoleKey.D3 ||
                       caractere.Key == ConsoleKey.D4 || caractere.Key == ConsoleKey.D5 ||
                       caractere.Key == ConsoleKey.D6 || caractere.Key == ConsoleKey.D7 ||
                       caractere.Key == ConsoleKey.D8 || caractere.Key == ConsoleKey.D9)            // Écrire de la phrase, mot par mot => Vérification qu’on n’appuie toujours sur une touche entre 2 et 9
                {
                    if (caractere.Key == ConsoleKey.NumPad2 || caractere.Key == ConsoleKey.D2) { codeMot += "2"; codePhrase += "2"; lettreDefaut = "A"; }

                    else if (caractere.Key == ConsoleKey.NumPad3 || caractere.Key == ConsoleKey.D3) { codeMot += "3"; codePhrase += "3"; lettreDefaut = "D"; }

                    else if (caractere.Key == ConsoleKey.NumPad4 || caractere.Key == ConsoleKey.D4) { codeMot += "4"; codePhrase += "4"; lettreDefaut = "G"; }

                    else if (caractere.Key == ConsoleKey.NumPad5 || caractere.Key == ConsoleKey.D5) { codeMot += "5"; codePhrase += "5"; lettreDefaut = "J"; }

                    else if (caractere.Key == ConsoleKey.NumPad6 || caractere.Key == ConsoleKey.D6) { codeMot += "6"; codePhrase += "6"; lettreDefaut = "M"; }

                    else if (caractere.Key == ConsoleKey.NumPad7 || caractere.Key == ConsoleKey.D7) { codeMot += "7"; codePhrase += "7"; lettreDefaut = "P"; }

                    else if (caractere.Key == ConsoleKey.NumPad8 || caractere.Key == ConsoleKey.D8) { codeMot += "8"; codePhrase += "8"; lettreDefaut = "T"; }

                    else { codeMot += "9"; codePhrase += "9"; lettreDefaut = "W"; }

                    mots = corresDico(dico, codeMot);

                    if (mots[0] == " ")                                                             // Cas où le code ne correspond à aucun mot du dictionnaire
                    {
                        mot_choisi += lettreDefaut;                                                 // Par défaut, affichage de la première lettre de la touche du clavier du téléphone

                        Console.Clear();
                        Console.Write("Votre code : {0}\nVotre phrase : {1}\nVotre choix : {2}", codePhrase, phrase, mot_choisi);
                        Console.WriteLine("\nCe mot n’existe pas dans le dictionnaire.");
                        Console.WriteLine("Appuyez sur la touche Insérer si vous avez fini d’écrire votre mot et qu’il n’appartient au dictionnaire.");
                        Console.WriteLine("Sinon, continuer à entrer votre code…");

                        caractere = Console.ReadKey();

                        if (caractere.Key == ConsoleKey.Insert)                                     // Cas où l’on veut rentrer à la main un mot => Appel à la fonction decodageMultiTap
                        {
                            Console.Clear();
                            mot_choisi = decodageMultiTap();

                            Console.Clear();
                            Console.Write("Votre code : {0}\nVotre phrase : {1}\nVotre choix : {2}", codePhrase, phrase, mot_choisi);

                            caractere = Console.ReadKey();
                        }
                    }

                    else                                                                            // Cas où un ou plusieurs mots correspondent au code
                    {
                        mot_choisi = mots[0];                                                       // Par défaut, le mot choisi est le premier renvoyé par corresDico

                        Console.Clear();
                        Console.Write("Votre code : {0}\nVotre phrase : {1}\nVotre choix : {2}", codePhrase, phrase, mot_choisi);

                        i = 1;
                        caractere = Console.ReadKey();

                        while (caractere.Key == ConsoleKey.DownArrow)                               // Cas où le mot par défaut ne convient pas à l’utilisateur => Utilisation du la flèche du bas
                        {
                            Console.Write("\rVotre choix : {0}", mots[i % mots.Length]);
                            mot_choisi = mots[i % mots.Length];
                            i++;
                            caractere = Console.ReadKey();
                        }
                    }
                }
                #endregion

                #region Espace, ponctuation et erreurs
                if (caractere.Key == ConsoleKey.NumPad0 || caractere.Key == ConsoleKey.D0)          // Gestion des espaces
                {
                    codePhrase += "0";
                    phrase += mot_choisi + " ";                                                     // Ajout du mot écrit et d’un espace

                    Console.Clear();
                    Console.Write("Votre code : {0}\nVotre phrase : {1}\nVotre choix : {2}", codePhrase, phrase, " ");

                    codeMot = "";
                    mot_choisi = "";

                    caractere = Console.ReadKey();
                }

                else if (caractere.Key == ConsoleKey.NumPad1 || caractere.Key == ConsoleKey.D1)     // Gestion de la ponctuation
                {
                    codePhrase += "1";
                    phrase += mot_choisi;
                    char point = ponctuation[0];                                                    // Par défaut, le signe de ponctuation est un point

                    Console.Clear();
                    Console.Write("Votre code : {0}\nVotre phrase : {1}\nVotre choix : {2}", codePhrase, phrase, point);

                    i = 1;
                    caractere = Console.ReadKey();

                    while (caractere.Key == ConsoleKey.DownArrow)                                   // Cas où le signe de ponctuation par défaut ne convient pas à l’utilisateur
                    {
                        Console.Write("\rVotre choix : {0}", ponctuation[i % ponctuation.Length]);
                        point = ponctuation[i % ponctuation.Length];
                        i++;
                        caractere = Console.ReadKey();
                    }

                    phrase += point;
                    codeMot = "";
                    mot_choisi = "";

                    Console.Clear();
                    Console.Write("Votre code : {0}\nVotre phrase : {1}\nVotre choix : {2}", codePhrase, phrase, point);
                }

                else if (caractere.Key != ConsoleKey.Enter)                                         // Gestion des erreurs de frappe
                {
                    Console.Clear();
                    Console.WriteLine("=============ERREUR DE SAISIE=============");
                    Console.WriteLine("\n        IL FAUT SAISIR DES CHIFFRES");
                    Console.WriteLine("\n    OU APPUYER SUR ENTRÉE POUR QUITTER");
                    Console.WriteLine("\n------------------------------------------");
                    Console.WriteLine("\nAppuyez sur une touche pour continuer");
                    Console.ReadKey();

                    Console.Clear();
                    Console.Write("Votre code : {0}\nVotre phrase : {1}\nVotre choix : {2}", codePhrase, phrase, mot_choisi);

                    caractere = Console.ReadKey();
                }
                #endregion
            }
            while (caractere.Key != ConsoleKey.Enter);

            if (codePhrase.Length > 0 && (codePhrase[codePhrase.Length - 1] != 0 || codePhrase[codePhrase.Length - 1] != 1)) { phrase += mot_choisi; }
            Console.Clear();
            Console.WriteLine("Votre code : {0}\nVotre phrase : {1}", codePhrase, phrase);
            Console.WriteLine("\nAppuyez sur une touche pour continuer");
            Console.ReadKey();
        }
        #endregion
    }
}