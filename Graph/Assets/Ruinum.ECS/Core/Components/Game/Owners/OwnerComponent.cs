﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class OwnerComponent : IComponent
{
    [EntityIndex] public GameEntity Value;
}