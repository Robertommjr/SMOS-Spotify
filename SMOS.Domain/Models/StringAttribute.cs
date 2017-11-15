using System;

namespace SMOS.Domain.Models
{
    /// <summary>
    /// Responsável por retornar o texto de uma Enumeração
    /// </summary>
    public class StringAttribute : Attribute
    {
        public String Text { get; set; }
        public StringAttribute(String text)
        {
            this.Text = text;
        }
    }

}
