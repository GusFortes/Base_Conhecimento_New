using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace Base_Conhecimento
{
    public class RichTextEditorViewModel
    {
        [AllowHtml]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}
