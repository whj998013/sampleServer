using System;

namespace SG.Interface.Sample
{
    public interface IProofing
    {
        int Id { get; set; }
        string MachineType { get; set; }
        string ProgamPeople { get; set; }
        string ProofingCompany { get; set; }

        DateTime? ProofingDate { get; set; }
        string StyleId { get; set; }
        string TechnologyPeople { get; set; }
        int WeaveTime { get; set; }
        int LinkTime { get; set; }
    }
}