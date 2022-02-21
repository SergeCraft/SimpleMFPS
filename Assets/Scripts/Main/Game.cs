using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
   private IGameManager _gameManager;
   
   [Inject]
   public void Construct(IGameManager gameMgr, SignalBus signalBus)
   {
      _gameManager = gameMgr;
   }
}
