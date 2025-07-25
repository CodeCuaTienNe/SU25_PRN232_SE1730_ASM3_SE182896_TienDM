﻿using System;
using System.Collections.Generic;

namespace DNATestingSystem.Repository.TienDM.Models;

public partial class LociPhienNt
{
    public int PhienNtid { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsCodis { get; set; }

    public string? Description { get; set; }

    public decimal? MutationRate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AlleleResultsPhienNt> AlleleResultsPhienNts { get; set; } = new List<AlleleResultsPhienNt>();

    public virtual ICollection<LocusMatchResultsPhienNt> LocusMatchResultsPhienNts { get; set; } = new List<LocusMatchResultsPhienNt>();
}
