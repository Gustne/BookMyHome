﻿using System.ComponentModel.DataAnnotations;

namespace BookMyHome.Domain.Enitity;

public abstract class DomainEntity
{
    public int Id { get; protected set; }
    [Timestamp]
    public byte[] RowVersion { get; protected set; }
}