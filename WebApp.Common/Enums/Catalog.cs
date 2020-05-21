using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebApp.Common.Enums
{
	[Flags]
	public enum CatalogType : byte
	{
		[Description("Tipo de Asset")]
		AssetType = 1,
		[Description("Categoria")]
		Category = 2,
	}

	[Flags]
	public enum PersonType : byte
	{
		[Description("283dfe96-1489-4e44-930b-50d14dec49e3")]
		Fisica = 1,
		[Description("ca35fb3b-196e-48fe-9108-a18f7048e9e9")]
		Moral = 2
	}

	public enum PlaceType : byte
	{
		[Description("00000000-0000-0000-0000-000000000000")]
		Default = 1
	}

	public enum SepomexCode : byte
	{
		[Description("01-001-0000")]
		Default = 1
	} 

	public enum NotariaCode : byte
    {
        [Description("00000000-0000-0000-0000-000000000000")]
        Default = 1
    }

    public enum AppLevel : byte
    {
        [Description("Admin")]
        Default = 1,
        [Description("TPA")]
        TPA = 2,
        [Description("Proveedor")]
        Proveedor = 3,
        [Description("ClienteCorp")]
        ClienteCorp = 4,
        [Description("DerechoHabiente")]
        DerechoHabiente = 5
    }
    public enum LevelDocumentType : byte
    {
       [Description("Default")]
        Default = 0,
       [Description("General")]
        General = 1,
       [Description("Especialidad")]
        Especialidad = 2,
    }
    public enum AcademicInformationType : byte
    {
        [Description("Publicaciones")]
        Publicaciones = 1,
        [Description("Actividad Laboral Institucional")]
        ActividadInstitucional = 2,
        [Description("Actividad Laboral Privada")]
        ActividadPrivada = 3,
    }

    public enum SaveType : byte
    {
        [Description("All")]
        All = 0,
        [Description("User")]
        User = 1,
        [Description("Password")]
        Password = 2,
    }
    public enum ProviderType : byte
    {
        [Description("Medico")]
        Medico = 1,
        [Description("Farmacia")]
        Farmacia = 2,
        [Description("Laboratorio")]
        Laboratorio = 3,
        [Description("Gabinete")]
        Gabinete = 4,
        [Description("Hospital")]
        Hospital = 5,
        [Description("Varios")]
        Varios = 6,
    }
}