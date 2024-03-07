using System;
using System.Collections.Generic;

class RabinKarpAlgorithm
{
    static void Main()
    {
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        int p = 31;
        int s_length = s.Length;
        int t_length = t.Length;

        int[] p_st = new int[t_length];
        p_st[0] = 1;
        for (int i = 1; i < t_length; i++)
        {
            p_st[i] = p_st[i - 1] * p;
        }

        int s_hash = 0;
        for (int i = 0; i < s_length; i++)
        {
            s_hash += (s[i] - 'a' + 1) * p_st[i];
        }
        //Console.WriteLine("Хеш шаблона: " + s_hash);


        int[] hashs = new int[t_length];
        for (int i = 0; i < t_length; i++)
        {
            hashs[i] = (t[i] - 'a' + 1) * p_st[i];
            if (i != 0)
            {
                hashs[i] += hashs[i - 1];
            }
        }

        //Console.WriteLine();
        //for (int k = 0; k < t_length; k++)
        //{
        //    Console.WriteLine(hashs[k]);
        //}
        //Console.WriteLine();


        int cur_h;
        for (int i = 0; i < t_length - s_length + 1; i++)
        {
            cur_h = hashs[i + s_length - 1];
            if (i != 0)
            {
                cur_h -= hashs[i - 1];
            }
            if (cur_h == s_hash * p_st[i])
            {
                Console.WriteLine(i);
            }
        }
    }
}