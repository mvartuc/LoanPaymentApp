using Microsoft.EntityFrameworkCore;
using VakifBankKrediKullandirimAPI.Models;
using VakifBankKrediKullandirimAPI.Models.Category;
using VakifBankKrediKullandirimAPI.Repository;

namespace VakifBankKrediKullandirimAPI.Data
{
  public class Seed
  {
    public static async void SeedData(IApplicationBuilder app)
    {
      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
        if (context == null) { throw new NullReferenceException(nameof(context)); }
        context.Database.EnsureCreated();

        var categoryRepository = new CategoryRepository(context);

        var category_adatli = new ProductParentCategory()
        {
          Code = "44400007",
          Name = "Adatlı Krediler",
          Description = "Belirlenen vade ve limit içinde serbestçe kullanılan, faiz oranı para piyasalarındaki gelişmelere göre değişen kredilerdir.",
        };
        var category_taksitli = new ProductParentCategory()
        {
          Code = "44400016",
          Name = "Taksitli Krediler",
          Description = "Taksitli Kredileri, kısa veya orta vadeli tüketim amaçlı finansman ihtiyaçlarınızı karşılamak üzere kullanabilirsiniz.",
        };


        if (!context.ParentCategories.Any())
        {
          context.ParentCategories.AddRange(new List<ProductParentCategory>()
                    {
                        category_adatli, category_taksitli
                    });
          context.SaveChanges();
        }

        if (!context.Categories.Any())
        {
          var db_adatli = await categoryRepository.GetParentCategoryByCodeAsync("44400007");
          var db_taksitli = await categoryRepository.GetParentCategoryByCodeAsync("44400016");

          var category_rotatif = new ProductCategory()
          {
            Code = "55500089",
            Name = "Rotatif Kredi",
            Description = "Rotatif Krediler, müşterilerimize kasa kolaylığı sağlanması ve kısa süreli nakit ihtiyacının karşılanması amacıyla belli bir limit dahilinde istenildiği zaman kullandırım ve geri ödeme yapılabilen nakdi kredi ürünüdür.",
            ParentCategoryID = db_adatli.Id
          };
          var category_isletme_ihtiyac = new ProductCategory()
          {
            Code = "55500344",
            Name = "İşletme İhtiyaç Kredisi",
            Description = "Firmanızın kısa ve orta vadeli finansman ihtiyaçlarının, finansal döngünüze uygun ödeme seçenekleri ile karşılandığı TL kredilerdir.",
            ParentCategoryID = db_taksitli.Id
          };

          context.Categories.AddRange(new List<ProductCategory>()
                    {
                        category_rotatif, category_isletme_ihtiyac
                    });
          context.SaveChanges();
        }

        if (!context.SpecialOffers.Any())
        {
          var rotatif_kredi_category = await categoryRepository.GetCategoryByCodeAsync("55500089");
          var isletme_ihtiyac_category = await categoryRepository.GetCategoryByCodeAsync("55500344");

          var offer_endeksli_rotatif = new SpecialOffer()
          {
            Code = "6000004741",
            Name = "Endeksli Rotatif Kredi",
            Description = "Bankamızca uluslararası standartlara uygun ve şeffaf bir endeks oranı olan TLREF’e (Türk Lirası Gecelik Referans Faiz Oranı) endeksli kredi türü oluşturulmuştur.Bu kredi türü ile müşterilerimizin faiz indirimi beklentilerini karşılayarak, Türk Lirası cinsinden değişken faizli borçlanma imkânı sunuyoruz.",
            ProductCategoryID = rotatif_kredi_category.Id
          };
          var offer_esnaf_candir = new SpecialOffer()
          {
            Code = "6000003471",
            Name = "Esnaf Candır Kredisi",
            Description = "VakıfBank Esnafımıza özel, 36 aya varan vadeler ve uygun faiz oranları ile 50.000 TL’ye kadar kredi kullanma avantajı sunuyor. Ayrıca VakıfBank’tan Esnafımıza özel 3 farklı geri ödeme seçeneği.Esnafımız kredi taksitlerini,Sabit taksitli ödeme planı, Değişken taksitli ödeme planı, Taksit ertelemeli ödeme planı,Seçeneklerle ödeyebiliyor.",
            ProductCategoryID = isletme_ihtiyac_category.Id
          };

          context.SpecialOffers.AddRange(new List<SpecialOffer>()
                    {
                        offer_endeksli_rotatif, offer_esnaf_candir
                    });
          context.SaveChanges();
        }

        if (!context.Parameters.Any())
        {
          var par_usageType_none = new Parameter()
          {
            Code = "0",
            GroupCode = "KullandirimTipi",
            Name = "None",
            Description = ""
          };
          var par_usageType_TP = new Parameter()
          {
            Code = "1",
            GroupCode = "KullandirimTipi",
            Name = "TP",
            Description = "Türk Parası"
          };
          var par_usageType_YP = new Parameter()
          {
            Code = "2",
            GroupCode = "KullandirimTipi",
            Name = "YP",
            Description = "Yabancı Para"
          };
          var par_loanYearLimit = new Parameter()
          {
            Code = "3",
            GroupCode = "VadeYilMaksimum",
            Name = "",
            Description = "25"
          };
          var par_periodMonthLimit = new Parameter()
          {
            Code = "4",
            GroupCode = "PeriyotAyMaksimum",
            Name = "",
            Description = "12"
          };
          var par_codeLength = new Parameter()
          {
            Code = "5",
            GroupCode = "KodUzunluk",
            Name = "",
            Description = "8"
          };
          var par_codeChars = new Parameter()
          {
            Code = "6",
            GroupCode = "KodKarakterIcerik",
            Name = "",
            Description = "0123456789"
          };
          var par_defaultBsmv = new Parameter()
          {
            Code = "7",
            GroupCode = "BsmvDefault",
            Name = "",
            Description = "15"
          };

          var par_equalInstallment = new Parameter()
          {
            Code = "1",
            GroupCode = "VadeHesaplamaTuru",
            Name = "Eşit Taksit",
            Description = "Eşit Taksit"
          };
          var par_equalTotalAmount = new Parameter()
          {
            Code = "0",
            GroupCode = "VadeHesaplamaTuru",
            Name = "Eşit Ana Para",
            Description = "Eşit Ana Para"
          };

          context.Parameters.AddRange(new List<Parameter>()
                    {
                        par_usageType_none, par_usageType_TP, par_usageType_YP, par_loanYearLimit, par_periodMonthLimit, par_codeLength, par_codeChars, par_defaultBsmv, par_equalInstallment, par_equalTotalAmount
                    });
          context.SaveChanges();
        }
      }
    }
    public static async void ResetData(IApplicationBuilder app)
    {
      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
        if (context == null) { throw new NullReferenceException(nameof(context)); }
        context.Products.RemoveRange(context.Products);
        context.ParentCategories.RemoveRange(context.ParentCategories);
        context.Categories.RemoveRange(context.Categories);
        context.SpecialOffers.RemoveRange(context.SpecialOffers);
        context.Parameters.RemoveRange(context.Parameters);
        context.SaveChanges();
        if (context.Database.IsSqlite())
        {
          context.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence");
        }
        else if (context.Database.IsSqlServer())
        {
          context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Categories', RESEED, 0)");
          context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Parameters', RESEED, 0)");
          context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('ParentCategories', RESEED, 0)");
          context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Products', RESEED, 0)");
          context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('SpecialOffers', RESEED, 0)");
          context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('DatePart', RESEED, 0)");
          context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Installments', RESEED, 0)");
          context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('RepaymentTerm', RESEED, 0)");
          context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('PaymentPlans', RESEED, 0)");
        }

        context.SaveChanges();
      }
    }
  }
}
