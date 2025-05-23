using Code.Shared;
using LiteEntitySystem;
using UnityEngine;

namespace Code.Server
{
    public class ServerBotController : AiControllerLogic<BasePlayer>
    {
        private float _rotation;
        private float _rotationChangeTimer = 0.5f;

        public ServerBotController(EntityParams entityParams) : base(entityParams)
        {
            _rotation = Random.Range(0, 360);
        }

        protected override void BeforeControlledUpdate()
        {
            _rotationChangeTimer -= EntityManager.DeltaTimeF;
            if (_rotationChangeTimer < 0f)
            {
                _rotation += Random.Range(-30f, 30f);
                _rotationChangeTimer = Random.Range(0.5f, 3f);
            }
            bool normalFire = Random.Range(0, 50) == 0;
            bool secondaryFire = Random.Range(0, 100) == 0;
            ControlledEntity.SetInput(
                normalFire,
                !normalFire && secondaryFire,
                _rotation,
                new Vector2(Mathf.Cos(_rotation * Mathf.Deg2Rad),Mathf.Sin(_rotation * Mathf.Deg2Rad)*0.1f));
        }
    }
}