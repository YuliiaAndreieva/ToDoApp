using ToDoApp.BLL.DTOs.Category;
using ToDoApp.DAL.Entities;

namespace ToDoApp.BLL.Mapping;

public static class CategoryMapping
{
    public static Category ToEntity(
        this CreateCategoryDto dto)
    {
        return new Category()
        {
            Name = dto.Name
        };
    }
    
    public static CategoryDto ToDto(
        this Category category)
    {
        return new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        };
    }
    
    public static List<CategoryDto> ToListDtos(
        this List<Category> categories)
    {
        return categories.Select(category => category.ToDto()).ToList();
    }
}