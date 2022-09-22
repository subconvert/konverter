using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SubConvert
{
    public class MyFileInfo
    {
        [Display(Name = "Фолдер")]
        public string Folder { get; set; }
        
        [Display(Name = "Назив фајла")]
        public string FileName { get; set; }

        [Display(Name = "Енкодинг")]
        public string FileEncoding { get; set; }
    }
}
