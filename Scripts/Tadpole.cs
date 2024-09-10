using Godot;
using System;

public partial class Tadpole : CharacterBody3D
{
	AnimationPlayer tadpoleAnimationPlayer;
	NavigationAgent3D _navAgent;
	double moveSpeedX = GD.RandRange(-5,5);
	double moveSpeedY = GD.RandRange(-5,5);
	bool clicked = false;
	public Vector3 velocity;
	private float _rotationVelocity = 3.5f;
	float _gravity = 0.1f;
	float _speed = 3.5f;
	public override void _Ready()
	{
		tadpoleAnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		tadpoleAnimationPlayer.Play("Idle");
		_navAgent = GetNode<NavigationAgent3D>("NavigationAgent3D");
		//_navAgent.PathDesiredDistance = 0.5f;
		//_navAgent.TargetDesiredDistance = 0.5f;
	}

	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;
		if (!IsOnFloor()) 
		{
			velocity.Y -= _gravity * (float)delta;
		}
		if (!_navAgent.IsNavigationFinished())
		{
			Vector3 next = _navAgent.GetNextPathPosition();
			LookAt(new Vector3(next.X, GlobalPosition.Y, next.Z), Vector3.Up);
			Vector3 dir = (next - GlobalPosition).Normalized();
			velocity.X = dir.X * _speed;
			velocity.Z = dir.Z * _speed;
		}else
		{
			velocity.X = 0;
			velocity.Z = 0.0f;
		}
		Velocity = velocity;
		MoveAndSlide();
		
		/*Translate(new Vector3((float)(moveSpeedX*delta),(float)(moveSpeedY*delta),0));
		if (Position.X > GD.RandRange(10,20))
		{
			moveSpeedX = GD.RandRange(-5,0);
			//Rotation = new Vector3(GD.Randf(),GD.Randf(),GD.Randf()); 
 
		}else if (Position.X < GD.RandRange(-20,-10))
		{
			moveSpeedX = GD.RandRange(0,5);
		}

		if (Position.Y > GD.RandRange(5,9))
		{
			moveSpeedY = GD.RandRange(-5,0);
		}else if (Position.Y < GD.RandRange(-9,-5))
		{
			moveSpeedY = GD.RandRange(0,5);
		}*/
	}

	/*private void _OnInputEvent(Node camera, InputEvent inputEvent, Vector3 clickPosition, Vector3 clickNormal, int shapeIdx)
    {
		if (inputEvent is InputEventMouseButton)
			if (inputEvent.IsActionPressed("click") && !clicked)
	        {
				tadpoleAnimationPlayer.Play("Clicked");
				clicked = true;
				Global._clicked += 1;
				Position = Vector3.Zero;
				moveSpeedY = GD.RandRange(-5,5);
				moveSpeedX = GD.RandRange(-5,5);
        	}
    }*/
	private void _OnAnimationFinished(StringName animationName)
	{
		clicked = false;
		tadpoleAnimationPlayer.Play("Idle");
		QueueFree();
	}
	public void SetTargetPosition(Vector3 pos)
	{
		var map = GetWorld3D().NavigationMap;
		var p = NavigationServer3D.MapGetClosestPoint(map, pos);
		_navAgent.TargetPosition = p;
		
	}
}
