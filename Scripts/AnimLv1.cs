using Godot;
using System;

public partial class AnimLv1 : Node3D
{
	private AnimationPlayer _anim;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_anim = GetNode<AnimationPlayer>("AnimationPlayer");
		_anim.Play("new_animation");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _onAnimationFinished(StringName anim)
	{
		GetTree().ChangeSceneToFile("res://Scenes/MainScene.tscn");
	}
}
