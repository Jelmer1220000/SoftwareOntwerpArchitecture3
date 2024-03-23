using Avans_DevOps.Rapport.Document.Parts;

namespace Avans_DevOps.Rapport.Document
{
    public abstract class Rapport
    {
        public Header? Header;
        public Body Body;
        public Footer? Footer;

        public Rapport(Header? header, Body body, Footer? footer)
        {
            Header = header;
            Body = body;
            Footer = footer;
        }

        public abstract string Generate();
    }
}
