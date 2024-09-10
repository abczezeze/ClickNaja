using Godot;
using System;

public partial class Algae : Node3D
{
	private AnimationPlayer _swaying;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_swaying = GetNode<AnimationPlayer>("AnimationPlayer");
		_swaying.Play("Sway");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
