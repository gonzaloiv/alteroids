using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDController : MonoBehaviour {

	#region Fields

  private string INITIAL_SCORE = "00";
  private int INITIAL_LIVES = 3;

  [SerializeField] private Text scoreLabel;
  [SerializeField] private RawImage[] livesLabels;

  private int score;
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
    scoreLabel.text = (Int32.Parse(scoreLabel.text) + asteroidHitEvent.Score).ToString();
  }

  void OnPlayerHitEvent(PlayerHitEvent playerHitEvent) {
    lives--;
    if(lives <= 0) 
      EventManager.TriggerEvent(new GameOverEvent());
    for(int i = livesLabels.Length - 1; i >= 0; i--)
      livesLabels[i].enabled = i < lives ? true : false;
  }

  #endregion

  #region Private Behaviour

  private void Reset() {

    // SCORE
    scoreLabel.text = INITIAL_SCORE;
    score = Int32.Parse(INITIAL_SCORE);

    // LEVES
    lives = INITIAL_LIVES;
    for(int i = 0; i < livesLabels.Length; i++)
      livesLabels[i].enabled = true;
  }

  #endregion

}
