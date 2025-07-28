var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Sadece bir MapControllerRoute tan�m� yeterli
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();




//app.MapControllerRoute(
//name: "GroupCompanies-index",
//pattern: "GroupCompanies",
//defaults: new { controller = "GroupCompanies", action = "Index" }
//);

//app.MapControllerRoute(
//name: "GroupCompanies-detail",
//pattern: "GroupCompanies/Detaylar",
//defaults: new { controller = "GroupCompanies", action = "Detail" }
//);
//app.MapControllerRoute(
//name: "GroupCompanies-MAR",
//pattern: "GroupCompanies/MAR",
//defaults: new { controller = "GroupCompanies", action = "Mar" }
//);
//app.MapControllerRoute(
//name: "GroupCompanies-Top�ularENdustriyel",
//pattern: "GroupCompanies/Top�ularEndustriyel",
//defaults: new { controller = "GroupCompanies", action = "TopcularEndustriyel" }
//);
//app.MapControllerRoute(
//name: "GroupCompanies-RevoEndustriyel",
//pattern: "GroupCompanies/RevoEndustriyel",
//defaults: new { controller = "GroupCompanies", action = "RevoEndustriyel" }
//);
//app.MapControllerRoute(
//name: "GroupCompanies-ReisMakina",
//pattern: "GroupCompanies/ReisMakina",
//defaults: new { controller = "GroupCompanies", action = "ReisMakina" }
//);

//app.MapControllerRoute(
//name: "media-index",
//pattern: "Media",
//defaults: new { controller = "Media", action = "Index" }
//);

//app.MapControllerRoute(
//name: "media-detail",
//pattern: "Media/Detaylar",
//defaults: new { controller = "Media", action = "Detail" }
//);
//app.MapControllerRoute(
//name: "media-detail",
//pattern: "Media/Detaylar",
//defaults: new { controller = "Media", action = "Detail1" }
//);
//app.MapControllerRoute(
//name: "media-detail",
//pattern: "Media/Detaylar",
//defaults: new { controller = "Media", action = "Detail2" }
//);
//app.MapControllerRoute(
//name: "media-detail",
//pattern: "Media/Detaylar",
//defaults: new { controller = "Media", action = "Detail3" }
//);
//app.MapControllerRoute(
//name: "media-detail",
//pattern: "Media/Detaylar",
//defaults: new { controller = "Media", action = "Detail4" }
//);
//app.MapControllerRoute(
//name: "media-detail",
//pattern: "Media/Detaylar",
//defaults: new { controller = "Media", action = "Detail5" }
//);
//app.MapControllerRoute(
//name: "media-detail",
//pattern: "Media/Detaylar",
//defaults: new { controller = "Media", action = "Detail6" }
//);

////app.MapControllerRoute(
////name: "media-post",
////pattern: "Media/Payla��lanlar",
////defaults: new { controller = "Media", action = "Post" }
////);
//app.MapControllerRoute(
//name: "HumanResouces-index",
//pattern: "�nsan Kaynaklar�",
//defaults: new { controller = "HumanResources", action = "Index" }
//);



//app.MapControllerRoute(
//name: "contact-index",
//pattern: "�leti�im",
//defaults: new { controller = "Contact", action = "Index" }
//);

//app.MapControllerRoute(
//name: "about-index",
//pattern: "Hakk�m�zda",
//defaults: new { controller = "About", action = "Index" }
//);

//app.MapControllerRoute(
//name: "history-index",
//pattern: "Tarih�emiz",
//defaults: new { controller = "History", action = "Index" }
// );

//app.MapControllerRoute(
//name: "MissionandVision-index",
//pattern: "Misyonumuz Ve Vizyonumuz",
//defaults: new { controller = "MissionandVision", action = "Index" }
// );

//app.MapControllerRoute(
//name: "PresidentMessage-index",
//pattern: "Ba�kan�n Mesaj�",
//defaults: new { controller = "PresidentMessage", action = "Index" }
// );
//app.MapControllerRoute(
//name: "GeneralPresident_sMessage-index",
//pattern: " Genel M�d�r�n Mesaj�",
//defaults: new { controller = "GeneralPresident_sMessage", action = "Index" }
// );
//app.MapControllerRoute(
//name: "OurValues-index",
//pattern: " De�erlerimiz",
//defaults: new { controller = "De�erlerimiz", action = "Index" }
// );

//// Fallback (varsay�lan) route:
//app.MapControllerRoute(
//name: "default",
//pattern: "{controller=Home}/{action=Index}/{id?}");
