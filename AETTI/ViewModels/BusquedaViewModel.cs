﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AETTI.ViewModels
{
    public class BusquedaViewModel
    {
        [DisplayName("Titular")]
        public string RazonSocial { get; set; }
        [DisplayName("Nro Proyecto")]
        public int? NroProyecto { get; set; }
    }
}