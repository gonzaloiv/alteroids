using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config {
  public static float TIME_SCALE = 1f;
}

public enum Layer {
  Board = 8,
  Player = 9,
  Enemies = 10
}

public enum AsteroidType {
  Large,
  Medium,
  Small,
  None
}

public enum UFOType {
  Large,
  Small
}

public enum Scene {
  Title,
  Modes,
  Mode01,
  Mode02,
  Mode03,
  Mode04,
  Mode05,
  Mode06,
  Mode07,
  Mode08
}