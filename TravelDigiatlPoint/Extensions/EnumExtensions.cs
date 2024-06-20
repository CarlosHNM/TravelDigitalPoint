using TravelDigiatlPoint.Models;

namespace TravelDigiatlPoint.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            // Lógica para retornar a descrição do enum
            // Exemplo genérico:
            return value switch
            {
                Cargo.Admin => "Administrativo",
                Cargo.Mecanico => "Mecânico",
                Cargo.Motorista => "Motorista",
                // Adicione outros casos conforme necessário para todos os valores do enum Cargo
                _ => throw new NotImplementedException(),
            };
        }
    }
}
