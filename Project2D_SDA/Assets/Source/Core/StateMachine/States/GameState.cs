using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class GameState : BaseState
    {
        public override void InitState(GameController gC)
        {
            base.InitState(gC);
            gC.PlayerMovement.Init();
        }

        public override void UpdateState()
        {
            
        }

        public override void FixedUpdateState()
        {
            gC.PlayerMovement.UpdatePosition();
        }

        public override void DestroyState()
        {
            gC.PlayerMovement.Dispose();
        }
    }
}
