using Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.XR;

namespace Core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private MenuView menuView;
        public MenuView MenuView => menuView;

        [SerializeField]
        private PlayerMovement playerMovement;
        public PlayerMovement PlayerMovement => playerMovement;

        private BaseState currentState;

        private void Start()
        {
            //inicjalizacja zmiennych
            //ustawienie startowego stanu

            ChangeState(new MenuState());
        }

        private void Update()
        {
            currentState?.UpdateState();
        }

        private void FixedUpdate()
        {
            currentState?.FixedUpdateState();
        }

        private void OnDestroy()
        {
            //co ma się stać przed wyłaczeniem gry -> np. save
        }

        public void ChangeState(BaseState newState)
        {
            currentState?.DestroyState(); //if(currentState != null) -> ?
            currentState = newState;
            currentState?.InitState(this);
        }
    }

}

