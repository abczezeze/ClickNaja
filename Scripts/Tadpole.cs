using Godot;
using System;

public partial class Tadpole : Area3D
{
	AnimationPlayer tadpoleAnimationPlayer;
	double moveSpeedX = GD.RandRange(-5,5);
	double moveSpeedY = GD.RandRange(-5,5);
	bool clicked = false;
	public override void _Ready()
	{
		tadpoleAnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		tadpoleAnimationPlayer.Play("Idle");
	}

	public override void _Process(double delta)
	{
		
		Translate(new Vector3(Convert.ToSingle(moveSpeedX*delta),Convert.ToSingle(moveSpeedY*delta),0));
		if (Position.X > GD.RandRange(10,20))
		{
			moveSpeedX = GD.RandRange(-5,0);
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
		}
	}

	private void _OnInputEvent(Node camera, InputEvent inputEvent, Vector3 clickPosition, Vector3 clickNormal, int shapeIdx)
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
    }
	private void _OnAnimationFinished(StringName animationName)
	{
		clicked = false;
		tadpoleAnimationPlayer.Play("Idle");
	}
}
