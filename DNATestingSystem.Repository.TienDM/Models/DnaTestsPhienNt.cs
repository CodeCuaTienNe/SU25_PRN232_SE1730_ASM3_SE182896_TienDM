﻿using System;
using System.Collections.Generic;

namespace DNATestingSystem.Repository.TienDM.Models;

public partial class DnaTestsPhienNt
{
    public int PhienNtid { get; set; }

    public string TestType { get; set; } = null!;

    public string? Conclusion { get; set; }

    public decimal? ProbabilityOfRelationship { get; set; }

    public decimal? RelationshipIndex { get; set; }

    public bool? IsCompleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AlleleResultsPhienNt> AlleleResultsPhienNts { get; set; } = new List<AlleleResultsPhienNt>();

    public virtual ICollection<LocusMatchResultsPhienNt> LocusMatchResultsPhienNts { get; set; } = new List<LocusMatchResultsPhienNt>();
}
