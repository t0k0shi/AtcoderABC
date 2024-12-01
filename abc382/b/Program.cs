using System;
using System.Collections.Generic;
using System.Linq;

namespace x
{
    class Program
{
    static void Main()
    {
        // 入力の読み込み
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int D = int.Parse(input[1]);
        string S = Console.ReadLine();

        // Sを可変にするために文字配列に変換
        char[] boxes = S.ToCharArray();

        // D日間クッキーを食べる
        for (int day = 0; day < D; day++)
        {
            for (int i = N - 1; i >= 0; i--)
            {
                if (boxes[i] == '@')
                {
                    boxes[i] = '.';
                    break;
                }
            }
        }

        // 結果を文字列にして出力
        Console.WriteLine(new string(boxes));
    }
}

}