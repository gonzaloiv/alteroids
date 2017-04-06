using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

  #region Fields Behaviour

  [SerializeField] private float thrust = 0.0001f;
  [SerializeField] private float rotationSpeed = 0.00001f;
  private Rigidbody2D rb;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
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
    rb.AddForce(transform.up * thrust);
  }

  void OnMoveRightInput(MoveRightInput moveRightInput) {
    transform.Rotate(-Vector3.forward * rotationSpeed * Time.timeScale);
  }

  void OnMoveLeftInput(MoveLeftInput moveLeftInput) {
    transform.Rotate(Vector3.forward * rotationSpeed * Time.timeScale);
  }

  #endregion
	
}
