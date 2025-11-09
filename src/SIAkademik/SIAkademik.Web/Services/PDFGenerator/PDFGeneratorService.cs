using PuppeteerSharp;
using PuppeteerSharp.Media;
using Razor.Templating.Core;
using System.Reflection.PortableExecutable;

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
        var header = await _razorTemplateEngine.RenderAsync("Views/Shared/_Header1LaporanPartial.cshtml");
        var footer = await _razorTemplateEngine.RenderAsync("Views/Shared/_Footer1LaporanPartial.cshtml");

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

    public async Task<byte[]> GeneratePDF(
        string html, 
        string header, 
        string footer, 
        string fileName,
        double marginTop,
        double marginBottom,
        double marginLeft,
        double marginRight)
    {
        var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();

        using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Timeout = 0, Headless = true, Args = ["--no-sandbox"] });
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
                Top = $"{marginTop}px",
                Bottom = $"{marginBottom}px",
                Left = $"{marginLeft}px",
                Right = $"{marginRight}px",
            }
        });

        return await File.ReadAllBytesAsync(filePath);
    }
}
