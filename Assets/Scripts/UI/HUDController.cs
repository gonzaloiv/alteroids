using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDController : Singleton<HUDController> {

	#region Fields

  [SerializeField] private Text scoreLabel;
  [SerializeField] private GameObject[] livesLabels;

  #endregion

  #region Public Behaviour

  public static void UpdateScore(int score) {
    Instance.scoreLabel.text = (score).ToString();
  }

  public static void UpdateLives(int lives) {
    for (int i = 0; i < Instance.livesLabels.Length; i++) {
      Instance.livesLabels[i].SetActive(false); 
      if(i < lives)
        Instance.livesLabels[i].SetActive(true); 
    }
  }

  #endregion

}
