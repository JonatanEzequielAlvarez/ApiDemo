using System;
namespace ApiTest.Models
{
	public class Sections
	{
        //ID_Area, ID_Empresa, ID_Establecimiento, RazonSocial, Activo
        public int ID_Area { get; set; }
        public int ID_Empresa { get; set; }
        public int ID_Establecimiento { get; set; }
        public string RazonSocial { get; set; }
        public bool Activo { get; set; }
    }
}

