using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ModesScreenController : MonoBehaviour {

  #region Fields

  private const int WAVE_AMOUNT = 5;
  private const float INPUT_TIME = 0.2f;
  private const int COLS = 4;

  [SerializeField] private Text[] modes;
  private Text selectedMode;
  private int selectedModeIndex = 0;
  private float lastInput;

  [SerializeField] private GameObject asteroids;
  private AsteroidSpawner asteroidSpawner;

  #endregion

  #region Mono Behaviour

  void Awake() {
    asteroidSpawner = asteroids.GetComponent<AsteroidSpawner>();
    lastInput = Time.time;
    SelectMode(selectedModeIndex);
  }

  void Start() {
    asteroidSpawner.SpawnAsteroids(WAVE_AMOUNT, AsteroidType.Large);
    asteroidSpawner.SpawnAsteroids(WAVE_AMOUNT, AsteroidType.Medium);
    asteroidSpawner.SpawnAsteroids(WAVE_AMOUNT, AsteroidType.Small);
  }

  void OnEnable() {
    EventManager.StartListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StartListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StartListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StartListening<MoveDownInput>(OnMoveDownInput);
    EventManager.StartListening<SpaceInput>(OnSpaceInput);
    EventManager.StartListening<ReturnInput>(OnReturnInput);
  }

  void OnDisable() {
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StopListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StopListening<MoveDownInput>(OnMoveDownInput);
    EventManager.StopListening<SpaceInput>(OnSpaceInput);
    EventManager.StopListening<ReturnInput>(OnReturnInput);
  }

  #endregion

  #region Event Behaviour

  void OnMoveRightInput(MoveRightInput moveRightInput) {
    if (Time.time > lastInput + INPUT_TIME && selectedModeIndex < modes.Length - 1)
      SelectMode(selectedModeIndex + 1);
  }

  void OnMoveLeftInput(MoveLeftInput moveLeftInput) {
    if (Time.time > lastInput + INPUT_TIME && selectedModeIndex > 0)
      SelectMode(selectedModeIndex - 1);
  }

  void OnMoveUpInput(MoveUpInput moveUpInput) {
    if (Time.time > lastInput + INPUT_TIME && selectedModeIndex > COLS - 1)
      SelectMode(selectedModeIndex - COLS);
  }

  void OnMoveDownInput(MoveDownInput moveDownInput) {
    Debug.Log("CODE REACHED");
    if (Time.time > lastInput + INPUT_TIME && selectedModeIndex < modes.Length - COLS) {
      SelectMode(selectedModeIndex + COLS);
    }
  }

  void OnSpaceInput(SpaceInput spaceInput) {
    SceneManager.LoadScene(selectedModeIndex + 2); // Adds title and mode selection screen
  }

  void OnReturnInput(ReturnInput returnInput) {
    SceneManager.LoadScene(selectedModeIndex + 2); // Adds title and mode selection screen
  }

  #endregion

  #region Private Behaviour

  private void SelectMode(int index) {

      lastInput = Time.time;
      selectedModeIndex = index;

      if (selectedMode != null)
        selectedMode.GetComponent<Animator>().Play("Idle");
      selectedMode = modes[index];
      selectedMode.GetComponent<Animator>().Play("BlinkingText");

      EventManager.TriggerEvent(new SelectModeEvent());

  }

  #endregion

}




