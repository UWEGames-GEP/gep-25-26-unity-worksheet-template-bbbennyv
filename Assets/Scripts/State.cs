using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Scripts
{
    public abstract class State
    {
        public abstract float ts { get; }

        public virtual void Enter(GameManager manager)
        {
            Time.timeScale = ts;
        }
       
    }

    public class GameplayState : State
    {
        public override float ts => 1f;

        public override void Enter(GameManager manager)
        {
            base.Enter(manager);

            manager.PauseUI.SetActive(false);
            manager.InventoryUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public class PauseState : State
    {
        public override float ts => 0f;

        public override void Enter(GameManager manager)
        {
            base.Enter(manager);

            manager.PauseUI.SetActive(true);
            manager.InventoryUI.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public class InventoryState : State
    {
        public override float ts => 0f;

        public override void Enter(GameManager manager)
        {
            base.Enter(manager);

            manager.PauseUI.SetActive(false);
            manager.InventoryUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


}
