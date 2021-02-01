using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace UtilitiesMain
{        
    class Program
    {
        enum utility
        {
            ProcessArray,
            DisplayEntities,
            ProcessStrings,
            SentenceAnalyzer,
            ProcessList,
            DocumentAnalyzer,
            StreamReader,
            HouseBuilder,
            FileCopier,
            FileExplorer,
        }
        
        static void Main(string[] args)
        {           
            switch (SelectionMenu())
            {
                case utility.ProcessArray:
                    ProcessArray();
                    break;

                case utility.DisplayEntities:
                    DisplayEntities();
                    break;

                case utility.ProcessStrings:
                    ProcessStrings();
                    break;

                case utility.SentenceAnalyzer:
                    SentenceAnalyzer();
                    break;

                case utility.ProcessList:
                    ProcessList();
                    break;

                case utility.DocumentAnalyzer:
                    DocumentAnalyzer DocAnalyzerInstance = new DocumentAnalyzer();
                    DocAnalyzerInstance.AnalyzerV3();
                    break;

                case utility.StreamReader:
                    StreamReader();
                    break;

                case utility.HouseBuilder:
                    HouseBuilder_program HouseBuilderInstance = new HouseBuilder_program();
                    HouseBuilderInstance.HouseBuilder();
                    break;

                case utility.FileCopier:
                    FileCopier();
                    break;

                case utility.FileExplorer:
                    Console.SetWindowSize(150, 40);
                    FileExplorer fileExplorer = new FileExplorer();
                    List<string> extensions = new List<string>();
                    extensions.Add("*.txt");
                    fileExplorer.AllowedExtensions = extensions;
                    fileExplorer.ExploreFiles(@"D:\Projects\School\Programming\003_ThirdGrade\Utilities\utilities\UtilitiesSol\textFiles\sourceTexts", "UTILITYTEST");
                    break;
            }
        }

        static utility SelectionMenu()
        {
            //adding prefixes to utilities name: *xx* = not working, will be unselectable; *x* = working, not finished - will be selectable with a warning
            List<string> utilities = new List<string>();
            utilities.AddRange(new List<string>() 
            { 
                "Process Array", 
                "Display Entities", 
                "Process Strings", 
                "Sentence Analyzer", 
                "Process List", 
                "Document Analyzer", 
                "Stream Reader", 
                "House Builder", 
                "File Copier",
                "*x*File Explorer (Alpha Version)"
            });            
            
            bool confirmed = false;
            int selection = 0;

            while(!confirmed)
            {
                Console.WriteLine("UTILITIES");
                Console.WriteLine("------");
                
                Console.WriteLine("Color legends:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("     -> Finished, fully working;");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("     -> Unfinished, partly working;");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     -> Unfinished, not working.");
                Console.ResetColor();

                Console.WriteLine("---");
                Console.WriteLine("To select an utility, please use Up and Down arrows.");
                Console.WriteLine("To confirm your choice, press Enter.");
                Console.WriteLine("---");

                for(int i = 0; i < utilities.Count; i++)
                {
                    if (i == selection)
                    {
                        if (utilities[i].StartsWith("*xx*"))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(" x   {0}. {1}", i + 1, utilities[i].Substring(4));
                        }
                        else if (utilities[i].StartsWith("*x*"))
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(" !   {0}. {1}", i + 1, utilities[i].Substring(3));
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(" >   {0}. {1}", i + 1, utilities[i]);
                        }
                    }
                    else
                    {
                        if (utilities[i].StartsWith("*xx*"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("     {0}. {1}", i + 1, utilities[i].Substring(4));
                        }
                        else if (utilities[i].StartsWith("*x*"))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("     {0}. {1}", i + 1, utilities[i].Substring(3));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("     {0}. {1}", i + 1, utilities[i]);
                        }
                    }

                    Console.ResetColor();
                }

                switch(Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selection = Math.Max(0, selection - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selection = Math.Min(utilities.Count - 1, selection + 1);
                        break;
                    case ConsoleKey.Enter:
                        if(!utilities[selection].StartsWith("*xx*"))
                        {
                            confirmed = true;
                        }
                        
                        break;
                }

                Console.Clear();
            }

            return (utility)selection;
        }
        
        //vytvořeno a dokončeno: 16.9.        
        static void ProcessArray()
        {
            int[] poleCisel = new int[4];

            for (int i = 0; i < poleCisel.Length; i++)
            {
                poleCisel[i] = i + 1;
            }

            for (int i = 0; i < poleCisel.Length; i++)
            {
                poleCisel[i] = poleCisel[i] * poleCisel[i];
            }

            for (int i = 0; i < poleCisel.Length; i++)
            {
                Console.WriteLine("Číslo {0} se rovná {1}", i + 1, poleCisel[i]);
            }

            Console.ReadKey(true);
        }

        //vytvořeno a dokončeno: 21.9.
        static void DisplayEntities()
        {
            string[] manufacturer = new string[5] { "Mazda", "Škoda", "Mercedes-Benz", "Ford", "Chevrolet" };
            string[] modelName = new string[5] { "MX-5 ND", "Octavia RS III.", "AMG C63 Coupe", "Mustang GT 2020", "Corvette" };
            string[] color = new string[5] { "Oranžová", "Tmavě šedá", "Černá", "Modrá", "Červená" };
            string[] engineFuel = new string[5] { "Benzín", "Benzín", "Benzín", "Benzín", "Benzín" };
            int[] engineCylinders = new int[5] { 4, 4, 8, 8, 8 };
            int[] engineHorsePower = new int[5] { 161, 245, 457, 449, 459 };
            int[] engineCapacity = new int[5] { 1998, 1984, 6208, 4951, 6000 };
            string[] transmissionType = new string[5] { "Manuální 6-stupňová", "Automatická 7-stupňová", "Automatická 7-stupňová", "Automatická 10-stupňová", "Manuální 7-stupňová" };
            double[] averageFuelConsumption = new double[5] { 6.9, 6.4, 12.0, 12.4, 14.1 };
            int[] price = new int[5] { 745900, 821900, 1803600, 1301990, 3112000 };

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Auto číslo {0}: {1} {2} v barvě: {3}", i + 1, manufacturer[i], modelName[i], color[i]);
                Console.WriteLine("Specifikace:");
                Console.WriteLine("Palivo: {0}", engineFuel[i]);
                Console.WriteLine("Výkon motoru: {0} koní", engineHorsePower[i]);
                Console.WriteLine("Zdvihový objem motoru: {0} ccm", engineCapacity[i]);
                Console.WriteLine("Počet válců: " + engineCylinders[i]);
                Console.WriteLine("Typ převodovky: " + transmissionType[i]);
                Console.WriteLine("Průměrná spotřeba: {0}l", averageFuelConsumption[i]);
                Console.WriteLine("Cena: {0} Kč", price[i]);
                Console.WriteLine();
            }

            Console.ReadKey(true);
        }

        //vytvořeno 23.9.; dokončeno: 30.9.
        static void ProcessStrings()
        {
            string novyRetezec = "Toto je moc pěkný řetězec.";
            string druhyRetezec = novyRetezec.Substring(0, 10);
            string[] retezce = novyRetezec.Split(' ');
            string[] poleRetezcu = new string[4] { "Toto", "není", "moc", "hezké." };
            string dalsiRetezec = string.Join(" ", poleRetezcu);

            Console.WriteLine(novyRetezec);
            Console.WriteLine();

            Console.WriteLine(druhyRetezec);
            Console.WriteLine();

            for (int i = 0; i < retezce.Length; i++)
            {
                Console.WriteLine(retezce[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < poleRetezcu.Length; i++)
            {
                Console.WriteLine(poleRetezcu[i]);
            }
            Console.WriteLine();

            Console.WriteLine(dalsiRetezec);

            Console.ReadKey(true);
        }

        //vytvořeno: 30.9.; částečně funkční verze: 7.10. (byla ukázana na hodině, bohužel jsem si ji přepsal :/); dokončeno, opraveny všechny známé bugy: 14.10.
        static void SentenceAnalyzer()
        {
            //příkladové věty
            string[] examples = new string[8] { "Tom was studying English in his room.", "He ate a lot of Apples and Peaches.", "He has been doing his project from home for two weeks now.", "She will be sleeping by the time they will get home.", "He would have been running fast provided that there was nothing in the way.", "Paul cried because the ball hit him, and I immediately apologized.", "Victoria is spending a lot of time inside even though her friends have been trying to get her out, yet she is enjoying the comfort of being home more and more.", "Nobody is going to go out even if the pandemic will have slowed down, so the streets will remain empty for a few weeks unless the virus is going to stop spreading completely." };

        //nadpis, další informace a input uživatele
        sentenceInput:
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         (ENGLISH) SYNTATIC                                                ");
            Console.WriteLine("                                              ANALYZER                                                     ");
            Console.WriteLine("                                                v2.0                                                       ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("About analyzer: ");
            Console.ResetColor();
            Console.WriteLine("---");
            Console.WriteLine("English syntatic analyzer is an app that lets you type in one sentence or more - it all depends on you.");
            Console.WriteLine("The app afterwards checks how many sentences there are, analyzes the type of sentence(s), and finds ");
            Console.WriteLine("subjects, verbs, objects and prepositional phrases in each sentence. After finishing, the app will give ");
            Console.WriteLine("you uncluttered list of S.V.O.Pp. in each sentence.");
            Console.WriteLine("---");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Notes and warnings: ");
            Console.ResetColor();
            Console.WriteLine("---");
            Console.WriteLine("! This analyzer supports up to TEN compound-complex sentences (this means you can type TEN or LESS ");
            Console.WriteLine("  dependent or independent clauses.");
            Console.WriteLine("! This analyzer does NOT support present simple tense and few past tense irregular verbs! (to be precise, ");
            Console.WriteLine("  it doesn't support irregular verbs, which have the same form as in present simple tense.)");
            Console.WriteLine("! This analyzer is sensitive to mispelling, and may not work if there are mispellings in sentences.");
            Console.WriteLine("---");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Additional information: ");
            Console.ResetColor();
            Console.WriteLine("---");
            Console.Write("- If you just want to try out this analyzer, write ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("'examples'");
            Console.ResetColor();
            Console.WriteLine(" in this form down below.");
            Console.Write("Your english sentence(s): ");
            string sentences = Console.ReadLine();
            Console.WriteLine("-----");
            Console.WriteLine();

            //vypsání příkladových vět
            if (sentences == "examples" || sentences == "Examples")
            {
                Console.WriteLine("Sentence examples: ");

                for (int i = 0; i < examples.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("[{0}] ", i + 1);
                    Console.ResetColor();
                    Console.WriteLine(examples[i]);
                }

                Console.WriteLine("-----");
                Console.Write("Select number: ");
                int exampleChoice = Convert.ToInt32(Console.ReadLine());

                switch (exampleChoice)
                {
                    case 1:
                        sentences = examples[0];
                        break;
                    case 2:
                        sentences = examples[1];
                        break;
                    case 3:
                        sentences = examples[2];
                        break;
                    case 4:
                        sentences = examples[3];
                        break;
                    case 5:
                        sentences = examples[4];
                        break;
                    case 6:
                        sentences = examples[5];
                        break;
                    case 7:
                        sentences = examples[6];
                        break;
                    case 8:
                        sentences = examples[7];
                        break;
                }
            }

            //deklarace polí stringů pro jejich pozdější zaplnění a vypsání na konci
            string sentenceType = "simple";
            string[] separatedSentences = new string[10];
            string[] sentencesSubjects = new string[10];
            string[] sentencesVerbs = new string[10];
            string[] sentencesObjects = new string[10];
            string[] sentencesPrePhrases = new string[10];
            string[] sentencesTenses = new string[10];
            string[] sentenceConjuctions = new string[10];
            int[] sentenceLengths = new int[10];
            bool[] sentencesNegative = new bool[10];
            bool error = false;

            //pole, která jsou potřebná pro rozpoznání druhů vět, času věty, pozice různých větných členů ve větě, ad.
            //string[] verbs = new string;
            string[] presentContinuous = new string[] { "am", "are", "is" };
            string[] irregularVerbs = new string[96] { "was", "were", "beat", "became", "began", "blew", "broke", "brought", "built", "burst", "bought", "caught", "chose", "came", "cost", "cut", "cried", "dealt", "did", "drew", "drank", "drove", "ate", "fell", "fed", "felt", "fought", "found", "flew", "forgot", "froze", "got", "gave", "went", "grew", "hung", "had", "heard", "hid", "hit", "held", "hurt", "kept", "knew", "laid", "led", "left", "lent", "let", "lay", "lit", "lost", "made", "meant", "met", "paid", "put", "rode", "rang", "rose", "ran", "said", "saw", "sold", "sent", "shook", "stole", "shone", "shot", "showed", "sang", "sank", "sat", "slept", "slid", "spoke", "spent", "sprang", "stood", "stuck", "swore", "swept", "swam", "swung", "took", "taught", "tore", "told", "thought", "threw", "understood", "woke", "wore", "wove", "won", "wrote" };
            string[] pastParticiple = new string[98] { "been", "beaten", "become", "begun", "bet", "blown", "broken", "brought", "built", "burst", "bought", "caught", "chosen", "come", "cost", "cut", "dealt", "done", "drawn", "drunk", "driven", "eaten", "fallen", "fed", "felt", "fought", "found", "flown", "forgotten", "frozen", "got", "given", "gone", "grown", "hung", "had", "heard", "hidden", "hit", "held", "hurt", "kept", "known", "laid", "led", "left", "lent", "let", "lain", "lit", "lost", "made", "meant", "met", "paid", "put", "read", "ridden", "rung", "risen", "run", "said", "seen", "sold", "sent", "set", "shaken", "stolen", "shone", "shot", "shown", "shut", "sung", "sunk", "sat", "slept", "slid", "spoken", "spent", "sprung", "stood", "stuck", "sworn", "swept", "swum", "swung", "taken", "taught", "torn", "told", "thought", "thrown", "understood", "woken", "worn", "woven", "won", "written" };
            string[] prepositions = new string[29] { "on", "in", "at", "since", "for", "before", "ago", "to", "past", "till", "until", "by", "next to", "beside", "under", "below", "over", "above", "across", "through", "into", "towards", "onto", "from", "of", "off", "out of", "about", "with" };
            string[] subConjuctions = new string[37] { "after", "although", "as", "as if", "as long as", "as much as", "as soon as", "as though", "because", "before", "by the time", "even if", "even though", "if", "in order that", "in case", "in the event that", "lest", "now that", "once", "only", "only if", "provided that", "since", "so", "supposing", "that", "than", "though", "till", "unless", "whenever", "where", "whereas", "wherever", "whether", "while" };
            string[] coordiConjuctions = new string[7] { "for", "and", "nor", "but", "or", "yet", "so" };

            //tato část kódu rozpoznává typ věty, podle čárek, spojek (conjuctions)
            string[] separatedWords = sentences.Split(' ');
            int separatedWordsLastPos = 0;
            int sentenceCount = 1;
            int nextSentenceLength = 0;

            for (int i = 0; i < separatedWords.Length; i++) //tento cyklus bude ověřovat každé slovo ve větě;
            {
                for (int j = 0; j < coordiConjuctions.Length; j++) //tento cyklus poté projíždí jednotlivé spojky;
                {
                    if (separatedWords[i] == coordiConjuctions[j])   //tato podmínka tedy kontroluje, zda-li aktuální slovo z věty není spojkou;
                    {
                        if (i > 0 && separatedWords[i - 1].EndsWith(",")) //pokud platí předchozí podmínka, tak tato další ještě zkontroluje, zda-li je před spojkou čárka. Pokud by nebyla, nedá se to považovat za spojku.
                        {
                            nextSentenceLength = i;

                            if (sentenceCount == separatedSentences.Length) //slouží k ověření, zda věta není delší, než deklarované pole stringů
                            {
                                error = true;
                                goto error;
                            }

                            //zapisuje délky vět, aby až se bude vytvářet pole stringů (rozdělená slova) pro každou větu, tak jsem nemusel odhadovat počet slov (=velikost pole)
                            if (sentenceCount == 1)
                            {
                                sentenceLengths[sentenceCount - 1] = i;
                            }
                            else if (sentenceCount > 1)
                            {
                                sentenceLengths[sentenceCount - 1] = i - sentenceLengths[sentenceCount - 2];
                            }

                            //zapsání věty do pole stringů a pozic, kde se skončilo, aby se při možném zapsání další věty vědělo, kde se skončilo
                            separatedSentences[sentenceCount - 1] = string.Join(" ", separatedWords, separatedWordsLastPos, nextSentenceLength - separatedWordsLastPos);
                            sentenceConjuctions[sentenceCount] = coordiConjuctions[j];
                            separatedWordsLastPos = i;
                            sentenceCount += 1;
                            i += 1;

                            if (sentenceCount == 2)
                            {
                                sentenceType = "compound";
                            }
                        }
                    }
                }

                for (int j = 0; j < subConjuctions.Length; j++) //stejný účel cyklu, jako výše, jen projíždí jiný druh spojek a zde není nutné ověrovat, zda-li je před spojkou čárka.
                {
                    /* protože tento druh spojek může mít délku až čtyři slova, a některé delší spojky začínají nebo končí stejným slovem, jako kratší spojka, je
                     * tedy nutné ověřit nejdříve, zda se ve souvětí nenachází nějaká delší spojka - od nejdelších po nejkratší-
                     * 
                     * uvnitř samotných podmínek pak probíhá to samé co výše, jen s tou výjimkou, že je zde přidáno případné přeskočení slov, aby se třeba
                     * tří-slovná spojka nekontrolovala znovu, viz. číslo 1 uvnitř if */
                    if (i + 3 < separatedWords.Length && string.Join(" ", separatedWords, i, 3) == subConjuctions[j])
                    {
                        nextSentenceLength = i;

                        if (sentenceCount == separatedSentences.Length)
                        {
                            error = true;
                            goto error;
                        }

                        if (sentenceCount == 1)
                        {
                            sentenceLengths[sentenceCount - 1] = i + 3;
                        }
                        else if (sentenceCount > 1)
                        {
                            sentenceLengths[sentenceCount - 1] = i - sentenceLengths[sentenceCount - 2] + 3;
                        }

                        separatedSentences[sentenceCount - 1] = string.Join(" ", separatedWords, separatedWordsLastPos, nextSentenceLength - separatedWordsLastPos);
                        sentenceConjuctions[sentenceCount] = subConjuctions[j];
                        separatedWordsLastPos = i;
                        sentenceCount += 1;
                        i += 3; //1

                        if (sentenceCount == 2)
                        {
                            sentenceType = "complex";
                        }
                    }
                    else if (i + 2 < separatedWords.Length && string.Join(" ", separatedWords, i, 2) == subConjuctions[j])
                    {
                        nextSentenceLength = i;

                        if (sentenceCount == separatedSentences.Length)
                        {
                            error = true;
                            goto error;
                        }

                        if (sentenceCount == 1)
                        {
                            sentenceLengths[sentenceCount - 1] = i + 2;
                        }
                        else if (sentenceCount > 1)
                        {
                            sentenceLengths[sentenceCount - 1] = i - sentenceLengths[sentenceCount - 2] + 2;
                        }

                        separatedSentences[sentenceCount - 1] = string.Join(" ", separatedWords, separatedWordsLastPos, nextSentenceLength - separatedWordsLastPos);
                        sentenceConjuctions[sentenceCount] = subConjuctions[j];
                        separatedWordsLastPos = i;
                        sentenceCount += 1;
                        i += 2; //1

                        if (sentenceCount == 2)
                        {
                            sentenceType = "complex";
                        }
                    }
                    else if (i + 1 < separatedWords.Length && string.Join(" ", separatedWords, i, 1) == subConjuctions[j])
                    {
                        nextSentenceLength = i;

                        if (sentenceCount == separatedSentences.Length)
                        {
                            error = true;
                            goto error;
                        }

                        if (sentenceCount == 1)
                        {
                            sentenceLengths[sentenceCount - 1] = i + 1;
                        }
                        else if (sentenceCount > 1)
                        {
                            sentenceLengths[sentenceCount - 1] = i - sentenceLengths[sentenceCount - 2] + 1;
                        }

                        separatedSentences[sentenceCount - 1] = string.Join(" ", separatedWords, separatedWordsLastPos, nextSentenceLength - separatedWordsLastPos);
                        sentenceConjuctions[sentenceCount] = subConjuctions[j];
                        separatedWordsLastPos = i;
                        sentenceCount += 1;
                        i += 1; //1

                        if (sentenceCount == 2)
                        {
                            sentenceType = "complex";
                        }
                    }
                    else if (separatedWords[i] == subConjuctions[j])
                    {
                        nextSentenceLength = i;

                        if (sentenceCount == separatedSentences.Length)
                        {
                            error = true;
                            goto error;
                        }

                        if (sentenceCount == 1)
                        {
                            sentenceLengths[sentenceCount - 1] = i;
                        }
                        else if (sentenceCount > 1)
                        {
                            sentenceLengths[sentenceCount - 1] = i - sentenceLengths[sentenceCount - 2];
                        }

                        separatedSentences[sentenceCount - 1] = string.Join(" ", separatedWords, separatedWordsLastPos, nextSentenceLength - separatedWordsLastPos);
                        sentenceConjuctions[sentenceCount] = subConjuctions[j];
                        separatedWordsLastPos = i;
                        sentenceCount += 1;

                        if (sentenceCount == 2)
                        {
                            sentenceType = "complex";
                        }
                    }
                }
            }

            if (sentenceCount > 2)
            {
                sentenceType = "compound-complex";
            }

            //zapsání poslední věty; nebo v případě, že byla zapsána pouze jedna věta, tak potom je to zapsání věty první
            separatedSentences[sentenceCount - 1] = string.Join(" ", separatedWords, separatedWordsLastPos, separatedWords.Length - separatedWordsLastPos);

            /* Tento cyklus projíždí jednotlivě každou větu. Před začátkem hledání větných členů si větu rozdělí a případně odstraní čárky nebo tečky na koncích slov,
             * aby nedocházelo k problémům, když se budou hledat slovesa. */
            for (int h = 0; h < separatedSentences.Length; h++)
            {
                string[] separatedWordsFromSentence = new string[sentenceLengths[h]];

                if (separatedSentences[h] != null)
                {
                    separatedWordsFromSentence = separatedSentences[h].Split(' ');
                }

                if (separatedWordsFromSentence.Length - 1 >= 1 && separatedWordsFromSentence[separatedWordsFromSentence.Length - 1].EndsWith("."))
                {
                    separatedWordsFromSentence[separatedWordsFromSentence.Length - 1] = separatedWordsFromSentence[separatedWordsFromSentence.Length - 1].TrimEnd('.');
                }
                else if (separatedWordsFromSentence.Length - 1 >= 1 && separatedWordsFromSentence[separatedWordsFromSentence.Length - 1].EndsWith(","))
                {
                    separatedWordsFromSentence[separatedWordsFromSentence.Length - 1] = separatedWordsFromSentence[separatedWordsFromSentence.Length - 1].TrimEnd(',');
                }

                /* 1) Tato část kódu zjišťuje na jaké pozici v každé větě leží sloveso (verb) - je to důležité zjistit jako první, protože od té pozice se lze      *
                 *    odpíchnout a najít další větné členy, jako objekt (object), subjekt (subject) a případně i předložkovou frázi (prepositional phrase).         *
                 *    Mimo jiné se v této části zjistí, v jakém čase věty jsou a zda jsou v negativním (negative) nebo pozitivním (affirmative) tvaru.              *
                 * 2) Jediným problémem zde je, že přítomný čas (jednoduchý) a některé věty v minulém čase (jednoduchém) s iregulárními slovesy,                    *
                 *    se nedají nějak rozpoznat - nemají žádné vodítko před, nebo za slovesem. Iregulární slovesa jsem vyřešil přidáním pole, které                 *
                 *    obsahuje takových sloves téměř 100. Nicméně jsem tam nemohl dát slovesa, která mají stejný tvar jak v minulém tak i přítomném čase.           *
                 *    Tudíž tento analyzátor nerozpozná ten nejzákladnější čas, tedy přítomný. Je těžké zjistit i pozici slovesa, vzhledem k tomu, že subject       *
                 *    i object, případně předložková fráze, mohou být různě dlouhé. Jedním ze dvou řešení by tedy bylo, že by uživatel zadal pozici slovesa         *
                 *    sám, ale to by trošku název "analyzátor" postrádal smysl, když by si to uživatel měl zjistit sám. :D Druhé řešení by bylo opět deklarování    *
                 *    pole stringů, které by obsahovalo opravdu velké množství sloves a ověřovalo by se to z toho.                                                  */

                int verbStartPosition = 0;
                int verbEndPosition = 0;

                for (int i = 0; i < separatedWordsFromSentence.Length; i++)
                {
                    for (int j = 0; j < presentContinuous.Length; j++)
                    {
                        if (separatedWordsFromSentence[i] == presentContinuous[j])
                        {
                            if (separatedWordsFromSentence[i + 1] == "going" && separatedWordsFromSentence[i + 2] == "to" && i + 2 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses[h] = "future - going to";
                                sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 3);
                                verbStartPosition = i;
                                verbEndPosition = i + 2;
                                break;
                            }
                            else if (separatedWordsFromSentence[i + 1].EndsWith("ing") && i + 1 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses[h] = "present continuous";
                                sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 2);
                                verbStartPosition = i;
                                verbEndPosition = i + 1;
                                break;
                            }
                        }
                    }

                    for (int j = 0; j < irregularVerbs.Length; j++)
                    {
                        if (i + 1 < separatedWordsFromSentence.Length && separatedWordsFromSentence[i] == irregularVerbs[j] && separatedWordsFromSentence[i + 1].EndsWith("ing") == false)
                        {
                            sentencesTenses[h] = "past simple";
                            sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 1);
                            verbStartPosition = i;
                            verbEndPosition = i;
                            break;
                        }
                    }

                    if (separatedWordsFromSentence[i] == "will")
                    {
                        if (separatedWordsFromSentence[i + 1] == "be" && separatedWordsFromSentence[i + 2].EndsWith("ing") && i + 2 < separatedWordsFromSentence.Length)
                        {
                            sentencesTenses[h] = "future continuous";
                            sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 3);
                            verbStartPosition = i;
                            verbEndPosition = i + 2;
                        }
                        else if (separatedWordsFromSentence[i + 1] == "have" && i + 1 < separatedWordsFromSentence.Length)
                        {
                            if (separatedWordsFromSentence[i + 2] == "been" && separatedWordsFromSentence[i + 3].EndsWith("ing") && i + 3 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses[h] = "future perfect continuous";
                                sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 4);
                                verbStartPosition = i;
                                verbEndPosition = i + 3;
                            }
                            else if (separatedWordsFromSentence[i + 2].EndsWith("ed") && i + 2 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses[h] = "future perfect simple";
                                sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 3);
                                verbStartPosition = i;
                                verbEndPosition = i + 2;
                            }
                            else
                            {
                                for (int k = 0; k < pastParticiple.Length; k++)
                                {
                                    if (separatedWordsFromSentence[i + 2] == pastParticiple[k] && i + 2 < separatedWordsFromSentence.Length)
                                    {
                                        sentencesTenses[h] = "future perfect simple";
                                        sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 3);
                                        verbStartPosition = i;
                                        verbEndPosition = i + 2;
                                    }
                                }
                            }
                        }
                        else
                        {
                            sentencesTenses[h] = "future simple";
                            sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 2);
                            verbStartPosition = i;
                            verbEndPosition = i + 1;
                        }

                        break;
                    }
                    else if (separatedWordsFromSentence[i] == "would")
                    {
                        if (separatedWordsFromSentence[i + 1] == "be" && separatedWordsFromSentence[i + 2].EndsWith("ing") && i + 2 < separatedWordsFromSentence.Length)
                        {
                            sentencesTenses[h] = "Conditional Continuous";
                            sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 3);
                            verbStartPosition = i;
                            verbEndPosition = i + 2;
                        }
                        else if (separatedWordsFromSentence[i + 1] == "have" && i + 1 < separatedWordsFromSentence.Length)
                        {
                            if (separatedWordsFromSentence[i + 2] == "been" && separatedWordsFromSentence[i + 3].EndsWith("ing") && i + 3 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses[h] = "conditional perfect continuous";
                                sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 4);
                                verbStartPosition = i;
                                verbEndPosition = i + 3;
                            }
                            else if (separatedWordsFromSentence[i + 2].EndsWith("ed") && i + 2 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses[h] = "conditional perfect simple";
                                sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 3);
                                verbStartPosition = i;
                                verbEndPosition = i + 2;
                            }
                            else
                            {
                                for (int k = 0; k < pastParticiple.Length; k++)
                                {
                                    if (separatedWordsFromSentence[i + 2] == pastParticiple[k] && i + 2 < separatedWordsFromSentence.Length)
                                    {
                                        sentencesTenses[h] = "conditional perfect simple";
                                        sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 3);
                                        verbStartPosition = i;
                                        verbEndPosition = i + 2;
                                    }
                                }
                            }
                        }
                        else
                        {
                            sentencesTenses[h] = "conditional simple (would)";
                            sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 2);
                            verbStartPosition = i;
                            verbEndPosition = i + 1;
                        }

                        break;
                    }
                    else if (separatedWordsFromSentence[i] == "had")
                    {
                        if (separatedWordsFromSentence[i + 1] == "been" && separatedWordsFromSentence[i + 2].EndsWith("ing") && i + 2 < separatedWordsFromSentence.Length)
                        {
                            sentencesTenses[h] = "past perfect continuous";
                            sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 3);
                            verbStartPosition = i;
                            verbEndPosition = i + 2;
                        }
                        else if (separatedWordsFromSentence[i + 1].EndsWith("ed") && i + 1 < separatedWordsFromSentence.Length)
                        {
                            sentencesTenses[h] = "past perfect simple";
                            sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 2);
                            verbStartPosition = i;
                            verbEndPosition = i + 1;
                        }
                        else
                        {
                            for (int k = 0; k < pastParticiple.Length; k++)
                            {
                                sentencesTenses[h] = "past simple";
                                sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 1);
                                verbStartPosition = i;
                                verbEndPosition = i;

                                if (separatedWordsFromSentence[i + 1] == pastParticiple[k] && i + 1 < separatedWordsFromSentence.Length)
                                {
                                    sentencesTenses[h] = "past perfect simple";
                                    sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 2);
                                    verbStartPosition = i;
                                    verbEndPosition = i + 1;
                                }
                            }
                        }

                        break;
                    }
                    else if (separatedWordsFromSentence[i] == "was" || separatedWordsFromSentence[i] == "were")
                    {
                        if (separatedWordsFromSentence[i + 1].EndsWith("ing") && i + 1 < separatedWordsFromSentence.Length)
                        {
                            sentencesTenses[h] = "past continuous";
                            sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 2);
                            verbStartPosition = i;
                            verbEndPosition = i + 1;
                        }
                        else
                        {
                            sentencesTenses[h] = "past simple";
                            sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 1);
                            verbStartPosition = i;
                            verbEndPosition = i;
                        }

                        break;
                    }
                    else if (separatedWordsFromSentence[i].EndsWith("ed"))
                    {
                        sentencesTenses[h] = "past simple";
                        sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 1);
                        verbStartPosition = i;
                        verbEndPosition = i;
                    }
                    else if (separatedWordsFromSentence[i] == "has" || separatedWordsFromSentence[i] == "have")
                    {
                        if (separatedWordsFromSentence[i + 1] == "been" && separatedWordsFromSentence[i + 2].EndsWith("ing") && i + 2 < separatedWordsFromSentence.Length)
                        {
                            sentencesTenses[h] = "present perfect continuous";
                            sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 3);
                            verbStartPosition = i;
                            verbEndPosition = i + 2;
                        }
                        else if (separatedWordsFromSentence[i + 1].EndsWith("ed") && i + 1 < separatedWordsFromSentence.Length)
                        {
                            sentencesTenses[h] = "present perfect simple";
                            sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 2);
                            verbStartPosition = i;
                            verbEndPosition = i + 1;
                        }
                        else
                        {
                            for (int k = 0; k < pastParticiple.Length; k++)
                            {
                                if (separatedWordsFromSentence[i + 1] == pastParticiple[k] && i + 1 < separatedWordsFromSentence.Length)
                                {
                                    sentencesTenses[h] = "present perfect simple";
                                    sentencesVerbs[h] = string.Join(" ", separatedWordsFromSentence, i, 2);
                                    verbStartPosition = i;
                                    verbEndPosition = i + 1;
                                }
                            }
                        }

                        break;
                    }
                }

                //pokud by se stalo, že uživatel zadal například větu v přítomném čase, tak zde se vypíše chyba - zkontroluje si to z toho, zda-li alespoň první sloveso není null
                if (sentencesVerbs[0] == null)
                {
                    error = true;
                    goto error;
                }

                //zapisování subjektu - kontroluje se také, zda aktuální věta obsahuje spojku, pokud ano, nesmí se objevit v subjektu
                if (sentenceConjuctions[h] != null && verbStartPosition - sentenceConjuctions[h].Split(' ').Length > 0)
                {
                    sentencesSubjects[h] = string.Join(" ", separatedWordsFromSentence, sentenceConjuctions[h].Split(' ').Length, verbStartPosition - sentenceConjuctions[h].Split(' ').Length);
                }
                else if (sentenceConjuctions[h] == null)
                {
                    sentencesSubjects[h] = string.Join(" ", separatedWordsFromSentence, 0, verbStartPosition);
                }

                //zapisování předložkové fráze a následně objektu - nejdříve se najde podle předložky předložková fráze a následně je jasné, že mezi slovesem a frází bude objekt
                for (int i = verbEndPosition; i < separatedWordsFromSentence.Length; i++)
                {
                    for (int j = 0; j < prepositions.Length; j++)
                    {
                        if (separatedWordsFromSentence[i] == prepositions[j])
                        {
                            sentencesPrePhrases[h] = string.Join(" ", separatedWordsFromSentence, i, separatedWordsFromSentence.Length - i);

                            if (i != verbEndPosition + 1 && verbEndPosition + 1 < separatedWordsFromSentence.Length && i - verbEndPosition - 1 > 0)
                            {
                                sentencesObjects[h] = string.Join(" ", separatedWordsFromSentence, verbEndPosition + 1, i - verbEndPosition - 1);
                            }

                            break;
                        }
                    }
                }

                //nakonec, pokud ve větě není předložková fráze, tak se zapíše samotný objekt, který začíná hned za slovesem a končí na konci věty.
                if (sentencesPrePhrases[h] == null && verbEndPosition + 1 < separatedWordsFromSentence.Length)
                {
                    sentencesObjects[h] = string.Join(" ", separatedWordsFromSentence, verbEndPosition + 1, separatedWordsFromSentence.Length - verbEndPosition - 1);
                }
            }

        error:
            if (error == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ouch! Error. Unfortunately, the analyzer was unable to analyze this sentence(s). :(");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("There may be a problem with:");
                Console.WriteLine(" -> the sentence's tense (this analyzer does not support present simple and some of past simple verbs)");
                Console.WriteLine(" -> the form of the sentence (Use only affirmative or negative form, not question!)");
                Console.WriteLine(" -> use of verb's shorter form (for example: 'We're' instead of 'We are')");
                Console.WriteLine(" -> typing too many sentences (the limit is 10)");
                Console.WriteLine(" -> other, unknown problem.");
                Console.WriteLine("-----");
                Console.ReadKey(true);
                Console.WriteLine("Please, try again.");
                System.Threading.Thread.Sleep(3000);
                goto sentenceInput;
            } //vypisuje se, pokud za běhu programu nastane nějaká chyba, aby buď nevypisoval nesmysly a nebo aby nespadl

            //toto je samotné vypsání výsledků analýzy
            int progressMultiplier = 0;

            switch (sentenceCount)
            {
                case 0:
                    progressMultiplier = 1;
                    break;

                case 1:
                    progressMultiplier = 1;
                    break;

                case 2:
                    progressMultiplier = 2;
                    break;

                case 3:
                    progressMultiplier = 2;
                    break;

                case 4:
                    progressMultiplier = 3;
                    break;

                case 5:
                    progressMultiplier = 3;
                    break;

                case 6:
                    progressMultiplier = 4;
                    break;

                case 7:
                    progressMultiplier = 4;
                    break;

                case 8:
                    progressMultiplier = 5;
                    break;

                case 9:
                    progressMultiplier = 6;
                    break;
            }

            for (int i = 0; i <= 100; i++)
            {
                Console.Clear();
                Console.WriteLine("----------");
                Console.Write("Progress: [");
                Console.ForegroundColor = ConsoleColor.Green;

                switch (i)
                {
                    case int j when (j >= 0 && j < 5):
                        Console.Write("{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("                    ]");
                        Console.WriteLine("Separating all words, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 30);
                        break;

                    case int j when (j >= 5 && j < 10):
                        Console.Write("#{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("                   ]");
                        Console.WriteLine("Searching for conjuctions, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 60);
                        break;

                    case int j when (j >= 10 && j < 15):
                        Console.Write("##{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("                  ]");
                        Console.WriteLine("Analyzing sentence type, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 70);
                        break;

                    case int j when (j >= 15 && j < 20):
                        Console.Write("###{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("                 ]");
                        Console.WriteLine("Joining separated words into sentences, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 30);
                        break;

                    case int j when (j >= 20 && j < 25):
                        Console.Write("####{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("                ]");
                        Console.WriteLine("Separating words from each sentence, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 30);
                        break;

                    case int j when (j >= 25 && j < 30):
                        Console.Write("#####{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("               ]");
                        Console.WriteLine("Searching for a verb in each sentence, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 80);
                        break;

                    case int j when (j >= 30 && j < 35):
                        Console.Write("######{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("              ]");
                        Console.WriteLine("Searching for a verb in each sentence, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 80);
                        break;

                    case int j when (j >= 35 && j < 40):
                        Console.Write("#######{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("             ]");
                        Console.WriteLine("Saving verbs, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 10);
                        break;

                    case int j when (j >= 40 && j < 45):
                        Console.Write("########{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("            ]");
                        Console.WriteLine("Analyzing each sentence's tense, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 40);
                        break;

                    case int j when (j >= 45 && j < 50):
                        Console.Write("#########{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("           ]");
                        Console.WriteLine("Saving tenses, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 10);
                        break;

                    case int j when (j >= 50 && j < 55):
                        Console.Write("##########{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("          ]");
                        Console.WriteLine("Checking for errors, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 30);
                        break;

                    case int j when (j >= 55 && j < 60):
                        Console.Write("###########{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("        ]");
                        Console.WriteLine("Searching for a conjuction in each sentence, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 30);
                        break;

                    case int j when (j >= 60 && j < 65):
                        Console.Write("############{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("       ]");
                        Console.WriteLine("Saving conjuctions, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 10);
                        break;

                    case int j when (j >= 65 && j < 70):
                        Console.Write("#############{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("      ]");
                        Console.WriteLine("Searching for a subject in each sentence, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 60);
                        break;

                    case int j when (j >= 70 && j < 75):
                        Console.Write("##############{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("     ]");
                        Console.WriteLine("Saving subjects, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 10);
                        break;

                    case int j when (j >= 75 && j < 80):
                        Console.Write("###############{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("    ]");
                        Console.WriteLine("Searching for a preposition in each sentence, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 60);
                        break;

                    case int j when (j >= 80 && j < 85):
                        Console.Write("################{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("   ]");
                        Console.WriteLine("Saving prepositional phrases, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 10);
                        break;

                    case int j when (j >= 85 && j < 90):
                        Console.Write("#################{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("  ]");
                        Console.WriteLine("Searching for an object in each sentence, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 60);
                        break;

                    case int j when (j >= 90 && j < 95):
                        Console.Write("##################{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine(" ]");
                        Console.WriteLine("Saving objects, please wait...");
                        System.Threading.Thread.Sleep(progressMultiplier * 10);
                        break;

                    case int j when (j >= 0 && j < 100):
                        Console.Write("###################{0}%", i);
                        Console.ResetColor();
                        Console.WriteLine("]");
                        Console.WriteLine("Finishing...");
                        System.Threading.Thread.Sleep(progressMultiplier * 100);
                        break;

                    case int j when (j == 100):
                        Console.Write("FINISHED!");
                        Console.ResetColor();
                        Console.WriteLine("]");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The sentence(s) was/were successfully analyzed! :)");
                        break;
                }
            } //tato část kódu je tu jen proto, že jsem si potřeboval hrát a udělat progress bar, ale vůbec by tu nemusela být :))))

            Console.ResetColor();
            Console.WriteLine("----------");
            Console.WriteLine("RESULTS:");
            Console.WriteLine("---");
            Console.Write("You typed in: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(sentences);
            Console.ResetColor();
            Console.Write("You typed in ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} sentence(s).", sentenceCount);
            Console.ResetColor();
            Console.Write("You typed in ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} type sentence(s)", sentenceType);
            Console.ResetColor();
            Console.WriteLine("---");

            for (int i = 0; i < sentenceCount; i++)
            {
                Console.Write("Sentence number {0} is: ", i + 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(separatedSentences[i]);
                Console.ResetColor();

                if (sentencesNegative[i] == false)
                {
                    Console.Write("Sentence number {0} is in ", i + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("affirmative form.");
                    Console.ResetColor();
                }
                else if (sentencesNegative[i] == true)
                {
                    Console.Write("Sentence number {0} is in ", i + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("negative form.");
                    Console.ResetColor();
                }

                if (sentenceConjuctions[i] != null)
                {
                    Console.Write("Sentence's number {0} conjuction is: ", i + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(sentenceConjuctions[i]);
                    Console.ResetColor();
                }

                Console.Write("Sentence's number {0} tense is: ", i + 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(sentencesTenses[i]);
                Console.ResetColor();

                Console.Write("Sentence's number {0} subject is: ", i + 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(sentencesSubjects[i]);
                Console.ResetColor();

                Console.Write("Sentence's number {0} verb is: ", i + 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(sentencesVerbs[i]);
                Console.ResetColor();

                if (sentencesObjects[i] != null)
                {
                    Console.Write("Sentence's number {0} object is: ", i + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(sentencesObjects[i]);
                    Console.ResetColor();
                }

                if (sentencesPrePhrases[i] != null)
                {
                    Console.Write("Sentence's number {0} prepositional phrase is: ", i + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(sentencesPrePhrases[i]);
                    Console.ResetColor();
                }

                Console.WriteLine("---");
            } //vypisuje jednotlivé prvky z každé věty

            Console.ReadKey(true);

            Console.WriteLine();
            Console.WriteLine("Do you want to type in another sentence(s)?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Y] - Yes");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("     [Any key] - No, end the app.");
            Console.ResetColor();
            Console.Write("Your answer: ");
            string answer = Console.ReadLine();

            if (answer == "Y" || answer == "y")
            {
                Console.Clear();
                goto sentenceInput;
            }
        }

        //vytvořeno a dokončeno 12.10.
        static void ProcessList()
        {
            List<int> poleCisel = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                poleCisel.Add(i + 1);
            }

            for (int i = 0; i < poleCisel.Count; i++)
            {
                poleCisel[i] = poleCisel[i] * poleCisel[i];
            }

            foreach (int number in poleCisel)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey(true);
        }

        static void StreamReader()
        {
            input:
            Console.WriteLine("STREAM READER");
            Console.WriteLine("---");
            Console.Write("Vložte cestu k souboru, který chcete vypsat: ");
            string pathToFile = @"" + Console.ReadLine();

            MyStreamReader streamReaderInstance = new MyStreamReader();

            if (streamReaderInstance.ReadFile(pathToFile) == "A" || streamReaderInstance.ReadFile(pathToFile) == "a")
            {
                goto input;
            }
        }        

        static void FileCopier()
        {
            FileCopierApp fileCopier = new FileCopierApp();
            
            string sourcePath = null;
            string endPath = null;       

            while(!fileCopier.copied)
            {
                Console.WriteLine("FILE COPIER");
                Console.WriteLine("---");
                
                if (sourcePath == null && endPath == null)
                {
                    Console.Write("Vložte cestu k souboru, který chcete, aby byl překopírován: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    sourcePath = @"" + Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Cesta byla úspěšně uložena!");
                    System.Threading.Thread.Sleep(1000);
                }               
                else if (sourcePath != null && endPath == null)
                {
                    Console.Write("Vložte cestu, kam chcete, aby se soubor nakopíroval: ");
                    Console.ForegroundColor = ConsoleColor.Yellow; 
                    endPath = @"" + Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Cesta byla úspěšně uložena!");
                    System.Threading.Thread.Sleep(1000);
                }
                else 
                {
                    fileCopier.Copy(sourcePath, endPath);

                    if (fileCopier.copied)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Soubor byl úspěšně překopírován! :)");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Program bude ukončen.");
                    System.Threading.Thread.Sleep(5000);
                }

                Console.ResetColor();
                Console.Clear();
            }             
        }
    }
}
