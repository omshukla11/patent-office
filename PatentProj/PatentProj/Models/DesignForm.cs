using System;
namespace PatentProj.Models
{
    public class DesignForm
    {
        public long Id { get; set; }
        public string? FormName { get; set; }
        public string? TypesOfGoods { get; set; }
        public string? GIName { get; set; }
        public string? IDCClass { get; set; }
        public string? ApplicationType { get; set; }
        public string? ApplicantName { get; set; }
        public string? ApplicantAddress { get; set; }
        public string? City_Town { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ApplicantType { get; set; }
        public string? PreRegClasses { get; set; }
        public string? Under_No { get; set; }
        public string? AddressOfService { get; set; }
        public string? EmailID { get; set; }
        public uint PhoneNo { get; set; }
        public bool IsComplete { get; set; }
    }
}

