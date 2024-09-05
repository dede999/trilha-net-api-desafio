namespace TrilhaApiDesafio.Models.DTOs;

public class UpdateTaskDto
{
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public EnumStatusTarefa? Status { get; set; }
}