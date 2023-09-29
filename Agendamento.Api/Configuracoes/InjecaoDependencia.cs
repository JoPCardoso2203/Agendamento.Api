using Agendamento.Dominio.Interfaces.Repositorios;
using Agendamento.Dominio.Interfaces.Servicos;
using Agendamento.Dominio.Servicos;
using Agendamento.Infraestrutura.Dados.Repositorios;
using Agendamento.Infraestrutura.Repositorios;

namespace Agendamento.Api.Configuracoes
{
    public static class InjecaoDependencia
    {
        public static void AddInjecaoDependencia(this IServiceCollection services)
        {
            services.AddScoped<IRepositorioBase, RepositorioBase>();

            services.AddScoped<IRepositorioAgendamento, RepositorioAgendamento>();
            services.AddScoped<IRepositorioAmrTransportadoraMotorista, RepositorioAmrTransportadoraMotorista>();
            services.AddScoped<IRepositorioMotorista, RepositorioMotorista>();
            services.AddScoped<IRepositorioTransportadora, RepositorioTransportadora>();

            services.AddScoped<IServicoAgendamento, ServicoAgendamento>();
            services.AddScoped<IServicoAmrTransportadoraMotorista, ServicoAmrTransportadoraMotorista>();
            services.AddScoped<IServicoMotorista, ServicoMotorista>();
            services.AddScoped<IServicoTransportadora, ServicoTransportadora>();
        }
    }
}
