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

class Result
{

    /*
     * Complete the 'tastesLikeWinning' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER m
     */
    const int mod = 1000000007;

    public static int GetPowerMod(int m)
    {
        int powerM = 1;

        for (int i = 0; i < m; i++)
        {
            powerM *= 2;
            if (powerM >= mod) powerM %= mod;
            if(powerM == 0)
            {
                Console.WriteLine("KKK");
            }
        }

        return powerM;
    }

    public static int tastesLikeWinning(int n, int m)
    {
        int[] games = new int[n + 1];
        int[] zeroGames = new int[n + 1];
        int powerM = GetPowerMod(m);
        //while (powerM <= n) powerM += mod;

        games[0] = 1;

        zeroGames[0] = 1;
        zeroGames[1] = 0;
        for (int i = 1; i <= n; i++)
        {
            long temp = (long)games[i - 1] * (powerM - i);
            if (Math.Abs(temp) >= mod) temp %= mod;
            //if (temp < 0) temp += mod;
            games[i] = Convert.ToInt32(temp);
        }
        for (int i = 2; i <= n; i++)
        {

            long temp1 = (long)games[i - 1] - (long)zeroGames[i - 1];
            long temp2 = (long)(i - 1) * (powerM - 1 - (i - 2));
            if (Math.Abs(temp2) >= mod)
                temp2 %= mod;
            temp2 = temp2 * zeroGames[i - 2];
            if (Math.Abs(temp2) >= mod)
                temp2 %= mod;
            if (Math.Abs(temp1) >= mod) 
                temp1 %= mod;
            long temp = temp1 - temp2;
            if (Math.Abs(temp) >= mod)
                temp %= mod;
            //if (temp < 0) temp += mod;
            zeroGames[i] =  Convert.ToInt32(temp);


        }

        //return games[1];
        long result = games[n] - zeroGames[n];
        result %= mod;
        if(result < 0) result += mod;
        
        return Convert.ToInt32(result);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        //int n = Convert.ToInt32(firstMultipleInput[0]);

        //int m = Convert.ToInt32(firstMultipleInput[1]);

        //int result = Result.tastesLikeWinning(n, m);

        //Console.Write(result);
        Console.WriteLine(Result.tastesLikeWinning(2587330, 1262385));
        Console.WriteLine("Expected: 452042758");

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
