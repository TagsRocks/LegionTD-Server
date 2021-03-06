﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegionTDServerReborn.Models
{
    public class Fraction
    {
        [Key]
        public string Name { get; set; }
        [InverseProperty("Fraction")]
        public List<PlayerMatchData> PlayedMatches {get; set;}
        [InverseProperty("Fraction")]
        public List<Unit> Units {get; set;}
        [InverseProperty("Fraction")]
        public List<FractionStatistic> Statistics {get; set;}
        public FractionStatistic CurrentStatistic => Statistics.OrderByDescending(s => s.TimeStamp).FirstOrDefault();
    }
}
