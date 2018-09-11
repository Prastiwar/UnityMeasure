using System;
using UnityEngine;

namespace TP.Measurement
{
    public abstract class TPTestScript : MonoBehaviour
    {
        private Action[] measureActions;
        private Action onUpdateProfile;

        [Header("Test Settings")]
        public int RepeatLength = 1000;
        public int RepeatAverageLength = 10;
        public string ProfileUpdateSampleName = "MeasureUpdate";
        public string[] MeasureNames = new string[]{ "", "", "" };

        [Header("Test Objects")]
        public TPTestables Testables;

        /// <summary> Empty void method </summary>
        public void Void() { }

        /// <summary> Empty void method taking object as parameter </summary>
        public void Void(object obj) { }

        protected virtual void OnAwakened() { }

        protected virtual void OnStarted() { }

        protected virtual void OnUpdate() { }
        protected virtual void UpdateProfile() { }

        /// <summary> Iterate over GetMeasureActions() and shows their results with TPMeasure.MeasureAverageRepeat(RepeatAverageLength, RepeatLength, MeasureNames[i]) </summary>
        protected void MeasureAverageRepeat()
        {
            Action[] actions = GetMeasureActionsSafe(out int length);
            for (int i = 0; i < length; i++)
            {
                TPMeasure.MeasureAverageRepeat(RepeatAverageLength, RepeatLength, MeasureNames[i], actions[i]).ShowLog();
            }
        }

        /// <summary> Iterate over GetMeasureActions() and shows their results with TPMeasure.MeasureAverage(MeasureNames[i]) </summary>
        protected void MeasureAverage()
        {
            Action[] actions = GetMeasureActionsSafe(out int length);
            for (int i = 0; i < length; i++)
            {
                TPMeasure.MeasureAverage(RepeatLength, MeasureNames[i], actions[i]).ShowLog();
            }
        }

        /// <summary> Iterate over GetMeasureActions() and shows their results with TPMeasure.Measure(MeasureNames[i]) </summary>
        protected void Measure()
        {
            Action[] actions = GetMeasureActionsSafe(out int length);
            for (int i = 0; i < length; i++)
            {
                TPMeasure.Measure(MeasureNames[i], actions[i]).ShowLog();
            }
        }

        /// <summary> Iterate over GetMeasureActions() and shows their results with TPMeasure.MeasureRepeat(RepeatLength, MeasureNames[i]) </summary>
        protected void MeasureRepeat()
        {
            Action[] actions = GetMeasureActionsSafe(out int length);
            for (int i = 0; i < length; i++)
            {
                TPMeasure.MeasureRepeat(RepeatLength, MeasureNames[i], actions[i]).ShowLog();
            }
        }

        /// <summary> Spawns and returns array of primitives </summary>
        protected GameObject[] SpawnGameObjects(int count, PrimitiveType type = PrimitiveType.Cube)
        {
            GameObject[] array = new GameObject[count];
            GameObject copy = GameObject.CreatePrimitive(type);
            for (int i = 0; i < count; i++)
            {
                array[i] = Instantiate(copy);
            }
            DestroyImmediate(copy);
            return array;
        }

        protected virtual Action[] GetActionsToMeasure() { return new Action[0]; }

        private Action[] GetMeasureActionsSafe(out int length)
        {
            if (measureActions == null)
            {
                measureActions = GetActionsToMeasure();
                int actionLength = measureActions.Length;
                int namesLength = MeasureNames.Length;
                if (actionLength > MeasureNames.Length)
                {
                    Debug.LogWarning("Measure names count doesn't match measures count! Creating empty labels...");
                    Array.Resize(ref MeasureNames, actionLength);
                }
            }
            length = measureActions.Length;
            return measureActions;
        }

        private void Awake()
        {
            onUpdateProfile = UpdateProfile;
            TPMeasure.MeasureAverageRepeat(2, 1000, null, Void);
            OnAwakened();
        }

        private void Start()
        {
            OnStarted();
        }

        private void Update()
        {
            OnUpdate();
            TPMeasure.Profile(ProfileUpdateSampleName, onUpdateProfile);
        }
    }
}
