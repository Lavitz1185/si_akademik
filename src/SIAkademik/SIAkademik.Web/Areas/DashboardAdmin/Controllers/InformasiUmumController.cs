using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulProfil.Repositories;
using SIAkademik.Domain.ValueObjects;
using SIAkademik.Infrastructure.Services.FileServices;
using SIAkademik.Web.Areas.DashboardAdmin.Models.InformasiUmumModels;
using SIAkademik.Web.Services.Toastr;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class InformasiUmumController : Controller
{
    private readonly IInformasiUmumRepository _informasiUmumRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToastrNotificationService _toastrNotificationService;
    private readonly IFileService _fileService;

    public InformasiUmumController(
        IInformasiUmumRepository informasiUmumRepository,
        IUnitOfWork unitOfWork,
        IToastrNotificationService toastrNotificationService,
        IFileService fileService)
    {
        _informasiUmumRepository = informasiUmumRepository;
        _unitOfWork = unitOfWork;
        _toastrNotificationService = toastrNotificationService;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index()
    {
        var informasiUmum = await _informasiUmumRepository.Get();

        return View(new EditVM
        {
            NamaSekolah = informasiUmum.NamaSekolah,
            AlamatSekolah = informasiUmum.AlamatSekolah,
            EmailSekolah = informasiUmum.EmailSekolah,
            FacebookSekolah = informasiUmum.FacebookSekolah,
            InstagramSekolah = informasiUmum.InstagramSekolah,
            LirikMarsSekolah = informasiUmum.LirikMarsSekolah,
            VisiSekolah = informasiUmum.VisiSekolah,
            MisiSekolah = informasiUmum.MisiSekolah,
            NoHPSekolah = informasiUmum.NoHPSekolah.Value,
            ProfilSingkatSekolah = informasiUmum.ProfilSingkatSekolah,
            SloganSekolah = informasiUmum.SloganSekolah,
            LogoSekolahLama = informasiUmum.LogoSekolah,
            VideoHalamanBeranda = informasiUmum.VideoHalamanBeranda,
            VideoHalamanTentangKami = informasiUmum.VideoHalamanTentangKami,
            DewanPembinaYayasan = informasiUmum.DewanPembinaYayasan,
            KetuaUmumYayasan = informasiUmum.KetuaUmumYayasan,
            KetuaUmum2Yayasan = informasiUmum.KetuaUmum2Yayasan,
            NamaYayasan = informasiUmum.NamaYayasan,
            SambutanPimpinanYayasan = informasiUmum.SambutanPimpinanYayasan
        });
    }

    public async Task<IActionResult> Edit()
    {
        var informasiUmum = await _informasiUmumRepository.Get();

        return View(new EditVM
        {
            NamaSekolah = informasiUmum.NamaSekolah,
            AlamatSekolah = informasiUmum.AlamatSekolah,
            EmailSekolah = informasiUmum.EmailSekolah,
            FacebookSekolah = informasiUmum.FacebookSekolah,
            InstagramSekolah = informasiUmum.InstagramSekolah,
            LirikMarsSekolah = informasiUmum.LirikMarsSekolah,
            VisiSekolah = informasiUmum.VisiSekolah,
            MisiSekolah = informasiUmum.MisiSekolah,
            NoHPSekolah = informasiUmum.NoHPSekolah.Value,
            ProfilSingkatSekolah = informasiUmum.ProfilSingkatSekolah,
            SloganSekolah = informasiUmum.SloganSekolah,
            LogoSekolahLama = informasiUmum.LogoSekolah,
            VideoHalamanBeranda = informasiUmum.VideoHalamanBeranda,
            VideoHalamanTentangKami = informasiUmum.VideoHalamanTentangKami,
            DewanPembinaYayasan = informasiUmum.DewanPembinaYayasan,
            KetuaUmumYayasan = informasiUmum.KetuaUmumYayasan,
            KetuaUmum2Yayasan = informasiUmum.KetuaUmum2Yayasan,
            NamaYayasan = informasiUmum.NamaYayasan,
            SambutanPimpinanYayasan = informasiUmum.SambutanPimpinanYayasan
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var noHP = NoHP.Create(vm.NoHPSekolah);
        if (noHP.IsFailure)
        {
            ModelState.AddModelError(nameof(EditVM.NoHPSekolah), "No. Telepon Sekolah tidak valid");
            return View(vm);
        }

        var informasiUmum = await _informasiUmumRepository.Get();

        informasiUmum.NamaSekolah = vm.NamaSekolah;
        informasiUmum.AlamatSekolah = vm.AlamatSekolah;
        informasiUmum.EmailSekolah = vm.EmailSekolah;
        informasiUmum.FacebookSekolah = vm.FacebookSekolah;
        informasiUmum.InstagramSekolah = vm.InstagramSekolah;
        informasiUmum.LirikMarsSekolah = vm.LirikMarsSekolah;
        informasiUmum.VisiSekolah = vm.VisiSekolah;
        informasiUmum.MisiSekolah = vm.MisiSekolah;
        informasiUmum.NoHPSekolah = noHP.Value;
        informasiUmum.ProfilSingkatSekolah = vm.ProfilSingkatSekolah;
        informasiUmum.SloganSekolah = vm.SloganSekolah;
        informasiUmum.VideoHalamanBeranda = vm.VideoHalamanBeranda;
        informasiUmum.VideoHalamanTentangKami = vm.VideoHalamanTentangKami;
        informasiUmum.DewanPembinaYayasan = vm.DewanPembinaYayasan;
        informasiUmum.KetuaUmumYayasan = vm.KetuaUmumYayasan;
        informasiUmum.KetuaUmum2Yayasan = vm.KetuaUmum2Yayasan;
        informasiUmum.NamaYayasan = vm.NamaYayasan;
        informasiUmum.SambutanPimpinanYayasan = vm.SambutanPimpinanYayasan;

        if (vm.LogoSekolahBaru is not null)
        {
            var logoSekolahBaru = await _fileService.UploadFile<EditVM>(
                vm.LogoSekolahBaru,
                "images/logo",
                [".jpg", ".jpeg", ".png"],
                0,
                104858);

            if (logoSekolahBaru.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.LogoSekolahBaru), logoSekolahBaru.Error.Message);
                return View(vm);
            }

            informasiUmum.LogoSekolah = logoSekolahBaru.Value;
        }

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Simpan Gagal!");

            if (vm.LogoSekolahBaru is not null) _fileService.Delete(informasiUmum.LogoSekolah);

            return View(vm);
        }

        if (vm.LogoSekolahBaru is not null) _fileService.Delete(vm.LogoSekolahLama);

        _toastrNotificationService.AddSuccess("Simpan Berhasil!");

        return RedirectToAction(nameof(Index));
    }
}
