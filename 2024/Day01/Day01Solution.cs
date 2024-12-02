using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DotNetEnv;
using Sprache;

namespace _2024.Day01
{
    internal class Day01Solution
    {
        private static string _sampleInput = """
                                        3   4
                                        4   3
                                        2   5
                                        1   3
                                        3   9
                                        3   3
                                        """;
        public int Part1(string input)
        {            
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            List<int> differences = new List<int>();

            foreach (var line in input.Split("\n"))
            {
                string[] parts = line.Trim().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                string first_num_str = parts[0];
                string second_num_str = parts[1];

                if (int.TryParse(first_num_str, out int first_num_int))
                {
                    left.Add(first_num_int);
                }

                if (int.TryParse(second_num_str, out int second_num_int))
                {
                    right.Add(second_num_int);
                }
            }

            left.Sort();
            right.Sort();

            for (int i = 0; i < left.Count; i++)
            {
                differences.Add(Math.Abs(left[i] - right[i]));
            }

            int sum = differences.Sum();
            return sum;
        }

        public int Part2(string input)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            List<int> similarityScore = new List<int>();
            List<int> countList = new List<int>();

            foreach (var line in input.Split("\n"))
            {
                string[] parts = line.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string first_num_str = parts[0];
                string second_num_str = parts[1];

                if (int.TryParse(first_num_str, out int first_num_int))
                {
                    left.Add(first_num_int);
                }

                if (int.TryParse(second_num_str, out int second_num_int))
                {
                    right.Add(second_num_int);
                }
            }

            foreach (var i in left)
            {
                countList.Add(right.Count(n  => n == i));                
            }

            for (int i = 0; i < left.Count; i++)
            {
                similarityScore.Add(left[i] * countList[i]);
            }

            return similarityScore.Sum();
        }

        public void Run()
        {            
            Console.WriteLine("Day 1 - Part 1: " + Part1(_sampleInput));
            Console.WriteLine("Day 1 - Part 2: " + Part2(_sampleInput));
            
        }
    }    
}
