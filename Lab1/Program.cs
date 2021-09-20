//#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace Lab1
{


    class Program
    {
        public static string Menu()
        {
             return "******************************************\n1) Import"
                                          + "\n2) Bubble Sort"
                                          + "\n3) LINQ/Lambda sort words "
                                          + "\n4) count the Distinct Words"
                                          + " \n5) Take the first 10 words"
                                          + " \n6) Get the Number of words that start with \'j\' and display the count"
                                          + " \n7) Get and display of words that end with \'d\' abd display the count"
                                          + " \n8) get and display words that are greater than 4 characters long, and display the count"
                                          + " \n9) Get and display of words that are less than 3 characters long and start with the letter \'a\' and display the count"
                                          + " \nX) Exit";
        }
       
        public static void Distinct(IList<string> word)
        {
            Console.WriteLine("the Number of distinct words is" + word.Select(x => x).Distinct().Count());
        }

        public static IList<string> Getlistofwords(string file)
        {

            IList<string> words = new List<string>();
            words = File.ReadAllLines(file).ToList();
            return words;
        }

        public static IList<string> Bubble(IList<string> word)
        {
            string _temp;
            for (int i = 0; i < word.Count(); i++)
            {
                for (int j = i + 1; j < word.Count(); j++)
                {
                    if (word[j].CompareTo(word[i]) < 0)
                    {
                        _temp = word[i];
                        word[i] = word[j];
                        word[j] = _temp;
                    }
                }
            }
            return word;
        }

        static void Main(string[] args)
        {
            IList<string> words = null;
            char _selection = '1';

            do
            {
                Console.WriteLine(Menu());

                Console.Write("\n>> ");
                _selection = Console.ReadKey().KeyChar;
                while (Console.KeyAvailable)
                {
                    Console.ReadKey();
                }

                /*   try {
                      // Console.WriteLine("DEBUG *************"+_selection);
                   } catch (FormatException e) when (e.Equals('x') || e.Equals('x'))
                   {
                       _selection = 'x';
                   };
   */


                switch (_selection)
                {
                    case 'x': case 'X':break;

                    case '1': words = Getlistofwords("Words.txt"); break;
                    //Bubble sort this
                    case '2':
                        Stopwatch sw = new Stopwatch();
                        if (!(words == null))
                        {
                            if (words == null) { Console.Error.WriteLine("List is empty"); break; }
                            else
                            {
                                sw.Start();
                                var bubbled = Bubble(words);
                                sw.Stop();
                                foreach (var w in bubbled) Console.WriteLine(w);
                            }
                            Console.WriteLine("Execution time (ms): " + sw.ElapsedMilliseconds);
                        }
                        break;
                    //simple orderby query
                    case '3':
                        if (words == null) { Console.Error.WriteLine("List is empty"); break; }
                        var order = from x in words orderby x select x;
                        foreach (var w in order) Console.WriteLine(w);
                        break;
                    //count the disinct words
                    case '4':
                        if (words == null) { Console.Error.WriteLine("List is empty"); break; }
                        Distinct(words);
                        break;
                    // take the first 10 elements
                    case '5':
                        if (words == null) { Console.Error.WriteLine("List is empty"); break; }
                        var first_five = words.Select(x => x).Take(10);
                        foreach (var w in first_five)
                        { Console.WriteLine(w); }
                        break;
                    //get the number of words that start with 'j'
                    case '6':
                        if (words == null) { Console.Error.WriteLine("List is empty"); break; }
                        var words_that_starts_in_J = from x in words where x.StartsWith('j') select x;
                        foreach (var w in words_that_starts_in_J)
                        {
                            Console.WriteLine(w);
                        }
                        Console.WriteLine("Count: " + words_that_starts_in_J.Count());
                        break;
                    case '7':
                        if (words == null) { Console.Error.WriteLine("List is empty"); break; }
                        var words_that_end_in_d = from x in words where x.EndsWith('d') select x;
                        foreach (var w in words_that_end_in_d)
                        {
                            Console.WriteLine(w);
                        }
                        Console.WriteLine("Count: " + words_that_end_in_d.Count());
                        break;
                    case '8':

                        if (words == null) { Console.Error.WriteLine("List is empty"); break; }
                        var words_greater_than_4Chars = from x in words where (x.Length > 4) select x;
                        foreach (var w in words_greater_than_4Chars)
                        {
                            Console.WriteLine(w);
                        }
                        Console.WriteLine("Count: " + words_greater_than_4Chars.Count());
                        break;
                    case '9':
                        if (words == null) { Console.Error.WriteLine("List is empty"); break; }
                        var words_that_are_Less_than_3Chars = from x in words where (x.Length < 3) select x;
                        foreach (var w in words_that_are_Less_than_3Chars)
                        {
                            Console.WriteLine(w);
                        }
                        Console.WriteLine("Count: " + words_that_are_Less_than_3Chars.Count());

                        break;
                    case 'a':
                        if (words == null) { Console.Error.WriteLine("List is empty"); break; }
                        foreach (var w in words)
                        {
                            Console.WriteLine(w);
                        }
                        break;
                    case 'b': break;

                    default:
                        Console.WriteLine("\n **** not a valid selection ****\n");
                        break;
                }
                if (_selection == 'x' || _selection == 'X')
                {
                    break;
                }



            } while (true);
        }


    }
}
