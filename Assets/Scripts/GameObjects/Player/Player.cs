using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  #region Fields

  private int INITIAL_SCORE = 0;
  private int INITIAL_LIVES = 3;

  public int Score { get { return score; } } 
  private int score;

  public int Lives { get { return lives; } } 
  private int lives;

  #endregion 

	#region Mono Behaviour

  void OnEnable() {
    EventManager.StartListening<AsteroidHitEvent>(OnAsteroidHitEvent);
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);
    Reset();
  }

  void OnDisable() {
    EventManager.StopListening<AsteroidHitEvent>(OnAsteroidHitEvent);
    EventManager.StopListening<PlayerHitEvent>(OnPlayerHitEvent);
  }

  #endregion

  #region Event Behaviour

  void OnAsteroidHitEvent(AsteroidHitEvent asteroidHitEvent) {
    score = score + asteroidHitEvent.Score;
    HUDController.UpdateScore(score);
  }

  void OnPlayerHitEvent(PlayerHitEvent playerHitEvent) {
    lives--;
    if(lives <= 0) 
      EventManager.TriggerEvent(new GameOverEvent());
    HUDController.UpdateLives(lives);
  }

  #endregion

  #region Private Behaviour

  private void Reset() {
    score = INITIAL_SCORE;
    lives = INITIAL_LIVES;
    HUDController.UpdateLives(lives);
  }

  #endregion
	
}
