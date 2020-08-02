using AutoMapper;
using DHRM.BusinessEntity;

namespace DHRM.WebHelper
{
    public class ApplicationMapper
    {
        public static void Load()
        {
            Mapper.Initialize(InitializeMappers);
            //Mapper.Initialize(cfg => {
            //    InitializeMappers(cfg);
            // });
        }

        private static void InitializeMappers(IMapperConfigurationExpression cfg)
        {
            // user Inof
           // var login = cfg.CreateMap<USP_GETUSERINFO_Result, UserInfo>();
            //login.ForMember(dto => dto.IsAutenticated, conf => conf.MapFrom(ol => !true));
        }

        private static string GetBoolText(bool? val)
        {
            if (!val.HasValue) return "";
            else if (val.Value) return "Yes";
            else return "No";
        }
    }
}
