/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Collections.Generic;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {

                int size = nums.Length;

                // limits for searching : low and high
                int low = 0;
                int high = size - 1;

                int mid = low + (high - low) / 2;         // middle of low and high

                while (low <= high)
                {       // run until limits overlap

                    if (nums[mid] < target)          // if less than target, cut the search space to left half 
                        low = mid + 1;

                    else if (nums[mid] > target)         // if greater than target, cut the space to right half
                        high = mid - 1;

                    if (nums[mid] == target)         // if equal, then return the index
                        return mid;

                    mid = low + (high - low) / 2;            // calculate the middle 
                }

                if (target > nums[mid])          // check's the position to be placed given that we didnot find the target: low/ high
                    return low;
                return high;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                //write your code here.

                // remove punctuations and make lowercase      
                paragraph = paragraph.Replace(".", "");
                paragraph = paragraph.Replace(",", "");
                paragraph = paragraph.ToLower();

                string[] arr = paragraph.Split();         // split the paragraph into words: delimited by " "

                // defining a dictionary for words and their occurance count
                Dictionary<string, int> d = new Dictionary<string, int>();

                for (int i = 0; i < arr.Length; i++)
                {      // iterate through the string array
                    if (Array.IndexOf(banned, arr[i]) == -1)
                    {      // check if it is a banned word or not
                        if (d.ContainsKey(arr[i]) == true)     // if key already present, then increment the counter or else just add it to dict
                            d[arr[i]] += 1;
                        else
                            d.Add(arr[i], 1);
                    }
                }

                int maxval = -1;

                string ret = "";

                foreach (KeyValuePair<string, int> kvp in d)
                {   // search through kvps in the dict
                    if (kvp.Value >= maxval)
                    {                       // if the value we have is greater, then replace it
                        ret = kvp.Key;
                        maxval = kvp.Value;
                    }
                }
                return ret;     // return the string
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                //write your code here.\

                // defining a dictionary
                Dictionary<int, int> d = new Dictionary<int, int>();

                for (int i = 0; i < arr.Length; i++)
                {   // update the dictionary with numbers and their counts
                    if (!d.ContainsKey(arr[i]))
                        d.Add(arr[i], 1);
                    else
                        d[arr[i]] += 1;
                }

                int lucky = -1;      // initialize a var for result
                foreach (KeyValuePair<int, int> kvp in d)
                {
                    if (kvp.Value == kvp.Key)
                    {         // if the frequency and the number are equal, then it's lucky
                        if (lucky < kvp.Key)             // if we already have a lucky no, check which one is greater
                            lucky = kvp.Key;
                    }
                }
                return lucky;       // return the number
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                //write your code here.
                int size = secret.Length;         // get the size of the string

                // defining a dictionary
                Dictionary<char, int> d = new Dictionary<char, int>();

                for (int i = 0; i < size; i++)
                {       // map the elements to their counts
                    if (!d.ContainsKey(secret[i]))
                        d.Add(secret[i], 1);
                    else
                        d[secret[i]] += 1;
                }

                int bulls_counter, cows_counter;

                bulls_counter = cows_counter = 0;

                for (int i = 0; i < size; i++)
                {           // count the bulls in the string: by checking the char same or not
                    if (secret[i] == guess[i])
                    {
                        bulls_counter++;
                        d[guess[i]] = d[guess[i]] - 1;          // decrement the val in dict so that we don't add it to cow counter
                    }
                }

                for (int i = 0; i < size; i++)
                {             // count the number of cows in the string by checking in the dictionary 
                    if (secret[i] != guess[i])
                    {
                        if (d.ContainsKey(guess[i]) == true)
                        {
                            if (d[guess[i]] > 0)
                                cows_counter++;
                        }
                    }
                }
                return bulls_counter.ToString() + "A" + cows_counter.ToString() + "B";        // return the result in the required format

            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                //write your code here.
                List<int> li = new List<int>();

                int pindex = 0;        // variable that stores the index where the partition ends
                int size = s.Length;

                // defining a dictionary
                Dictionary<char, int> d = new Dictionary<char, int>();

                int prev = 0;


                for (int i = 0; i < size;)
                {

                    char cur = s[i];  // first char of this partition

                    for (int j = i; j < size; j++)
                    {
                        if (d.ContainsKey(s[j]) == true)
                        {
                            if (d[s[j]] <= pindex || cur == s[j])   // if the char already occured, or if it's the cur again,
                                pindex = j;        // change the partitioning index limit
                            d[s[j]] = j;
                        }
                        else
                        {
                            d.Add(s[j], j);         // add to the dict
                        }
                    }
                    int ind = pindex + 1;             // this will be added to the list li
                    if (i != 0)
                    {
                        ind = ind - prev;           // get the size
                    }
                    li.Add(ind);                // add to the list li
                    i = pindex + 1;                 // update the i
                    prev = pindex + 1;
                }
                return li;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                //write your code here.

                // defining a dictionary
                Dictionary<char, int> d = new Dictionary<char, int>();

                for (int i = 0; i < widths.Length; i++)
                {      // fill the dictionary with the letter s mapped to their corresponding widths
                    d.Add((char)((int)'a' + i), widths[i]);
                }

                int c, l;
                c = l = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (i == 0) l++;
                    if (c + d[s[i]] > 100)
                    {       // if the count is exceeding 100 pixels,
                        c = d[s[i]];             // increment the line
                        l++;
                    }
                    else
                        c = c + d[s[i]];	        // else, just add to c
                }

                return new List<int>() { l, c };      // return output
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {

                int size = bulls_string10.Length;
                // define var s for all types of brackets
                int nr = 0;
                int sq = 0;
                int cr = 0;

                // if we come across an open bracket, then increment the counter, or else just decrement. IF at end, the value is 0, then it's balanced

                for (int i = 0; i < size; i++)
                {
                    if (bulls_string10[i] == '(')
                        nr++;
                    else if (bulls_string10[i] == ')')
                        nr--;
                    else if (bulls_string10[i] == '[')
                        sq++;
                    else if (bulls_string10[i] == ']')
                        sq--;
                    else if (bulls_string10[i] == '{')
                        cr++;
                    else if (bulls_string10[i] == '}')
                        cr--;
                }
                if (nr == 0 && sq == 0 && cr == 0)       // as explained above, if all 0, then true else false   
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {

                // write the morse codes for all letters
                string[] mcodes = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };


                // define a dictionary for letters mapping to morse
                Dictionary<char, string> map = new Dictionary<char, string>();

                for (int i = 0; i < mcodes.Length; i++)     // fill the above dictionary
                    map.Add((char)((int)'a' + i), mcodes[i]);


                // define a dictionary for unique morse coeds

                Dictionary<string, int> mdist = new Dictionary<string, int>();


                for (int i = 0; i < words.Length; i++)
                {

                    string word = words[i].ToLower();
                    string mc = "";

                    for (int j = 0; j < word.Length; j++)    // add the individual morse codes of all the chars so we get the final code for the string
                        mc += map[word[j]];
                    // add to dict so finally we can just get the keys and they will say how many distinct codes there are
                    if (mdist.ContainsKey(mc) == true)
                        mdist[mc] += 1;
                    else
                        mdist.Add(mc, 1);

                }

                return mdist.Count;  // return the number of keys in the dictionary.
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                int len1 = word1.Length;          // length of two strings in two vars
                int len2 = word2.Length;

                int[,] DP = new int[len1 + 1, len2 + 1];     // 2darray for bottom up dynamic programming approach

                for (int i = 0; i <= len1; i++)
                {               // bottom up approach for dp : start from bottom and fill to the top using previously stored subproblems/ entries

                    for (int j = 0; j <= len2; j++)
                    {

                        if (i == 0 && j == 0)            // string len is 0, so just dp[i,j] = 0
                            DP[i, j] = 0;
                        else if (i == 0)                 // if word1 s len is 0, then we req j (word2 len) ops
                            DP[i, j] = j;
                        else if (j == 0)                 // if word2 s len is 0, then we req i (word1 len) ops
                            DP[i, j] = i;
                        else if (word1[i - 1] == word2[j - 1])  // if the last char of both the strings are same, then just dp[i-1,j-1]
                            DP[i, j] = DP[i - 1, j - 1];
                        else                                // else, then calc the minimum of all the three ops (intsert, remove, replace) on the word1
                            DP[i, j] = 1 + Math.Min(DP[i - 1, j - 1], Math.Min(DP[i, j - 1], DP[i - 1, j]));
                    }
                }
                return DP[len1, len2];       // return the dp[len1,len2] meaning the min opereations req for word1 to change to word2;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}