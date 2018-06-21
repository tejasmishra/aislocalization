using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace AISLocalization
{
    public class LocalizationManager : MonoBehaviour
    {

        public static LocalizationManager Instance;

        private Dictionary<string, string> localizedText;
        private bool isReady = false;
        private string missingTextString = "Localized text not found!";

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != null)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        public void LoadLocalizedText(string fileName)
        {
            localizedText = new Dictionary<string, string>();
            string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

                foreach (var item in loadedData.items)
                {
                    localizedText.Add(item.key, item.value);
                }

                Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
            }
            else
            {
                Debug.LogError("Can't find file!");
            }

            isReady = true;
        }

        public string GetLocalizedValue(string key)
        {
            string result = missingTextString;

            if (localizedText.ContainsKey(key))
            {
                result = localizedText[key];
            }

            return result;
        }

        public bool GetIsReady()
        {
            return isReady;
        }
    }
}
