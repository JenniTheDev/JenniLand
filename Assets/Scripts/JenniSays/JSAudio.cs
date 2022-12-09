// Jenni
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JenniSays{
    public class JSAudio : MonoBehaviour {

        [SerializeField]
        private AudioSource buttonPlayer;

        [SerializeField]
        private JSButton button;

        private AudioClip soundToPlay;

        void Start() {

        }

       
        void Update() {

        }

        private void PlayButtonAudio(JSButton selectedButton) {
           soundToPlay = selectedButton.GetComponent<AudioClip>();
            buttonPlayer.clip = soundToPlay;
            buttonPlayer.Play(); 
        }

    }
}

