﻿using System;

abstract class TestBase: ITest
{
    public abstract bool Run();

    protected void Print(int[][] array)
    {
        for(int i = 0; i < array.Length; i++)
        {
            int[] row = array[i];
            for(int j = 0; j < row.Length; j++)
            {
                Console.Write("{0}\t", array[i][j]);
            }
            Console.WriteLine();
        }
    }
}