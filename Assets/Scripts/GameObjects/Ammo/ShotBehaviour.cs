using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour {

  #region Fields

  private float THRUST = 1000;
  private Rigidbody2D rb;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
  }

  void OnEnable() {
    rb.AddForce(transform.up * THRUST);
  }

  #endregion

}
