using Avans_DevOps.Rapport.Document.Parts;
namespace Avans_DevOps.Rapport.RapportFactory
{
    public interface IRapportFactory
    {
        public string CreateRapport(Footer? footer, Header? header, Body? body, Document.Document.RapportTypes type);
    }
}
