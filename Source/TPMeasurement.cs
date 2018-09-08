using System.Text;
using UnityEngine;

namespace TP.Measurement
{
    public struct TPMeasurement
    {
        private static StringBuilder builder = new StringBuilder(32);

        private string results;

        public TPMeasurement(string label, double results)
        {
            this.results = GetResults(label, results);
        }

        public void ShowLog()
        {
            Debug.Log(results);
        }

        public override string ToString()
        {
            return results;
        }

        private static string GetResults(string label, double results)
        {
            builder.Length = 0;
            builder.Append(label);
            builder.Append(" ");
            builder.Append(results);
            builder.Append(" ms ");
            return builder.ToString();
        }
    }
}
