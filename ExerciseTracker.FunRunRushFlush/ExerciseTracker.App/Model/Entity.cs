﻿using System.ComponentModel.DataAnnotations;

namespace ExerciseTracker.App.Model;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }
}