﻿using System.ComponentModel.DataAnnotations;

namespace zad10.Data;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string firstName { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string lastName { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }
    public ICollection<Perscription> Perscriptions { get; set; }
}