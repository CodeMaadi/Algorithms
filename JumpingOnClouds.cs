using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

// https://www.hackerrank.com/challenges/jumping-on-the-clouds/problem
class Solution {

    // Complete the jumpingOnClouds function below.
    static int JumpingOnClouds(int[] c) {
        if (c == null || c.Length <= 1) return 0;
        
        int[] minJumps = new int[c.Length];
        
        minJumps[0] = 0;
        // Let's start from 1 index.
        for (int i = 1; i < c.Length; i++)
        {
            if (c[i] == 1)
            {
                minJumps[i] = Int32.MaxValue;
            }
            else
            {
                if ((i - 2) >= 0)
                {
                    minJumps[i] = Math.Min(minJumps[i-1], minJumps[i-2]) + 1;
                }
                else if (minJumps[i-1] != Int32.MaxValue)
                {
                    minJumps[i] = minJumps[i - 1] + 1;
                }
                else
                {
                    minJumps[i] = Int32.MaxValue;
                }
            }
        }
        
        return minJumps[c.Length - 1];
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = JumpingOnClouds(c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
