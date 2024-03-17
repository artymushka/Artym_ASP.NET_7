using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApplication1.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateData(string customName, string customContent, string customFileName)
        {
            string dataContent = $"Custom Name: {customName}\nCustom Content: {customContent}";
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DataFiles");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, customFileName + ".txt");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(dataContent);
            }

            return PhysicalFile(filePath, "text/plain", customFileName + ".txt");
        }
    }
}










