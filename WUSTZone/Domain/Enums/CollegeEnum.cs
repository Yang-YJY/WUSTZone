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
        //[Display(Name = "材料与冶金学院")]
        //MaterialsAndMetallurgy,
        //[Display(Name = "城市建设学院")]
        //UrbanConstruction,
        //[Display(Name = "恒大管理学院")]
        //EvergrandManagement,
        //[Display(Name = "国际学院")]
        //International,
        //[Display(Name = "化学与化工学院")]
        //ChemistryAndChemical,
        //[Display(Name = "机械自动化学院")]
        //MechanicalAutomation,
        //[Display(Name = "计算机科学与技术学院")]
        //ComputerScience,
        //[Display(Name = "理学院")]
        //Science,
        //[Display(Name = "马克思主义学院")]
        //Marxism,
        //[Display(Name = "汽车与交通工程学院")]
        //AutomotiveAndTraffic,
        //[Display(Name = "生命科学与健康学院")]
        //LifeSciencesAndHealth,
        //[Display(Name = "体育学院")]
        //PhysicalEducation,
        //[Display(Name = "外国语学院")]
        //ForeignLanguage,
        //[Display(Name = "文法与经济学院")]
        //CultureAndEconomy,
        //[Display(Name = "信息科学与工程学院")]
        //InformationScienceAndEngineering,
        //[Display(Name = "医学院")]
        //Medical,
        //[Display(Name = "艺术与设计学院")]
        //Art,
        //[Display(Name = "资源与环境学院")]
        //ResourcesAndEnvironment
        [Display(Name ="哲学类")]
        哲学类,
        [Display(Name = "经济学类")]
        经济学类, 
        [Display(Name = "财政学类")]
        财政学类,
        [Display(Name = "金融学类")]
        金融学类,
        [Display(Name = "经济与贸易")]
        经济与贸易,
        [Display(Name = "法学类")]
        法学类,
        [Display(Name = "政治学类")]
        政治学类,
        [Display(Name = "社会学类")]
        社会学类,
        [Display(Name = "民族学类")]
        民族学类,
        [Display(Name = "马克思主义理论类")]
        马克思主义理论类,
        [Display(Name = "公安学类")]
        公安学类,
        [Display(Name = "教育学类")]
        教育学类,
        [Display(Name = "体育学类")]
        体育学类,
        [Display(Name = "中国语言文学类")]
        中国语言文学类,
        [Display(Name = "外国语言文学类")]
        外国语言文学类,
        [Display(Name = "新闻传播学类")]
        新闻传播学类,
        [Display(Name = "历史学类")]
        历史学类,
        [Display(Name = "数学类")]
        数学类,
        [Display(Name = "物理学类")]
        物理学类,
        [Display(Name = "化学类")]
        化学类,
        [Display(Name = "天文学类")]
        天文学类,
        [Display(Name = "地理科学类")]
        地理科学类,
        [Display(Name = "大气科学类")]
        大气科学类,
        [Display(Name = "海洋科学类")]
        海洋科学类,
        [Display(Name = "地球物理学")]
        地球物理学,
        [Display(Name = "地质学类")]
        地质学类,
        [Display(Name = "生物科学类")]
        生物科学类,
        [Display(Name = "心理学类")]
        心理学类,
        [Display(Name = "统计学类")]
        统计学类,
        [Display(Name = "力学类")]
        力学类,
        [Display(Name = "机械类")]
        机械类,
        [Display(Name = "仪器类")]
        仪器类,
        [Display(Name = "材料类")]
        材料类,
        [Display(Name = "能源动力类")]
        能源动力类,
        [Display(Name = "电气类")]
        电气类,
        [Display(Name = "电子信息类")]
        电子信息类,
        [Display(Name = "自动化类")]
        自动化类,
        [Display(Name = "计算机类")]
        计算机类,
        [Display(Name = "土木类")]
        土木类,
        [Display(Name = "水利类")]
        水利类,
        [Display(Name = "测绘类")]
        测绘类,
        [Display(Name = "化工与制药类")]
        化工与制药类,
        [Display(Name = "地质类")]
        地质类,
        [Display(Name = "矿业类")]
        矿业类,
        [Display(Name = "纺织类")]
        纺织类,
        [Display(Name = "轻工类")]
        轻工类,
        [Display(Name = "交通运输类")]
        交通运输类,
        [Display(Name = "海洋工程类")]
        海洋工程类,
        [Display(Name = "航空航天类")]
        航空航天类,
        [Display(Name = "兵器类")]
        兵器类,
        [Display(Name = "核工程类")]
        核工程类,
        [Display(Name = "农业工程类")]
        农业工程类,
        [Display(Name = "林业工程类")]
        林业工程类,
        [Display(Name = "环境科学与工程类")]
        环境科学与工程类,
        [Display(Name = "生物医学工程类")]
        生物医学工程类,
        [Display(Name = "食品科学与工程")]
        食品科学与工程,
        [Display(Name = "建筑类")]
        建筑类,
        [Display(Name = "安全科学与工程类")]
        安全科学与工程类,
        [Display(Name = "生物工程类")]
        生物工程类,
        [Display(Name = "公安技术类")]
        公安技术类,
        [Display(Name = "植物生产类")]
        植物生产类,
        [Display(Name = "自然保护与环境生态")]
        自然保护与环境生态,
        [Display(Name = "动物生产类")]
        动物生产类,
        [Display(Name = "动物医学类")]
        动物医学类,
        [Display(Name = "林学类")]
        林学类,
        [Display(Name = "水产类")]
        水产类,
        [Display(Name = "草学类")]
        草学类,
        [Display(Name = "基础医学类")]
        基础医学类,
        [Display(Name = "临床医学类")]
        临床医学类,
        [Display(Name = "口腔医学类")]
        口腔医学类,
        [Display(Name = "中医学类")]
        中医学类,
        [Display(Name = "公共卫生与预防医学")]
        公共卫生与预防医学,
        [Display(Name = "中西医结合类")]
        中西医结合类,
        [Display(Name = "药学类")]
        药学类,
        [Display(Name = "中药学类")]
        中药学类,
        [Display(Name = "法医学类")]
        法医学类,
        [Display(Name = "医学技术类")]
        医学技术类,
        [Display(Name = "护理学类")]
        护理学类,
        [Display(Name = "管理科学与工程类")]
        管理科学与工程类,
        [Display(Name = "工商管理类")]
        工商管理类,
        [Display(Name = "农业经济管理类")]
        农业经济管理类,
        [Display(Name = "公共管理类")]
        公共管理类,
        [Display(Name = "图书情报与档案管理")]
        图书情报与档案管理,
        [Display(Name = "物流管理与工程类	")]
        物流管理与工程类,
        [Display(Name = "旅游管理类")]
        旅游管理类,
        [Display(Name = "电子商务类")]
        电子商务类,
        [Display(Name = "艺术学理论类")]
        艺术学理论类,
        [Display(Name = "音乐与舞蹈学类")]
        音乐与舞蹈学类,
        [Display(Name = "戏剧与影视学类")]
        戏剧与影视学类,
        [Display(Name = "美术学类")]
        美术学类,
        [Display(Name = "设计学类")]
        设计学类
    }

    //public static class CollegeEnumExtensions
    //{
    //    public static string GetString(this CollegeEnum college)
    //    {
    //        switch (college)
    //        {
    //            //case CollegeEnum.MaterialsAndMetallurgy: return "材料与冶金学院";
    //            //case CollegeEnum.UrbanConstruction: return "城市建设学院";
    //            //case CollegeEnum.EvergrandManagement: return "恒大管理学院";
    //            //case CollegeEnum.International: return "国际学院";
    //            //case CollegeEnum.ChemistryAndChemical: return "化学与化工学院";
    //            //case CollegeEnum.MechanicalAutomation: return "机械自动化学院";
    //            //case CollegeEnum.ComputerScience: return "计算机科学与技术学院";
    //            //case CollegeEnum.Science: return "理学院";
    //            //case CollegeEnum.Marxism: return "马克思主义学院";
    //            //case CollegeEnum.AutomotiveAndTraffic: return "汽车与交通工程学院";
    //            //case CollegeEnum.LifeSciencesAndHealth: return "生命科学与健康学院";
    //            //case CollegeEnum.PhysicalEducation: return "体育学院";
    //            //case CollegeEnum.ForeignLanguage: return "外国语学院";
    //            //case CollegeEnum.CultureAndEconomy: return "文法与经济学院";
    //            //case CollegeEnum.InformationScienceAndEngineering: return "信息科学与工程学院";
    //            //case CollegeEnum.Medical: return "医学院";
    //            //case CollegeEnum.Art: return "艺术与设计学院";
    //            //case CollegeEnum.ResourcesAndEnvironment: return "资源与环境学院";
    //            default: return "未知";
    //        }
    //    }
    //}
}
