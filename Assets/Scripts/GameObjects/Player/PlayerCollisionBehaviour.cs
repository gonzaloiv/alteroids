using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionBehaviour : MonoBehaviour {

  #region Fields

  private PlayerController playerController;
  private Player player;

  private const float COLLISION_TIME = 1f;
  private float lastCollision;

  #endregion

  #region Mono Behaviour

  void Awake() {
    playerController = GetComponent<PlayerController>();
    player = GetComponent<Player>();
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (Time.time > lastCollision + COLLISION_TIME && collision2D.gameObject.layer == (int) Layer.Enemies) {
        lastCollision = Time.time;
        EventManager.TriggerEvent(new PlayerHitEvent());
        if (player.Lives > 0)
          playerController.Respawn();
        else // In case of Game Over
          playerController.Disable();
    }
  }

  #endregion  
	
}
