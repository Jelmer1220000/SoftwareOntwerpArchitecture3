using Avans_DevOps.Rapport.Document.Document;
using Avans_DevOps.Rapport.Document.Parts;

namespace Avans_DevOps.Rapport.RapportFactory
{
    public class RapportFactory : IRapportFactory
    {

        public string CreateRapport(Footer? footer, Header? header, Body body, RapportTypes type)
        {
            switch (type)
            {
                case RapportTypes.PNG:
                    return new PNGRapport(header, body, footer).Generate();
                case RapportTypes.PDF:
                    return new PDFRapport(header, body, footer).Generate();
                default
                         :
                    throw new NotImplementedException();
            }
        }
    }
}
