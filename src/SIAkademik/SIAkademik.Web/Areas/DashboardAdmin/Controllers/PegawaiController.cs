using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.Enums;
using SIAkademik.Domain.ModulSiakad.Entities;
using SIAkademik.Domain.ModulSiakad.Repositories;
using SIAkademik.Domain.ValueObjects;
using SIAkademik.Web.Areas.DashboardAdmin.Models.PegawaiModels;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class PegawaiController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPegawaiRepository _pegawaiRepository;
    private readonly IAppUserRepository _appUserRepository;
    private readonly IJabatanRepository _jabatanRepository;
    private readonly IDivisiRepository _divisiRepository;
    private readonly IPasswordHasher<AppUser> _passwordHasher;

    public PegawaiController(
        IUnitOfWork unitOfWork,
        IPegawaiRepository pegawaiRepository,
        IAppUserRepository appUserRepository,
        IJabatanRepository jabatanRepository,
        IDivisiRepository divisiRepository,
        IPasswordHasher<AppUser> passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _pegawaiRepository = pegawaiRepository;
        _appUserRepository = appUserRepository;
        _jabatanRepository = jabatanRepository;
        _divisiRepository = divisiRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<IActionResult> Index()
    {
        var daftarPegawai = await _pegawaiRepository.GetAll();

        return View(daftarPegawai);
    }

    public async Task<IActionResult> DetailPegawai(string nip)
    {
        var pegawai = await _pegawaiRepository.Get(nip);

        if (pegawai is null) return NotFound();

        return View(pegawai);
    }

    public IActionResult Tambah()
    {
        return View(new TambahVM());
    }

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        //Validasi
        if (!ModelState.IsValid) return View(vm);

        if((await _pegawaiRepository.Get(vm.NIP)) is not null)
        {
            ModelState.AddModelError(nameof(TambahVM.NIP), $"NIP '{vm.NIP}' sudah digunakan! Gunakan NIP lain.");
            return View(vm);
        }

        var noHP = NoHP.Create(vm.NoHP);
        if(noHP.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.NoHP), noHP.Error.Message);
            return View(vm);
        }

        if((await _appUserRepository.GetByUserName(vm.Email)) is not null)
        {
            ModelState.AddModelError(nameof(TambahVM.Email), $"Email '{vm.Email}' sudah digunakan! Gunakan email lain.");
            return View(vm);
        }

        var jabatan = await _jabatanRepository.Get(vm.JabatanId);
        if(jabatan is null)
        {
            ModelState.AddModelError(nameof(TambahVM.JabatanId), $"Jabatan dengan Id '{vm.JabatanId}' tidak ditemukan");
            return View(vm);
        }

        if (jabatan.Jenis == JenisJabatan.Guru && vm.Password is null)
        {
            ModelState.AddModelError(nameof(TambahVM.Password), $"Password harus diisi");
            return View(vm);
        }

        var divisi = await _divisiRepository.Get(vm.DivisiId);
        if(divisi is null)
        {
            ModelState.AddModelError(nameof(TambahVM.DivisiId), $"Divisi dengan Id '{vm.DivisiId}' tidak ditemukan");
            return View(vm);
        }

        //Tambah data baru
        var pegawai = new Pegawai
        {
            Id = vm.NIP,
            Nama = vm.Nama,
            Agama = vm.Agama,
            AlamatKTP = vm.AlamatKTP,
            Email = vm.Email,
            NoHP = noHP.Value,
            GolonganDarah = vm.GolonganDarah,
            JenisKelamin = vm.JenisKelamin,
            NamaInstagram = vm.NamaInstagram ?? string.Empty,
            NIK = vm.NIK,
            NoRekening = vm.NoRekening,
            StatusPerkawinan = vm.StatusPerkawinan,
            TanggalLahir = vm.TanggalLahir,
            TanggalMasuk = vm.TanggalMasuk,
            TempatLahir = vm.TempatLahir,
            Jabatan = jabatan,
            Divisi = divisi,
        };

        if(jabatan.Jenis == JenisJabatan.Guru)
        {
            var appUser = new AppUser
            {
                UserName = pegawai.Email,
                PasswordHash = _passwordHasher.HashPassword(null, vm.Password!),
                Role = AppUserRoles.Guru,
                Guru = pegawai,
            };

            pegawai.Account = appUser;

            _appUserRepository.Add(appUser);
        }

        _pegawaiRepository.Add(pegawai);

        var result = await _unitOfWork.SaveChangesAsync();
        if(result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, "Gagal menyimpan data pegawai baru!");
            return View(vm);
        }

        return RedirectToAction(nameof(Index));
    }
}
