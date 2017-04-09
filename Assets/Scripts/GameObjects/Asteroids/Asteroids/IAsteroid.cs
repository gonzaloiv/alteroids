using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAsteroid {

  AsteroidType Type { get; }
  int Pieces { get; } 
  float Speed { get; }
  int Score { get; }

}
