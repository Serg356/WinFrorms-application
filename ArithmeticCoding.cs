using ArithmeticCoding;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace ArithmeticCoding
{
    class ArithmeticCoding
    {
        public static Dictionary<char, int> charCounts;
        public static Dictionary<char, Segment> segments;
        public static Dictionary<char, double> charFreqs;
        Dictionary<char, int> CountsFromFile(String file)
        {
            var reader = new StreamReader(file,  Encoding.UTF8);
            Dictionary<char, int> counts = new Dictionary<char, int>();
            while (!reader.EndOfStream)
            {
                updateCharCount(counts, (char)reader.Read());
            }
            reader.Close();
            return counts;
        }

        static void updateCharCount(Dictionary<char, int> counts, String text)
        {
            foreach (var ch in text)
            {
                if (counts.ContainsKey(ch)) { counts[ch]++; }
                else { counts[ch] = 1;}
               
            }
        
        }
        static void updateCharCount(Dictionary<char, int> counts, char ch)
        {
            if (counts.ContainsKey(ch)) { counts[ch]++; }
            else { counts[ch] = 1; }
        }
        public static Dictionary<char, double> createCharFreq(Dictionary<char, int> counts) {
            Dictionary<char, double> freqs = new Dictionary<char, double>();
            //int cnt = counts.Keys.Sum(ch => counts[ch]);
            int cnt = counts.Values.Sum();
            
            foreach (var pair in counts)
            {
                var ch = pair.Key;
                var count = pair.Value;
                freqs[ch] = (double)count / cnt;
            }
            charFreqs = freqs;
            return freqs;

        }

        public static Dictionary<char, Segment> defineSegments(Dictionary<char, double> freqs) {
            double left = 0;
            segments = new Dictionary<char, Segment>();
            foreach (var ch in freqs.Keys)
            {
                segments[ch] = new Segment(left, left + freqs[ch]);
                left += freqs[ch];
            }
            return segments;
        }
        //public static double encode(Dictionary<char, Segment> segments, String text)
        //{
        //    double left = 0;
        //    double right = 1;
        //    foreach (var ch in text)
        //    {
        //        double lenght = right - left;
        //        right = left + lenght * segments[ch].right;
        //        left = left + lenght * segments[ch].left;
        //    }
        //    return (left + right) / 2;
        //}
        public static double encode(String text)
        {
            charCounts = new Dictionary<char, int>();
            updateCharCount(charCounts, text);
            defineSegments(createCharFreq(charCounts));
            double left = 0;
            double right = 1;
            foreach (var ch in text)
            {
                //double lenght = right - left;
                //right = left + lenght * segments[ch].right;
                //left = left + lenght * segments[ch].left;
                double newLeft = left + (right - left) * segments[ch].left;
                double newRight = left + (right - left) * segments[ch].right;
                left = newLeft;
                right = newRight;
                if (left == right) 
                    return -1;
            }
            return (left + right) / 2;
        }
        public static String decode(Dictionary<char, Segment> segments, double code, int textLenght)
        {
            StringBuilder text = new StringBuilder();
            double left = 0;
            double right = 1;
            for (int i = 0; i < textLenght; i++)
            {          
                foreach (var ch in segments.Keys)
                {
                    double newLeft = left + (right - left) * segments[ch].left;
                    double newRight = left + (right - left) * segments[ch].right;
                    if (code < newRight && code > newLeft)
                    {
                        text.Append(ch);
                        left = newLeft;
                        right = newRight;
                        break;
                    }
                }
            }
            return text.ToString();
        }
        //public static String decode(Dictionary<char, Segment> segments, double code, int textLenght)
        //{
        //    StringBuilder text = new StringBuilder();
        //    double left = 0;
        //    double right = 1;
        //    int ind = 0;
        //    var sortedSegments = segments.OrderBy((c) => (c.Value.right, c.Value.left)).ToArray();
        //    for (int i = 0; i < textLenght; i++)
        //    {
        //        ind = binarySearch(code, sortedSegments, left, right);
        //        double newLeft = left + (right - left) * sortedSegments[ind].Value.left;
        //        double newRight = left + (right - left) * sortedSegments[ind].Value.right;
        //        text.Append(sortedSegments[ind].Key);
        //        left = newLeft;
        //        right = newRight;
        //    }
        //    return text.ToString();
        //}
        static int binarySearch(double code, KeyValuePair<char, Segment>[] sortedSegments, double left, double right)
        {
            int leftIndex = 0;
            int rightIndex = sortedSegments.Length - 1;
            bool found = false;
            int m = 0;
            while (!found && rightIndex >= leftIndex)
            {
                m = (leftIndex + rightIndex) / 2;
                double newLeft = left + (right - left) * sortedSegments[m].Value.left;
                double newRight = left + (right - left) * sortedSegments[m].Value.right;
                found = true;
                if (code >= newLeft)
                {
                    leftIndex = m + 1;
                }
                else
                {
                    found = false;
                }
                if (code < newRight)
                {
                    rightIndex = m - 1;
                }
                else
                {
                    found = false;
                }
            }
            if (found)
            {
                return m;
            }
            else
            {
                return -1;
            }
        }







    }
    struct Segment
    {
        public double left;
        public double right;
        public Segment(double newLeft, double newRight)
        {
            left = newLeft;
            right = newRight;
        }
    }

}
