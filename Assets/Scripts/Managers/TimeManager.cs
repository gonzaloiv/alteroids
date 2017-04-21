using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Based on Marc Breaux's: http://www.gamasutra.com/blogs/MarcBreaux/20141007/227245/Pausing_and_Time_Management_in_Unity.php
public class TimeManager : Singleton<TimeManager> {

  #region Fields

  [SerializeField] private float modeTimeScale;

  public static float DeltaTime { get { return deltaTime; } }

  private static float deltaTime;
  private static float lastframetime;

  #endregion

  #region Mono Behaviour

  void Start() {
    lastframetime = Time.realtimeSinceStartup;
    AlterTimeScale(modeTimeScale);
  }

  void Update() {
    deltaTime = Time.realtimeSinceStartup - lastframetime;
    lastframetime = Time.realtimeSinceStartup;
  }

  void OnDestroy() {
    AlterTimeScale(Config.TIME_SCALE);
  }

  #endregion

  #region Public Behaviour

  public static void StopTime() {
    Time.timeScale = 0;
  }

  public static void StartTime() {
    Time.timeScale = Config.TIME_SCALE;
  }

  public static void AlterTimeScale(float timeScale) {
    Time.timeScale = timeScale;
  }

  #endregion

}
