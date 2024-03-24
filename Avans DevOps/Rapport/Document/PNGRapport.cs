using Avans_DevOps.Rapport.Document.Parts;

namespace Avans_DevOps.Rapport.Document.Document
{
    public class PNGRapport : Rapport
    {
        public PNGRapport(Header? header, Body body, Footer? footer) : base(header, body, footer)
        {
        }

        public override string Generate()
        {
            throw new NotImplementedException();
        }
    }
}
