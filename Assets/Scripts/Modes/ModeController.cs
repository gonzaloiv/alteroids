using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeController : MonoBehaviour {

	#region Fields

  [SerializeField] private GameObject gameOverScreen;

  #endregion

  #region Mono Behaviour

  void Awake() {
    gameOverScreen.SetActive(false);
  }

  void OnEnable() {
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StartListening<EscapeInput>(OnEscapeInput);
  }

  void OnDisable() {
    EventManager.StopListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StopListening<EscapeInput>(OnEscapeInput);
  }

  #endregion 

  #region Event Behaviour

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
	  StartCoroutine(GameOverRoutine());
  }

  void OnEscapeInput(EscapeInput escapeInput) {
    SceneManager.LoadScene((int) Scene.Title);
  }

  #endregion

  #region Private Behaviour

  private IEnumerator GameOverRoutine() {
  	gameOverScreen.SetActive(true);
  	yield return new WaitForSeconds(1);
	  SceneManager.LoadScene((int) Scene.Title);
  }

  #endregion

}
