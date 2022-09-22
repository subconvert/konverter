using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SubConvert
{
    public class MyFileInfo
    {
        [Display(Name = "Фолдер", Order = 0)]
        public string Folder { get; set; }
        
        [Display(Name = "Назив фајла", Order = 1)]
        public string FileName { get; set; }

        [Display(Name = "Енкодинг", Order = 2)]
        public string FileEncoding { get; set; }

        public MyFileInfo()
        {
            Folder = string.Empty;
            FileName = string.Empty;
            FileEncoding = string.Empty;
        }
    }
}
