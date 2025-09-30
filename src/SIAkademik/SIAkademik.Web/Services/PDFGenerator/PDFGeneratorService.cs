using PuppeteerSharp.Media;
using PuppeteerSharp;
using Razor.Templating.Core;

namespace SIAkademik.Web.Services.PDFGenerator;

public class PDFGeneratorService : IPDFGeneratorService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IRazorTemplateEngine _razorTemplateEngine;

    public PDFGeneratorService(IWebHostEnvironment environment, IRazorTemplateEngine razorTemplateEngine)
    {
        _webHostEnvironment = environment;
        _razorTemplateEngine = razorTemplateEngine;
    }

    public async Task<byte[]> GeneratePDF(string html, string fileName)
    {
        var header = await _razorTemplateEngine.RenderAsync("Views/Shared/_HeaderLaporanPartial.cshtml");
        var footer = await _razorTemplateEngine.RenderAsync("Views/Shared/_FooterLaporanPartial.cshtml");

        var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();

        using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true, Args = ["--no-sandbox"] });
        using var page = await browser.NewPageAsync();
        await page.SetContentAsync(html);

        if (!Directory.Exists($"{_webHostEnvironment.WebRootPath}/file/pdf"))
            Directory.CreateDirectory($"{_webHostEnvironment.WebRootPath}/file/pef");

        var filePath = $"{_webHostEnvironment.WebRootPath}/file/pdf/{fileName}.pdf";
        await page.PdfAsync(filePath, new PdfOptions
        {
            DisplayHeaderFooter = true,
            HeaderTemplate = header,
            FooterTemplate = footer,
            Format = PaperFormat.A4,
            MarginOptions = new MarginOptions
            {
                Bottom = "50px",
                Top = "170px",
                Left = "80px",
                Right = "80px",
            }
        });

        return await File.ReadAllBytesAsync(filePath);
    }
}
