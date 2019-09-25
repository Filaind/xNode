﻿using System.Linq;
using UnityEngine;

namespace XNode.Examples.LogicToy {
	[NodeWidth(140)]
	public class ToggleNode : LogicNode {
		[Input] public bool input;
		[Output] public bool output;
		public override bool led { get { return output; } }

		protected override void OnInputChanged() {
			bool newInput = GetPort("input").GetInputValues<bool>().Any(x => x);

			if (!input && newInput) {
				input = newInput;
				output = !output;
				SendSignal(GetPort("output"));
			} else if (input && !newInput) {
				input = newInput;
			}
		}

		public override object GetValue(NodePort port) {
			return output;
		}
	}
}