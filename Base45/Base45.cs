using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Text
{
    public static class Base45
    {
        private const string Label = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:";
        private static readonly Dictionary<int, string> Values = new Dictionary<int, string>();
        private static readonly Dictionary<char, int> ValuesAsString = new Dictionary<char, int>();
        private const int O45X45 = 45 * 45;
        static Base45()
        {
            int count = 0;
            foreach (var l in Label)
            {
                Values.Add(count++, l.ToString());
                ValuesAsString.Add(l, count - 1);
            }
        }
        public static string ToBase45(this string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var bytes = Encoding.UTF8.GetBytes(value);
            for (int i = 0; i < bytes.Length; i += 2)
            {
                var values = bytes.Skip(i).Take(2);
                int? second = null;
                if (values.Count() > 1)
                    second = values.Last();
                var returnedValue = Calculate(values.First(), second);
                stringBuilder.Append($"{Values[returnedValue.Item1]}{Values[returnedValue.Item2]}{(returnedValue.Item3.HasValue ? Values[returnedValue.Item3.Value] : string.Empty)}");
            }
            return stringBuilder.ToString();
        }
        private static Tuple<int, int, int?> Calculate(int a, int? b = null)
        {
            int? e = null;
            int value = !b.HasValue ? a : a * 256 + b.Value;
            if (b.HasValue)
            {
                e = value / O45X45;
                value %= O45X45;
            }
            int d = value / 45;
            value %= 45;
            return new Tuple<int, int, int?>(value, d, e);
        }
        public static string FromBase45(this string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<int> bytes = value.ToCharArray().Select(x => ValuesAsString[x]).ToList();
            for (int i = 0; i < bytes.Count; i += 3)
            {
                var values = bytes.Skip(i).Take(3);
                int? third = null;
                if (values.Count() > 2)
                    third = values.Last();
                var returnedValue = Calculate(values.First(), values.Skip(1).First(), third);
                stringBuilder.Append($"{(returnedValue.Item2.HasValue ? new string((char)returnedValue.Item2.Value, 1) : string.Empty)}{(char)returnedValue.Item1}");
            }
            return stringBuilder.ToString();
        }
        private static Tuple<int, int?> Calculate(int c, int d, int? e = null)
        {
            int? b = null;
            int value = c + d * 45 + (e.HasValue ? e.Value * O45X45 : 0);
            if (e.HasValue)
            {
                b = value / 256;
                value %= 256;
            }
            return new Tuple<int, int?>(value, b);
        }
    }
}