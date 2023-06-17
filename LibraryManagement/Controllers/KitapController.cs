using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class KitapController : Controller
    {
        private readonly eLibraryDbContext _context;

        public KitapController(eLibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult KitapEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KitapEkle(Kitap kitap, OduncAlan oduncAlan)
        {
            if (ModelState.IsValid)
            {
                _context.Kitaplar.Add(kitap);

                oduncAlan.KitapId = kitap.KitapId;

                _context.OduncAlanlar.Add(oduncAlan);
                _context.SaveChanges();

                return RedirectToAction("KitapEklendi");
            }

            return View(kitap);
        }

        public IActionResult KitapEklendi()
        {
            return View();
        }

        public IActionResult KitapGeriDonus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KitapGeriDonus(string TCKimlikNo, string ISBN)
        {
            var oduncAlan = _context.OduncAlanlar.FirstOrDefault(a => a.TCKimlikNo == TCKimlikNo && a.Kitap.ISBN == ISBN);
            if (oduncAlan != null)
            {
                oduncAlan.GeriDonusTarihi = DateTime.Now;

                var kitap = _context.Kitaplar.FirstOrDefault(k => k.KitapId == oduncAlan.KitapId);
                if (kitap != null)
                {
                    kitap.GeriDonusTarihi = DateTime.Now;
                }

                _context.SaveChanges();

                return RedirectToAction("KitapGeriDonusBasarili");
            }

            ModelState.AddModelError("", "Ödünç alan kişi bulunamadı.");
            return View();
        }

        public IActionResult KitapGeriDonusBasarili()
        {
            return View();
        }

        public IActionResult KitapRaporu()
        {
            var rapor = _context.OduncAlanlar
                .Where(a => a.GeriDonusTarihi.HasValue)
                .GroupBy(a => a.Kitap.ISBN)
                .Select(g => new
                {
                    ISBN = g.Key,
                    ToplamSure = g.Sum(a => (a.GeriDonusTarihi.Value - a.OduncAlmaTarihi).TotalHours)
                })
                .OrderByDescending(r => r.ToplamSure)
                .ToList();

            return View(rapor);
        }
    }
}



