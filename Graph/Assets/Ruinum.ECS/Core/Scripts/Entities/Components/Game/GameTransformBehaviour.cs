using UnityEngine;

namespace Ruinum.ECS.Scripts.Entities.Components.Game
{
    [RequireComponent(typeof(GameEntityBehaviour))]
    public sealed class GameTransformBehaviour : GameEntityComponentBehaviour, IScaleVectorListener
    {
        [SerializeField] private bool _updateTransform;
        private Transform _transform;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;

        public void OnScaleVector(GameEntity entity, Vector3 value) =>
            _transform.localScale = value;

        private void Update()
        {
            if (!Initialized || !_updateTransform)
            {
                return;
            }
            UpdateTransform();
        }

        private void UpdatePosition(Vector3 newPosition)
        {
            if (_position == newPosition)
            {
                return;
            }
            _position = newPosition;
            Entity.ReplaceTransformPosition(newPosition);
        }

        private void UpdateRotation(Quaternion newRotation)
        {
            if (_rotation == newRotation)
            {
                return;
            }
            _rotation = newRotation;
            Entity.ReplaceTransformRotation(newRotation);
        }

        private void UpdateTransform()
        {
            UpdatePosition(_transform.position);
            UpdateRotation(_transform.rotation);
        }

        protected override void OnEntityDestroyed() =>
            Entity.RemoveScaleVectorListener(this);

        protected override void OnSetEntity(GameEntity entity)
        {
            _transform = transform;
            entity.AddTransformPosition(_transform.position);
            entity.AddTransformRotation(_transform.rotation);
            entity.AddScaleVectorListener(this);

            UpdateTransform();
        }
    }
}