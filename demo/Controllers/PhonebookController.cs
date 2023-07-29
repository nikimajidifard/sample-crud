using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection.Metadata.Ecma335;


namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppdbController : ControllerBase
    {
        private AppDbContext appdbcontext;
        
        public AppdbController(AppDbContext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }

        [HttpGet]
        [Route("GetPhones")]

        public List<phonebook> GetPhones()
        {
            return appdbcontext.PhonebookEntries.ToList(); //return a list of all phonebooks data by get method 
        }

        [HttpGet]
        [Route("GetSpecifiedPhone")]

        public phonebook GetPhone(int id)
        {
            return appdbcontext.PhonebookEntries.Where(x => x.Id == id).FirstOrDefault(); //return the specified phonebook by id and get method 
        }

        [HttpPost]
        [Route("AddPhone")]

        public void AddPhone(phonebook phone) // to add a phone by post method
        {
            appdbcontext.PhonebookEntries.Add(phone);
            appdbcontext.SaveChanges();
           // Console.WriteLine("phone added");
        }


        [HttpDelete]
        [Route("DeletePhone")]
        public void DeletePhone(phonebook phone)
        {
            appdbcontext.PhonebookEntries.Remove(phone);
            appdbcontext.SaveChanges();

        }

        [HttpPut]
        [Route("UpdatePhone")]
        public void UpdatePhone(phonebook phone)
        {
            appdbcontext.Entry(phone).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
            appdbcontext.SaveChanges();
        }

    }
    
}