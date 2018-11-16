using System;

namespace IBLL.Sample
{
    public interface IProofing: IBaseModel
    {
        int Id { get; set; }
        string MachineType { get; set; }
        string ProgamPeople { get; set; }
        string ProofingCompany { get; set; }
        DateTime? ProofingDate { get; set; }
        string StyleId { get; set; }
        string TechnologyPeople { get; set; }
        int WeaveTime { get; set; }
    }
}