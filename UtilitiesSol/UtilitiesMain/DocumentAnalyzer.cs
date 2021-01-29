using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMain
{
    public class DocumentAnalyzer
    {
        // vytvořeno: 14.10.; částečně funkční verze: 21.10.; plně funkční verze, opravené chyby: 28.10.           
        public void AnalyzerV3()
        {
            List<string> examples = new List<string>();
            examples.Add("Tom was studying English in his room.");
            examples.Add("He ate a lot of Apples and Peaches.");
            examples.Add("He has been doing his project from home for two weeks now.");
            examples.Add("She will be sleeping by the time they will get home.");
            examples.Add("He would have been running fast provided that there was nothing in the way.");
            examples.Add("Paul cried because the ball hit him, and I immediately apologized.");
            examples.Add("Victoria is spending a lot of time inside even though her friends have been trying to get her out, yet she is enjoying the comfort of being home more and more.");
            examples.Add("Nobody is going to go out even if the pandemic will have slowed down, so the streets will remain empty for a few weeks unless the virus is going to stop spreading completely.");

        sentenceInput:
            bool typing = true;
            List<string> sentences = new List<string>();
            int sentenceNumber = 1;

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         (ENGLISH) SYNTATIC                                                ");
            Console.WriteLine("                                              ANALYZER                                                     ");
            Console.WriteLine("                                                v3.0                                                       ");
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Changelog v3.0: ");
            Console.ResetColor();
            Console.WriteLine("---");
            Console.WriteLine("1) You are now able to type in more rows. So you can check multiple simple, compound or complex sentences! :)");
            Console.WriteLine("2) You are now able to type in unlimited sentences! That means unlimited dependent or independent clauses! :)");
            Console.WriteLine("3) Faster analyzing! THIS APP IS SPEED. WE ARE NOT JOKING! ... yes, we are joking... but it's FASTER!!! FAAASTEEEERR!!!");
            Console.WriteLine("---");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Notes and warnings: ");
            Console.ResetColor();
            Console.WriteLine("---");
            Console.WriteLine("! This analyzer does NOT suppport question or negative sentence form!");
            Console.WriteLine("! This analyzer does NOT support present simple tense and few past tense irregular verbs! (to be precise, ");
            Console.WriteLine("  it doesn't support irregular verbs, which have the same form as in present simple tense.)");
            Console.WriteLine("! This analyzer is sensitive to mispelling, and may not work if there are mispellings in sentences.");
            Console.WriteLine("---");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Additional information: ");
            Console.ResetColor();
            Console.WriteLine("---");
            Console.Write("- After typing all sentences, type ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("'EOD'");
            Console.ResetColor();
            Console.WriteLine(", or leave the space blank and press Enter.");
            Console.Write("- If you just want to try out this analyzer, write ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("'examples'");
            Console.ResetColor();
            Console.WriteLine(" in this form down below.");
            Console.WriteLine("-----");

            while (typing)
            {
                Console.Write("Your english sentence(s) number {0}: ", sentenceNumber);
                string input = Console.ReadLine();

                if (input == "examples" || input == "Examples")
                {
                    Console.WriteLine("Sentence examples: ");

                    for (int i = 0; i < examples.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("[{0}] ", i + 1);
                        Console.ResetColor();
                        Console.WriteLine(examples[i]);
                    }

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("[9] ");
                    Console.ResetColor();
                    Console.WriteLine("All of the above.");
                    Console.WriteLine("-----");

                    Console.Write("Select number: ");
                    int exampleChoice = Convert.ToInt32(Console.ReadLine());

                    int CursorStartPos = Console.CursorTop;
                    for (int i = 0; i <= 14; i++)
                    {
                        Console.SetCursorPosition(0, CursorStartPos - i);
                        Console.Write(new string(' ', Console.WindowWidth));
                    }
                    Console.WriteLine("Added examples: ");

                    switch (exampleChoice)
                    {
                        case 1:
                            sentences.Add(examples[0]);
                            Console.Write("Sentence {0} ", sentenceNumber);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("sucessfully added!");
                            Console.ResetColor();
                            sentenceNumber++;
                            Console.WriteLine();
                            break;
                        case 2:
                            sentences.Add(examples[1]);
                            Console.Write("Sentence {0} ", sentenceNumber);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("sucessfully added!");
                            Console.ResetColor();
                            sentenceNumber++;
                            Console.WriteLine();
                            break;
                        case 3:
                            sentences.Add(examples[2]);
                            Console.Write("Sentence {0} ", sentenceNumber);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("sucessfully added!");
                            Console.ResetColor();
                            sentenceNumber++;
                            Console.WriteLine();
                            break;
                        case 4:
                            sentences.Add(examples[3]);
                            Console.Write("Sentence {0} ", sentenceNumber);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("sucessfully added!");
                            Console.ResetColor();
                            sentenceNumber++;
                            Console.WriteLine();
                            break;
                        case 5:
                            sentences.Add(examples[4]);
                            Console.Write("Sentence {0} ", sentenceNumber);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("sucessfully added!");
                            Console.ResetColor();
                            sentenceNumber++;
                            Console.WriteLine();
                            break;
                        case 6:
                            sentences.Add(examples[5]);
                            Console.Write("Sentence {0} ", sentenceNumber);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("sucessfully added!");
                            Console.ResetColor();
                            sentenceNumber++;
                            Console.WriteLine();
                            break;
                        case 7:
                            sentences.Add(examples[6]);
                            Console.Write("Sentence {0} ", sentenceNumber);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("sucessfully added!");
                            Console.ResetColor();
                            sentenceNumber++;
                            Console.WriteLine();
                            break;
                        case 8:
                            sentences.Add(examples[7]);
                            Console.Write("Sentence {0} ", sentenceNumber);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("sucessfully added!");
                            Console.ResetColor();
                            sentenceNumber++;
                            Console.WriteLine();
                            break;
                        case 9:
                            for (int i = 0; i < examples.Count; i++)
                            {
                                sentences.Add(examples[i]);
                                Console.Write("Sentence {0} ", sentenceNumber);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("sucessfully added!");
                                Console.ResetColor();
                                sentenceNumber++;
                                System.Threading.Thread.Sleep(50);
                            }
                            Console.WriteLine();
                            break;
                    }
                }
                else if (input == "eod" || input == "EOD" || input == "Eod" || input == "" || input == " ")
                {
                    typing = false;
                }
                else
                {
                    sentences.Add(input);
                    Console.Write("Sentence {0} ", sentenceNumber);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("sucessfully added!");
                    Console.ResetColor();
                    sentenceNumber++;
                    Console.WriteLine();
                }
            }

            List<string> sentenceType = new List<string>();
            List<string> separatedSentences = new List<string>();
            List<string> sentencesSubjects = new List<string>();
            List<string> sentencesVerbs = new List<string>();
            List<string> sentencesObjects = new List<string>();
            List<string> sentencesPrePhrases = new List<string>();
            List<string> sentencesTenses = new List<string>();
            List<string> sentenceConjuctions = new List<string>();
            List<int> sentenceLengths = new List<int>();
            List<int> sentencesOnRow = new List<int>();
            sentencesOnRow.Add(0);
            int rowsAnalyzed = 1;
            int realpos = 0;
            bool error = false;

            //nechal jsem tyto položky jako pole, protože tady není potřeba, aby se nějak velikost přizpůsobovala při běhu programu
            string[] presentContinuous = new string[3] { "am", "are", "is" };
            string[] irregularVerbs = new string[96] { "was", "were", "beat", "became", "began", "blew", "broke", "brought", "built", "burst", "bought", "caught", "chose", "came", "cost", "cut", "cried", "dealt", "did", "drew", "drank", "drove", "ate", "fell", "fed", "felt", "fought", "found", "flew", "forgot", "froze", "got", "gave", "went", "grew", "hung", "had", "heard", "hid", "hit", "held", "hurt", "kept", "knew", "laid", "led", "left", "lent", "let", "lay", "lit", "lost", "made", "meant", "met", "paid", "put", "rode", "rang", "rose", "ran", "said", "saw", "sold", "sent", "shook", "stole", "shone", "shot", "showed", "sang", "sank", "sat", "slept", "slid", "spoke", "spent", "sprang", "stood", "stuck", "swore", "swept", "swam", "swung", "took", "taught", "tore", "told", "thought", "threw", "understood", "woke", "wore", "wove", "won", "wrote" };
            string[] pastParticiple = new string[98] { "been", "beaten", "become", "begun", "bet", "blown", "broken", "brought", "built", "burst", "bought", "caught", "chosen", "come", "cost", "cut", "dealt", "done", "drawn", "drunk", "driven", "eaten", "fallen", "fed", "felt", "fought", "found", "flown", "forgotten", "frozen", "got", "given", "gone", "grown", "hung", "had", "heard", "hidden", "hit", "held", "hurt", "kept", "known", "laid", "led", "left", "lent", "let", "lain", "lit", "lost", "made", "meant", "met", "paid", "put", "read", "ridden", "rung", "risen", "run", "said", "seen", "sold", "sent", "set", "shaken", "stolen", "shone", "shot", "shown", "shut", "sung", "sunk", "sat", "slept", "slid", "spoken", "spent", "sprung", "stood", "stuck", "sworn", "swept", "swum", "swung", "taken", "taught", "torn", "told", "thought", "thrown", "understood", "woken", "worn", "woven", "won", "written" };
            string[] prepositions = new string[29] { "on", "in", "at", "since", "for", "before", "ago", "to", "past", "till", "until", "by", "next to", "beside", "under", "below", "over", "above", "across", "through", "into", "towards", "onto", "from", "of", "off", "out of", "about", "with" };
            string[] subConjuctions = new string[37] { "after", "although", "as", "as if", "as long as", "as much as", "as soon as", "as though", "because", "before", "by the time", "even if", "even though", "if", "in order that", "in case", "in the event that", "lest", "now that", "once", "only", "only if", "provided that", "since", "so", "supposing", "that", "than", "though", "till", "unless", "whenever", "where", "whereas", "wherever", "whether", "while" };
            string[] coordiConjuctions = new string[7] { "for", "and", "nor", "but", "or", "yet", "so" };

            //využití foreach dle zadání.
            foreach (string sentence in sentences)
            {
                int sentenceCount = 1;
                sentenceConjuctions.Add(null);

                string[] separatedWords = sentence.Split(' ');
                int separatedWordsLastPos = 0;
                int nextSentenceLength = 0;

                for (int i = 0; i < separatedWords.Length; i++)
                {
                    for (int j = 0; j < coordiConjuctions.Length; j++)
                    {
                        if (separatedWords[i] == coordiConjuctions[j])
                        {
                            if (i > 0 && separatedWords[i - 1].EndsWith(","))
                            {
                                nextSentenceLength = i;

                                if (sentenceCount == 1)
                                {
                                    sentenceLengths.Add(i);
                                }
                                else if (sentenceCount > 1)
                                {
                                    sentenceLengths.Add(i - sentenceLengths[sentenceCount - 2] + 1);
                                }

                                separatedSentences.Add(string.Join(" ", separatedWords, separatedWordsLastPos, nextSentenceLength - separatedWordsLastPos));
                                sentenceConjuctions.Add(coordiConjuctions[j]);
                                separatedWordsLastPos = i;
                                sentenceCount += 1;
                                i += 1;

                                if (sentenceCount == 2)
                                {
                                    sentenceType.Add("compound");
                                }
                            }
                        }
                    }

                    for (int j = 0; j < subConjuctions.Length; j++)
                    {
                        if (i + 3 < separatedWords.Length && string.Join(" ", separatedWords, i, 3) == subConjuctions[j])
                        {
                            nextSentenceLength = i;

                            if (sentenceCount == 1)
                            {
                                sentenceLengths.Add(i);
                            }
                            else if (sentenceCount > 1)
                            {
                                sentenceLengths.Add(i - sentenceLengths[sentenceCount - 2] + 4);
                            }

                            separatedSentences.Add(string.Join(" ", separatedWords, separatedWordsLastPos, nextSentenceLength - separatedWordsLastPos));
                            sentenceConjuctions.Add(subConjuctions[j]);
                            separatedWordsLastPos = i;
                            sentenceCount += 1;
                            i += 3;

                            if (sentenceCount == 2)
                            {
                                sentenceType.Add("complex");
                            }
                        }
                        else if (i + 2 < separatedWords.Length && string.Join(" ", separatedWords, i, 2) == subConjuctions[j])
                        {
                            nextSentenceLength = i;

                            if (sentenceCount == 1)
                            {
                                sentenceLengths.Add(i);
                            }
                            else if (sentenceCount > 1)
                            {
                                sentenceLengths.Add(i - sentenceLengths[sentenceCount - 2] + 3);
                            }

                            separatedSentences.Add(string.Join(" ", separatedWords, separatedWordsLastPos, nextSentenceLength - separatedWordsLastPos));
                            sentenceConjuctions.Add(subConjuctions[j]);
                            separatedWordsLastPos = i;
                            sentenceCount += 1;
                            i += 2;

                            if (sentenceCount == 2)
                            {
                                sentenceType.Add("complex");
                            }
                        }
                        else if (i + 1 < separatedWords.Length && string.Join(" ", separatedWords, i, 1) == subConjuctions[j])
                        {
                            nextSentenceLength = i;

                            if (sentenceCount == 1)
                            {
                                sentenceLengths.Add(i);
                            }
                            else if (sentenceCount > 1)
                            {
                                sentenceLengths.Add(i - sentenceLengths[sentenceCount - 2] + 2);
                            }

                            separatedSentences.Add(string.Join(" ", separatedWords, separatedWordsLastPos, nextSentenceLength - separatedWordsLastPos));
                            sentenceConjuctions.Add(subConjuctions[j]);
                            separatedWordsLastPos = i;
                            sentenceCount += 1;
                            i += 1;

                            if (sentenceCount == 2)
                            {
                                sentenceType.Add("complex");
                            }
                        }
                        else if (separatedWords[i] == subConjuctions[j])
                        {
                            nextSentenceLength = i;

                            if (sentenceCount == 1)
                            {
                                sentenceLengths.Add(i);
                            }
                            else if (sentenceCount > 1)
                            {
                                sentenceLengths.Add(i - sentenceLengths[sentenceCount - 2] + 1);
                            }

                            separatedSentences.Add(string.Join(" ", separatedWords, separatedWordsLastPos, nextSentenceLength - separatedWordsLastPos));
                            sentenceConjuctions.Add(subConjuctions[j]);
                            separatedWordsLastPos = i;
                            sentenceCount += 1;

                            if (sentenceCount == 2)
                            {
                                sentenceType.Add("complex");
                            }
                        }
                    }
                }

                if (sentenceCount > 2)
                {
                    sentenceType.RemoveAt(rowsAnalyzed - 1);
                    sentenceType.Add("compound-complex");
                }
                else if (sentenceCount == 1)
                {
                    sentenceType.Add("simple");
                }

                separatedSentences.Add(string.Join(" ", separatedWords, separatedWordsLastPos, separatedWords.Length - separatedWordsLastPos));
                sentenceLengths.Add(separatedSentences[separatedSentences.Count - 1].Split(' ').Length);
                sentencesOnRow.Add(sentenceCount);

                for (int h = 0; h < sentencesOnRow[rowsAnalyzed]; h++)
                {
                    string[] separatedWordsFromSentence = new string[separatedSentences[realpos].Split(' ').Length];
                    int startAnalyzeAt = 0;
                    int verbStartPosition = 0;
                    int verbEndPosition = 0;

                    if (separatedSentences[realpos] != null)
                    {
                        separatedWordsFromSentence = separatedSentences[realpos].Split(' ');
                    }

                    if (separatedWordsFromSentence.Length - 1 >= 1 && separatedWordsFromSentence[separatedWordsFromSentence.Length - 1].EndsWith("."))
                    {
                        separatedWordsFromSentence[separatedWordsFromSentence.Length - 1] = separatedWordsFromSentence[separatedWordsFromSentence.Length - 1].TrimEnd('.');
                    }
                    else if (separatedWordsFromSentence.Length - 1 >= 1 && separatedWordsFromSentence[separatedWordsFromSentence.Length - 1].EndsWith(","))
                    {
                        separatedWordsFromSentence[separatedWordsFromSentence.Length - 1] = separatedWordsFromSentence[separatedWordsFromSentence.Length - 1].TrimEnd(',');
                    }

                    if (sentenceConjuctions[realpos] != null)
                    {
                        startAnalyzeAt = sentenceConjuctions[realpos].Split(' ').Length;
                    }

                    for (int i = startAnalyzeAt; i < separatedWordsFromSentence.Length; i++)
                    {
                        for (int j = 0; j < presentContinuous.Length; j++)
                        {
                            if (separatedWordsFromSentence[i] == presentContinuous[j])
                            {
                                if (separatedWordsFromSentence[i + 1] == "going" && separatedWordsFromSentence[i + 2] == "to" && i + 2 < separatedWordsFromSentence.Length)
                                {
                                    sentencesTenses.Add("future - going to");
                                    sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 3));
                                    verbStartPosition = i;
                                    verbEndPosition = i + 2;
                                    i += 3;
                                    break;
                                }
                                else if (separatedWordsFromSentence[i + 1].EndsWith("ing") && i + 1 < separatedWordsFromSentence.Length)
                                {
                                    sentencesTenses.Add("present continuous");
                                    sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 2));
                                    verbStartPosition = i;
                                    verbEndPosition = i + 1;
                                    i += 2;
                                    break;
                                }
                            }
                        }

                        for (int j = 0; j < irregularVerbs.Length; j++)
                        {
                            if (i + 1 < separatedWordsFromSentence.Length && separatedWordsFromSentence[i] == irregularVerbs[j] && separatedWordsFromSentence[i + 1].EndsWith("ing") == false)
                            {
                                sentencesTenses.Add("past simple");
                                sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 1));
                                verbStartPosition = i;
                                verbEndPosition = i;
                                i += 1;
                                break;
                            }
                        }

                        if (realpos < sentencesVerbs.Count && separatedWordsFromSentence[i] == sentencesVerbs[realpos])
                        {
                            break;
                        }

                        if (separatedWordsFromSentence[i] == "will")
                        {
                            if (separatedWordsFromSentence[i + 1] == "be" && separatedWordsFromSentence[i + 2].EndsWith("ing") && i + 2 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses.Add("future continuous");
                                sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 3));
                                verbStartPosition = i;
                                verbEndPosition = i + 2;
                                i += 3;
                            }
                            else if (separatedWordsFromSentence[i + 1] == "have" && i + 1 < separatedWordsFromSentence.Length)
                            {
                                if (separatedWordsFromSentence[i + 2] == "been" && separatedWordsFromSentence[i + 3].EndsWith("ing") && i + 3 < separatedWordsFromSentence.Length)
                                {
                                    sentencesTenses.Add("future perfect continuous");
                                    sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 4));
                                    verbStartPosition = i;
                                    verbEndPosition = i + 3;
                                    i += 4;
                                }
                                else if (separatedWordsFromSentence[i + 2].EndsWith("ed") && i + 2 < separatedWordsFromSentence.Length)
                                {
                                    sentencesTenses.Add("future perfect simple");
                                    sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 3));
                                    verbStartPosition = i;
                                    verbEndPosition = i + 2;
                                    i += 3;
                                }
                                else
                                {
                                    for (int k = 0; k < pastParticiple.Length; k++)
                                    {
                                        if (separatedWordsFromSentence[i + 2] == pastParticiple[k] && i + 2 < separatedWordsFromSentence.Length)
                                        {
                                            sentencesTenses.Add("future perfect simple");
                                            sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 3));
                                            verbStartPosition = i;
                                            verbEndPosition = i + 2;
                                            i += 3;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                sentencesTenses.Add("future simple");
                                sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 2));
                                verbStartPosition = i;
                                verbEndPosition = i + 1;
                                i += 2;
                            }

                            break;
                        }
                        else if (separatedWordsFromSentence[i] == "would")
                        {
                            if (separatedWordsFromSentence[i + 1] == "be" && separatedWordsFromSentence[i + 2].EndsWith("ing") && i + 2 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses.Add("Conditional Continuous");
                                sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 3));
                                verbStartPosition = i;
                                verbEndPosition = i + 2;
                                i += 3;
                            }
                            else if (separatedWordsFromSentence[i + 1] == "have" && i + 1 < separatedWordsFromSentence.Length)
                            {
                                if (separatedWordsFromSentence[i + 2] == "been" && separatedWordsFromSentence[i + 3].EndsWith("ing") && i + 3 < separatedWordsFromSentence.Length)
                                {
                                    sentencesTenses.Add("conditional perfect continuous");
                                    sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 4));
                                    verbStartPosition = i;
                                    verbEndPosition = i + 3;
                                    i += 4;
                                }
                                else if (separatedWordsFromSentence[i + 2].EndsWith("ed") && i + 2 < separatedWordsFromSentence.Length)
                                {
                                    sentencesTenses.Add("conditional perfect simple");
                                    sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 3));
                                    verbStartPosition = i;
                                    verbEndPosition = i + 2;
                                    i += 3;
                                }
                                else
                                {
                                    for (int k = 0; k < pastParticiple.Length; k++)
                                    {
                                        if (separatedWordsFromSentence[i + 2] == pastParticiple[k] && i + 2 < separatedWordsFromSentence.Length)
                                        {
                                            sentencesTenses.Add("conditional perfect simple");
                                            sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 3));
                                            verbStartPosition = i;
                                            verbEndPosition = i + 2;
                                            i += 3;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                sentencesTenses.Add("conditional simple (would)");
                                sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 2));
                                verbStartPosition = i;
                                verbEndPosition = i + 1;
                                i += 2;
                            }

                            break;
                        }
                        else if (separatedWordsFromSentence[i] == "had")
                        {
                            if (separatedWordsFromSentence[i + 1] == "been" && separatedWordsFromSentence[i + 2].EndsWith("ing") && i + 2 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses.Add("past perfect continuous");
                                sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 3));
                                verbStartPosition = i;
                                verbEndPosition = i + 2;
                                i += 3;
                            }
                            else if (separatedWordsFromSentence[i + 1].EndsWith("ed") && i + 1 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses.Add("past perfect simple");
                                sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 2));
                                verbStartPosition = i;
                                verbEndPosition = i + 1;
                                i += 2;
                            }
                            else
                            {
                                for (int k = 0; k < pastParticiple.Length; k++)
                                {
                                    sentencesTenses.Add("past simple");
                                    sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 1));
                                    verbStartPosition = i;
                                    verbEndPosition = i;
                                    i += 1;

                                    if (separatedWordsFromSentence[i + 1] == pastParticiple[k] && i + 1 < separatedWordsFromSentence.Length)
                                    {
                                        sentencesTenses.Add("past perfect simple");
                                        sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 2));
                                        verbStartPosition = i;
                                        verbEndPosition = i + 1;
                                        i += 2;
                                    }
                                }
                            }

                            break;
                        }
                        else if (separatedWordsFromSentence[i] == "was" || separatedWordsFromSentence[i] == "were")
                        {
                            if (separatedWordsFromSentence[i + 1].EndsWith("ing") && i + 1 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses.Add("past continuous");
                                sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 2));
                                verbStartPosition = i;
                                verbEndPosition = i + 1;
                                i += 2;
                            }
                            else
                            {
                                sentencesTenses.Add("past simple");
                                sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 1));
                                verbStartPosition = i;
                                verbEndPosition = i;
                                i += 1;
                            }

                            break;
                        }
                        else if (separatedWordsFromSentence[i].EndsWith("ed") && separatedWordsFromSentence[i] != sentenceConjuctions[realpos])
                        {
                            sentencesTenses.Add("past simple");
                            sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 1));
                            verbStartPosition = i;
                            verbEndPosition = i;
                            i += 2;
                        }
                        else if (separatedWordsFromSentence[i] == "has" || separatedWordsFromSentence[i] == "have")
                        {
                            if (separatedWordsFromSentence[i + 1] == "been" && separatedWordsFromSentence[i + 2].EndsWith("ing") && i + 2 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses.Add("present perfect continuous");
                                sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 3));
                                verbStartPosition = i;
                                verbEndPosition = i + 2;
                                i += 3;
                            }
                            else if (separatedWordsFromSentence[i + 1].EndsWith("ed") && i + 1 < separatedWordsFromSentence.Length)
                            {
                                sentencesTenses.Add("present perfect simple");
                                sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 2));
                                verbStartPosition = i;
                                verbEndPosition = i + 1;
                                i += 2;
                            }
                            else
                            {
                                for (int k = 0; k < pastParticiple.Length; k++)
                                {
                                    if (separatedWordsFromSentence[i + 1] == pastParticiple[k] && i + 1 < separatedWordsFromSentence.Length)
                                    {
                                        sentencesTenses.Add("present perfect simple");
                                        sentencesVerbs.Add(string.Join(" ", separatedWordsFromSentence, i, 2));
                                        verbStartPosition = i;
                                        verbEndPosition = i + 1;
                                        i += 2;
                                    }
                                }
                            }

                            break;
                        }
                    }

                    if (sentencesVerbs[0] == null)
                    {
                        error = true;
                        goto error;
                    }

                    if (sentencesVerbs.Count == 1 || sentenceConjuctions[realpos] == null)
                    {
                        sentencesSubjects.Add(string.Join(" ", separatedWordsFromSentence, 0, verbStartPosition));
                    }
                    else if (sentencesVerbs.Count > 1 && sentenceConjuctions[realpos] != null)
                    {
                        sentencesSubjects.Add(string.Join(" ", separatedWordsFromSentence, sentenceConjuctions[realpos].Split(' ').Length, verbStartPosition - sentenceConjuctions[realpos].Split(' ').Length));
                    }

                    for (int i = verbEndPosition; i < separatedWordsFromSentence.Length; i++)
                    {
                        for (int j = 0; j < prepositions.Length; j++)
                        {
                            if (separatedWordsFromSentence[i] == prepositions[j])
                            {
                                sentencesPrePhrases.Add(string.Join(" ", separatedWordsFromSentence, i, separatedWordsFromSentence.Length - i));

                                if (i != verbEndPosition + 1 && verbEndPosition + 1 < separatedWordsFromSentence.Length && i - verbEndPosition - 1 > 0)
                                {
                                    sentencesObjects.Add(string.Join(" ", separatedWordsFromSentence, verbEndPosition + 1, i - verbEndPosition - 1));
                                }

                                break;
                            }
                        }

                        if (sentencesPrePhrases.Count > realpos && sentencesPrePhrases[realpos].Substring(0, separatedWordsFromSentence[i].Length) == separatedWordsFromSentence[i])
                        {
                            break;
                        }
                    }

                    if (sentencesPrePhrases.Count < realpos + 1 && verbEndPosition + 1 <= separatedWordsFromSentence.Length)
                    {
                        sentencesObjects.Add(string.Join(" ", separatedWordsFromSentence, verbEndPosition + 1, separatedWordsFromSentence.Length - verbEndPosition - 1));
                    }

                    if (sentencesPrePhrases.Count < realpos + 1)
                    {
                        sentencesPrePhrases.Add(null);
                    }

                    if (sentencesObjects.Count < realpos + 1)
                    {
                        sentencesObjects.Add(null);
                    }
                    else if (sentencesObjects[realpos] == "")
                    {
                        sentencesObjects[realpos] = null;
                    }

                    realpos += 1;
                }

            error:
                if (error == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ouch! Error. Unfortunately, the analyzer was unable to analyze this sentence(s). :(");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("There may be a problem with:");
                    Console.WriteLine(" -> the sentence's tense (this analyzer does not support present simple and some of past simple verbs)");
                    Console.WriteLine(" -> the form of the sentence (Use only affirmative form, not question or negative!)");
                    Console.WriteLine(" -> use of verb's shorter form (for example: 'We're' instead of 'We are')");
                    Console.WriteLine(" -> other, unknown problem.");
                    Console.WriteLine("-----");
                    Console.ReadKey(true);
                    Console.WriteLine("Please, try again.");
                    System.Threading.Thread.Sleep(3000);
                    goto sentenceInput;
                }

                rowsAnalyzed += 1;
            }

            int progressMultiplier = 0;
            int rowNumber = 0;
            int sentencePos = 0;
            int sentencesWritten = 0;
            int stopWritingAt = 0;

            switch (sentencesOnRow.Count)
            {
                case 1:
                    progressMultiplier = 1;
                    break;

                case 2:
                    progressMultiplier = 1;
                    break;

                case 3:
                    progressMultiplier = 2;
                    break;

                case 4:
                    progressMultiplier = 2;
                    break;

                case 5:
                    progressMultiplier = 3;
                    break;

                case 6:
                    progressMultiplier = 3;
                    break;

                case 7:
                    progressMultiplier = 4;
                    break;

                case 8:
                    progressMultiplier = 4;
                    break;

                case 9:
                    progressMultiplier = 5;
                    break;

                case int j when (j >= 10):
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
            }

            Console.ResetColor();
            Console.WriteLine("----------");
            Console.WriteLine("RESULTS:");
            Console.WriteLine("-----");

            foreach (string sentence in sentences)
            {
                rowNumber += 1;
                sentencesWritten = 0;
                stopWritingAt = sentencePos + sentencesOnRow[rowNumber];

                Console.WriteLine("ROW NUMBER {0}", rowNumber);
                Console.WriteLine("---");
                Console.Write("On row number {0} you typed in: ", rowNumber);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(sentence);
                Console.ResetColor();
                Console.Write("On this row you typed in ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0} sentence(s).", sentencesOnRow[rowNumber]);
                Console.ResetColor();
                Console.Write("On this row you typed in ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0} type sentence(s)", sentenceType[rowNumber - 1]);
                Console.ResetColor();
                Console.WriteLine("---");

                for (int i = sentencePos; i < stopWritingAt; i++)
                {
                    sentencePos += 1;
                    sentencesWritten += 1;

                    Console.Write("Sentence number {0} on this row is: ", sentencesWritten);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(separatedSentences[i]);
                    Console.ResetColor();

                    if (sentenceConjuctions.Count > i && sentenceConjuctions[i] != null)
                    {
                        Console.Write("Sentence's number {0} conjuction on this row is: ", sentencesWritten);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(sentenceConjuctions[i]);
                        Console.ResetColor();
                    }

                    Console.Write("Sentence's number {0} tense on this row is: ", sentencesWritten);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(sentencesTenses[i]);
                    Console.ResetColor();

                    Console.Write("Sentence's number {0} subject on this row is: ", sentencesWritten);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(sentencesSubjects[i]);
                    Console.ResetColor();

                    Console.Write("Sentence's number {0} verb on this row is: ", sentencesWritten);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(sentencesVerbs[i]);
                    Console.ResetColor();

                    if (sentencesObjects.Count > i && sentencesObjects[i] != null)
                    {
                        Console.Write("Sentence's number {0} object on this row is: ", sentencesWritten);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(sentencesObjects[i]);
                        Console.ResetColor();
                    }

                    if (sentencesPrePhrases.Count > i && sentencesPrePhrases[i] != null)
                    {
                        Console.Write("Sentence's number {0} prepositional phrase on this row is: ", sentencesWritten);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(sentencesPrePhrases[i]);
                        Console.ResetColor();
                    }

                    if (i + 1 < stopWritingAt)
                    {
                        Console.WriteLine("---");
                    }
                }

                if (sentencePos < separatedSentences.Count)
                {
                    Console.WriteLine("-----");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to write results of the next row.");
                    Console.WriteLine();
                    Console.ReadKey(true);
                    Console.WriteLine("-----");
                }
            }

            Console.WriteLine();
            Console.WriteLine("-----");
            Console.WriteLine("Do you want to type in another sentence(s)?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Y] - Yes");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("     [Any key] - No, end the app.");
            Console.ResetColor();
            Console.Write("Your answer: ");
            string answer = Console.ReadLine();

            if (answer == "Y" || answer == "y" || answer == "yes" || answer == "Yes")
            {
                Console.Clear();
                goto sentenceInput;
            }
        }
    }
}
