﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebApiTurnos.Data.Models;

public partial class TTurno
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public string Hora { get; set; }

    public string Cliente { get; set; }

    public DateTime? FechaCancelacion { get; set; }

    public string MotivoCancelacion { get; set; }
}