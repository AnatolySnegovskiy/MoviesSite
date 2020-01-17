using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Movies.Domain.Entities
{
    public class Movie
    {
        [HiddenInput(DisplayValue = false)]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название фильма")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите описание фильма")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите категорию фильма")]
        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите ссылку на фильм")]
        [Display(Name = "Ссылка")]
        public string Link { get; set; }
    }
}
