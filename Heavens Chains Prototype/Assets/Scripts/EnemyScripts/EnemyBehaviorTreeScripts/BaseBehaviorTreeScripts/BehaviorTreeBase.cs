using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class BehaviorTreeBase: MonoBehaviour
    {
        protected Node _root = null;

        //Every update, run Evaluate()
        private void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        //Generic SetupTree() constructor
        
        protected abstract Node SetupTree();
        public abstract void Command(string command, bool commandState);
    }

}