using AutoMapper;
using Shared.DTOs;
using Shared.Models;

namespace Server.Infrastructure.Mappings;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<Recipe, RecipeDTO>();
        CreateMap<Category, CategoryDTO>();
        CreateMap<Ingredients, IngredientsDTO>();
        CreateMap<Instructions, InstructionsDTO>();
        CreateMap<Macros, MacrosDTO>();
        
        CreateMap<RecipeDTO, Recipe>()
            .ForMember(dest => dest.ID, opt => opt.Ignore())
            .ForMember(dest => dest.CreationDate, opt => opt.Ignore());
        CreateMap<CategoryDTO, Category>()
            .ForMember(dest => dest.ID, opt => opt.Ignore())
            .ForMember(dest => dest.Recipe, opt => opt.Ignore())
            .ForMember(dest => dest.RecipeId, opt => opt.Ignore());
        CreateMap<IngredientsDTO, Ingredients>()
            .ForMember(dest => dest.ID, opt => opt.Ignore())
            .ForMember(dest => dest.Recipe, opt => opt.Ignore())
            .ForMember(dest => dest.RecipeId, opt => opt.Ignore());
        CreateMap<InstructionsDTO, Instructions>()
            .ForMember(dest => dest.ID, opt => opt.Ignore())
            .ForMember(dest => dest.Recipe, opt => opt.Ignore())
            .ForMember(dest => dest.RecipeId, opt => opt.Ignore());
        CreateMap<MacrosDTO, Macros>()
            .ForMember(dest => dest.ID, opt => opt.Ignore())
            .ForMember(dest => dest.Recipe, opt => opt.Ignore())
            .ForMember(dest => dest.RecipeId, opt => opt.Ignore());
    }
}