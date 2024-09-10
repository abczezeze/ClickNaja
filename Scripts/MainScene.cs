using System;
using Godot;

public partial class MainScene : Node3D
{
	Tadpole duplicatetadpole;
	Label clickLabel;
	private bool _rightClickedThisFrame = false;
    private Vector2 _rightClickMousePos;
	public override void _Ready()
	{
		//worldMain = GetNode<WorldEnvironment>("WorldEnvironment");
		duplicatetadpole = GetNode<Tadpole>("Tadpole");
		clickLabel = GetNode<Label>("Label");
		/*for(int i=0;i<=10;i++)
		{
			AddChild(duplicatetadpole.Duplicate());
		}*/
	}
    /*public override void _Process(double delta)
    {
        clickLabel.Text = Convert.ToString(Global._clicked);
    }*/
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton e && e.Pressed && e.ButtonIndex == MouseButton.Right)
		{
			_rightClickedThisFrame = true;
			_rightClickMousePos = e.Position;
		} else 
		{
			_rightClickedThisFrame = false;
		}
	}
	private const float RayLength = 1000.0f;

	public override void _PhysicsProcess(double delta)
	{
		if (_rightClickedThisFrame)
		{
			var camera3D = GetNode<Camera3D>("Camera3D");
			var from = camera3D.ProjectRayOrigin(_rightClickMousePos);
			var to = from + camera3D.ProjectRayNormal(_rightClickMousePos) * RayLength;
			var spaceState = GetWorld3D().DirectSpaceState;
			var query = PhysicsRayQueryParameters3D.Create(from, to, 2);
			var result = spaceState.IntersectRay(query);
			if (result.Count > 0)
			{
				duplicatetadpole.SetTargetPosition(result["position"].AsVector3());
				GD.Print(result["position"]);
				
			}
		}
	}

}
