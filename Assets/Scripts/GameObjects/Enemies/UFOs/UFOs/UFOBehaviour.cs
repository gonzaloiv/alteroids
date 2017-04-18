using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBehaviour : MonoBehaviour {

  #region Fields

  private AudioSource ufoSound;

  #endregion

  #region Mono Behaviour

  void Awake() {
    ufoSound = GetComponent<AudioSource>();
  }

  void OnBecameVisible() {
    ufoSound.Play();
  }

  void OnBecameInvisible() {
    ufoSound.Stop();
  }

  #endregion

}
