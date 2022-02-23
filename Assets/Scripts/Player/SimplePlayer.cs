using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SimplePlayer: IPlayer, IDisposable
{
    #region Fields

    private ISettings _settings;
    private int _hp;
    private List<int> _score;
    

    #endregion
    
    #region Properties
    
    public GameObject MFPController { get; private set; }

    public int HP
    {
        get
        {
            return _hp;
        }
        private set
        {
            _hp = value;
            OnHPChanged(_hp);
        }
    }

    public List<int> Score
    {
        get
        {
            return _score;
        }
        private set
        {
            _score = value;
            OnScoreChanged(_score);
        }
    }

    public SignalBus SignalBus { get; private set; }

    public PlayerStates State
    {
        get; private set;
    }
    
    public TrophyTypes WeaponType { get; private set; }

    #endregion

    #region Constructors

    public SimplePlayer(ISettings settings, SignalBus signalBus)
    {
        _settings = settings;
        SignalBus = signalBus;
        MFPController = GameObject.Find("MFPControllerMod(Clone)");
        MFPController.name = "Player";
        WeaponType = TrophyTypes.Undefined;
        State = PlayerStates.NotSpawned;

        SignalBus.Subscribe<PlayerHitSignal>(OnPlayerTakeHit);
        SignalBus.Subscribe<TrophyPickedSignal>(OnTrophyPicked);
    }


    #endregion

    #region Public methods
    
    public void Dispose()
    {
        
        SignalBus.Unsubscribe<PlayerHitSignal>(OnPlayerTakeHit);
    }
    
    public void Respawn()
    {
        var playerTransform = MFPController.transform.GetChild(0);
        
        playerTransform.rotation = Quaternion.identity;
        playerTransform.position = _settings.PlayerInitialPosition;

        HP = 100;
        Score = new List<int>(3){0, 0 ,0};
        State = PlayerStates.Alive;
    }
    
    
    private void AddScore(TrophyTypes trophyType)
    {
        switch (trophyType)
        {
            case TrophyTypes.Red:
                _score[0]++;
                break;
            case TrophyTypes.Green:
                _score[1]++;
                break;
            case TrophyTypes.Yellow:
                _score[2]++;
                break;
        }
        OnScoreChanged(_score);
    }

    #endregion

    #region Private methods

    void OnHPChanged(int actualHP)
    {
        MFPController.transform.GetChild(1).GetChild(10).GetComponent<Text>()
            .text = actualHP.ToString();
    }
    
    
    private void OnScoreChanged(List<int> score)
    {
        var scoreGroupTransform = MFPController.transform.GetChild(1).GetChild(11);
        for (int i = 0; i < score.Count; i++)
        {
            var scoreTransform = scoreGroupTransform.GetChild(i);
            if (scoreTransform != null)
            {
                scoreTransform.GetComponent<Text>().text = score[i].ToString();
            }
        }
    }

    #endregion


    #region Event handlers
    
    public void OnPlayerTakeHit(PlayerHitSignal args)
    {
        HP -= args.Damage;
        if (HP <= 0)
        {
            State = PlayerStates.Dead;
            SignalBus.Fire<PlayerDeadSignal>();
        }
    }
    
    private void OnTrophyPicked(TrophyPickedSignal args)
    {
        var trophyType = args.Trophy.gameObject.GetComponent<Trophy1Controller>().Type;
        WeaponType = trophyType;
        AddScore(trophyType);
    }


    #endregion

}