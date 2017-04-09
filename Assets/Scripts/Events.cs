using UnityEngine.Events;
using UnityEngine;

#region Input Events

public class MoveRightInput : UnityEvent {}
public class MoveLeftInput : UnityEvent {}
public class MoveUpInput : UnityEvent {}
public class SpaceInput : UnityEvent {}
public class EscapeInput : UnityEvent {}

#endregion

#region Mode01 Events

public class AsteroidHitEvent : UnityEvent {

  public int Score { get { return score; } } 
  private int score;

  public AsteroidHitEvent(int score) {
    this.score = score;
  }

}
public class PlayerHitEvent : UnityEvent {}
public class GameOverEvent : UnityEvent {}

#endregion