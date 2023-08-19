using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{

	public enum NodeState
	{
		RUNNING, 
		SUCCESS, 
		FAILURE
	}

	public class Node
	{
		protected NodeState state;

		public Node parent;
		protected List<Node> children = new List<Node>();

		public Node()
		{
			parent = null;
		}

		//Iterate through the behavior tree and use _Attach() to attach a child node to each parent node
		public Node(List<Node> children)
		{
			foreach(Node child in children)
			{
				_Attach(child);
			}
		}

		//Attach a node to its parent
		private void _Attach(Node node)
		{
			node.parent = this;
			children.Add(node);
		}

		//Generic method that is overriden by the sequencer
		public virtual NodeState Evaluate() => NodeState.FAILURE;

		//Get the dictionary of nodes and their keys
		private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

		//Set the data in each node
		public void SetData<T>(string key, T value)
		{
			_dataContext[key] = value;
		}

		//Recursively retrive the data in each node by iterating up through the behavior tree until you reach the root node
		public T GetData<T>(string key)
		{
			object val;
			if (_dataContext.TryGetValue(key, out val))
				return (T)val;
			else 
				val = default(T);

			Node node = parent;
			if (node != null)
				val = node.GetData<T>(key);
			return (T)val;

		}

		//Same recursive process as GetData except you just remove data instead
		public bool ClearData(string key)
		{
			bool cleared = false;
			if (_dataContext.ContainsKey(key))
			{
				_dataContext.Remove(key);
				return true;
			}

			Node node = parent;
			if (node != null)
				cleared = node.ClearData(key);
			return cleared;
		}

	}

}
