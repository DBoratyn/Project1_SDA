using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector2 = UnityEngine.Vector2;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rigidbody2D;

        public void Init()
        {
            //ustaw startow? pozycj?
            gameObject.SetActive(true);
        }

        public void UpdatePosition()
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (rigidbody2D.velocity.x > 0)
                    rigidbody2D.velocity = Vector2.zero;
                rigidbody2D.AddForce(Vector2.left * 10, ForceMode2D.Force);
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (rigidbody2D.velocity.x < 0)
                    rigidbody2D.velocity = Vector2.zero;
                rigidbody2D.AddForce(Vector2.right * 10, ForceMode2D.Force);
            }
        }

        public void Dispose()
        {
            gameObject.SetActive(false);
        }
    }

}
