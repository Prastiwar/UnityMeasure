using System;
using UnityEngine;

namespace TP.Measurement.Unity
{
    [Serializable]
    public class TPTestables
    {
        public GameObject GameObject;
        public TPTestableScriptableObject ScriptableObject;
        public TPTestableClass Class;
        public TPTestableStruct Struct;
        public TPTestableStructInt StructInt;
        public ITPTestableInterface Interface;
    }

    public interface ITPTestableInterface
    {
        void Void();
    }

    [Serializable]
    public class TPTestableClass : ITPTestableInterface
    {
        public int ValueInt;
        public string ValueString;

        public void Void() { }
    }

    [Serializable]
    public struct TPTestableStruct : ITPTestableInterface
    {
        public int ValueInt;
        public string ValueString;

        public void Void() { }
    }

    [Serializable]
    public struct TPTestableStructInt : ITPTestableInterface
    {
        public int ValueInt;

        public TPTestableStructInt(int integer)
        {
            ValueInt = integer;
        }

        public void Void() { }

        public static implicit operator TPTestableStructInt(int integer)
        {
            return new TPTestableStructInt(integer);
        }
    }
}
