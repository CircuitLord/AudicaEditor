﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NotReaper.UserInput;
using UnityEngine;
using UnityEngine.UI;

namespace NotReaper.UI {


    public enum EditorMode { Compose, Metadata, Settings };
    public class UIModeSelect : MonoBehaviour {

        public EditorInput editorInput;
        public GameObject slider;
        public RectTransform sliderRTrans;

        public UIMetadata uIMetadata;
        public float startOffset = 37f;
        public float indexOffset = 66.6f;

    
        public void SelectFromUI(string mode) {
            switch (mode) {
                case "compose":
                    editorInput.SelectMode(EditorMode.Compose);
                    break;
                case "metadata":
                    editorInput.SelectMode(EditorMode.Metadata);
                    break;
                case "settings":
                    editorInput.SelectMode(EditorMode.Settings);
                    break;
            }

        }


        public void UpdateUI(EditorMode mode) {
            switch (mode) {
                
                case EditorMode.Compose:
                    

                    DOSliderToButton(0, NRSettings.config.leftColor);

                    EditorInput.inUI = false;

                    uIMetadata.StopAllCoroutines();
                    StartCoroutine(uIMetadata.FadeOut());

                    break;

                case EditorMode.Metadata:
                    uIMetadata.gameObject.SetActive(true);
                    DOSliderToButton(1, NRSettings.config.rightColor);

                    uIMetadata.StopAllCoroutines();
                    StartCoroutine(uIMetadata.FadeIn());
                    
                    EditorInput.inUI = true;




                    break;

                case EditorMode.Settings:

                    DOSliderToButton(2, Color.white);

                    EditorInput.inUI = true;

                    uIMetadata.StopAllCoroutines();
                    StartCoroutine(uIMetadata.FadeOut());

                    break;

  
            }
        }


 




        private void DOSliderToButton(int index, Color colorChange) {
           float final = startOffset + (index * indexOffset);

           //selectedSlider.transform.(new Vector3(0f, finalY, 0f), 1f).SetEase(Ease.InOutCubic);
           DOTween.To(SetSliderPosX, sliderRTrans.anchoredPosition.x, final, 0.3f).SetEase(Ease.InOutCubic);

           slider.GetComponent<Image>().DOColor(colorChange, 0.3f);
            
        }

        private void SetSliderPosX(float pos) {
            sliderRTrans.anchoredPosition = new Vector3(pos, -10.75f, 0);
        }


    }

}