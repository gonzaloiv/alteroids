using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTranslationController : MonoBehaviour {

  #region Fields Behaviour

  private float THRUST = 0.5f;
  [SerializeField] private ParticleSystem jetParticles;
  private Rigidbody2D rb;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
  }

  void OnEnable() {
    EventManager.StartListening<MoveUpInput>(OnMoveUpInput);
  }

  void OnDisable() {
    EventManager.StopListening<MoveUpInput>(OnMoveUpInput);
  }

  #endregion

  #region Event Behaviour

  void OnMoveUpInput(MoveUpInput moveUpInput) {
    rb.AddForce(transform.up * THRUST);
    jetParticles.Play();
  }

  #endregion

}
