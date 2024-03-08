using AutoMapper;
using IsubuBurada.KatalogService.Dtos;
using IsubuBurada.KatalogService.Models;

namespace IsubuBurada.KatalogService
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Kategori, KategoriDto>().ReverseMap();
            CreateMap<Kategori, CreateOrEditKategoriDto>().ReverseMap();

            CreateMap<Urun, UrunDto>().ReverseMap();
            CreateMap<Urun, CreateOrEditUrunDto>().ReverseMap();

        }
    }
}
