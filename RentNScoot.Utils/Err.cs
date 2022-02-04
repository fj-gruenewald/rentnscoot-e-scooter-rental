using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RentNScoot.Utils
{
    public static class Err
    {
        private static bool firstError = true;

        public static void D(object o, string tag, object value)
        {
#if DEBUG
            var writer = CreateStreamWriter(out var timeStamp);
            writer?.Write($"{timeStamp} {o.GetType().Name,-20} {tag} {value}\n");
            writer?.Flush();
            writer?.Close();
#endif
        }

        public static void D(string type, string tag, object value)
        {
#if DEBUG
            var writer = CreateStreamWriter(out var timeStamp);
            writer?.Write($"{timeStamp} {type,-20} {tag} {value}\n");
            writer?.Flush();
            writer?.Close();
#endif
        }

        public static void D(object o, string tag, IEnumerable<object> numerable)
        {
#if DEBUG
            var writer = CreateStreamWriter(out var timeStamp);
            writer?.Write($"{timeStamp} {o.GetType().Name,-20} {tag} \n");
            var max = Math.Min(5, numerable.Count());
            int num = 1;
            var enumerator = numerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                writer?.Write($"{enumerator.Current} | ");
                if (num++ > max) break;
            }
            writer?.Write("\n");
            writer?.Flush();
            writer?.Close();
#endif
        }

        private static StreamWriter CreateStreamWriter(out string timeStamp)
        {
            StreamWriter? writer = null;
            if (firstError)
            {
                writer = new StreamWriter("../../../ErrorFile.txt", false);
                firstError = false;
            }
            else
                writer = new StreamWriter("../../../ErrorFile.txt", true);

            DateTime dt = DateTime.Now;
            timeStamp = $"{dt.Day:d2}.{dt.Month:d2}.{dt.Year:d4}-" +
                        $"{dt.Hour:d2}:{dt.Minute:d2}:{dt.Second:d2}.{dt.Millisecond:0000} ";
            return writer;
        }
    }
}