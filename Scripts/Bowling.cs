using Godot;
using System;

public partial class Bowling : Node3D
{	
	RigidBody3D _BallRigid;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_BallRigid = GetNode<RigidBody3D>("BallRigid");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _OnBallRigidInputEvent(Node camera, InputEvent inputEvent, Vector3 position, Vector3 normal, int shape_idx)
	{
		if (inputEvent is InputEventMouseButton btn && btn.ButtonIndex == MouseButton.Left && inputEvent.IsPressed())
		{
			_BallRigid.ApplyImpulse(new Vector3(0, 0,-10));
        }
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey eventKey)
		{
			if (eventKey.Pressed && eventKey.Keycode == Key.Right)
			{
				_BallRigid.ApplyImpulse(new Vector3((float)0.1, 0,0));
			}
			if (eventKey.Pressed && eventKey.Keycode == Key.Left)
			{
				_BallRigid.ApplyImpulse(new Vector3((float)-0.1, 0,0));
			}
		}
	}
}
