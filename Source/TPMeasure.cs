#define ENABLE_PROFILER
using System;
using System.Diagnostics;
using UnityEngine.Profiling;

namespace TP.Measurement
{
    public static class TPMeasure
    {
        private static Stopwatch sw = new Stopwatch();

        /// <summary> Call action and return measurement results </summary>
        public static TPMeasurement Measure(string resultMessage, Action action)
        {
            SkipFirstMeasurement(action);
            Play();
            action();
            return Stop(resultMessage);
        }

        /// <summary> Repeat Measure(..) </summary>
        public static TPMeasurement MeasureRepeat(int actionRepeat, string resultMessage, Action action)
        {
            return Measure(resultMessage, () => {
                for (int i = 0; i < actionRepeat; i++)
                {
                    action();
                }
            });
        }

        /// <summary> Repeat measurement and calculate average results </summary>
        public static TPMeasurement MeasureAverage(int actionRepeat, string resultMessage, Action action)
        {
            SkipFirstMeasurement(action);
            double total = 0;
            for (int i = 0; i < actionRepeat; i++)
            {
                Play();
                action();
                Stop();
                total += sw.Elapsed.TotalMilliseconds;
            }
            return new TPMeasurement(resultMessage, total / actionRepeat);
        }

        /// <summary> Repeat MeasureAverage(..) </summary>
        public static TPMeasurement MeasureAverageRepeat(int averageRepeat, int actionRepeat, string resultMessage, Action action)
        {
            return MeasureAverage(averageRepeat, resultMessage, () => {
                for (int i = 0; i < actionRepeat; i++)
                {
                    action();
                }
            });
        }

        /// <summary> Profile action in Unity's profiler </summary>
        public static void Profile(string sampleName, Action action)
        {
            Profiler.BeginSample(sampleName);
            action();
            Profiler.EndSample();
        }

        /// <summary> Repeat Profile(..) </summary>
        public static void ProfileRepeat(int actionRepeat, string sampleName, Action action)
        {
            Profile(sampleName, () => {
                for (int i = 0; i < actionRepeat; i++)
                {
                    action();
                }
            });
        }

        /// <summary> Resets and starts StopWatch </summary>
        public static void Play()
        {
            sw.Reset();
            sw.Start();
        }

        /// <summary> Stops StopWatch returning results and start new one </summary>
        public static TPMeasurement Restart(string message = null)
        {
            TPMeasurement stopped = Stop(message);
            Play();
            return stopped;
        }

        /// <summary> Stops StopWatch returning results </summary>
        public static TPMeasurement Stop(string message = null)
        {
            sw.Stop();
            return new TPMeasurement(message, sw.Elapsed.TotalMilliseconds);
        }

        private static void SkipFirstMeasurement(Action action)
        {
            Play();
            action();
            Stop();
        }
    }
}
