﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace TP.Measurement.Unity
{
    [Serializable, CreateAssetMenu()]
    public class TPTestableScriptableObject : ScriptableObject
    {
        public string ValueString;
        public int ValueInt;
        public List<string> ValueStrings = new List<string>();

        public void Add(string value)
        {
            ValueStrings.Add(value);
        }
    }
}
