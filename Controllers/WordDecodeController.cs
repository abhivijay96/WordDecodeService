using Microsoft.AspNetCore.Mvc;
using HigherKnowledge.WordDecodeService.Models;
using Swashbuckle.SwaggerGen.Annotations;
using Newtonsoft.Json;
using System;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Spire.Doc.Documents;
using Spire.Doc;
using System.Text;

namespace HigherKnowledge.ReferenceService.Controllers
{

    [Route("api")]
    [Produces("application/json")]
    public class WordDecodeController
    {
        [HttpPostAttribute("Decode/pdf")]
        [SwaggerOperation(nameof(Decode))]
        public string Decode([FromBodyAttribute] WordDecodeData l)
        {
            ResultData d = new ResultData();
            if(!String.IsNullOrEmpty(l.data))
            {
                StringBuilder temp = new StringBuilder();
                Byte[] bytes = Convert.FromBase64String(l.data);
                PdfReader reader = new PdfReader(bytes);
                int number = reader.NumberOfPages;           
                for(int i = 1; i<= number;i++)
                {
                    temp.Append(PdfTextExtractor.GetTextFromPage(reader,i));
                }
                d.data = temp.ToString();
            }
            return JsonConvert.SerializeObject(d);
        }


        [HttpPostAttribute("Decode/doc")]
        [SwaggerOperation(nameof(DecodeWord))]
        public string DecodeWord([FromBodyAttribute] WordDecodeData l)
        {
            ResultData d = new ResultData();
            if(!String.IsNullOrEmpty(l.data))
            {
                 Byte[] bytes = Convert.FromBase64String(l.data);
                 StringBuilder temp = new StringBuilder();
                 System.IO.Stream stream = new System.IO.MemoryStream(bytes);
                 Document doc = new Document(stream);
                 foreach(Section s in doc.Sections)
                 {
                     foreach(Paragraph p in s.Paragraphs)
                     {
                         temp.Append(p.Text);
                     }
                 }
                 d.data = temp.ToString();
            }
            return JsonConvert.SerializeObject(d);
        }

        private class ResultData
        {
            public String data { get; set; }
        }
    }
}
