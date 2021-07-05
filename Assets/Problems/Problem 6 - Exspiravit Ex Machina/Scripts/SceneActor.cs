using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ExspiravitExMachina
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SceneActorMotor))]
    [RequireComponent(typeof(SceneActorSpriteHandler))]
    public class SceneActor : MonoBehaviour, IPointerClickHandler
    {
        private SceneActorMotor _motor = null;
        private SceneActorSpriteHandler _spriteHandler = null;
        private Ghost _ghost = null;

        public bool Alive { get; private set; } = true;
        public string ActorName { get; private set; } = "No-Name";

        private static CommonScripts.NameGenerator NAME_GENERATOR = new CommonScripts.NameGenerator();

        private void Awake()
        {
            _motor = GetComponent<SceneActorMotor>();
            _spriteHandler = GetComponent<SceneActorSpriteHandler>();

            ActorName = NAME_GENERATOR.GetName();
            gameObject.name = $"{gameObject.name} ({ActorName})";
        }

        private void Start()
        {
            RefreshSprite();
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            //Debug.Log($"Clicked: {gameObject.name}");

            //if (Alive)
            //    Kill();
            //else
                Revive();
        }

        /// <summary>
        /// If this actor is alive, this will kill them and turn them into a ghost.
        /// </summary>
        public void Kill()
        {
            if (Alive == false) return;

            Alive = false;
            _ghost = GhostGameManager.Instance._ghostMachine.Create(ActorName, Random.Range(1, 10));
            RefreshSprite();
        }

        /// <summary>
        /// If this actor is dead, this will revive them and remove their ghost reference.
        /// </summary>
        public void Revive()
        {
            if (Alive) return;

            Alive = true;
            GhostGameManager.Instance._ghostMachine.Destroy(_ghost);
            _ghost = null;
            RefreshSprite();
        }

        private void RefreshSprite()
        {
            _spriteHandler.SetSprite(Alive ? "alive" : "ghost");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!Alive) return;

            SceneActor bumper;

            if (collision.gameObject.TryGetComponent(out bumper))
            {
                if (bumper.Alive == false)
                {
                    Kill();
                }
            }
        }
    }
}
