using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class ModeColorController : MonoBehaviour {

  #region Fields

  [SerializeField] private Camera cam;
  [SerializeField] private GameObject asteroids;
  [SerializeField] private GameObject player;

  private List<Renderer> renderers = new List<Renderer>();
  private List<Text> texts = new List<Text>();
  private List<RawImage> images = new List<RawImage>();

  #endregion

  #region Mono Behaviour

  void Start() {
    InitialSetup();
  }

  void OnEnable() {
    EventManager.StartListening<EnemyHitEvent>(OnEnemyHitEvent);
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);
  }

  void OnDisable() {
    EventManager.StopListening<EnemyHitEvent>(OnEnemyHitEvent);
    EventManager.StopListening<PlayerHitEvent>(OnPlayerHitEvent);
  }

  #endregion

  #region Event Behaviour

  void OnEnemyHitEvent(EnemyHitEvent enemyHitEvent) {
    InvertColors();
  }

  void OnPlayerHitEvent(PlayerHitEvent PlayerHitEvent) {
    InvertColors();
  }

  #endregion

  #region Private Behaviour

  private void InitialSetup() {
    texts = GameObject.FindObjectsOfType(typeof(Text)).Cast<Text>().ToList();
    images = GameObject.FindObjectsOfType(typeof(RawImage)).Cast<RawImage>().ToList();
  }

  private void RenderersSetup() {
    cam.gameObject.GetComponentsInChildren<Renderer>(true).ToList().ForEach(x => renderers.Add(x));
    player.GetComponentsInChildren<Renderer>(true).ToList().ForEach(x => renderers.Add(x));
    asteroids.GetComponentsInChildren<Renderer>(true).ToList().ForEach(x => renderers.Add(x));
  }

  private void InvertColors() {

    RenderersSetup();

    cam.backgroundColor = cam.backgroundColor != Color.white ? Color.white : Color.black;

    foreach (Renderer rend in renderers) {
      if (cam.backgroundColor == Color.black)
        rend.material.color = Color.white;
      else
        rend.material.color = Color.black;
    }

    foreach (Text text in texts) {
      if (cam.backgroundColor == Color.black)
        text.color = Color.white;
      else
        text.color = Color.black;
    }

    foreach (RawImage image in images) {
      if (cam.backgroundColor == Color.black)
        image.color = Color.white;
      else
        image.color = Color.black;
    }

  }

  #endregion

}
