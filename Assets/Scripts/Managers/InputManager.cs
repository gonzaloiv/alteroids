using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

  #region Fields

  private const float INPUT_TIME = 0.1f;
  private float lastInput;

  #endregion

  #region Mono Behaviour

  void Awake() {
    lastInput = Time.time - INPUT_TIME;
  }

  void Update() {

    // Keyboard player input
    if (Time.timeScale != 0) {

      if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        EventManager.TriggerEvent(new MoveUpInput());
      if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        EventManager.TriggerEvent(new MoveRightInput());
      if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        EventManager.TriggerEvent(new MoveLeftInput());
      if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        EventManager.TriggerEvent(new MoveDownInput());

      if (Time.time > lastInput + INPUT_TIME) {
        lastInput = Time.time;
        if (Input.GetKey(KeyCode.Space))
          EventManager.TriggerEvent(new SpaceInput());
        if (Input.GetKey(KeyCode.Return))
          EventManager.TriggerEvent(new ReturnInput());
        if (Input.GetKey(KeyCode.Escape))
          EventManager.TriggerEvent(new EscapeInput());
      }

    }
   
    // UI input
    if (Input.GetKeyDown(KeyCode.Escape))
      EventManager.TriggerEvent(new SpaceInput());

  }

  #endregion

}
