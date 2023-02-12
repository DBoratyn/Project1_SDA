using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class MenuState : BaseState
    {
        public override void InitState(GameController gC)
        {
            base.InitState(gC);
            gC.MenuView.StartButton.onClick.AddListener(()=>gC.ChangeState(new GameState()));
            gC.MenuView.ShowView();
        }

        public override void UpdateState()
        {

        }

        public override void FixedUpdateState()
        {

        }

        public override void DestroyState()
        {
            gC.MenuView.StartButton.onClick.RemoveAllListeners();
            gC.MenuView.HideView();
        }
    }
}
