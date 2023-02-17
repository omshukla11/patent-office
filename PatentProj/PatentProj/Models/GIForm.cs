using System;
using Microsoft.EntityFrameworkCore;

namespace PatentProj.Models
{
	public class GIForm
	{
        public long Id { get; set; }
        public string? FormName { get; set; }
        public string? TypesOfGoods { get; set; }
        public string? GIName { get; set; }
        public string? GIClass { get; set; }
        public bool ApplicationType { get; set; }
        public string? ApplicantName { get; set; }
        public string? ApplicantAddress { get; set; }
        public string? City_Town { get; set; }
        public string? State { get; set; }
        public uint PinCode { get; set; }
        public string? Individual_OrganizationName { get; set; }
        public bool IsComplete { get; set; }
    }
}