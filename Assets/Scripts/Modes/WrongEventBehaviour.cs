using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class WrongEventBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private bool wrongSpaceInput = false;
  [SerializeField] private bool wrongMoveUpInput = false;
  [SerializeField] private bool wrongMoveRightInput = false;
  [SerializeField] private bool wrongMoveLeftInput = false;

  private AudioSource audioSource;
  private const float INPUT_TIME = 0.3f;
  private float lastInput;

  #endregion

  #region Mono Behaviour

  void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  void OnEnable(){
    EventManager.StartListening<SpaceInput>(OnSpaceInput);
    EventManager.StartListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StartListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StartListening<MoveLeftInput>(OnMoveLeftInput);
  }

  void OnDisable(){
    EventManager.StopListening<SpaceInput>(OnSpaceInput);
    EventManager.StopListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
  }

  #endregion

  #region Event Behaviour

  void OnSpaceInput(SpaceInput spaceInput) {
    if(wrongSpaceInput)
      Play();
  }

  void OnMoveUpInput(MoveUpInput moveUpInput) {
    if(wrongMoveUpInput)
      Play();
  }

  void OnMoveRightInput(MoveRightInput moveRightInput) {
    if(wrongMoveRightInput)
      Play();
  }

  void OnMoveLeftInput(MoveLeftInput moveLeftInput) {
    if(wrongMoveLeftInput)
      Play();
  }

  #endregion

  #region Private Behaviour

  private void Play() {
    if (Time.time > lastInput + INPUT_TIME) {
      lastInput = Time.time;
      audioSource.Play();
    }
  }

  #endregion

}
