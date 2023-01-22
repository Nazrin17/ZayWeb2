using AutoMapper;
using ZayWebSite.Dtos.CategoriesMonthDto;
using ZayWebSite.Dtos.CategoryDto;
using ZayWebSite.Dtos.ProductDto;
using ZayWebSite.Dtos.ServiceDto;
using ZayWebSite.Dtos.ServicesSec;
using ZayWebSite.Dtos.SettingDto;
using ZayWebSite.Dtos.SliderDto;
using ZayWebSite.Models;

namespace ZayWebSite.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<SettingUpdateDto, Setting>();
            CreateMap<SettingPostDto, Setting>();
            CreateMap<Setting, SettingGetDto>();
            CreateMap<Slider, SliderGetDto>();
            CreateMap<SliderPostDto, Slider>();
            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoriesMonth, CategoriesMonthGetDto>();
            CreateMap<CategoriesMonthPostDto, CategoriesMonth>();   
            CreateMap<ProductPostDto,Product>();
            CreateMap<Product, ProductGetDto>();
            CreateMap<ServiceSec, ServicesSecGetDto>();
            CreateMap<ServicesSecPostDto, ServiceSec>();
            CreateMap<Service, ServiceGetDto>();
            CreateMap<ServicePostDto, Service>();
        }
    }
}
