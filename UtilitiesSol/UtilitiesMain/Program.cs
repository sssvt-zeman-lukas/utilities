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
        static void Main(string[] args)
        {
            Console.WriteLine("Barevné popisky:");
            Console.Write("Funguje/je dokončeno: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("zelená barva");
            Console.ResetColor();
            Console.Write("Není dokončeno, částečně funguje: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("žlutá barva");
            Console.ResetColor();
            Console.Write("Nefunguje/není hotové: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("červená barva");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Vyberte utilitu, kterou chcete spustit: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1 - Process Array;");
            Console.WriteLine("2 - Display Entities;");
            Console.WriteLine("3 - Process Strings;");
            Console.WriteLine("4 - Sentence Analyzer");
            Console.WriteLine("5 - Process List");
            Console.WriteLine("6 - Document Analyzer");
            Console.WriteLine("7 - My Stream Reader");
            Console.WriteLine("8 - House Builder - NEW");
            Console.ResetColor();
            Console.WriteLine("Pro nejnovější funkční utilitu stiskněte enter nebo zadejte písmeno.");
            Console.Write("Napište vybrané číslo: ");
            string option = Console.ReadLine();
            Console.Clear();


            if (int.TryParse(option, out int optionNumber) == false)
            {
                optionNumber = 0;
            }

            switch (optionNumber)
            {
                case 0:
                    HouseBuilder();
                    break;

                case 1:
                    ProcessArray();
                    break;

                case 2:
                    DisplayEntities();
                    break;

                case 3:
                    ProcessStrings();
                    break;

                case 4:
                    SentenceAnalyzer();
                    break;

                case 5:
                    ProcessList();
                    break;

                case 6:
                    DocumentAnalyzer DocAnalyzerInstance = new DocumentAnalyzer();
                    DocAnalyzerInstance.AnalyzerV3();
                    break;

                case 7:
                    StreamReader();
                    break;

                case 8:
                    HouseBuilder();
                    break;
            }
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

        static void HouseBuilder()
        {
            //vytvoření dveří
            HouseBuilder.HouseBuilder_Door door1 = new HouseBuilder.HouseBuilder_Door(0.9, 2.2, false);
            HouseBuilder.HouseBuilder_Door door2 = new HouseBuilder.HouseBuilder_Door(1.8, 2.1, true);

            //vytvoření oken
            HouseBuilder.HouseBuilder_Window window1 = new HouseBuilder.HouseBuilder_Window("Standard", 0.8, 1.5);
            HouseBuilder.HouseBuilder_Window window2 = new HouseBuilder.HouseBuilder_Window("Standard", 0.8, 1.5);
            HouseBuilder.HouseBuilder_Window window3 = new HouseBuilder.HouseBuilder_Window("Francouz", 1.0, 2.2);

            //vytvoření domů
            HouseBuilder.HouseBuilder_House house1 = new HouseBuilder.HouseBuilder_House(8.5, 3.2, door1, window1, window2);
            HouseBuilder.HouseBuilder_House house2 = new HouseBuilder.HouseBuilder_House(12.1, 4.5, door2, window1, window3);

            //vytvoření bytů
            HouseBuilder.HouseBuilder_Flat flat1 = new HouseBuilder.HouseBuilder_Flat(8.5, 3.2, door1, window1, window2);
            HouseBuilder.HouseBuilder_Flat flat2 = new HouseBuilder.HouseBuilder_Flat(12.1, 4.5, door2, window1, window3);
            HouseBuilder.HouseBuilder_Flat flat3 = new HouseBuilder.HouseBuilder_Flat(10.2, 3.2, door2, window1, window2);
            HouseBuilder.HouseBuilder_Flat flat4 = new HouseBuilder.HouseBuilder_Flat(5.5, 3.2, door1, window1, null);
            HouseBuilder.HouseBuilder_Flat flat5 = new HouseBuilder.HouseBuilder_Flat(8.2, 3.2, door1, window3, window3);

            //vytvoření pater - nejdříve vytvoříme listy pro jednotlivá patra, které budou obsahovat byty na každém patře
            List<HouseBuilder.HouseBuilder_Flat> floor0_Flats = new List<HouseBuilder.HouseBuilder_Flat>();
            List<HouseBuilder.HouseBuilder_Flat> floor1_Flats = new List<HouseBuilder.HouseBuilder_Flat>();
            List<HouseBuilder.HouseBuilder_Flat> floor2_Flats = new List<HouseBuilder.HouseBuilder_Flat>();
            
            //vytvoření pater - zapíšeme jednotlivé byty do listů pater
            floor0_Flats.Add(flat3);
            floor0_Flats.Add(flat4);           
            floor1_Flats.Add(flat5);
            floor1_Flats.Add(flat1);
            floor2_Flats.Add(flat2);

            //vytvoření pater - vytvoříme instance tří pater
            HouseBuilder.HouseBuilder_Floor floor0 = new HouseBuilder.HouseBuilder_Floor(0, "přízemí", floor0_Flats);            
            HouseBuilder.HouseBuilder_Floor floor1 = new HouseBuilder.HouseBuilder_Floor(1, "byt s francouzskými okny má balkon", floor1_Flats);            
            HouseBuilder.HouseBuilder_Floor floor2 = new HouseBuilder.HouseBuilder_Floor(2, "s luxusním bytem a verandou", floor2_Flats);

            //vytvoření adres
            HouseBuilder.HouseBuilder_Adress adress1 = new HouseBuilder.HouseBuilder_Adress("K Ládví", 344, "Praha 8", 18100);
            HouseBuilder.HouseBuilder_Adress adress2 = new HouseBuilder.HouseBuilder_Adress("Vodičkova", 699, "Praha 1", 11000);
            HouseBuilder.HouseBuilder_Adress adress3 = new HouseBuilder.HouseBuilder_Adress("Sněmovní", 176, "Praha 1", 11826);

            //vytvoření paneláku - vytvoříme list obsahující jednotlivá patra paneláku
            List<HouseBuilder.HouseBuilder_Floor> towerBlock1_Floors = new List<HouseBuilder.HouseBuilder_Floor>();
            towerBlock1_Floors.Add(floor0);
            towerBlock1_Floors.Add(floor1);
            towerBlock1_Floors.Add(floor2);
            
            //vytvoření paneláku - vytvoříme instanci paneláku
            HouseBuilder.HouseBuilder_TowerBlock towerBlock1 = new HouseBuilder.HouseBuilder_TowerBlock(adress1, towerBlock1_Floors);

            //vypsání dveří
            Console.WriteLine("Dveře číslo 1 mají {0} metru na šířku, {1} metru na výšku a jsou " + ((door1.TwoSided == false) ? "jednokřídlé." : "dvoukřídlé."), door1.Width, door1.Width);
            Console.WriteLine("Dveře číslo 2 mají {0} metru na šířku, {1} metru na výšku a jsou " + ((door2.TwoSided == false) ? "jednokřídlé." : "dvoukřídlé."), door2.Width, door2.Width);

            //vypsání oken
            Console.WriteLine();
            Console.WriteLine("Okno typu {0} má šířku {1} metru a výšku {2} metru.", window1.Name, window1.Width, window1.Height);
            Console.WriteLine("Okno typu {0} má šířku {1} metru a výšku {2} metru.", window2.Name, window2.Width, window2.Height);
            Console.WriteLine("Okno typu {0} má šířku {1} metru a výšku {2} metru.", window3.Name, window3.Width, window3.Height);

            //vypsání domů
            Console.WriteLine();
            string windowsHouse1; string windowsHouse2;
            
            if (house1.Window2 == null)
            {
                windowsHouse1 = "jedno okno typu " + house1.Window1.Name;
            }
            else if (house1.Window1.Name == house1.Window2.Name)
            {
                windowsHouse1 = "dvě okna typu " + house1.Window1.Name;
            }
            else
            {
                windowsHouse1 = "jedno okno typu " + house1.Window1.Name + " a jedno typu " + house1.Window2.Name;
            }

            if (house2.Window2 == null)
            {
                windowsHouse2 = "jedno okno typu " + house2.Window1.Name;
            }
            else if (house2.Window1.Name == house2.Window2.Name)
            {
                windowsHouse2 = "dvě okna typu " + house2.Window1.Name;
            }
            else
            {
                windowsHouse2 = "jedno okno typu " + house2.Window1.Name + " a jedno typu " + house2.Window2.Name;
            }

            Console.WriteLine("Dům číslo 1 má šířku {0} metru a výšku {1} metru. Je tvořen " + ((house1.Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {2}.", house1.Width, house1.Height, windowsHouse1);
            Console.WriteLine("Dům číslo 2 má šířku {0} metru a výšku {1} metru. Je tvořen " + ((house2.Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {2}.", house2.Width, house2.Height, windowsHouse2);

            //vypsání bytů 
            Console.WriteLine();
            string windowsFlat1; string windowsFlat2; string windowsFlat3; string windowsFlat4; string windowsFlat5;

            if (flat1.Window2 == null)
            {
                windowsFlat1 = "jedno okno typu " + flat1.Window1.Name;
            }            
            else if (flat1.Window1.Name == flat1.Window2.Name)
            {
                windowsFlat1 = "dvě okna typu " + flat1.Window1.Name;
            }
            else
            {
                windowsFlat1 = "jedno okno typu " + flat1.Window1.Name + " a jedno typu " + flat1.Window2.Name;
            }

            if (flat2.Window2 == null)
            {
                windowsFlat2 = "jedno okno typu " + flat2.Window1.Name;
            }
            else if (flat2.Window1.Name == flat2.Window2.Name)
            {
                windowsFlat2 = "dvě okna typu " + flat2.Window1.Name;
            }
            else
            {
                windowsFlat2 = "jedno okno typu " + flat2.Window1.Name + " a jedno typu " + flat2.Window2.Name;
            }

            if (flat3.Window2 == null)
            {
                windowsFlat3 = "jedno okno typu " + flat3.Window1.Name;
            }
            else if (flat3.Window1.Name == flat3.Window2.Name)
            {
                windowsFlat3 = "dvě okna typu " + flat3.Window1.Name;
            }
            else
            {
                windowsFlat3 = "jedno okno typu " + flat3.Window1.Name + " a jedno typu " + flat3.Window2.Name;
            }

            if (flat4.Window2 == null)
            {
                windowsFlat4 = "jedno okno typu " + flat4.Window1.Name;
            }
            else if (flat4.Window1.Name == flat4.Window2.Name)
            {
                windowsFlat4 = "dvě okna typu " + flat4.Window1.Name;
            }
            else
            {
                windowsFlat4 = "jedno okno typu " + flat4.Window1.Name + " a jedno typu " + flat4.Window2.Name;
            }

            if (flat5.Window2 == null)
            {
                windowsFlat5 = "jedno okno typu " + flat5.Window1.Name;
            }
            else if (flat5.Window1.Name == flat5.Window2.Name)
            {
                windowsFlat5 = "dvě okna typu " + flat5.Window1.Name;
            }
            else
            {
                windowsFlat5 = "jedno okno typu " + flat5.Window1.Name + " a jedno typu " + flat5.Window2.Name;
            }

            Console.WriteLine("Byt číslo 1 má šířku {0} metru a výšku {1} metru. Je tvořen " + ((flat1.Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {2}.", flat1.Width, flat1.Height, windowsFlat1);
            Console.WriteLine("Byt číslo 2 má šířku {0} metru a výšku {1} metru. Je tvořen " + ((flat2.Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {2}.", flat2.Width, flat2.Height, windowsFlat2);
            Console.WriteLine("Byt číslo 3 má šířku {0} metru a výšku {1} metru. Je tvořen " + ((flat3.Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {2}.", flat3.Width, flat3.Height, windowsFlat3);
            Console.WriteLine("Byt číslo 4 má šířku {0} metru a výšku {1} metru. Je tvořen " + ((flat4.Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {2}.", flat4.Width, flat4.Height, windowsFlat4);
            Console.WriteLine("Byt číslo 5 má šířku {0} metru a výšku {1} metru. Je tvořen " + ((flat5.Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {2}.", flat5.Width, flat5.Height, windowsFlat5);

            //vypsání pater
            Console.WriteLine();
            string windows = "";

            Console.WriteLine("V patře číslo {0} ({1}) jsou následující byty: ", floor0.FloorNumber, floor0.FloorDescription);            
            for (int i = 0; i < floor0.Flat.Count; i++)
            {
                if (floor0.Flat[i] == flat1)
                {
                    windows = windowsFlat1;
                }
                else if (floor0.Flat[i] == flat2)
                {
                    windows = windowsFlat2;
                }
                else if (floor0.Flat[i] == flat3)
                {
                    windows = windowsFlat3;
                }
                else if (floor0.Flat[i] == flat4)
                {
                    windows = windowsFlat4;
                }
                else if (floor0.Flat[i] == flat5)
                {
                    windows = windowsFlat5;
                }

                Console.WriteLine("-> Byt číslo {0} má šířku {1} metru a výšku {2} metru. Je tvořen " + ((floor0.Flat[i].Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {3}.", i + 1, floor0.Flat[i].Width, floor0.Flat[i].Height, windows);
            }

            Console.WriteLine("V patře číslo {0} ({1}) jsou následující byty: ", floor1.FloorNumber, floor1.FloorDescription);
            for (int i = 0; i < floor1.Flat.Count; i++)
            {
                if (floor1.Flat[i] == flat1)
                {
                    windows = windowsFlat1;
                }
                else if (floor1.Flat[i] == flat2)
                {
                    windows = windowsFlat2;
                }
                else if (floor1.Flat[i] == flat3)
                {
                    windows = windowsFlat3;
                }
                else if (floor1.Flat[i] == flat4)
                {
                    windows = windowsFlat4;
                }
                else if (floor1.Flat[i] == flat5)
                {
                    windows = windowsFlat5;
                }

                Console.WriteLine("-> Byt číslo {0} má šířku {1} metru a výšku {2} metru. Je tvořen " + ((floor1.Flat[i].Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {3}.", i + 1, floor1.Flat[i].Width, floor1.Flat[i].Height, windows);
            }

            Console.WriteLine("V patře číslo {0} ({1}) jsou následující byty: ", floor2.FloorNumber, floor2.FloorDescription);
            for (int i = 0; i < floor2.Flat.Count; i++)
            {
                if (floor2.Flat[i] == flat1)
                {
                    windows = windowsFlat1;
                }
                else if (floor2.Flat[i] == flat2)
                {
                    windows = windowsFlat2;
                }
                else if (floor2.Flat[i] == flat3)
                {
                    windows = windowsFlat3;
                }
                else if (floor2.Flat[i] == flat4)
                {
                    windows = windowsFlat4;
                }
                else if (floor2.Flat[i] == flat5)
                {
                    windows = windowsFlat5;
                }

                Console.WriteLine("-> Byt číslo {0} má šířku {1} metru a výšku {2} metru. Je tvořen " + ((floor2.Flat[i].Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {3}.", i + 1, floor2.Flat[i].Width, floor2.Flat[i].Height, windows);
            }

            //vypsání adres
            Console.WriteLine();
            Console.WriteLine("První adresa: {0} {1}, {2}, {3}", adress1.Adress, adress1.HouseNumber, adress1.City, adress1.PostalCode);
            Console.WriteLine("Druhá adresa: {0} {1}, {2}, {3}", adress2.Adress, adress2.HouseNumber, adress2.City, adress2.PostalCode);
            Console.WriteLine("Třetí adresa: {0} {1}, {2}, {3}", adress3.Adress, adress3.HouseNumber, adress3.City, adress3.PostalCode);

            //vypsání paneláku
            Console.WriteLine();
            Console.WriteLine("Panelák číslo jedna má adresu: {0} {1}, {2}, {3} a má tyto patra:", towerBlock1.Adress.Adress, towerBlock1.Adress.HouseNumber, towerBlock1.Adress.City, towerBlock1.Adress.PostalCode);
            for (int i = 0; i < towerBlock1.Floors.Count; i++)
            {
                Console.WriteLine("V patře číslo {0} ({1}) jsou následující byty: ", towerBlock1.Floors[i].FloorNumber, towerBlock1.Floors[i].FloorDescription);
                
                for (int j = 0; j < towerBlock1.Floors[i].Flat.Count; j++)
                {
                    if (towerBlock1.Floors[i].Flat[j] == flat1)
                    {
                        windows = windowsFlat1;
                    }
                    else if (towerBlock1.Floors[i].Flat[j] == flat2)
                    {
                        windows = windowsFlat2;
                    }
                    else if (towerBlock1.Floors[i].Flat[j] == flat3)
                    {
                        windows = windowsFlat3;
                    }
                    else if (towerBlock1.Floors[i].Flat[j] == flat4)
                    {
                        windows = windowsFlat4;
                    }
                    else if (towerBlock1.Floors[i].Flat[j] == flat5)
                    {
                        windows = windowsFlat5;
                    }

                    Console.WriteLine("-> Byt číslo {0} má šířku {1} metru a výšku {2} metru. Je tvořen " + ((towerBlock1.Floors[i].Flat[j].Door.TwoSided == true) ? "dvoukřídlými" : "jednokřídlymi") + " dveřmi a má {3}.", j + 1, towerBlock1.Floors[i].Flat[j].Width, towerBlock1.Floors[i].Flat[j].Height, windows);
                }
            }

            Console.ReadKey(true);
        }
    }
}
