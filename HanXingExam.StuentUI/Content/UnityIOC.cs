using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity;


namespace HanXingExam.StuentUI
{
    using IDAL;
    using DAL;
    using IBLL;
    using BLL;
    using Entity;
    public static class UnityIOC
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            //业务逻辑层
            container.RegisterType<ICollege_BLL, CollegeBLL>();
            container.RegisterType<IRoles_BLL, RolesBLL>();
            container.RegisterType<IPermissions_BLL, PermissionsBLL>();
            container.RegisterType<IStages_BLL, StagesBLL>();
            container.RegisterType<IUser_BLL, UserBLL>();
            container.RegisterType<IStudent_BLL, StudentBLL>();
            container.RegisterType<IClasses_BLL, ClassesBLL>();
            container.RegisterType<IMajors_BLL, MajorsBLL>();
            container.RegisterType<IQuestions_BLL, QuestionsBLL>();
            container.RegisterType<IExamQuestion_BLL, ExamQuestionBLL>();
            container.RegisterType<IScores_BLL, ScoresBLL>();
            container.RegisterType<IHistoricalPapers_BLL, HistoricalPapersBLL>();
            container.RegisterType<IAnalysisInfo_BLL, AnalysisInfoBLL>();
            //数据访问层
            container.RegisterType<ICollege_DAL, CollegeDAL>();
            container.RegisterType<IRoles_DAL, RolesDAL>();
            container.RegisterType<IStages_DAL, StagesDAL>();
            container.RegisterType<IUsers_DAL, UsersDAL>();
            container.RegisterType<IPermissions_DAL, PermissionsDAL>();
            container.RegisterType<IStudent_DAL, StudentDAL>();
            container.RegisterType<IClasses_DAL, ClassesDAL>();
            container.RegisterType<IMajors_DAL, MajorsDAL>();
            container.RegisterType<IQuestions_DAL, QuestionsDAL>();
            container.RegisterType<IExamQuestion_DAL, ExamQuestionDAL>();
            container.RegisterType<IScores_DAL, ScoresDAL>();
            container.RegisterType<IHistoricalPapers_DAL, HistoricalPapersDAL>();
            container.RegisterType<IAnalysisInfo_DAL, AnalysisInfoDAL>();
        }
    }
}