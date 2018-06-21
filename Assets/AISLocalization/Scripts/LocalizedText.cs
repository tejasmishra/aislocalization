﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AISLocalization
{
    [RequireComponent(typeof(Text))]
    public class LocalizedText : MonoBehaviour
    {

        public string key;

        // Use this for initialization
        void Start()
        {
            Text text = GetComponent<Text>();
            text.text = LocalizationManager.Instance.GetLocalizedValue(key);
        }
    }
}