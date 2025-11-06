using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class State
    {
        public string state_name;
        public float ts;
     
       public State(string State,float timescale) 
       {
              state_name = State;
              ts = timescale;
       }
        
        
        public string getCurrentState()
        {
            return state_name;
        }

        public void setCurrentState(string State)
        {
            state_name = State;
        }
    }
}
