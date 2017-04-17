using UnityEngine;
using UnityEngine.Events;

#region Input Events

public class MoveRightInput : UnityEvent {}
public class MoveLeftInput : UnityEvent {}
public class MoveUpInput : UnityEvent {}
public class MoveDownInput : UnityEvent {}
public class SpaceInput : UnityEvent {}
public class EscapeInput : UnityEvent {}
public class ReturnInput : UnityEvent {}

#endregion

#region Modes Events

public class SelectModeEvent : UnityEvent {}

#endregion


#region Mode01 Events

public class EnemyHitEvent : UnityEvent {

  public int Score { get { return score; } } 
  private int score;

  public EnemyHitEvent(int score) {
    this.score = score;
  }

}

public class PlayerHitEvent : UnityEvent {}
public class PlayerShotEvent : UnityEvent {}
public class PlayerSpawnEvent : UnityEvent {}
public class GameOverEvent : UnityEvent {}
public class WaveOverEvent : UnityEvent {}

#endregion