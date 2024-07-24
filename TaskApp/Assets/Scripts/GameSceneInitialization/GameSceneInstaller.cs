using BonusLogic;
using BonusLogic.Weapon;
using BootLogic;
using DangerZoneCode;
using GameUI;
using GameInput;
using PlayerCode;
using UnityEngine;
using EnemyLogic;
using Score;


namespace GameSceneInitialization
{

    public class GameSceneInstaller : MonoBehaviour
    {
        Player _player;
        CameraFollow _cameraFollow;
        DangerZoneSpawner _zoneSpawner;
        GamePanel _gamePanel;

        CameraVisability _cameraVisability;

        BonusesSpawnSystem _bonusesSpawnSystem;

        WeaponService _weaponService;
        EnemyService _enemyService;

        IMovementInput _movementInput;
        IShootInput _shootInput;

        GameScore _currentScore;
        private void OnEnable()
        {
            GameEvents.OnEndGameEvent += OnEndGame;
        }
        private void OnDisable()
        {
            GameEvents.OnEndGameEvent -= OnEndGame;
        }
        private void Start()
        {
            _player = GetComponentInChildren<Player>();
            _cameraFollow = GetComponentInChildren<CameraFollow>();
            _zoneSpawner = GetComponentInChildren<DangerZoneSpawner>();
            _bonusesSpawnSystem = GetComponentInChildren<BonusesSpawnSystem>();
            _cameraVisability = GetComponentInChildren<CameraVisability>();

            _weaponService = GetComponentInChildren<WeaponService>();

            _enemyService = GetComponentInChildren<EnemyService>();

             _movementInput = GameCore.Instance().InputServiceProvider.
                Get(typeof(MovementInputService))
                as MovementInputService;

            _player.Initialize(_movementInput, _weaponService);

            _cameraFollow.Initialize(_player.PlayerTransform);

            IDangerZoneFactory speedZoneFactory =
                new DangerZoneFactory(_zoneSpawner.SpeedZoneTemplate, _player);

            IDangerZoneFactory fatalZoneFactory =
                new DangerZoneFactory(_zoneSpawner.FatalZoneTemplate, _player);

            _zoneSpawner.Initialize(_player.PlayerTransform,
                speedZoneFactory, fatalZoneFactory);

            _gamePanel = GameCore.Instance().UI.GamePanel;

            _gamePanel.Activate();

            _shootInput = GameCore.Instance().
                InputServiceProvider.Get(typeof(ShootInputService))
                as ShootInputService;

            _weaponService.Initialize(_player, _shootInput);

            _bonusesSpawnSystem.Initialze(_cameraVisability, _player, _weaponService);

            _currentScore = new GameScore();

            _enemyService.Initialize(_player, _cameraVisability, _currentScore);

            MouseExtention.Init(_player.PlayerTransform);
        }

        private void Update()
        {
            
        }

        void OnEndGame()
        {
            _movementInput.Disable();
            _shootInput.Disable();

            GameCore.Instance().UI.GamePanel.Deactivate();
            GameCore.Instance().UI.FinalGamePanel.Active();

            if(_currentScore.Score > 
                GameCore.Instance().GameScore.Score)
            {
                

                GameCore.Instance().UI.FinalGamePanel.NewRecordText.SetActive(true);

                _currentScore.Save();

                GameCore.Instance().GameScore.Load();
            }

            GameCore.Instance().UI.FinalGamePanel.ScoreValueText.text =
                    _currentScore.Score.ToString();
        }
    }
}
