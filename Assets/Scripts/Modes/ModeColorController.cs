using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEditor;

public class ModeColorController : MonoBehaviour {

  #region Fields

  [SerializeField] private Camera cam;
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
    ChangeColor();
  }

  void OnPlayerHitEvent(PlayerHitEvent PlayerHitEvent) {
    ChangeColor();
  }

  #endregion

  #region Private Behaviour

  private void InitialSetup() {
    texts = GameObject.FindObjectsOfType(typeof(Text)).Cast<Text>().ToList();
    images = GameObject.FindObjectsOfType(typeof(RawImage)).Cast<RawImage>().ToList();
    renderers = GameObject.FindObjectsOfTypeAll(typeof(Renderer)).Cast<Renderer>().ToList();
  }

  private void ChangeColor() {

    cam.backgroundColor = cam.backgroundColor != Color.white ? Color.white : Color.black;

    foreach (Renderer rend in renderers) {
      try {
        if (cam.backgroundColor == Color.black)
          rend.material.color = Color.white;
        else
          rend.material.color = Color.black;
      } catch (Exception ex) {
        Debug.Log("Object already inactive.");
      }
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
