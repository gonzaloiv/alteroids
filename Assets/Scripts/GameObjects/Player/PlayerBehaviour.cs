using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

  #region Fields

  private PlayerController playerController;

  #endregion

  #region Mono Behaviour

  void Awake() {
    playerController = GetComponent<PlayerController>();
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == (int) Layer.Asteroids)
      playerController.Spawn();
  }

  #endregion  
	
}
