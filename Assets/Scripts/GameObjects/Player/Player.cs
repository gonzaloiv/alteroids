using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  #region Fields

  private int INITIAL_SCORE = 0;
  private int INITIAL_LIVES = 3;
  private int EXTRA_LIFE_SCORE = 10000;

  public int Score { get { return score; } } 
  private int score;

  public int Lives { get { return lives; } } 
  private int lives;

  private int extraLife = 0;

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

    // Score
    score = score + asteroidHitEvent.Score;
    HUDController.UpdateScore(score);

    // Extra life
    extraLife = extraLife + asteroidHitEvent.Score;
    if(extraLife >  EXTRA_LIFE_SCORE) {
      extraLife = extraLife - EXTRA_LIFE_SCORE;
      lives++;
      HUDController.UpdateLives(lives);
    }

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
