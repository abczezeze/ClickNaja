using System;
using Godot;

public partial class MainScene : Node3D
{
	Area3D duplicatetadpole;
	Label clickLabel;
	public override void _Ready()
	{
		//worldMain = GetNode<WorldEnvironment>("WorldEnvironment");
		duplicatetadpole = GetNode<Area3D>("Tadpole");
		clickLabel = GetNode<Label>("Label");
		for(int i=0;i<=10;i++)
		{
			AddChild(duplicatetadpole.Duplicate());
		}
	}
    public override void _Process(double delta)
    {
        clickLabel.Text = Convert.ToString(Global._clicked);
    }
}
