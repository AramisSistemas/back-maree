using AutoMapper;
using backmaree.Interfaces;
using backmaree.Models;
using backmaree.Modelsdtos.Commons;

namespace backmaree.Services
{
    public class LoggService : ILoggService
    {
        private readonly mareeContext _context;
        private readonly IMapper _mapper;
        public LoggService(IMapper mapper, mareeContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Log(string detalle, string modulo, string tipo, string operador)
        {
            _context.ChangeTracker.Clear();

            LoggModel loggModel = new()
            {
                Detalle = detalle,
                Modulo = modulo,
                Tipo = tipo,
                Fecha = System.DateTime.Now.AddHours(-3),
                Operador = operador
            };
            UserLog? logg = _mapper.Map<UserLog>(loggModel);
            _context.UserLogs.Add(logg);
            _context.SaveChanges();
        }
    }
}
