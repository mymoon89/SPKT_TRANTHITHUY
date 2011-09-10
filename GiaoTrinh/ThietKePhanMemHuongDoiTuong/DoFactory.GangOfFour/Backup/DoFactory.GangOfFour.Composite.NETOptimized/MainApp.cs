using System;
using System.Collections;
using System.Windows.Forms;

namespace DoFactory.GangOfFour.Composite.NETOptimized
{
	
	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			TreeNode root = new TreeNode("Picture");

			root.Nodes.Add(new TreeNode("Red Line"));
			root.Nodes.Add(new TreeNode("Blue Circle"));
			root.Nodes.Add(new TreeNode("Green Box"));

			TreeNode branch = new TreeNode("Two Circles");
			branch.Nodes.Add("Black Circle");
			branch.Nodes.Add("White Circle");

			root.Nodes.Add(branch);

			// Add and remove a PrimitiveElement
			TreeNode pe = new TreeNode("Yellow Line");
			root.Nodes.Add(pe);
			root.Nodes.Remove(pe);

			Display(root, 1);

			Console.Read();
		}

		private static void Display(TreeNode tree, int indent)
		{
			Console.WriteLine(
				new String('-', indent) + "+ " + tree.Text);

			foreach(TreeNode node in tree.Nodes)
			{
				if (node.Nodes.Count > 0)
				{
					Display(node,indent + 2);
				}
				else
				{
					Console.WriteLine(
						new String('-', indent+1) + " " + node.Text);
				}
			}
		}
	}
}
