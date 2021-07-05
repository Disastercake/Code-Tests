using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExspiravitExMachina
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SceneActor))]
    public class SceneActorMotor : MonoBehaviour
    {
        public float LivingSpeed = 1f;
        public float DeadSpeed = 1f;

        public Rigidbody2D _rb { get; private set; } = null;
        private SceneActor _actor = null;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _actor = GetComponent<SceneActor>();
        }

        private void Start()
        {
            _rb.velocity = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        private void FixedUpdate()
        {
            // Keep at constant velocity.
            _rb.velocity = _rb.velocity.normalized * (_actor.Alive ? LivingSpeed : DeadSpeed);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {

        }
    }
}
