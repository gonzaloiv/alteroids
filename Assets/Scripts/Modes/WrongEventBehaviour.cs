using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class WrongEventBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private bool wrongSpaceInput = false;
  [SerializeField] private bool wrongMoveUpInput = false;

  private AudioSource audioSource;

  #endregion

  #region Mono Behaviour

  void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  void OnEnable(){
    EventManager.StartListening<SpaceInput>(OnSpaceInput);
    EventManager.StartListening<MoveUpInput>(OnMoveUpInput);
  }

  void OnDisable(){
    EventManager.StopListening<SpaceInput>(OnSpaceInput);
    EventManager.StopListening<MoveUpInput>(OnMoveUpInput);
  }

  #endregion

  #region Event Behaviour

  void OnSpaceInput(SpaceInput spaceInput) {
    if(wrongSpaceInput)
      audioSource.Play();
  }

  void OnMoveUpInput(MoveUpInput moveUpInput) {
    if(wrongMoveUpInput)
      audioSource.Play();
  }

  #endregion

}
