﻿using Entitas;
using Entitas.CodeGeneration.Attributes;


[Game]
public sealed class TargetMainCreatorComponent : IComponent
{
    [EntityIndex] public GameEntity Value;
}