using Godot;
using System;

[GlobalClass]
public partial class Globals : Node
{
	public static int _clicked { get; set; } = 0;
	public static AudioStreamPlayer lvTadpol;
	public override void _Ready()
	{
		lvTadpol = GetNode<AudioStreamPlayer>("AudioStreamPlayer");

	}
	public static void _levelOnePlay()
	{
		lvTadpol.Playing = true;
	}

}
