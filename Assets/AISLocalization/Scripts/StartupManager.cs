using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AISLocalization
{
    public class StartupManager : MonoBehaviour
    {

        private const string StartMenu = "MenuScreen";

        // Use this for initialization
        private IEnumerator Start()
        {
            while (!LocalizationManager.Instance.GetIsReady())
            {
                yield return null;
            }

            SceneManager.LoadScene(StartMenu);
        }

    }
}