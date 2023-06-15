using System;
using System.Globalization;
using System.Linq;

namespace Pgvector
{
    public class Vector
    {
        private readonly float[] vec;

        public Vector(float[] v)
        {
            vec = v;
        }

        public Vector(string s)
        {
            var toSplit = s.StartsWith("[") ? s.Substring(1, s.Length - 1) : s;
            vec = Array.ConvertAll(toSplit.Split(','), v => float.Parse(v, CultureInfo.InvariantCulture));
        }

        public override string ToString()
        {
            return string.Concat("[", string.Join(",", vec.Select(v => v.ToString(CultureInfo.InvariantCulture))), "]");
        }

        public float[] ToArray()
        {
            return vec;
        }
    }
}
