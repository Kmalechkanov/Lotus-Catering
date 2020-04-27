namespace LotusCatering.Web.Controllers
{
    using System.Threading.Tasks;

    using LotusCatering.Services.Messaging;
    using LotusCatering.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : Controller
    {
        private readonly IEmailSender emailSender;

        public ContactsController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactsViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.emailSender.SendEmailAsync(
                    "admin@LotusCatering.eu",
                    "LotusCatering",
                    "KaloqnMalechkanov@gmail.com",
                    input.Title,
                    $"Поща: {input.Email}<br>Име: {input.Name}<br>Номер: {input.PhoneNumber}<br>__________________________<br> Съобщение: {input.Title}<br>    {input.Text}");

            return this.RedirectToAction("Index");
        }
    }
}
