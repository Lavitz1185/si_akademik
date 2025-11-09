namespace SIAkademik.Web.Services.PDFGenerator;

public interface IPDFGeneratorService
{
    Task<byte[]> GeneratePDF(string html, string fileName);
    Task<byte[]> GeneratePDF(
        string html, 
        string header, 
        string footer, 
        string fileName,
        double marginTop,
        double marginBottom,
        double marginLeft,
        double marginRight);
}
