using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

  #region Fields

  private PlayerController playerController;
  private Player player;

  #endregion

  #region Mono Behaviour

  void Awake() {
    playerController = GetComponent<PlayerController>();
    player = GetComponent<Player>();
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == (int) Layer.Asteroids) {
      EventManager.TriggerEvent(new PlayerHitEvent());
      if (player.Lives == 0) {
        playerController.Disable();
      } else {
        playerController.Spawn();
      }
    }
  }

  #endregion  
	
}
