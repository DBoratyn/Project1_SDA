using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class BaseState
    {
        protected GameController gC;

        public virtual void InitState(GameController gC)
        {
            this.gC = gC;
        }

        public abstract void UpdateState();
        public abstract void FixedUpdateState();
        public abstract void DestroyState();

    }
}
