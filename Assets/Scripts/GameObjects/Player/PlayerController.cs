using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  #region Fields Behaviour

  private float THRUST = 0.5f;
  private float ROTATION_SPEED = 4f;
  private float DECELERATION = 0.99f;

  private Rigidbody2D rb;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update() {
    rb.velocity *= DECELERATION;
  }

  void OnEnable() {
    EventManager.StartListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StartListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StartListening<MoveLeftInput>(OnMoveLeftInput);
  }

  void OnDisable() {
    EventManager.StopListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
  }

  #endregion

  #region Event Behaviour

  void OnMoveUpInput(MoveUpInput moveUpInput) {
    rb.AddForce(transform.up * THRUST);
  }

  void OnMoveRightInput(MoveRightInput moveRightInput) {
    transform.Rotate(-Vector3.forward * ROTATION_SPEED);
  }

  void OnMoveLeftInput(MoveLeftInput moveLeftInput) {
    transform.Rotate(Vector3.forward * ROTATION_SPEED);
  }

  #endregion

  #region Public Behaviour

  public void Spawn() { // Resets the ship and spawns it in its original position
    transform.position = Vector2.zero;
    rb.velocity = Vector2.zero;
    rb.angularVelocity = 0;
  }

  #endregion

}
