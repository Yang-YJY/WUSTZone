using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WUSTZone.Domain.Enums
{
    /// <summary>
    /// 学院枚举
    /// </summary>
    public enum CollegeEnum
    {
        [Display(Name = "材料与冶金学院")]
        MaterialsAndMetallurgy,
        [Display(Name = "城市建设学院")]
        UrbanConstruction,
        [Display(Name = "恒大管理学院")]
        EvergrandManagement,
        [Display(Name = "国际学院")]
        International,
        [Display(Name = "化学与化工学院")]
        ChemistryAndChemical,
        [Display(Name = "机械自动化学院")]
        MechanicalAutomation,
        [Display(Name = "计算机科学与技术学院")]
        ComputerScience,
        [Display(Name = "理学院")]
        Science,
        [Display(Name = "马克思主义学院")]
        Marxism,
        [Display(Name = "汽车与交通工程学院")]
        AutomotiveAndTraffic,
        [Display(Name = "生命科学与健康学院")]
        LifeSciencesAndHealth,
        [Display(Name = "体育学院")]
        PhysicalEducation,
        [Display(Name = "外国语学院")]
        ForeignLanguage,
        [Display(Name = "文法与经济学院")]
        CultureAndEconomy,
        [Display(Name = "信息科学与工程学院")]
        InformationScienceAndEngineering,
        [Display(Name = "医学院")]
        Medical,
        [Display(Name = "艺术与设计学院")]
        Art,
        [Display(Name = "资源与环境学院")]
        ResourcesAndEnvironment
    }

    public static class CollegeEnumExtensions
    {
        public static string GetString(this CollegeEnum college)
        {
            switch (college)
            {
                case CollegeEnum.MaterialsAndMetallurgy: return "材料与冶金学院";
                case CollegeEnum.UrbanConstruction: return "城市建设学院";
                case CollegeEnum.EvergrandManagement: return "恒大管理学院";
                case CollegeEnum.International: return "国际学院";
                case CollegeEnum.ChemistryAndChemical: return "化学与化工学院";
                case CollegeEnum.MechanicalAutomation: return "机械自动化学院";
                case CollegeEnum.ComputerScience: return "计算机科学与技术学院";
                case CollegeEnum.Science: return "理学院";
                case CollegeEnum.Marxism: return "马克思主义学院";
                case CollegeEnum.AutomotiveAndTraffic: return "汽车与交通工程学院";
                case CollegeEnum.LifeSciencesAndHealth: return "生命科学与健康学院";
                case CollegeEnum.PhysicalEducation: return "体育学院";
                case CollegeEnum.ForeignLanguage: return "外国语学院";
                case CollegeEnum.CultureAndEconomy: return "文法与经济学院";
                case CollegeEnum.InformationScienceAndEngineering: return "信息科学与工程学院";
                case CollegeEnum.Medical: return "医学院";
                case CollegeEnum.Art: return "艺术与设计学院";
                case CollegeEnum.ResourcesAndEnvironment: return "资源与环境学院";
                default: return "未知";
            }
        }
    }
}
