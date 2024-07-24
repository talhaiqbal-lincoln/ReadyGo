using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class ImageViewModel
    {
        [Required]
        [SwaggerSchema("AxCode of entity.", Nullable = false)]

        public string AxCode { get; set; }

        [Required]
        [SwaggerSchema("Base64 string of image.", Nullable = false)]
        public string ImageString { get; set; }
    }
}
