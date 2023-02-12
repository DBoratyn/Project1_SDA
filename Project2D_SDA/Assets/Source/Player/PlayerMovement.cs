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
        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string SPRINT_AXIS = "Sprint";
        private const string JUMP_AXIS = "Jump";

        [SerializeField]
        private Rigidbody2D rigidbody2D;

        [SerializeField]
        private float playerSpeed;

        [SerializeField]
        private float sprintMultiplayer;

        [SerializeField]
        private float maxWalkSpeed;

        [SerializeField]
        private float maxRunSpeed;

        private bool isJumpButtonClicked;

        public void Init() { 
            gameObject.SetActive(true);
        }

        public void UpdatePosition()
        {
            float playerInput = Input.GetAxisRaw(HORIZONTAL_AXIS);
            float sprintInput = Input.GetAxisRaw(SPRINT_AXIS);
            float jumpInput = Input.GetAxisRaw(JUMP_AXIS);

            var result = Physics2D.BoxCast(this.transform.position, 
                this.transform.localScale, 0f, 
                Vector2.down, .2f);

            if (playerInput == 0 && result.collider != null )
            {
                rigidbody2D.velocity = Vector2.zero;
            }

            if (jumpInput == 0)
                isJumpButtonClicked = false;

            float finalMultiplier = playerInput * playerSpeed;
            if (sprintInput > 0)
            {
                finalMultiplier *= sprintMultiplayer;
            }

            if(jumpInput > 0 && !isJumpButtonClicked)
            {
                isJumpButtonClicked = true;

                
                if (result.collider != null && result.collider.CompareTag("JumpFloor"))
                {
                    rigidbody2D.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                }
            }

            rigidbody2D.AddForce(Vector2.right * finalMultiplier, ForceMode2D.Force);

            var x = rigidbody2D.velocity.x;
            var direction = Mathf.Sign(x);
            x = Mathf.Abs(x);

            if (sprintInput == 0)
            {
                x = Mathf.Clamp(x, 0, maxWalkSpeed);
            }
            else
            {
                x = Mathf.Clamp(x, 0, maxRunSpeed);
            }

            Vector2 finalVelocity = new Vector2(x * direction, rigidbody2D.velocity.y);
            rigidbody2D.velocity = finalVelocity;
        }

        public void Dispose()
        {
            gameObject.SetActive(false);
        }
    }
}
