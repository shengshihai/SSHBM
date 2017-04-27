 
 using IDALRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALMsSqlRepository
{
	public partial class FW_AUDIT_RECORD_REPOSITORY : BaseDALRepository<MODEL.FW_AUDIT_RECORD>,IFW_AUDIT_RECORD_REPOSITORY
    {
    }

	public partial class FW_MODULE_REPOSITORY : BaseDALRepository<MODEL.FW_MODULE>,IFW_MODULE_REPOSITORY
    {
    }

	public partial class FW_MODULEPERMISSION_REPOSITORY : BaseDALRepository<MODEL.FW_MODULEPERMISSION>,IFW_MODULEPERMISSION_REPOSITORY
    {
    }

	public partial class FW_OPERATELOG_REPOSITORY : BaseDALRepository<MODEL.FW_OPERATELOG>,IFW_OPERATELOG_REPOSITORY
    {
    }

	public partial class FW_PERMISSION_REPOSITORY : BaseDALRepository<MODEL.FW_PERMISSION>,IFW_PERMISSION_REPOSITORY
    {
    }

	public partial class FW_ROLE_REPOSITORY : BaseDALRepository<MODEL.FW_ROLE>,IFW_ROLE_REPOSITORY
    {
    }

	public partial class FW_ROLEPERMISSION_REPOSITORY : BaseDALRepository<MODEL.FW_ROLEPERMISSION>,IFW_ROLEPERMISSION_REPOSITORY
    {
    }

	public partial class FW_USER_REPOSITORY : BaseDALRepository<MODEL.FW_USER>,IFW_USER_REPOSITORY
    {
    }

	public partial class FW_USER_ROLE_REPOSITORY : BaseDALRepository<MODEL.FW_USER_ROLE>,IFW_USER_ROLE_REPOSITORY
    {
    }

	public partial class JF_Order_REPOSITORY : BaseDALRepository<MODEL.JF_Order>,IJF_Order_REPOSITORY
    {
    }

	public partial class JF_Product_REPOSITORY : BaseDALRepository<MODEL.JF_Product>,IJF_Product_REPOSITORY
    {
    }

	public partial class MST_ARTICLE_REPOSITORY : BaseDALRepository<MODEL.MST_ARTICLE>,IMST_ARTICLE_REPOSITORY
    {
    }

	public partial class MST_ATTACHMENTS_REPOSITORY : BaseDALRepository<MODEL.MST_ATTACHMENTS>,IMST_ATTACHMENTS_REPOSITORY
    {
    }

	public partial class MST_CAR_REPOSITORY : BaseDALRepository<MODEL.MST_CAR>,IMST_CAR_REPOSITORY
    {
    }

	public partial class MST_CATALOG_REPOSITORY : BaseDALRepository<MODEL.MST_CATALOG>,IMST_CATALOG_REPOSITORY
    {
    }

	public partial class MST_CATEGORY_REPOSITORY : BaseDALRepository<MODEL.MST_CATEGORY>,IMST_CATEGORY_REPOSITORY
    {
    }

	public partial class MST_COMPANY_REPOSITORY : BaseDALRepository<MODEL.MST_COMPANY>,IMST_COMPANY_REPOSITORY
    {
    }

	public partial class MST_COMPANY_MEM_REPOSITORY : BaseDALRepository<MODEL.MST_COMPANY_MEM>,IMST_COMPANY_MEM_REPOSITORY
    {
    }

	public partial class MST_MEMBER_REPOSITORY : BaseDALRepository<MODEL.MST_MEMBER>,IMST_MEMBER_REPOSITORY
    {
    }

	public partial class MST_POSITION_REPOSITORY : BaseDALRepository<MODEL.MST_POSITION>,IMST_POSITION_REPOSITORY
    {
    }

	public partial class MST_PRD_REPOSITORY : BaseDALRepository<MODEL.MST_PRD>,IMST_PRD_REPOSITORY
    {
    }

	public partial class MST_PRD_CATE_REPOSITORY : BaseDALRepository<MODEL.MST_PRD_CATE>,IMST_PRD_CATE_REPOSITORY
    {
    }

	public partial class MST_PRD_IMG_REPOSITORY : BaseDALRepository<MODEL.MST_PRD_IMG>,IMST_PRD_IMG_REPOSITORY
    {
    }

	public partial class MST_RESUME_REPOSITORY : BaseDALRepository<MODEL.MST_RESUME>,IMST_RESUME_REPOSITORY
    {
    }

	public partial class MST_RESUME_DTL_REPOSITORY : BaseDALRepository<MODEL.MST_RESUME_DTL>,IMST_RESUME_DTL_REPOSITORY
    {
    }

	public partial class MST_SUPPLIER_REPOSITORY : BaseDALRepository<MODEL.MST_SUPPLIER>,IMST_SUPPLIER_REPOSITORY
    {
    }

	public partial class SET_COUNTRY_REPOSITORY : BaseDALRepository<MODEL.SET_COUNTRY>,ISET_COUNTRY_REPOSITORY
    {
    }

	public partial class SET_NAVIGATION_ITEM_REPOSITORY : BaseDALRepository<MODEL.SET_NAVIGATION_ITEM>,ISET_NAVIGATION_ITEM_REPOSITORY
    {
    }

	public partial class SET_REGION_REPOSITORY : BaseDALRepository<MODEL.SET_REGION>,ISET_REGION_REPOSITORY
    {
    }

	public partial class SYS_REF_REPOSITORY : BaseDALRepository<MODEL.SYS_REF>,ISYS_REF_REPOSITORY
    {
    }

	public partial class TG_Address_REPOSITORY : BaseDALRepository<MODEL.TG_Address>,ITG_Address_REPOSITORY
    {
    }

	public partial class TG_BankCrad_REPOSITORY : BaseDALRepository<MODEL.TG_BankCrad>,ITG_BankCrad_REPOSITORY
    {
    }

	public partial class TG_Car_REPOSITORY : BaseDALRepository<MODEL.TG_Car>,ITG_Car_REPOSITORY
    {
    }

	public partial class TG_fenxiaoConfig_REPOSITORY : BaseDALRepository<MODEL.TG_fenxiaoConfig>,ITG_fenxiaoConfig_REPOSITORY
    {
    }

	public partial class TG_jifenLog_REPOSITORY : BaseDALRepository<MODEL.TG_jifenLog>,ITG_jifenLog_REPOSITORY
    {
    }

	public partial class TG_order_REPOSITORY : BaseDALRepository<MODEL.TG_order>,ITG_order_REPOSITORY
    {
    }

	public partial class TG_pic_REPOSITORY : BaseDALRepository<MODEL.TG_pic>,ITG_pic_REPOSITORY
    {
    }

	public partial class TG_product_REPOSITORY : BaseDALRepository<MODEL.TG_product>,ITG_product_REPOSITORY
    {
    }

	public partial class TG_productBrand_REPOSITORY : BaseDALRepository<MODEL.TG_productBrand>,ITG_productBrand_REPOSITORY
    {
    }

	public partial class TG_productCate_REPOSITORY : BaseDALRepository<MODEL.TG_productCate>,ITG_productCate_REPOSITORY
    {
    }

	public partial class TG_productColor_REPOSITORY : BaseDALRepository<MODEL.TG_productColor>,ITG_productColor_REPOSITORY
    {
    }

	public partial class TG_QD_REPOSITORY : BaseDALRepository<MODEL.TG_QD>,ITG_QD_REPOSITORY
    {
    }

	public partial class TG_redPaperLog_REPOSITORY : BaseDALRepository<MODEL.TG_redPaperLog>,ITG_redPaperLog_REPOSITORY
    {
    }

	public partial class TG_review_REPOSITORY : BaseDALRepository<MODEL.TG_review>,ITG_review_REPOSITORY
    {
    }

	public partial class TG_SCproduct_REPOSITORY : BaseDALRepository<MODEL.TG_SCproduct>,ITG_SCproduct_REPOSITORY
    {
    }

	public partial class TG_Thing_REPOSITORY : BaseDALRepository<MODEL.TG_Thing>,ITG_Thing_REPOSITORY
    {
    }

	public partial class TG_transactionLog_REPOSITORY : BaseDALRepository<MODEL.TG_transactionLog>,ITG_transactionLog_REPOSITORY
    {
    }

	public partial class TG_tuihuo_REPOSITORY : BaseDALRepository<MODEL.TG_tuihuo>,ITG_tuihuo_REPOSITORY
    {
    }

	public partial class TG_TXmoney_REPOSITORY : BaseDALRepository<MODEL.TG_TXmoney>,ITG_TXmoney_REPOSITORY
    {
    }

	public partial class TG_wuliu_REPOSITORY : BaseDALRepository<MODEL.TG_wuliu>,ITG_wuliu_REPOSITORY
    {
    }

	public partial class TokenConfig_REPOSITORY : BaseDALRepository<MODEL.TokenConfig>,ITokenConfig_REPOSITORY
    {
    }

	public partial class YX_Event_REPOSITORY : BaseDALRepository<MODEL.YX_Event>,IYX_Event_REPOSITORY
    {
    }

	public partial class YX_image_REPOSITORY : BaseDALRepository<MODEL.YX_image>,IYX_image_REPOSITORY
    {
    }

	public partial class YX_music_REPOSITORY : BaseDALRepository<MODEL.YX_music>,IYX_music_REPOSITORY
    {
    }

	public partial class YX_news_REPOSITORY : BaseDALRepository<MODEL.YX_news>,IYX_news_REPOSITORY
    {
    }

	public partial class YX_sysConfigs_REPOSITORY : BaseDALRepository<MODEL.YX_sysConfigs>,IYX_sysConfigs_REPOSITORY
    {
    }

	public partial class YX_sysLog_REPOSITORY : BaseDALRepository<MODEL.YX_sysLog>,IYX_sysLog_REPOSITORY
    {
    }

	public partial class YX_sysNews_REPOSITORY : BaseDALRepository<MODEL.YX_sysNews>,IYX_sysNews_REPOSITORY
    {
    }

	public partial class YX_text_REPOSITORY : BaseDALRepository<MODEL.YX_text>,IYX_text_REPOSITORY
    {
    }

	public partial class YX_video_REPOSITORY : BaseDALRepository<MODEL.YX_video>,IYX_video_REPOSITORY
    {
    }

	public partial class YX_voice_REPOSITORY : BaseDALRepository<MODEL.YX_voice>,IYX_voice_REPOSITORY
    {
    }

	public partial class YX_weiUser_REPOSITORY : BaseDALRepository<MODEL.YX_weiUser>,IYX_weiUser_REPOSITORY
    {
    }

	public partial class YX_weiXinMenus_REPOSITORY : BaseDALRepository<MODEL.YX_weiXinMenus>,IYX_weiXinMenus_REPOSITORY
    {
    }


}