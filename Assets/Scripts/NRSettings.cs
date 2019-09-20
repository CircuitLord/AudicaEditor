using System.Runtime.CompilerServices;
using System;
using System.Net;
using System.IO;
using UnityEngine;


namespace NotReaper {

    public class NRSettings : MonoBehaviour {

        public static NRJsonSettings config = new NRJsonSettings();

        public static bool isLoaded = false;

        private static readonly string configFilePath = Path.Combine(Application.persistentDataPath, "NRConfig.json");

        public static void LoadSettingsJson(bool regenConfig = false) {
            
            //If it doesn't exist, we need to gen a new one.
            if (regenConfig || !File.Exists(configFilePath)) {
                GenNewConfig();
            }

            try {
                config = JsonUtility.FromJson<NRJsonSettings>(File.ReadAllText(configFilePath));
            } catch(Exception e) {
                Debug.LogError(e);
            }

            //config.leftColor = new Color((float)config.userLeftColor.r, (float)config.userLeftColor.g, (float)config.userLeftColor.b);
            //config.rightColor = new Color((float)config.userRightColor.r, (float)config.userRightColor.g, (float)config.userRightColor.b);
            //config.selectedHighlightColor = new Color((float)config.userSelectedHighlightColor.r, (float)config.userSelectedHighlightColor.g, (float)config.userSelectedHighlightColor.b);


            isLoaded = true;

            

        }

        public static void SaveSettingsJson() {
            File.WriteAllText(configFilePath, JsonUtility.ToJson(config, true));
        }


        private static void GenNewConfig() {

            Debug.Log("Generating new configuration file...");

            NRJsonSettings temp = new NRJsonSettings();

            if (File.Exists(configFilePath)) File.Delete(configFilePath);
            
            File.WriteAllText(configFilePath, JsonUtility.ToJson(temp, true));

        }


    }

    [System.Serializable]
    public class UserColor {
        public double r = 0.3;
        public double g = 0.3;
        public double b = 0.3;
    }

    [System.Serializable]
    public class NRJsonSettings {

        public Color leftColor = new Color(0.0f, 0.5f, 1.0f, 1.0f);
        

        public Color rightColor = new Color(1.0f, 0.47f, 0.14f, 1.0f);
        

        public Color selectedHighlightColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        public double mainVol = 0.5f;
        public double noteVol = 0.5f;
        public double sustainVol = 0.5f;

        public double UIFadeDuration = 1.0f;

        public bool useDiscordRichPresence = true;
        public bool showTimeElapsed = true;
    }

}